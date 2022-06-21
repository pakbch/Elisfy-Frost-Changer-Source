using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;

namespace Elsify_v2_Ingame.UserAuth
{
	// Token: 0x02000038 RID: 56
	[NullableContext(1)]
	[Nullable(0)]
	internal class Security
	{
		// Token: 0x06000245 RID: 581 RVA: 0x000095A8 File Offset: 0x000077A8
		public static string Signature(string value)
		{
			string result;
			using (MD5 md5 = MD5.Create())
			{
				byte[] input = Encoding.UTF8.GetBytes(value);
				result = BitConverter.ToString(md5.ComputeHash(input)).Replace("-", "");
			}
			return result;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00009600 File Offset: 0x00007800
		private static string Session(int length)
		{
			Random random = new Random();
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00009644 File Offset: 0x00007844
		public static string Obfuscate(int length)
		{
			Random random = new Random();
			return new string((from s in Enumerable.Repeat<string>("gd8JQ57nxXzLLMPrLylVhxoGnWGCFjO4knKTfRE6mVvdjug2NF/4aptAsZcdIGbAPmcx0O+ftU/KvMIjcfUnH3j+IMdhAW5OpoX3MrjQdf5AAP97tTB5g1wdDSAqKpq9gw06t3VaqMWZHKtPSuAXy0kkZRsc+DicpcY8E9+vWMHXa3jMdbPx4YES0p66GzhqLd/heA2zMvX8iWv4wK7S3QKIW/a9dD4ALZJpmcr9OOE=", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00009688 File Offset: 0x00007888
		public static void Start()
		{
			string drive = Path.GetPathRoot(Environment.SystemDirectory);
			if (Constants.Started)
			{
				MessageBox.Show("A session has already been started, please end the previous one!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
				return;
			}
			using (StreamReader sr = new StreamReader(drive + "Windows\\System32\\drivers\\etc\\hosts"))
			{
				if (sr.ReadToEnd().Contains("api.auth.gg"))
				{
					Constants.Breached = true;
					MessageBox.Show("DNS redirecting has been detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
					Process.GetCurrentProcess().Kill();
				}
			}
			new InfoManager().StartListener();
			Constants.Token = Guid.NewGuid().ToString();
			ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(Security.PinPublicKey));
			Constants.APIENCRYPTKEY = Convert.ToBase64String(Encoding.Default.GetBytes(Security.Session(32)));
			Constants.APIENCRYPTSALT = Convert.ToBase64String(Encoding.Default.GetBytes(Security.Session(16)));
			Constants.IV = Convert.ToBase64String(Encoding.Default.GetBytes(Constants.RandomString(16)));
			Constants.Key = Convert.ToBase64String(Encoding.Default.GetBytes(Constants.RandomString(32)));
			Constants.Started = true;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000097DC File Offset: 0x000079DC
		public static void End()
		{
			if (!Constants.Started)
			{
				MessageBox.Show("No session has been started, closing for security reasons!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				Process.GetCurrentProcess().Kill();
				return;
			}
			Constants.Token = null;
			ServicePointManager.ServerCertificateValidationCallback = (([Nullable(1)] object <p0>, X509Certificate <p1>, X509Chain <p2>, SslPolicyErrors <p3>) => true);
			Constants.APIENCRYPTKEY = null;
			Constants.APIENCRYPTSALT = null;
			Constants.IV = null;
			Constants.Key = null;
			Constants.Started = false;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00009856 File Offset: 0x00007A56
		private static bool PinPublicKey(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return certificate != null && certificate.GetPublicKeyString() == "3082010A0282010100D0A2FCAC2861DF72F05EE166613656F27D3C037B985FECFCB5D943BC28B40DD9C035FFE44E16C57772312A9457E54973E15D40DF91660E2914ACE0AC3705562F32F023EBF32BC218423AE9DA1C752FD843EC0176307E1EE97EFCA50510DBBC88C4A253A9A06C7646BFB30CE86B773708D4240AB72919898387C60FB2F0B1B4E579BB5BC9DA286C348DD81A1205C1C43BF522032C0CA4226E08C2108E847670363B292E8E90D8B541C03CB11B03A13A88BCCC209D899994F8EADDF43AE8BBE63214EC4817922EC9496855D47E00CA21B533950C5401C6E31A727BC1A14F025D7F94B3DB2D4EE749B05C83A68A3EB17A4E375CD5CE16904F0CB1F8B7B8E75A86D30203010001";
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00009870 File Offset: 0x00007A70
		public static string Integrity(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x000098E0 File Offset: 0x00007AE0
		public static bool MaliciousCheck(string date)
		{
			DateTime d4 = DateTime.Parse(date);
			DateTime dt2 = DateTime.Now;
			TimeSpan d3 = d4 - dt2;
			if (Convert.ToInt32(d3.Seconds.ToString().Replace("-", "")) >= 5 || Convert.ToInt32(d3.Minutes.ToString().Replace("-", "")) >= 1)
			{
				Constants.Breached = true;
				return true;
			}
			return false;
		}

		// Token: 0x04000134 RID: 308
		private const string _key = "3082010A0282010100D0A2FCAC2861DF72F05EE166613656F27D3C037B985FECFCB5D943BC28B40DD9C035FFE44E16C57772312A9457E54973E15D40DF91660E2914ACE0AC3705562F32F023EBF32BC218423AE9DA1C752FD843EC0176307E1EE97EFCA50510DBBC88C4A253A9A06C7646BFB30CE86B773708D4240AB72919898387C60FB2F0B1B4E579BB5BC9DA286C348DD81A1205C1C43BF522032C0CA4226E08C2108E847670363B292E8E90D8B541C03CB11B03A13A88BCCC209D899994F8EADDF43AE8BBE63214EC4817922EC9496855D47E00CA21B533950C5401C6E31A727BC1A14F025D7F94B3DB2D4EE749B05C83A68A3EB17A4E375CD5CE16904F0CB1F8B7B8E75A86D30203010001";
	}
}
