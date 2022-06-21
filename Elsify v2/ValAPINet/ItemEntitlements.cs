using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200000B RID: 11
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemEntitlements
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002B38 File Offset: 0x00000D38
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00002B40 File Offset: 0x00000D40
		public string ItemTypeID { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002B49 File Offset: 0x00000D49
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002B51 File Offset: 0x00000D51
		public List<ItemEntitlements.Entitlement> Entitlements { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002B5A File Offset: 0x00000D5A
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002B62 File Offset: 0x00000D62
		public int StatusCode { get; set; }

		// Token: 0x06000067 RID: 103 RVA: 0x00002B6C File Offset: 0x00000D6C
		public static ItemEntitlements GetItemEntitlements(Auth au, string itemID)
		{
			new ItemEntitlements();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://pd.",
				au.region.ToString(),
				".a.pvp.net/store/v1/entitlements/",
				au.subject,
				"/",
				itemID
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			ItemEntitlements itemEntitlements = JsonConvert.DeserializeObject<ItemEntitlements>(responce.Content);
			itemEntitlements.StatusCode = (int)responce.StatusCode;
			return itemEntitlements;
		}

		// Token: 0x02000058 RID: 88
		[Nullable(0)]
		public class Entitlement
		{
			// Token: 0x17000132 RID: 306
			// (get) Token: 0x06000365 RID: 869 RVA: 0x0000B364 File Offset: 0x00009564
			// (set) Token: 0x06000366 RID: 870 RVA: 0x0000B36C File Offset: 0x0000956C
			public string ItemID { get; set; }

			// Token: 0x17000133 RID: 307
			// (get) Token: 0x06000367 RID: 871 RVA: 0x0000B375 File Offset: 0x00009575
			// (set) Token: 0x06000368 RID: 872 RVA: 0x0000B37D File Offset: 0x0000957D
			public string InstanceID { get; set; }
		}
	}
}
