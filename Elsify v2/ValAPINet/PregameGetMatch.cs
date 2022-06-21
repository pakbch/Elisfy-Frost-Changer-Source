using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000019 RID: 25
	[NullableContext(1)]
	[Nullable(0)]
	public class PregameGetMatch
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00003FD3 File Offset: 0x000021D3
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00003FDB File Offset: 0x000021DB
		public string ID { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00003FE4 File Offset: 0x000021E4
		// (set) Token: 0x0600013D RID: 317 RVA: 0x00003FEC File Offset: 0x000021EC
		public long Version { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00003FF5 File Offset: 0x000021F5
		// (set) Token: 0x0600013F RID: 319 RVA: 0x00003FFD File Offset: 0x000021FD
		public List<PregameGetMatch.Team> Teams { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00004006 File Offset: 0x00002206
		// (set) Token: 0x06000141 RID: 321 RVA: 0x0000400E File Offset: 0x0000220E
		public PregameGetMatch.AllyTeamobj AllyTeam { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00004017 File Offset: 0x00002217
		// (set) Token: 0x06000143 RID: 323 RVA: 0x0000401F File Offset: 0x0000221F
		public object EnemyTeam { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000144 RID: 324 RVA: 0x00004028 File Offset: 0x00002228
		// (set) Token: 0x06000145 RID: 325 RVA: 0x00004030 File Offset: 0x00002230
		public List<object> ObserverSubjects { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00004039 File Offset: 0x00002239
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00004041 File Offset: 0x00002241
		public List<object> MatchCoaches { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000148 RID: 328 RVA: 0x0000404A File Offset: 0x0000224A
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00004052 File Offset: 0x00002252
		public int EnemyTeamSize { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600014A RID: 330 RVA: 0x0000405B File Offset: 0x0000225B
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00004063 File Offset: 0x00002263
		public int EnemyTeamLockCount { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600014C RID: 332 RVA: 0x0000406C File Offset: 0x0000226C
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00004074 File Offset: 0x00002274
		public string PregameState { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600014E RID: 334 RVA: 0x0000407D File Offset: 0x0000227D
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00004085 File Offset: 0x00002285
		public DateTime LastUpdated { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000150 RID: 336 RVA: 0x0000408E File Offset: 0x0000228E
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00004096 File Offset: 0x00002296
		public string MapID { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000152 RID: 338 RVA: 0x0000409F File Offset: 0x0000229F
		// (set) Token: 0x06000153 RID: 339 RVA: 0x000040A7 File Offset: 0x000022A7
		public string GamePodID { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000040B0 File Offset: 0x000022B0
		// (set) Token: 0x06000155 RID: 341 RVA: 0x000040B8 File Offset: 0x000022B8
		public string Mode { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000156 RID: 342 RVA: 0x000040C1 File Offset: 0x000022C1
		// (set) Token: 0x06000157 RID: 343 RVA: 0x000040C9 File Offset: 0x000022C9
		public string VoiceSessionID { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000158 RID: 344 RVA: 0x000040D2 File Offset: 0x000022D2
		// (set) Token: 0x06000159 RID: 345 RVA: 0x000040DA File Offset: 0x000022DA
		public string MUCName { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600015A RID: 346 RVA: 0x000040E3 File Offset: 0x000022E3
		// (set) Token: 0x0600015B RID: 347 RVA: 0x000040EB File Offset: 0x000022EB
		public string QueueID { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600015C RID: 348 RVA: 0x000040F4 File Offset: 0x000022F4
		// (set) Token: 0x0600015D RID: 349 RVA: 0x000040FC File Offset: 0x000022FC
		public string ProvisioningFlowID { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00004105 File Offset: 0x00002305
		// (set) Token: 0x0600015F RID: 351 RVA: 0x0000410D File Offset: 0x0000230D
		public bool IsRanked { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00004116 File Offset: 0x00002316
		// (set) Token: 0x06000161 RID: 353 RVA: 0x0000411E File Offset: 0x0000231E
		public long PhaseTimeRemainingNS { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00004127 File Offset: 0x00002327
		// (set) Token: 0x06000163 RID: 355 RVA: 0x0000412F File Offset: 0x0000232F
		public bool altModesFlagADA { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00004138 File Offset: 0x00002338
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00004140 File Offset: 0x00002340
		public int StatusCode { get; set; }

		// Token: 0x06000166 RID: 358 RVA: 0x0000414C File Offset: 0x0000234C
		public static PregameGetMatch GetMatch(Auth au, string matchid)
		{
			new PregameGetMatch();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://glz-",
				au.region.ToString(),
				"-1.",
				au.region.ToString(),
				".a.pvp.net/pregame/v1/matches/",
				matchid
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			PregameGetMatch pregameGetMatch = JsonConvert.DeserializeObject<PregameGetMatch>(responce.Content);
			pregameGetMatch.StatusCode = (int)responce.StatusCode;
			return pregameGetMatch;
		}

		// Token: 0x02000088 RID: 136
		[Nullable(0)]
		public class PlayerIdentity
		{
			// Token: 0x1700021C RID: 540
			// (get) Token: 0x06000569 RID: 1385 RVA: 0x0000C46E File Offset: 0x0000A66E
			// (set) Token: 0x0600056A RID: 1386 RVA: 0x0000C476 File Offset: 0x0000A676
			public string Subject { get; set; }

			// Token: 0x1700021D RID: 541
			// (get) Token: 0x0600056B RID: 1387 RVA: 0x0000C47F File Offset: 0x0000A67F
			// (set) Token: 0x0600056C RID: 1388 RVA: 0x0000C487 File Offset: 0x0000A687
			public string PlayerCardID { get; set; }

			// Token: 0x1700021E RID: 542
			// (get) Token: 0x0600056D RID: 1389 RVA: 0x0000C490 File Offset: 0x0000A690
			// (set) Token: 0x0600056E RID: 1390 RVA: 0x0000C498 File Offset: 0x0000A698
			public string PlayerTitleID { get; set; }

			// Token: 0x1700021F RID: 543
			// (get) Token: 0x0600056F RID: 1391 RVA: 0x0000C4A1 File Offset: 0x0000A6A1
			// (set) Token: 0x06000570 RID: 1392 RVA: 0x0000C4A9 File Offset: 0x0000A6A9
			public bool Incognito { get; set; }
		}

		// Token: 0x02000089 RID: 137
		[Nullable(0)]
		public class SeasonalBadgeInfo
		{
			// Token: 0x17000220 RID: 544
			// (get) Token: 0x06000572 RID: 1394 RVA: 0x0000C4BA File Offset: 0x0000A6BA
			// (set) Token: 0x06000573 RID: 1395 RVA: 0x0000C4C2 File Offset: 0x0000A6C2
			public string SeasonID { get; set; }

			// Token: 0x17000221 RID: 545
			// (get) Token: 0x06000574 RID: 1396 RVA: 0x0000C4CB File Offset: 0x0000A6CB
			// (set) Token: 0x06000575 RID: 1397 RVA: 0x0000C4D3 File Offset: 0x0000A6D3
			public int NumberOfWins { get; set; }

			// Token: 0x17000222 RID: 546
			// (get) Token: 0x06000576 RID: 1398 RVA: 0x0000C4DC File Offset: 0x0000A6DC
			// (set) Token: 0x06000577 RID: 1399 RVA: 0x0000C4E4 File Offset: 0x0000A6E4
			public object WinsByTier { get; set; }

			// Token: 0x17000223 RID: 547
			// (get) Token: 0x06000578 RID: 1400 RVA: 0x0000C4ED File Offset: 0x0000A6ED
			// (set) Token: 0x06000579 RID: 1401 RVA: 0x0000C4F5 File Offset: 0x0000A6F5
			public int Rank { get; set; }

			// Token: 0x17000224 RID: 548
			// (get) Token: 0x0600057A RID: 1402 RVA: 0x0000C4FE File Offset: 0x0000A6FE
			// (set) Token: 0x0600057B RID: 1403 RVA: 0x0000C506 File Offset: 0x0000A706
			public int LeaderboardRank { get; set; }
		}

		// Token: 0x0200008A RID: 138
		[Nullable(0)]
		public class Player
		{
			// Token: 0x17000225 RID: 549
			// (get) Token: 0x0600057D RID: 1405 RVA: 0x0000C517 File Offset: 0x0000A717
			// (set) Token: 0x0600057E RID: 1406 RVA: 0x0000C51F File Offset: 0x0000A71F
			public string Subject { get; set; }

			// Token: 0x17000226 RID: 550
			// (get) Token: 0x0600057F RID: 1407 RVA: 0x0000C528 File Offset: 0x0000A728
			// (set) Token: 0x06000580 RID: 1408 RVA: 0x0000C530 File Offset: 0x0000A730
			public string CharacterID { get; set; }

			// Token: 0x17000227 RID: 551
			// (get) Token: 0x06000581 RID: 1409 RVA: 0x0000C539 File Offset: 0x0000A739
			// (set) Token: 0x06000582 RID: 1410 RVA: 0x0000C541 File Offset: 0x0000A741
			public string CharacterSelectionState { get; set; }

			// Token: 0x17000228 RID: 552
			// (get) Token: 0x06000583 RID: 1411 RVA: 0x0000C54A File Offset: 0x0000A74A
			// (set) Token: 0x06000584 RID: 1412 RVA: 0x0000C552 File Offset: 0x0000A752
			public string PregamePlayerState { get; set; }

			// Token: 0x17000229 RID: 553
			// (get) Token: 0x06000585 RID: 1413 RVA: 0x0000C55B File Offset: 0x0000A75B
			// (set) Token: 0x06000586 RID: 1414 RVA: 0x0000C563 File Offset: 0x0000A763
			public int CompetitiveTier { get; set; }

			// Token: 0x1700022A RID: 554
			// (get) Token: 0x06000587 RID: 1415 RVA: 0x0000C56C File Offset: 0x0000A76C
			// (set) Token: 0x06000588 RID: 1416 RVA: 0x0000C574 File Offset: 0x0000A774
			public PregameGetMatch.PlayerIdentity PlayerIdentity { get; set; }

			// Token: 0x1700022B RID: 555
			// (get) Token: 0x06000589 RID: 1417 RVA: 0x0000C57D File Offset: 0x0000A77D
			// (set) Token: 0x0600058A RID: 1418 RVA: 0x0000C585 File Offset: 0x0000A785
			public PregameGetMatch.SeasonalBadgeInfo SeasonalBadgeInfo { get; set; }
		}

		// Token: 0x0200008B RID: 139
		[Nullable(0)]
		public class Team
		{
			// Token: 0x1700022C RID: 556
			// (get) Token: 0x0600058C RID: 1420 RVA: 0x0000C596 File Offset: 0x0000A796
			// (set) Token: 0x0600058D RID: 1421 RVA: 0x0000C59E File Offset: 0x0000A79E
			public string TeamID { get; set; }

			// Token: 0x1700022D RID: 557
			// (get) Token: 0x0600058E RID: 1422 RVA: 0x0000C5A7 File Offset: 0x0000A7A7
			// (set) Token: 0x0600058F RID: 1423 RVA: 0x0000C5AF File Offset: 0x0000A7AF
			public List<PregameGetMatch.Player> Players { get; set; }
		}

		// Token: 0x0200008C RID: 140
		[Nullable(0)]
		public class AllyTeamobj
		{
			// Token: 0x1700022E RID: 558
			// (get) Token: 0x06000591 RID: 1425 RVA: 0x0000C5C0 File Offset: 0x0000A7C0
			// (set) Token: 0x06000592 RID: 1426 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
			public string TeamID { get; set; }

			// Token: 0x1700022F RID: 559
			// (get) Token: 0x06000593 RID: 1427 RVA: 0x0000C5D1 File Offset: 0x0000A7D1
			// (set) Token: 0x06000594 RID: 1428 RVA: 0x0000C5D9 File Offset: 0x0000A7D9
			public List<PregameGetMatch.Player> Players { get; set; }
		}
	}
}
