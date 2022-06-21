using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000006 RID: 6
	[NullableContext(1)]
	[Nullable(0)]
	public class AccountXP
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002140 File Offset: 0x00000340
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002148 File Offset: 0x00000348
		public int StatusCode { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002151 File Offset: 0x00000351
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002159 File Offset: 0x00000359
		public int Version { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002162 File Offset: 0x00000362
		// (set) Token: 0x0600000F RID: 15 RVA: 0x0000216A File Offset: 0x0000036A
		public string Subject { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002173 File Offset: 0x00000373
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000217B File Offset: 0x0000037B
		public AccountXP.XpProgress Progress { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002184 File Offset: 0x00000384
		// (set) Token: 0x06000013 RID: 19 RVA: 0x0000218C File Offset: 0x0000038C
		public List<AccountXP.XpHistory> History { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002195 File Offset: 0x00000395
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000219D File Offset: 0x0000039D
		public string LastTimeGrantedFirstWin { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000021A6 File Offset: 0x000003A6
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000021AE File Offset: 0x000003AE
		public string NextTimeFirstWinAvailable { get; set; }

		// Token: 0x06000018 RID: 24 RVA: 0x000021B8 File Offset: 0x000003B8
		public static AccountXP GetOffers(Auth au)
		{
			new AccountXP();
			RestClient restClient = new RestClient("https://pd." + au.region.ToString() + ".a.pvp.net/account-xp/v1/players/" + au.subject);
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			AccountXP accountXP = JsonConvert.DeserializeObject<AccountXP>(responce.Content);
			accountXP.StatusCode = (int)responce.StatusCode;
			return accountXP;
		}

		// Token: 0x02000040 RID: 64
		[NullableContext(0)]
		public class XpProgress
		{
			// Token: 0x170000CA RID: 202
			// (get) Token: 0x0600027D RID: 637 RVA: 0x0000ABBC File Offset: 0x00008DBC
			// (set) Token: 0x0600027E RID: 638 RVA: 0x0000ABC4 File Offset: 0x00008DC4
			public int Level { get; set; }

			// Token: 0x170000CB RID: 203
			// (get) Token: 0x0600027F RID: 639 RVA: 0x0000ABCD File Offset: 0x00008DCD
			// (set) Token: 0x06000280 RID: 640 RVA: 0x0000ABD5 File Offset: 0x00008DD5
			public int XP { get; set; }
		}

		// Token: 0x02000041 RID: 65
		[NullableContext(0)]
		public class StartProgress
		{
			// Token: 0x170000CC RID: 204
			// (get) Token: 0x06000282 RID: 642 RVA: 0x0000ABE6 File Offset: 0x00008DE6
			// (set) Token: 0x06000283 RID: 643 RVA: 0x0000ABEE File Offset: 0x00008DEE
			public int Level { get; set; }

			// Token: 0x170000CD RID: 205
			// (get) Token: 0x06000284 RID: 644 RVA: 0x0000ABF7 File Offset: 0x00008DF7
			// (set) Token: 0x06000285 RID: 645 RVA: 0x0000ABFF File Offset: 0x00008DFF
			public int XP { get; set; }
		}

		// Token: 0x02000042 RID: 66
		[NullableContext(0)]
		public class EndProgress
		{
			// Token: 0x170000CE RID: 206
			// (get) Token: 0x06000287 RID: 647 RVA: 0x0000AC10 File Offset: 0x00008E10
			// (set) Token: 0x06000288 RID: 648 RVA: 0x0000AC18 File Offset: 0x00008E18
			public int Level { get; set; }

			// Token: 0x170000CF RID: 207
			// (get) Token: 0x06000289 RID: 649 RVA: 0x0000AC21 File Offset: 0x00008E21
			// (set) Token: 0x0600028A RID: 650 RVA: 0x0000AC29 File Offset: 0x00008E29
			public int XP { get; set; }
		}

		// Token: 0x02000043 RID: 67
		[Nullable(0)]
		public class XPSource
		{
			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x0600028C RID: 652 RVA: 0x0000AC3A File Offset: 0x00008E3A
			// (set) Token: 0x0600028D RID: 653 RVA: 0x0000AC42 File Offset: 0x00008E42
			public string ID { get; set; }

			// Token: 0x170000D1 RID: 209
			// (get) Token: 0x0600028E RID: 654 RVA: 0x0000AC4B File Offset: 0x00008E4B
			// (set) Token: 0x0600028F RID: 655 RVA: 0x0000AC53 File Offset: 0x00008E53
			public int Amount { get; set; }
		}

		// Token: 0x02000044 RID: 68
		[Nullable(0)]
		public class XpHistory
		{
			// Token: 0x170000D2 RID: 210
			// (get) Token: 0x06000291 RID: 657 RVA: 0x0000AC64 File Offset: 0x00008E64
			// (set) Token: 0x06000292 RID: 658 RVA: 0x0000AC6C File Offset: 0x00008E6C
			public string ID { get; set; }

			// Token: 0x170000D3 RID: 211
			// (get) Token: 0x06000293 RID: 659 RVA: 0x0000AC75 File Offset: 0x00008E75
			// (set) Token: 0x06000294 RID: 660 RVA: 0x0000AC7D File Offset: 0x00008E7D
			public DateTime MatchStart { get; set; }

			// Token: 0x170000D4 RID: 212
			// (get) Token: 0x06000295 RID: 661 RVA: 0x0000AC86 File Offset: 0x00008E86
			// (set) Token: 0x06000296 RID: 662 RVA: 0x0000AC8E File Offset: 0x00008E8E
			public AccountXP.StartProgress StartProgress { get; set; }

			// Token: 0x170000D5 RID: 213
			// (get) Token: 0x06000297 RID: 663 RVA: 0x0000AC97 File Offset: 0x00008E97
			// (set) Token: 0x06000298 RID: 664 RVA: 0x0000AC9F File Offset: 0x00008E9F
			public AccountXP.EndProgress EndProgress { get; set; }

			// Token: 0x170000D6 RID: 214
			// (get) Token: 0x06000299 RID: 665 RVA: 0x0000ACA8 File Offset: 0x00008EA8
			// (set) Token: 0x0600029A RID: 666 RVA: 0x0000ACB0 File Offset: 0x00008EB0
			public int XPDelta { get; set; }

			// Token: 0x170000D7 RID: 215
			// (get) Token: 0x0600029B RID: 667 RVA: 0x0000ACB9 File Offset: 0x00008EB9
			// (set) Token: 0x0600029C RID: 668 RVA: 0x0000ACC1 File Offset: 0x00008EC1
			public List<AccountXP.XPSource> XPSources { get; set; }

			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x0600029D RID: 669 RVA: 0x0000ACCA File Offset: 0x00008ECA
			// (set) Token: 0x0600029E RID: 670 RVA: 0x0000ACD2 File Offset: 0x00008ED2
			public List<object> XPMultipliers { get; set; }
		}
	}
}
