using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000012 RID: 18
	[NullableContext(1)]
	[Nullable(0)]
	public class Inventory
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00003254 File Offset: 0x00001454
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x0000325C File Offset: 0x0000145C
		public string Subject { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00003265 File Offset: 0x00001465
		// (set) Token: 0x060000AB RID: 171 RVA: 0x0000326D File Offset: 0x0000146D
		public int Version { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003276 File Offset: 0x00001476
		// (set) Token: 0x060000AD RID: 173 RVA: 0x0000327E File Offset: 0x0000147E
		public List<Inventory.Gun> Guns { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003287 File Offset: 0x00001487
		// (set) Token: 0x060000AF RID: 175 RVA: 0x0000328F File Offset: 0x0000148F
		public List<Inventory.Spray> Sprays { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003298 File Offset: 0x00001498
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x000032A0 File Offset: 0x000014A0
		public Inventory.PlayerCardObj PlayerCard { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x000032A9 File Offset: 0x000014A9
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x000032B1 File Offset: 0x000014B1
		public Inventory.PlayerTitleObj PlayerTitle { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x000032BA File Offset: 0x000014BA
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x000032C2 File Offset: 0x000014C2
		public int StatusCode { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x000032CB File Offset: 0x000014CB
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x000032D3 File Offset: 0x000014D3
		public Inventory.IdentityObj Identity { get; set; }

		// Token: 0x060000B8 RID: 184 RVA: 0x000032DC File Offset: 0x000014DC
		public static Inventory GetInventory(Auth au)
		{
			new Inventory();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://pd.",
				au.region.ToString(),
				".a.pvp.net/personalization/v2/players/",
				au.subject,
				"/playerloadout"
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken);
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			IRestResponse responce = restClient.Execute(request);
			Inventory inventory = JsonConvert.DeserializeObject<Inventory>(responce.Content);
			inventory.StatusCode = (int)responce.StatusCode;
			return inventory;
		}

		// Token: 0x0200005E RID: 94
		[Nullable(0)]
		public class Gun
		{
			// Token: 0x1700014D RID: 333
			// (get) Token: 0x060003A1 RID: 929 RVA: 0x0000B55F File Offset: 0x0000975F
			// (set) Token: 0x060003A2 RID: 930 RVA: 0x0000B567 File Offset: 0x00009767
			public string ID { get; set; }

			// Token: 0x1700014E RID: 334
			// (get) Token: 0x060003A3 RID: 931 RVA: 0x0000B570 File Offset: 0x00009770
			// (set) Token: 0x060003A4 RID: 932 RVA: 0x0000B578 File Offset: 0x00009778
			public string SkinID { get; set; }

			// Token: 0x1700014F RID: 335
			// (get) Token: 0x060003A5 RID: 933 RVA: 0x0000B581 File Offset: 0x00009781
			// (set) Token: 0x060003A6 RID: 934 RVA: 0x0000B589 File Offset: 0x00009789
			public string SkinLevelID { get; set; }

			// Token: 0x17000150 RID: 336
			// (get) Token: 0x060003A7 RID: 935 RVA: 0x0000B592 File Offset: 0x00009792
			// (set) Token: 0x060003A8 RID: 936 RVA: 0x0000B59A File Offset: 0x0000979A
			public string ChromaID { get; set; }

			// Token: 0x17000151 RID: 337
			// (get) Token: 0x060003A9 RID: 937 RVA: 0x0000B5A3 File Offset: 0x000097A3
			// (set) Token: 0x060003AA RID: 938 RVA: 0x0000B5AB File Offset: 0x000097AB
			public List<object> Attachments { get; set; }

			// Token: 0x17000152 RID: 338
			// (get) Token: 0x060003AB RID: 939 RVA: 0x0000B5B4 File Offset: 0x000097B4
			// (set) Token: 0x060003AC RID: 940 RVA: 0x0000B5BC File Offset: 0x000097BC
			public string CharmInstanceID { get; set; }

			// Token: 0x17000153 RID: 339
			// (get) Token: 0x060003AD RID: 941 RVA: 0x0000B5C5 File Offset: 0x000097C5
			// (set) Token: 0x060003AE RID: 942 RVA: 0x0000B5CD File Offset: 0x000097CD
			public string CharmID { get; set; }

			// Token: 0x17000154 RID: 340
			// (get) Token: 0x060003AF RID: 943 RVA: 0x0000B5D6 File Offset: 0x000097D6
			// (set) Token: 0x060003B0 RID: 944 RVA: 0x0000B5DE File Offset: 0x000097DE
			public string CharmLevelID { get; set; }
		}

		// Token: 0x0200005F RID: 95
		[Nullable(0)]
		public class Spray
		{
			// Token: 0x17000155 RID: 341
			// (get) Token: 0x060003B2 RID: 946 RVA: 0x0000B5EF File Offset: 0x000097EF
			// (set) Token: 0x060003B3 RID: 947 RVA: 0x0000B5F7 File Offset: 0x000097F7
			public string EquipSlotID { get; set; }

			// Token: 0x17000156 RID: 342
			// (get) Token: 0x060003B4 RID: 948 RVA: 0x0000B600 File Offset: 0x00009800
			// (set) Token: 0x060003B5 RID: 949 RVA: 0x0000B608 File Offset: 0x00009808
			public string SprayID { get; set; }

			// Token: 0x17000157 RID: 343
			// (get) Token: 0x060003B6 RID: 950 RVA: 0x0000B611 File Offset: 0x00009811
			// (set) Token: 0x060003B7 RID: 951 RVA: 0x0000B619 File Offset: 0x00009819
			public object SprayLevelID { get; set; }
		}

		// Token: 0x02000060 RID: 96
		[Nullable(0)]
		public class PlayerCardObj
		{
			// Token: 0x17000158 RID: 344
			// (get) Token: 0x060003B9 RID: 953 RVA: 0x0000B62A File Offset: 0x0000982A
			// (set) Token: 0x060003BA RID: 954 RVA: 0x0000B632 File Offset: 0x00009832
			public string ID { get; set; }
		}

		// Token: 0x02000061 RID: 97
		[Nullable(0)]
		public class PlayerTitleObj
		{
			// Token: 0x17000159 RID: 345
			// (get) Token: 0x060003BC RID: 956 RVA: 0x0000B643 File Offset: 0x00009843
			// (set) Token: 0x060003BD RID: 957 RVA: 0x0000B64B File Offset: 0x0000984B
			public string ID { get; set; }
		}

		// Token: 0x02000062 RID: 98
		[Nullable(0)]
		public class IdentityObj
		{
			// Token: 0x1700015A RID: 346
			// (get) Token: 0x060003BF RID: 959 RVA: 0x0000B65C File Offset: 0x0000985C
			// (set) Token: 0x060003C0 RID: 960 RVA: 0x0000B664 File Offset: 0x00009864
			public string PlayerCardID { get; set; }

			// Token: 0x1700015B RID: 347
			// (get) Token: 0x060003C1 RID: 961 RVA: 0x0000B66D File Offset: 0x0000986D
			// (set) Token: 0x060003C2 RID: 962 RVA: 0x0000B675 File Offset: 0x00009875
			public string PlayerTitleID { get; set; }
		}
	}
}
