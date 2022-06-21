using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000017 RID: 23
	[NullableContext(1)]
	[Nullable(0)]
	public class StoreOffers
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00003C2E File Offset: 0x00001E2E
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00003C36 File Offset: 0x00001E36
		public List<StoreOffers.Offer> Offers { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00003C3F File Offset: 0x00001E3F
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00003C47 File Offset: 0x00001E47
		public List<StoreOffers.UpgradeCurrencyOffer> UpgradeCurrencyOffers { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00003C50 File Offset: 0x00001E50
		// (set) Token: 0x06000105 RID: 261 RVA: 0x00003C58 File Offset: 0x00001E58
		public int StatusCode { get; set; }

		// Token: 0x06000106 RID: 262 RVA: 0x00003C64 File Offset: 0x00001E64
		public static StoreOffers GetOffers(Auth au)
		{
			new StoreOffers();
			RestClient restClient = new RestClient("https://pd." + au.region.ToString() + ".a.pvp.net/store/v1/offers/");
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			StoreOffers storeOffers = JsonConvert.DeserializeObject<StoreOffers>(responce.Content);
			storeOffers.StatusCode = (int)responce.StatusCode;
			return storeOffers;
		}

		// Token: 0x0200007A RID: 122
		[NullableContext(0)]
		public class Cost
		{
			// Token: 0x170001E7 RID: 487
			// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0000C079 File Offset: 0x0000A279
			// (set) Token: 0x060004F2 RID: 1266 RVA: 0x0000C081 File Offset: 0x0000A281
			[JsonProperty("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741")]
			public int ValorantPoints { get; set; }
		}

		// Token: 0x0200007B RID: 123
		[Nullable(0)]
		public class Reward
		{
			// Token: 0x170001E8 RID: 488
			// (get) Token: 0x060004F4 RID: 1268 RVA: 0x0000C092 File Offset: 0x0000A292
			// (set) Token: 0x060004F5 RID: 1269 RVA: 0x0000C09A File Offset: 0x0000A29A
			public string ItemTypeID { get; set; }

			// Token: 0x170001E9 RID: 489
			// (get) Token: 0x060004F6 RID: 1270 RVA: 0x0000C0A3 File Offset: 0x0000A2A3
			// (set) Token: 0x060004F7 RID: 1271 RVA: 0x0000C0AB File Offset: 0x0000A2AB
			public string ItemID { get; set; }

			// Token: 0x170001EA RID: 490
			// (get) Token: 0x060004F8 RID: 1272 RVA: 0x0000C0B4 File Offset: 0x0000A2B4
			// (set) Token: 0x060004F9 RID: 1273 RVA: 0x0000C0BC File Offset: 0x0000A2BC
			public int Quantity { get; set; }
		}

		// Token: 0x0200007C RID: 124
		[Nullable(0)]
		public class Offer
		{
			// Token: 0x170001EB RID: 491
			// (get) Token: 0x060004FB RID: 1275 RVA: 0x0000C0CD File Offset: 0x0000A2CD
			// (set) Token: 0x060004FC RID: 1276 RVA: 0x0000C0D5 File Offset: 0x0000A2D5
			public string OfferID { get; set; }

			// Token: 0x170001EC RID: 492
			// (get) Token: 0x060004FD RID: 1277 RVA: 0x0000C0DE File Offset: 0x0000A2DE
			// (set) Token: 0x060004FE RID: 1278 RVA: 0x0000C0E6 File Offset: 0x0000A2E6
			public bool IsDirectPurchase { get; set; }

			// Token: 0x170001ED RID: 493
			// (get) Token: 0x060004FF RID: 1279 RVA: 0x0000C0EF File Offset: 0x0000A2EF
			// (set) Token: 0x06000500 RID: 1280 RVA: 0x0000C0F7 File Offset: 0x0000A2F7
			public string StartDate { get; set; }

			// Token: 0x170001EE RID: 494
			// (get) Token: 0x06000501 RID: 1281 RVA: 0x0000C100 File Offset: 0x0000A300
			// (set) Token: 0x06000502 RID: 1282 RVA: 0x0000C108 File Offset: 0x0000A308
			public StoreOffers.Cost Cost { get; set; }

			// Token: 0x170001EF RID: 495
			// (get) Token: 0x06000503 RID: 1283 RVA: 0x0000C111 File Offset: 0x0000A311
			// (set) Token: 0x06000504 RID: 1284 RVA: 0x0000C119 File Offset: 0x0000A319
			public List<StoreOffers.Reward> Rewards { get; set; }
		}

		// Token: 0x0200007D RID: 125
		[Nullable(0)]
		public class UpgradeCurrencyOffer
		{
			// Token: 0x170001F0 RID: 496
			// (get) Token: 0x06000506 RID: 1286 RVA: 0x0000C12A File Offset: 0x0000A32A
			// (set) Token: 0x06000507 RID: 1287 RVA: 0x0000C132 File Offset: 0x0000A332
			public string OfferID { get; set; }

			// Token: 0x170001F1 RID: 497
			// (get) Token: 0x06000508 RID: 1288 RVA: 0x0000C13B File Offset: 0x0000A33B
			// (set) Token: 0x06000509 RID: 1289 RVA: 0x0000C143 File Offset: 0x0000A343
			public string StorefrontItemID { get; set; }
		}
	}
}
