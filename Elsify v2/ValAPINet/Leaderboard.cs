using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000013 RID: 19
	[NullableContext(1)]
	[Nullable(0)]
	public class Leaderboard
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000BA RID: 186 RVA: 0x000033AC File Offset: 0x000015AC
		// (set) Token: 0x060000BB RID: 187 RVA: 0x000033B4 File Offset: 0x000015B4
		public int StatusCode { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000033BD File Offset: 0x000015BD
		// (set) Token: 0x060000BD RID: 189 RVA: 0x000033C5 File Offset: 0x000015C5
		public string Deployment { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000BE RID: 190 RVA: 0x000033CE File Offset: 0x000015CE
		// (set) Token: 0x060000BF RID: 191 RVA: 0x000033D6 File Offset: 0x000015D6
		public string QueueID { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x000033DF File Offset: 0x000015DF
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x000033E7 File Offset: 0x000015E7
		public string SeasonID { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x000033F0 File Offset: 0x000015F0
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x000033F8 File Offset: 0x000015F8
		public int TopTierRRThreshold { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00003401 File Offset: 0x00001601
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00003409 File Offset: 0x00001609
		public List<Leaderboard.Player> Players { get; set; }

		// Token: 0x060000C6 RID: 198 RVA: 0x00003414 File Offset: 0x00001614
		public static Leaderboard GetLeaderboard(Auth au, Region region, string season = "nonegiven")
		{
			if (season == "nonegiven")
			{
				season = Content.GetSeason(au.region);
			}
			new Leaderboard();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://pd.",
				au.region.ToString(),
				".a.pvp.net/mmr/v1/leaderboards/affinity/",
				region.ToString(),
				"/queue/competitive/season/",
				season
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(responce.Content);
			leaderboard.StatusCode = (int)responce.StatusCode;
			return leaderboard;
		}

		// Token: 0x02000063 RID: 99
		[Nullable(0)]
		public class Player
		{
			// Token: 0x1700015C RID: 348
			// (get) Token: 0x060003C4 RID: 964 RVA: 0x0000B686 File Offset: 0x00009886
			// (set) Token: 0x060003C5 RID: 965 RVA: 0x0000B68E File Offset: 0x0000988E
			public string PlayerCardID { get; set; }

			// Token: 0x1700015D RID: 349
			// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000B697 File Offset: 0x00009897
			// (set) Token: 0x060003C7 RID: 967 RVA: 0x0000B69F File Offset: 0x0000989F
			public string TitleID { get; set; }

			// Token: 0x1700015E RID: 350
			// (get) Token: 0x060003C8 RID: 968 RVA: 0x0000B6A8 File Offset: 0x000098A8
			// (set) Token: 0x060003C9 RID: 969 RVA: 0x0000B6B0 File Offset: 0x000098B0
			public bool IsBanned { get; set; }

			// Token: 0x1700015F RID: 351
			// (get) Token: 0x060003CA RID: 970 RVA: 0x0000B6B9 File Offset: 0x000098B9
			// (set) Token: 0x060003CB RID: 971 RVA: 0x0000B6C1 File Offset: 0x000098C1
			public bool IsAnonymized { get; set; }

			// Token: 0x17000160 RID: 352
			// (get) Token: 0x060003CC RID: 972 RVA: 0x0000B6CA File Offset: 0x000098CA
			// (set) Token: 0x060003CD RID: 973 RVA: 0x0000B6D2 File Offset: 0x000098D2
			public string puuid { get; set; }

			// Token: 0x17000161 RID: 353
			// (get) Token: 0x060003CE RID: 974 RVA: 0x0000B6DB File Offset: 0x000098DB
			// (set) Token: 0x060003CF RID: 975 RVA: 0x0000B6E3 File Offset: 0x000098E3
			public string gameName { get; set; }

			// Token: 0x17000162 RID: 354
			// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000B6EC File Offset: 0x000098EC
			// (set) Token: 0x060003D1 RID: 977 RVA: 0x0000B6F4 File Offset: 0x000098F4
			public string tagLine { get; set; }

			// Token: 0x17000163 RID: 355
			// (get) Token: 0x060003D2 RID: 978 RVA: 0x0000B6FD File Offset: 0x000098FD
			// (set) Token: 0x060003D3 RID: 979 RVA: 0x0000B705 File Offset: 0x00009905
			public int leaderboardRank { get; set; }

			// Token: 0x17000164 RID: 356
			// (get) Token: 0x060003D4 RID: 980 RVA: 0x0000B70E File Offset: 0x0000990E
			// (set) Token: 0x060003D5 RID: 981 RVA: 0x0000B716 File Offset: 0x00009916
			public int rankedRating { get; set; }

			// Token: 0x17000165 RID: 357
			// (get) Token: 0x060003D6 RID: 982 RVA: 0x0000B71F File Offset: 0x0000991F
			// (set) Token: 0x060003D7 RID: 983 RVA: 0x0000B727 File Offset: 0x00009927
			public int numberOfWins { get; set; }

			// Token: 0x17000166 RID: 358
			// (get) Token: 0x060003D8 RID: 984 RVA: 0x0000B730 File Offset: 0x00009930
			// (set) Token: 0x060003D9 RID: 985 RVA: 0x0000B738 File Offset: 0x00009938
			public int competitiveTier { get; set; }
		}
	}
}
