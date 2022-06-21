using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200001D RID: 29
	[NullableContext(1)]
	[Nullable(0)]
	public class Storefront
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000178 RID: 376 RVA: 0x000049CD File Offset: 0x00002BCD
		// (set) Token: 0x06000179 RID: 377 RVA: 0x000049D5 File Offset: 0x00002BD5
		public Storefront.FeaturedBundleobj FeaturedBundle { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600017A RID: 378 RVA: 0x000049DE File Offset: 0x00002BDE
		// (set) Token: 0x0600017B RID: 379 RVA: 0x000049E6 File Offset: 0x00002BE6
		public Storefront.SkinsPanelLayoutobj SkinsPanelLayout { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600017C RID: 380 RVA: 0x000049EF File Offset: 0x00002BEF
		// (set) Token: 0x0600017D RID: 381 RVA: 0x000049F7 File Offset: 0x00002BF7
		public Storefront.BonusStoreobj BonusStore { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00004A00 File Offset: 0x00002C00
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00004A08 File Offset: 0x00002C08
		public int StatusCode { get; set; }

		// Token: 0x06000180 RID: 384 RVA: 0x00004A14 File Offset: 0x00002C14
		public static Storefront GetOffers(Auth au)
		{
			new Storefront();
			RestClient restClient = new RestClient("https://pd." + au.region.ToString() + ".a.pvp.net/store/v2/storefront/" + au.subject);
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			Storefront storefront = JsonConvert.DeserializeObject<Storefront>(responce.Content);
			storefront.StatusCode = (int)responce.StatusCode;
			return storefront;
		}

		// Token: 0x02000090 RID: 144
		[Nullable(0)]
		public class Item2
		{
			// Token: 0x17000260 RID: 608
			// (get) Token: 0x060005FC RID: 1532 RVA: 0x0000C944 File Offset: 0x0000AB44
			// (set) Token: 0x060005FD RID: 1533 RVA: 0x0000C94C File Offset: 0x0000AB4C
			public string ItemTypeID { get; set; }

			// Token: 0x17000261 RID: 609
			// (get) Token: 0x060005FE RID: 1534 RVA: 0x0000C955 File Offset: 0x0000AB55
			// (set) Token: 0x060005FF RID: 1535 RVA: 0x0000C95D File Offset: 0x0000AB5D
			public string ItemID { get; set; }

			// Token: 0x17000262 RID: 610
			// (get) Token: 0x06000600 RID: 1536 RVA: 0x0000C966 File Offset: 0x0000AB66
			// (set) Token: 0x06000601 RID: 1537 RVA: 0x0000C96E File Offset: 0x0000AB6E
			public int Amount { get; set; }
		}

		// Token: 0x02000091 RID: 145
		[Nullable(0)]
		public class Item
		{
			// Token: 0x17000263 RID: 611
			// (get) Token: 0x06000603 RID: 1539 RVA: 0x0000C97F File Offset: 0x0000AB7F
			// (set) Token: 0x06000604 RID: 1540 RVA: 0x0000C987 File Offset: 0x0000AB87
			public Storefront.Item2 ItemInfo { get; set; }

			// Token: 0x17000264 RID: 612
			// (get) Token: 0x06000605 RID: 1541 RVA: 0x0000C990 File Offset: 0x0000AB90
			// (set) Token: 0x06000606 RID: 1542 RVA: 0x0000C998 File Offset: 0x0000AB98
			public int BasePrice { get; set; }

			// Token: 0x17000265 RID: 613
			// (get) Token: 0x06000607 RID: 1543 RVA: 0x0000C9A1 File Offset: 0x0000ABA1
			// (set) Token: 0x06000608 RID: 1544 RVA: 0x0000C9A9 File Offset: 0x0000ABA9
			public string CurrencyID { get; set; }

			// Token: 0x17000266 RID: 614
			// (get) Token: 0x06000609 RID: 1545 RVA: 0x0000C9B2 File Offset: 0x0000ABB2
			// (set) Token: 0x0600060A RID: 1546 RVA: 0x0000C9BA File Offset: 0x0000ABBA
			public int DiscountPercent { get; set; }

			// Token: 0x17000267 RID: 615
			// (get) Token: 0x0600060B RID: 1547 RVA: 0x0000C9C3 File Offset: 0x0000ABC3
			// (set) Token: 0x0600060C RID: 1548 RVA: 0x0000C9CB File Offset: 0x0000ABCB
			public bool IsPromoItem { get; set; }
		}

		// Token: 0x02000092 RID: 146
		[Nullable(0)]
		public class Bundle
		{
			// Token: 0x17000268 RID: 616
			// (get) Token: 0x0600060E RID: 1550 RVA: 0x0000C9DC File Offset: 0x0000ABDC
			// (set) Token: 0x0600060F RID: 1551 RVA: 0x0000C9E4 File Offset: 0x0000ABE4
			public string ID { get; set; }

			// Token: 0x17000269 RID: 617
			// (get) Token: 0x06000610 RID: 1552 RVA: 0x0000C9ED File Offset: 0x0000ABED
			// (set) Token: 0x06000611 RID: 1553 RVA: 0x0000C9F5 File Offset: 0x0000ABF5
			public string DataAssetID { get; set; }

			// Token: 0x1700026A RID: 618
			// (get) Token: 0x06000612 RID: 1554 RVA: 0x0000C9FE File Offset: 0x0000ABFE
			// (set) Token: 0x06000613 RID: 1555 RVA: 0x0000CA06 File Offset: 0x0000AC06
			public string CurrencyID { get; set; }

			// Token: 0x1700026B RID: 619
			// (get) Token: 0x06000614 RID: 1556 RVA: 0x0000CA0F File Offset: 0x0000AC0F
			// (set) Token: 0x06000615 RID: 1557 RVA: 0x0000CA17 File Offset: 0x0000AC17
			public List<Storefront.Item> Items { get; set; }
		}

		// Token: 0x02000093 RID: 147
		[Nullable(0)]
		public class FeaturedBundleobj
		{
			// Token: 0x1700026C RID: 620
			// (get) Token: 0x06000617 RID: 1559 RVA: 0x0000CA28 File Offset: 0x0000AC28
			// (set) Token: 0x06000618 RID: 1560 RVA: 0x0000CA30 File Offset: 0x0000AC30
			public Storefront.Bundle Bundle { get; set; }

			// Token: 0x1700026D RID: 621
			// (get) Token: 0x06000619 RID: 1561 RVA: 0x0000CA39 File Offset: 0x0000AC39
			// (set) Token: 0x0600061A RID: 1562 RVA: 0x0000CA41 File Offset: 0x0000AC41
			public int BundleRemainingDurationInSeconds { get; set; }
		}

		// Token: 0x02000094 RID: 148
		[Nullable(0)]
		public class SkinsPanelLayoutobj
		{
			// Token: 0x1700026E RID: 622
			// (get) Token: 0x0600061C RID: 1564 RVA: 0x0000CA52 File Offset: 0x0000AC52
			// (set) Token: 0x0600061D RID: 1565 RVA: 0x0000CA5A File Offset: 0x0000AC5A
			public List<string> SingleItemOffers { get; set; }

			// Token: 0x1700026F RID: 623
			// (get) Token: 0x0600061E RID: 1566 RVA: 0x0000CA63 File Offset: 0x0000AC63
			// (set) Token: 0x0600061F RID: 1567 RVA: 0x0000CA6B File Offset: 0x0000AC6B
			public int SingleItemOffersRemainingDurationInSeconds { get; set; }
		}

		// Token: 0x02000095 RID: 149
		[NullableContext(0)]
		public class Cost
		{
			// Token: 0x17000270 RID: 624
			// (get) Token: 0x06000621 RID: 1569 RVA: 0x0000CA7C File Offset: 0x0000AC7C
			// (set) Token: 0x06000622 RID: 1570 RVA: 0x0000CA84 File Offset: 0x0000AC84
			[JsonProperty("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741")]
			public int _85ad13f73d1b51289eb27cd8ee0b5741 { get; set; }
		}

		// Token: 0x02000096 RID: 150
		[Nullable(0)]
		public class Reward
		{
			// Token: 0x17000271 RID: 625
			// (get) Token: 0x06000624 RID: 1572 RVA: 0x0000CA95 File Offset: 0x0000AC95
			// (set) Token: 0x06000625 RID: 1573 RVA: 0x0000CA9D File Offset: 0x0000AC9D
			public string ItemTypeID { get; set; }

			// Token: 0x17000272 RID: 626
			// (get) Token: 0x06000626 RID: 1574 RVA: 0x0000CAA6 File Offset: 0x0000ACA6
			// (set) Token: 0x06000627 RID: 1575 RVA: 0x0000CAAE File Offset: 0x0000ACAE
			public string ItemID { get; set; }

			// Token: 0x17000273 RID: 627
			// (get) Token: 0x06000628 RID: 1576 RVA: 0x0000CAB7 File Offset: 0x0000ACB7
			// (set) Token: 0x06000629 RID: 1577 RVA: 0x0000CABF File Offset: 0x0000ACBF
			public int Quantity { get; set; }
		}

		// Token: 0x02000097 RID: 151
		[Nullable(0)]
		public class Offer
		{
			// Token: 0x17000274 RID: 628
			// (get) Token: 0x0600062B RID: 1579 RVA: 0x0000CAD0 File Offset: 0x0000ACD0
			// (set) Token: 0x0600062C RID: 1580 RVA: 0x0000CAD8 File Offset: 0x0000ACD8
			public string OfferID { get; set; }

			// Token: 0x17000275 RID: 629
			// (get) Token: 0x0600062D RID: 1581 RVA: 0x0000CAE1 File Offset: 0x0000ACE1
			// (set) Token: 0x0600062E RID: 1582 RVA: 0x0000CAE9 File Offset: 0x0000ACE9
			public bool IsDirectPurchase { get; set; }

			// Token: 0x17000276 RID: 630
			// (get) Token: 0x0600062F RID: 1583 RVA: 0x0000CAF2 File Offset: 0x0000ACF2
			// (set) Token: 0x06000630 RID: 1584 RVA: 0x0000CAFA File Offset: 0x0000ACFA
			public string StartDate { get; set; }

			// Token: 0x17000277 RID: 631
			// (get) Token: 0x06000631 RID: 1585 RVA: 0x0000CB03 File Offset: 0x0000AD03
			// (set) Token: 0x06000632 RID: 1586 RVA: 0x0000CB0B File Offset: 0x0000AD0B
			public Storefront.Cost Cost { get; set; }

			// Token: 0x17000278 RID: 632
			// (get) Token: 0x06000633 RID: 1587 RVA: 0x0000CB14 File Offset: 0x0000AD14
			// (set) Token: 0x06000634 RID: 1588 RVA: 0x0000CB1C File Offset: 0x0000AD1C
			public List<Storefront.Reward> Rewards { get; set; }
		}

		// Token: 0x02000098 RID: 152
		[NullableContext(0)]
		public class DiscountCosts
		{
			// Token: 0x17000279 RID: 633
			// (get) Token: 0x06000636 RID: 1590 RVA: 0x0000CB2D File Offset: 0x0000AD2D
			// (set) Token: 0x06000637 RID: 1591 RVA: 0x0000CB35 File Offset: 0x0000AD35
			[JsonProperty("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741")]
			public int ValorantPoints { get; set; }
		}

		// Token: 0x02000099 RID: 153
		[Nullable(0)]
		public class BonusStoreOffer
		{
			// Token: 0x1700027A RID: 634
			// (get) Token: 0x06000639 RID: 1593 RVA: 0x0000CB46 File Offset: 0x0000AD46
			// (set) Token: 0x0600063A RID: 1594 RVA: 0x0000CB4E File Offset: 0x0000AD4E
			public string BonusOfferID { get; set; }

			// Token: 0x1700027B RID: 635
			// (get) Token: 0x0600063B RID: 1595 RVA: 0x0000CB57 File Offset: 0x0000AD57
			// (set) Token: 0x0600063C RID: 1596 RVA: 0x0000CB5F File Offset: 0x0000AD5F
			public Storefront.Offer Offer { get; set; }

			// Token: 0x1700027C RID: 636
			// (get) Token: 0x0600063D RID: 1597 RVA: 0x0000CB68 File Offset: 0x0000AD68
			// (set) Token: 0x0600063E RID: 1598 RVA: 0x0000CB70 File Offset: 0x0000AD70
			public int DiscountPercent { get; set; }

			// Token: 0x1700027D RID: 637
			// (get) Token: 0x0600063F RID: 1599 RVA: 0x0000CB79 File Offset: 0x0000AD79
			// (set) Token: 0x06000640 RID: 1600 RVA: 0x0000CB81 File Offset: 0x0000AD81
			public Storefront.DiscountCosts DiscountCosts { get; set; }

			// Token: 0x1700027E RID: 638
			// (get) Token: 0x06000641 RID: 1601 RVA: 0x0000CB8A File Offset: 0x0000AD8A
			// (set) Token: 0x06000642 RID: 1602 RVA: 0x0000CB92 File Offset: 0x0000AD92
			public bool IsSeen { get; set; }
		}

		// Token: 0x0200009A RID: 154
		[Nullable(0)]
		public class BonusStoreobj
		{
			// Token: 0x1700027F RID: 639
			// (get) Token: 0x06000644 RID: 1604 RVA: 0x0000CBA3 File Offset: 0x0000ADA3
			// (set) Token: 0x06000645 RID: 1605 RVA: 0x0000CBAB File Offset: 0x0000ADAB
			public List<Storefront.BonusStoreOffer> BonusStoreOffers { get; set; }

			// Token: 0x17000280 RID: 640
			// (get) Token: 0x06000646 RID: 1606 RVA: 0x0000CBB4 File Offset: 0x0000ADB4
			// (set) Token: 0x06000647 RID: 1607 RVA: 0x0000CBBC File Offset: 0x0000ADBC
			public int BonusStoreRemainingDurationInSeconds { get; set; }
		}
	}
}
