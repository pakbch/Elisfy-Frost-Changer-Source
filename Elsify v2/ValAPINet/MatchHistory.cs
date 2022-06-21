using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000015 RID: 21
	[NullableContext(1)]
	[Nullable(0)]
	public class MatchHistory
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00003679 File Offset: 0x00001879
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00003681 File Offset: 0x00001881
		public string Subject { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000DA RID: 218 RVA: 0x0000368A File Offset: 0x0000188A
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00003692 File Offset: 0x00001892
		public int BeginIndex { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000DC RID: 220 RVA: 0x0000369B File Offset: 0x0000189B
		// (set) Token: 0x060000DD RID: 221 RVA: 0x000036A3 File Offset: 0x000018A3
		public int EndIndex { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000DE RID: 222 RVA: 0x000036AC File Offset: 0x000018AC
		// (set) Token: 0x060000DF RID: 223 RVA: 0x000036B4 File Offset: 0x000018B4
		public int Total { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x000036BD File Offset: 0x000018BD
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x000036C5 File Offset: 0x000018C5
		public int StatusCode { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x000036CE File Offset: 0x000018CE
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x000036D6 File Offset: 0x000018D6
		public List<MatchHistory.Matches> History { get; set; }

		// Token: 0x060000E4 RID: 228 RVA: 0x000036E0 File Offset: 0x000018E0
		public static MatchHistory GetMatchHistory(Auth au, int startindex, int endindex, string queue, string playerid = "useauth")
		{
			new MatchHistory();
			if (playerid == "useauth")
			{
				playerid = au.subject;
			}
			string paramz = string.Concat(new string[]
			{
				"?startIndex=",
				startindex.ToString(),
				"&endIndex=",
				endindex.ToString(),
				"&queue=",
				queue
			});
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://pd.",
				au.region.ToString(),
				".a.pvp.net/match-history/v1/history/",
				playerid,
				paramz
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			MatchHistory matchHistory = JsonConvert.DeserializeObject<MatchHistory>(responce.Content);
			matchHistory.StatusCode = (int)responce.StatusCode;
			return matchHistory;
		}

		// Token: 0x02000079 RID: 121
		[Nullable(0)]
		public class Matches
		{
			// Token: 0x170001E4 RID: 484
			// (get) Token: 0x060004EA RID: 1258 RVA: 0x0000C03E File Offset: 0x0000A23E
			// (set) Token: 0x060004EB RID: 1259 RVA: 0x0000C046 File Offset: 0x0000A246
			public string MatchID { get; set; }

			// Token: 0x170001E5 RID: 485
			// (get) Token: 0x060004EC RID: 1260 RVA: 0x0000C04F File Offset: 0x0000A24F
			// (set) Token: 0x060004ED RID: 1261 RVA: 0x0000C057 File Offset: 0x0000A257
			public object GameStartTime { get; set; }

			// Token: 0x170001E6 RID: 486
			// (get) Token: 0x060004EE RID: 1262 RVA: 0x0000C060 File Offset: 0x0000A260
			// (set) Token: 0x060004EF RID: 1263 RVA: 0x0000C068 File Offset: 0x0000A268
			public string TeamID { get; set; }
		}
	}
}
