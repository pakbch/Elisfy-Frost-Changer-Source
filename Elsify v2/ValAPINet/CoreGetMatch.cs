using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200000F RID: 15
	[NullableContext(1)]
	[Nullable(0)]
	public class CoreGetMatch
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002D62 File Offset: 0x00000F62
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002D6A File Offset: 0x00000F6A
		public string MatchID { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002D73 File Offset: 0x00000F73
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00002D7B File Offset: 0x00000F7B
		public long Version { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002D84 File Offset: 0x00000F84
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00002D8C File Offset: 0x00000F8C
		public string State { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002D95 File Offset: 0x00000F95
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00002D9D File Offset: 0x00000F9D
		public string MapID { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00002DA6 File Offset: 0x00000FA6
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00002DAE File Offset: 0x00000FAE
		public string ModeID { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00002DB7 File Offset: 0x00000FB7
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00002DBF File Offset: 0x00000FBF
		public string ProvisioningFlow { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002DC8 File Offset: 0x00000FC8
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00002DD0 File Offset: 0x00000FD0
		public string GamePodID { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00002DD9 File Offset: 0x00000FD9
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00002DE1 File Offset: 0x00000FE1
		public string AllMUCName { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00002DEA File Offset: 0x00000FEA
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00002DF2 File Offset: 0x00000FF2
		public string TeamMUCName { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00002DFB File Offset: 0x00000FFB
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00002E03 File Offset: 0x00001003
		public string TeamVoiceID { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002E0C File Offset: 0x0000100C
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00002E14 File Offset: 0x00001014
		public bool IsReconnectable { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00002E1D File Offset: 0x0000101D
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00002E25 File Offset: 0x00001025
		public CoreGetMatch.ConnectionDetailsobj ConnectionDetails { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00002E2E File Offset: 0x0000102E
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00002E36 File Offset: 0x00001036
		public object PostGameDetails { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00002E3F File Offset: 0x0000103F
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00002E47 File Offset: 0x00001047
		public List<CoreGetMatch.Player> Players { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00002E50 File Offset: 0x00001050
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00002E58 File Offset: 0x00001058
		public object MatchmakingData { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00002E61 File Offset: 0x00001061
		// (set) Token: 0x0600008B RID: 139 RVA: 0x00002E69 File Offset: 0x00001069
		public int StatusCode { get; set; }

		// Token: 0x0600008C RID: 140 RVA: 0x00002E74 File Offset: 0x00001074
		public static CoreGetMatch GetMatch(Auth au, string matchid)
		{
			new CoreGetMatch();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://glz-",
				au.region.ToString(),
				"-1.",
				au.region.ToString(),
				".a.pvp.net/core-game/v1/matches/",
				matchid
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			CoreGetMatch coreGetMatch = JsonConvert.DeserializeObject<CoreGetMatch>(responce.Content);
			coreGetMatch.StatusCode = (int)responce.StatusCode;
			return coreGetMatch;
		}

		// Token: 0x02000059 RID: 89
		[Nullable(0)]
		public class ConnectionDetailsobj
		{
			// Token: 0x17000134 RID: 308
			// (get) Token: 0x0600036A RID: 874 RVA: 0x0000B38E File Offset: 0x0000958E
			// (set) Token: 0x0600036B RID: 875 RVA: 0x0000B396 File Offset: 0x00009596
			public string GameServerHost { get; set; }

			// Token: 0x17000135 RID: 309
			// (get) Token: 0x0600036C RID: 876 RVA: 0x0000B39F File Offset: 0x0000959F
			// (set) Token: 0x0600036D RID: 877 RVA: 0x0000B3A7 File Offset: 0x000095A7
			public int GameServerPort { get; set; }

			// Token: 0x17000136 RID: 310
			// (get) Token: 0x0600036E RID: 878 RVA: 0x0000B3B0 File Offset: 0x000095B0
			// (set) Token: 0x0600036F RID: 879 RVA: 0x0000B3B8 File Offset: 0x000095B8
			public long GameServerObfuscatedIP { get; set; }

			// Token: 0x17000137 RID: 311
			// (get) Token: 0x06000370 RID: 880 RVA: 0x0000B3C1 File Offset: 0x000095C1
			// (set) Token: 0x06000371 RID: 881 RVA: 0x0000B3C9 File Offset: 0x000095C9
			public long GameClientHash { get; set; }

			// Token: 0x17000138 RID: 312
			// (get) Token: 0x06000372 RID: 882 RVA: 0x0000B3D2 File Offset: 0x000095D2
			// (set) Token: 0x06000373 RID: 883 RVA: 0x0000B3DA File Offset: 0x000095DA
			public string PlayerKey { get; set; }

			// Token: 0x17000139 RID: 313
			// (get) Token: 0x06000374 RID: 884 RVA: 0x0000B3E3 File Offset: 0x000095E3
			// (set) Token: 0x06000375 RID: 885 RVA: 0x0000B3EB File Offset: 0x000095EB
			public string TempMap { get; set; }

			// Token: 0x1700013A RID: 314
			// (get) Token: 0x06000376 RID: 886 RVA: 0x0000B3F4 File Offset: 0x000095F4
			// (set) Token: 0x06000377 RID: 887 RVA: 0x0000B3FC File Offset: 0x000095FC
			public string TempTeam { get; set; }
		}

		// Token: 0x0200005A RID: 90
		[Nullable(0)]
		public class PlayerIdentity
		{
			// Token: 0x1700013B RID: 315
			// (get) Token: 0x06000379 RID: 889 RVA: 0x0000B40D File Offset: 0x0000960D
			// (set) Token: 0x0600037A RID: 890 RVA: 0x0000B415 File Offset: 0x00009615
			public string Subject { get; set; }

			// Token: 0x1700013C RID: 316
			// (get) Token: 0x0600037B RID: 891 RVA: 0x0000B41E File Offset: 0x0000961E
			// (set) Token: 0x0600037C RID: 892 RVA: 0x0000B426 File Offset: 0x00009626
			public string PlayerCardID { get; set; }

			// Token: 0x1700013D RID: 317
			// (get) Token: 0x0600037D RID: 893 RVA: 0x0000B42F File Offset: 0x0000962F
			// (set) Token: 0x0600037E RID: 894 RVA: 0x0000B437 File Offset: 0x00009637
			public string PlayerTitleID { get; set; }

			// Token: 0x1700013E RID: 318
			// (get) Token: 0x0600037F RID: 895 RVA: 0x0000B440 File Offset: 0x00009640
			// (set) Token: 0x06000380 RID: 896 RVA: 0x0000B448 File Offset: 0x00009648
			public bool Incognito { get; set; }
		}

		// Token: 0x0200005B RID: 91
		[Nullable(0)]
		public class SeasonalBadgeInfo
		{
			// Token: 0x1700013F RID: 319
			// (get) Token: 0x06000382 RID: 898 RVA: 0x0000B459 File Offset: 0x00009659
			// (set) Token: 0x06000383 RID: 899 RVA: 0x0000B461 File Offset: 0x00009661
			public string SeasonID { get; set; }

			// Token: 0x17000140 RID: 320
			// (get) Token: 0x06000384 RID: 900 RVA: 0x0000B46A File Offset: 0x0000966A
			// (set) Token: 0x06000385 RID: 901 RVA: 0x0000B472 File Offset: 0x00009672
			public int NumberOfWins { get; set; }

			// Token: 0x17000141 RID: 321
			// (get) Token: 0x06000386 RID: 902 RVA: 0x0000B47B File Offset: 0x0000967B
			// (set) Token: 0x06000387 RID: 903 RVA: 0x0000B483 File Offset: 0x00009683
			public object WinsByTier { get; set; }

			// Token: 0x17000142 RID: 322
			// (get) Token: 0x06000388 RID: 904 RVA: 0x0000B48C File Offset: 0x0000968C
			// (set) Token: 0x06000389 RID: 905 RVA: 0x0000B494 File Offset: 0x00009694
			public int Rank { get; set; }

			// Token: 0x17000143 RID: 323
			// (get) Token: 0x0600038A RID: 906 RVA: 0x0000B49D File Offset: 0x0000969D
			// (set) Token: 0x0600038B RID: 907 RVA: 0x0000B4A5 File Offset: 0x000096A5
			public int LeaderboardRank { get; set; }
		}

		// Token: 0x0200005C RID: 92
		[Nullable(0)]
		public class Player
		{
			// Token: 0x17000144 RID: 324
			// (get) Token: 0x0600038D RID: 909 RVA: 0x0000B4B6 File Offset: 0x000096B6
			// (set) Token: 0x0600038E RID: 910 RVA: 0x0000B4BE File Offset: 0x000096BE
			public string Subject { get; set; }

			// Token: 0x17000145 RID: 325
			// (get) Token: 0x0600038F RID: 911 RVA: 0x0000B4C7 File Offset: 0x000096C7
			// (set) Token: 0x06000390 RID: 912 RVA: 0x0000B4CF File Offset: 0x000096CF
			public string TeamID { get; set; }

			// Token: 0x17000146 RID: 326
			// (get) Token: 0x06000391 RID: 913 RVA: 0x0000B4D8 File Offset: 0x000096D8
			// (set) Token: 0x06000392 RID: 914 RVA: 0x0000B4E0 File Offset: 0x000096E0
			public string CharacterID { get; set; }

			// Token: 0x17000147 RID: 327
			// (get) Token: 0x06000393 RID: 915 RVA: 0x0000B4E9 File Offset: 0x000096E9
			// (set) Token: 0x06000394 RID: 916 RVA: 0x0000B4F1 File Offset: 0x000096F1
			public CoreGetMatch.PlayerIdentity PlayerIdentity { get; set; }

			// Token: 0x17000148 RID: 328
			// (get) Token: 0x06000395 RID: 917 RVA: 0x0000B4FA File Offset: 0x000096FA
			// (set) Token: 0x06000396 RID: 918 RVA: 0x0000B502 File Offset: 0x00009702
			public CoreGetMatch.SeasonalBadgeInfo SeasonalBadgeInfo { get; set; }
		}
	}
}
