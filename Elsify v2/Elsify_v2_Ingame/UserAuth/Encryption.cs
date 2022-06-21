using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Elsify_v2_Ingame.UserAuth
{
	// Token: 0x02000039 RID: 57
	[NullableContext(1)]
	[Nullable(0)]
	internal class Encryption
	{
		// Token: 0x0600024E RID: 590 RVA: 0x00009960 File Offset: 0x00007B60
		public static string APIService(string value)
		{
			string password = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password));
			byte[] iv = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			return Encryption.EncryptString(value, key, iv);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000099C0 File Offset: 0x00007BC0
		public static string EncryptService(string value)
		{
			string password = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password));
			byte[] iv = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			string str = Encryption.EncryptString(value, key, iv);
			int property = int.Parse(OnProgramStart.AID.Substring(0, 2));
			return str + Security.Obfuscate(property);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00009A3C File Offset: 0x00007C3C
		public static string DecryptService(string value)
		{
			string password = Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTKEY));
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password));
			byte[] iv = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(Constants.APIENCRYPTSALT)));
			return Encryption.DecryptString(value, key, iv);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00009A9C File Offset: 0x00007C9C
		public static string EncryptString(string plainText, byte[] key, byte[] iv)
		{
			Aes encryptor = Aes.Create();
			encryptor.Mode = CipherMode.CBC;
			encryptor.Key = key;
			encryptor.IV = iv;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);
			byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);
			cryptoStream.Write(plainBytes, 0, plainBytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] cipherBytes = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00009B18 File Offset: 0x00007D18
		public static string DecryptString(string cipherText, byte[] key, byte[] iv)
		{
			Aes encryptor = Aes.Create();
			encryptor.Mode = CipherMode.CBC;
			encryptor.Key = key;
			encryptor.IV = iv;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);
			string plainText = string.Empty;
			try
			{
				byte[] cipherBytes = Convert.FromBase64String(cipherText);
				cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
				cryptoStream.FlushFinalBlock();
				byte[] plainBytes = memoryStream.ToArray();
				plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
			}
			finally
			{
				memoryStream.Close();
				cryptoStream.Close();
			}
			return plainText;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00009BB4 File Offset: 0x00007DB4
		public static string Decode(string text)
		{
			text = text.Replace('_', '/').Replace('-', '+');
			int num = text.Length % 4;
			if (num != 2)
			{
				if (num == 3)
				{
					text += "=";
				}
			}
			else
			{
				text += "==";
			}
			return Encoding.UTF8.GetString(Convert.FromBase64String(text));
		}
	}
}
