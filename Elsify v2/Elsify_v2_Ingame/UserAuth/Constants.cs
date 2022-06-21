using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace Elsify_v2_Ingame.UserAuth
{
	// Token: 0x02000033 RID: 51
	[NullableContext(1)]
	[Nullable(0)]
	internal class Constants
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000200 RID: 512 RVA: 0x00007B72 File Offset: 0x00005D72
		// (set) Token: 0x06000201 RID: 513 RVA: 0x00007B79 File Offset: 0x00005D79
		public static string Token { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00007B81 File Offset: 0x00005D81
		// (set) Token: 0x06000203 RID: 515 RVA: 0x00007B88 File Offset: 0x00005D88
		public static string Date { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000204 RID: 516 RVA: 0x00007B90 File Offset: 0x00005D90
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00007B97 File Offset: 0x00005D97
		public static string APIENCRYPTKEY { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00007B9F File Offset: 0x00005D9F
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00007BA6 File Offset: 0x00005DA6
		public static string APIENCRYPTSALT { get; set; }

		// Token: 0x06000208 RID: 520 RVA: 0x00007BAE File Offset: 0x00005DAE
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
			select s[Constants.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00007BE9 File Offset: 0x00005DE9
		public static string HWID()
		{
			return WindowsIdentity.GetCurrent().User.Value;
		}

		// Token: 0x04000112 RID: 274
		public static bool Breached = false;

		// Token: 0x04000113 RID: 275
		public static bool Started = false;

		// Token: 0x04000114 RID: 276
		public static string IV = null;

		// Token: 0x04000115 RID: 277
		public static string Key = null;

		// Token: 0x04000116 RID: 278
		public static string ApiUrl = "https://api.auth.gg/csharp/";

		// Token: 0x04000117 RID: 279
		public static bool Initialized = false;

		// Token: 0x04000118 RID: 280
		public static Random random = new Random();
	}
}
