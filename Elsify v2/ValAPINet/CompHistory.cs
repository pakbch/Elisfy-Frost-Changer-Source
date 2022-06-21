using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000009 RID: 9
	[NullableContext(1)]
	[Nullable(0)]
	public class CompHistory
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000026C4 File Offset: 0x000008C4
		// (set) Token: 0x0600002F RID: 47 RVA: 0x000026CC File Offset: 0x000008CC
		public int Version { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000026D5 File Offset: 0x000008D5
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000026DD File Offset: 0x000008DD
		public string Subject { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000026E6 File Offset: 0x000008E6
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000026EE File Offset: 0x000008EE
		public List<CompHistory.Match> Matches { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000026F7 File Offset: 0x000008F7
		// (set) Token: 0x06000035 RID: 53 RVA: 0x000026FF File Offset: 0x000008FF
		public int StatusCode { get; set; }

		// Token: 0x06000036 RID: 54 RVA: 0x00002708 File Offset: 0x00000908
		public static CompHistory GetCompHistory(Auth au, int startindex, int endindex, string playerid = "useauth")
		{
			new CompHistory();
			if (playerid == "useauth")
			{
				playerid = au.subject;
			}
			string paramz = "?startIndex=" + startindex.ToString() + "&endIndex=" + endindex.ToString();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://pd.",
				au.region.ToString(),
				".a.pvp.net/mmr/v1/players/",
				playerid,
				"/competitiveupdates",
				paramz
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			CompHistory compHistory = JsonConvert.DeserializeObject<CompHistory>(responce.Content);
			compHistory.StatusCode = (int)responce.StatusCode;
			return compHistory;
		}

		// Token: 0x02000045 RID: 69
		[Nullable(0)]
		public class Match
		{
			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000ACE3 File Offset: 0x00008EE3
			// (set) Token: 0x060002A1 RID: 673 RVA: 0x0000ACEB File Offset: 0x00008EEB
			public string MatchID { get; set; }

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000ACF4 File Offset: 0x00008EF4
			// (set) Token: 0x060002A3 RID: 675 RVA: 0x0000ACFC File Offset: 0x00008EFC
			public string MapID { get; set; }

			// Token: 0x170000DB RID: 219
			// (get) Token: 0x060002A4 RID: 676 RVA: 0x0000AD05 File Offset: 0x00008F05
			// (set) Token: 0x060002A5 RID: 677 RVA: 0x0000AD0D File Offset: 0x00008F0D
			public string SeasonID { get; set; }

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x060002A6 RID: 678 RVA: 0x0000AD16 File Offset: 0x00008F16
			// (set) Token: 0x060002A7 RID: 679 RVA: 0x0000AD1E File Offset: 0x00008F1E
			public object MatchStartTime { get; set; }

			// Token: 0x170000DD RID: 221
			// (get) Token: 0x060002A8 RID: 680 RVA: 0x0000AD27 File Offset: 0x00008F27
			// (set) Token: 0x060002A9 RID: 681 RVA: 0x0000AD2F File Offset: 0x00008F2F
			public int TierAfterUpdate { get; set; }

			// Token: 0x170000DE RID: 222
			// (get) Token: 0x060002AA RID: 682 RVA: 0x0000AD38 File Offset: 0x00008F38
			// (set) Token: 0x060002AB RID: 683 RVA: 0x0000AD40 File Offset: 0x00008F40
			public int TierBeforeUpdate { get; set; }

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x060002AC RID: 684 RVA: 0x0000AD49 File Offset: 0x00008F49
			// (set) Token: 0x060002AD RID: 685 RVA: 0x0000AD51 File Offset: 0x00008F51
			public int RankedRatingAfterUpdate { get; set; }

			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x060002AE RID: 686 RVA: 0x0000AD5A File Offset: 0x00008F5A
			// (set) Token: 0x060002AF RID: 687 RVA: 0x0000AD62 File Offset: 0x00008F62
			public int RankedRatingBeforeUpdate { get; set; }

			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x060002B0 RID: 688 RVA: 0x0000AD6B File Offset: 0x00008F6B
			// (set) Token: 0x060002B1 RID: 689 RVA: 0x0000AD73 File Offset: 0x00008F73
			public int RankedRatingEarned { get; set; }

			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000AD7C File Offset: 0x00008F7C
			// (set) Token: 0x060002B3 RID: 691 RVA: 0x0000AD84 File Offset: 0x00008F84
			public int RankedRatingPerformanceBonus { get; set; }

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x060002B4 RID: 692 RVA: 0x0000AD8D File Offset: 0x00008F8D
			// (set) Token: 0x060002B5 RID: 693 RVA: 0x0000AD95 File Offset: 0x00008F95
			public string CompetitiveMovement { get; set; }

			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000AD9E File Offset: 0x00008F9E
			// (set) Token: 0x060002B7 RID: 695 RVA: 0x0000ADA6 File Offset: 0x00008FA6
			public int AFKPenalty { get; set; }
		}
	}
}
