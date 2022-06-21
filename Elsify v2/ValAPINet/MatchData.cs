using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000014 RID: 20
	[NullableContext(1)]
	[Nullable(0)]
	public class MatchData
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000352D File Offset: 0x0000172D
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00003535 File Offset: 0x00001735
		public MatchData.MatchInfo matchInfo { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000CA RID: 202 RVA: 0x0000353E File Offset: 0x0000173E
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00003546 File Offset: 0x00001746
		public List<MatchData.Player> players { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000CC RID: 204 RVA: 0x0000354F File Offset: 0x0000174F
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00003557 File Offset: 0x00001757
		public List<object> bots { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00003560 File Offset: 0x00001760
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00003568 File Offset: 0x00001768
		public List<MatchData.Team> teams { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00003571 File Offset: 0x00001771
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00003579 File Offset: 0x00001779
		public List<MatchData.RoundResult> roundResults { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00003582 File Offset: 0x00001782
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x0000358A File Offset: 0x0000178A
		public List<MatchData.Kill> kills { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00003593 File Offset: 0x00001793
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x0000359B File Offset: 0x0000179B
		public int StatusCode { get; set; }

		// Token: 0x060000D6 RID: 214 RVA: 0x000035A4 File Offset: 0x000017A4
		public static MatchData GetMatchData(Auth au, string matchID)
		{
			new MatchData();
			RestClient restClient = new RestClient("https://pd." + au.region.ToString() + ".a.pvp.net/match-details/v1/matches/" + matchID);
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			MatchData matchData = JsonConvert.DeserializeObject<MatchData>(responce.Content);
			matchData.StatusCode = (int)responce.StatusCode;
			return matchData;
		}

		// Token: 0x02000064 RID: 100
		[Nullable(0)]
		public class MatchInfo
		{
			// Token: 0x17000167 RID: 359
			// (get) Token: 0x060003DB RID: 987 RVA: 0x0000B749 File Offset: 0x00009949
			// (set) Token: 0x060003DC RID: 988 RVA: 0x0000B751 File Offset: 0x00009951
			public string matchId { get; set; }

			// Token: 0x17000168 RID: 360
			// (get) Token: 0x060003DD RID: 989 RVA: 0x0000B75A File Offset: 0x0000995A
			// (set) Token: 0x060003DE RID: 990 RVA: 0x0000B762 File Offset: 0x00009962
			public string mapId { get; set; }

			// Token: 0x17000169 RID: 361
			// (get) Token: 0x060003DF RID: 991 RVA: 0x0000B76B File Offset: 0x0000996B
			// (set) Token: 0x060003E0 RID: 992 RVA: 0x0000B773 File Offset: 0x00009973
			public string gamePodId { get; set; }

			// Token: 0x1700016A RID: 362
			// (get) Token: 0x060003E1 RID: 993 RVA: 0x0000B77C File Offset: 0x0000997C
			// (set) Token: 0x060003E2 RID: 994 RVA: 0x0000B784 File Offset: 0x00009984
			public string gameLoopZone { get; set; }

			// Token: 0x1700016B RID: 363
			// (get) Token: 0x060003E3 RID: 995 RVA: 0x0000B78D File Offset: 0x0000998D
			// (set) Token: 0x060003E4 RID: 996 RVA: 0x0000B795 File Offset: 0x00009995
			public string gameServerAddress { get; set; }

			// Token: 0x1700016C RID: 364
			// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000B79E File Offset: 0x0000999E
			// (set) Token: 0x060003E6 RID: 998 RVA: 0x0000B7A6 File Offset: 0x000099A6
			public string gameVersion { get; set; }

			// Token: 0x1700016D RID: 365
			// (get) Token: 0x060003E7 RID: 999 RVA: 0x0000B7AF File Offset: 0x000099AF
			// (set) Token: 0x060003E8 RID: 1000 RVA: 0x0000B7B7 File Offset: 0x000099B7
			public int gameLengthMillis { get; set; }

			// Token: 0x1700016E RID: 366
			// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0000B7C0 File Offset: 0x000099C0
			// (set) Token: 0x060003EA RID: 1002 RVA: 0x0000B7C8 File Offset: 0x000099C8
			public long gameStartMillis { get; set; }

			// Token: 0x1700016F RID: 367
			// (get) Token: 0x060003EB RID: 1003 RVA: 0x0000B7D1 File Offset: 0x000099D1
			// (set) Token: 0x060003EC RID: 1004 RVA: 0x0000B7D9 File Offset: 0x000099D9
			public string provisioningFlowID { get; set; }

			// Token: 0x17000170 RID: 368
			// (get) Token: 0x060003ED RID: 1005 RVA: 0x0000B7E2 File Offset: 0x000099E2
			// (set) Token: 0x060003EE RID: 1006 RVA: 0x0000B7EA File Offset: 0x000099EA
			public bool isCompleted { get; set; }

			// Token: 0x17000171 RID: 369
			// (get) Token: 0x060003EF RID: 1007 RVA: 0x0000B7F3 File Offset: 0x000099F3
			// (set) Token: 0x060003F0 RID: 1008 RVA: 0x0000B7FB File Offset: 0x000099FB
			public string customGameName { get; set; }

			// Token: 0x17000172 RID: 370
			// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0000B804 File Offset: 0x00009A04
			// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0000B80C File Offset: 0x00009A0C
			public bool forcePostProcessing { get; set; }

			// Token: 0x17000173 RID: 371
			// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0000B815 File Offset: 0x00009A15
			// (set) Token: 0x060003F4 RID: 1012 RVA: 0x0000B81D File Offset: 0x00009A1D
			public string queueID { get; set; }

			// Token: 0x17000174 RID: 372
			// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0000B826 File Offset: 0x00009A26
			// (set) Token: 0x060003F6 RID: 1014 RVA: 0x0000B82E File Offset: 0x00009A2E
			public string gameMode { get; set; }

			// Token: 0x17000175 RID: 373
			// (get) Token: 0x060003F7 RID: 1015 RVA: 0x0000B837 File Offset: 0x00009A37
			// (set) Token: 0x060003F8 RID: 1016 RVA: 0x0000B83F File Offset: 0x00009A3F
			public bool isRanked { get; set; }

			// Token: 0x17000176 RID: 374
			// (get) Token: 0x060003F9 RID: 1017 RVA: 0x0000B848 File Offset: 0x00009A48
			// (set) Token: 0x060003FA RID: 1018 RVA: 0x0000B850 File Offset: 0x00009A50
			public bool canProgressContracts { get; set; }

			// Token: 0x17000177 RID: 375
			// (get) Token: 0x060003FB RID: 1019 RVA: 0x0000B859 File Offset: 0x00009A59
			// (set) Token: 0x060003FC RID: 1020 RVA: 0x0000B861 File Offset: 0x00009A61
			public bool isMatchSampled { get; set; }

			// Token: 0x17000178 RID: 376
			// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000B86A File Offset: 0x00009A6A
			// (set) Token: 0x060003FE RID: 1022 RVA: 0x0000B872 File Offset: 0x00009A72
			public string seasonId { get; set; }

			// Token: 0x17000179 RID: 377
			// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000B87B File Offset: 0x00009A7B
			// (set) Token: 0x06000400 RID: 1024 RVA: 0x0000B883 File Offset: 0x00009A83
			public string completionState { get; set; }

			// Token: 0x1700017A RID: 378
			// (get) Token: 0x06000401 RID: 1025 RVA: 0x0000B88C File Offset: 0x00009A8C
			// (set) Token: 0x06000402 RID: 1026 RVA: 0x0000B894 File Offset: 0x00009A94
			public string platformType { get; set; }
		}

		// Token: 0x02000065 RID: 101
		[Nullable(0)]
		public class PlatformInfo
		{
			// Token: 0x1700017B RID: 379
			// (get) Token: 0x06000404 RID: 1028 RVA: 0x0000B8A5 File Offset: 0x00009AA5
			// (set) Token: 0x06000405 RID: 1029 RVA: 0x0000B8AD File Offset: 0x00009AAD
			public string platformType { get; set; }

			// Token: 0x1700017C RID: 380
			// (get) Token: 0x06000406 RID: 1030 RVA: 0x0000B8B6 File Offset: 0x00009AB6
			// (set) Token: 0x06000407 RID: 1031 RVA: 0x0000B8BE File Offset: 0x00009ABE
			public string platformOS { get; set; }

			// Token: 0x1700017D RID: 381
			// (get) Token: 0x06000408 RID: 1032 RVA: 0x0000B8C7 File Offset: 0x00009AC7
			// (set) Token: 0x06000409 RID: 1033 RVA: 0x0000B8CF File Offset: 0x00009ACF
			public string platformOSVersion { get; set; }

			// Token: 0x1700017E RID: 382
			// (get) Token: 0x0600040A RID: 1034 RVA: 0x0000B8D8 File Offset: 0x00009AD8
			// (set) Token: 0x0600040B RID: 1035 RVA: 0x0000B8E0 File Offset: 0x00009AE0
			public string platformChipset { get; set; }
		}

		// Token: 0x02000066 RID: 102
		[NullableContext(0)]
		public class Stats
		{
			// Token: 0x1700017F RID: 383
			// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000B8F1 File Offset: 0x00009AF1
			// (set) Token: 0x0600040E RID: 1038 RVA: 0x0000B8F9 File Offset: 0x00009AF9
			public int score { get; set; }

			// Token: 0x17000180 RID: 384
			// (get) Token: 0x0600040F RID: 1039 RVA: 0x0000B902 File Offset: 0x00009B02
			// (set) Token: 0x06000410 RID: 1040 RVA: 0x0000B90A File Offset: 0x00009B0A
			public int roundsPlayed { get; set; }

			// Token: 0x17000181 RID: 385
			// (get) Token: 0x06000411 RID: 1041 RVA: 0x0000B913 File Offset: 0x00009B13
			// (set) Token: 0x06000412 RID: 1042 RVA: 0x0000B91B File Offset: 0x00009B1B
			public int kills { get; set; }

			// Token: 0x17000182 RID: 386
			// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000B924 File Offset: 0x00009B24
			// (set) Token: 0x06000414 RID: 1044 RVA: 0x0000B92C File Offset: 0x00009B2C
			public int deaths { get; set; }

			// Token: 0x17000183 RID: 387
			// (get) Token: 0x06000415 RID: 1045 RVA: 0x0000B935 File Offset: 0x00009B35
			// (set) Token: 0x06000416 RID: 1046 RVA: 0x0000B93D File Offset: 0x00009B3D
			public int assists { get; set; }

			// Token: 0x17000184 RID: 388
			// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000B946 File Offset: 0x00009B46
			// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000B94E File Offset: 0x00009B4E
			public int playtimeMillis { get; set; }
		}

		// Token: 0x02000067 RID: 103
		[NullableContext(0)]
		public class BasicMovement
		{
			// Token: 0x17000185 RID: 389
			// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000B95F File Offset: 0x00009B5F
			// (set) Token: 0x0600041B RID: 1051 RVA: 0x0000B967 File Offset: 0x00009B67
			public int idleTimeMillis { get; set; }

			// Token: 0x17000186 RID: 390
			// (get) Token: 0x0600041C RID: 1052 RVA: 0x0000B970 File Offset: 0x00009B70
			// (set) Token: 0x0600041D RID: 1053 RVA: 0x0000B978 File Offset: 0x00009B78
			public int objectiveCompleteTimeMillis { get; set; }
		}

		// Token: 0x02000068 RID: 104
		[NullableContext(0)]
		public class BasicGunSkill
		{
			// Token: 0x17000187 RID: 391
			// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000B989 File Offset: 0x00009B89
			// (set) Token: 0x06000420 RID: 1056 RVA: 0x0000B991 File Offset: 0x00009B91
			public int idleTimeMillis { get; set; }

			// Token: 0x17000188 RID: 392
			// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000B99A File Offset: 0x00009B9A
			// (set) Token: 0x06000422 RID: 1058 RVA: 0x0000B9A2 File Offset: 0x00009BA2
			public int objectiveCompleteTimeMillis { get; set; }
		}

		// Token: 0x02000069 RID: 105
		[Nullable(0)]
		public class AdaptiveBots
		{
			// Token: 0x17000189 RID: 393
			// (get) Token: 0x06000424 RID: 1060 RVA: 0x0000B9B3 File Offset: 0x00009BB3
			// (set) Token: 0x06000425 RID: 1061 RVA: 0x0000B9BB File Offset: 0x00009BBB
			public int idleTimeMillis { get; set; }

			// Token: 0x1700018A RID: 394
			// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000B9C4 File Offset: 0x00009BC4
			// (set) Token: 0x06000427 RID: 1063 RVA: 0x0000B9CC File Offset: 0x00009BCC
			public int objectiveCompleteTimeMillis { get; set; }

			// Token: 0x1700018B RID: 395
			// (get) Token: 0x06000428 RID: 1064 RVA: 0x0000B9D5 File Offset: 0x00009BD5
			// (set) Token: 0x06000429 RID: 1065 RVA: 0x0000B9DD File Offset: 0x00009BDD
			public int adaptiveBotAverageDurationMillisAllAttempts { get; set; }

			// Token: 0x1700018C RID: 396
			// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000B9E6 File Offset: 0x00009BE6
			// (set) Token: 0x0600042B RID: 1067 RVA: 0x0000B9EE File Offset: 0x00009BEE
			public int adaptiveBotAverageDurationMillisFirstAttempt { get; set; }

			// Token: 0x1700018D RID: 397
			// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000B9F7 File Offset: 0x00009BF7
			// (set) Token: 0x0600042D RID: 1069 RVA: 0x0000B9FF File Offset: 0x00009BFF
			public object killDetailsFirstAttempt { get; set; }
		}

		// Token: 0x0200006A RID: 106
		[Nullable(0)]
		public class Ability
		{
			// Token: 0x1700018E RID: 398
			// (get) Token: 0x0600042F RID: 1071 RVA: 0x0000BA10 File Offset: 0x00009C10
			// (set) Token: 0x06000430 RID: 1072 RVA: 0x0000BA18 File Offset: 0x00009C18
			public int idleTimeMillis { get; set; }

			// Token: 0x1700018F RID: 399
			// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000BA21 File Offset: 0x00009C21
			// (set) Token: 0x06000432 RID: 1074 RVA: 0x0000BA29 File Offset: 0x00009C29
			public int objectiveCompleteTimeMillis { get; set; }

			// Token: 0x17000190 RID: 400
			// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000BA32 File Offset: 0x00009C32
			// (set) Token: 0x06000434 RID: 1076 RVA: 0x0000BA3A File Offset: 0x00009C3A
			public object grenadeEffects { get; set; }

			// Token: 0x17000191 RID: 401
			// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000BA43 File Offset: 0x00009C43
			// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000BA4B File Offset: 0x00009C4B
			public object ability1Effects { get; set; }

			// Token: 0x17000192 RID: 402
			// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000BA54 File Offset: 0x00009C54
			// (set) Token: 0x06000438 RID: 1080 RVA: 0x0000BA5C File Offset: 0x00009C5C
			public object ability2Effects { get; set; }

			// Token: 0x17000193 RID: 403
			// (get) Token: 0x06000439 RID: 1081 RVA: 0x0000BA65 File Offset: 0x00009C65
			// (set) Token: 0x0600043A RID: 1082 RVA: 0x0000BA6D File Offset: 0x00009C6D
			public object ultimateEffects { get; set; }
		}

		// Token: 0x0200006B RID: 107
		[NullableContext(0)]
		public class BombPlant
		{
			// Token: 0x17000194 RID: 404
			// (get) Token: 0x0600043C RID: 1084 RVA: 0x0000BA7E File Offset: 0x00009C7E
			// (set) Token: 0x0600043D RID: 1085 RVA: 0x0000BA86 File Offset: 0x00009C86
			public int idleTimeMillis { get; set; }

			// Token: 0x17000195 RID: 405
			// (get) Token: 0x0600043E RID: 1086 RVA: 0x0000BA8F File Offset: 0x00009C8F
			// (set) Token: 0x0600043F RID: 1087 RVA: 0x0000BA97 File Offset: 0x00009C97
			public int objectiveCompleteTimeMillis { get; set; }
		}

		// Token: 0x0200006C RID: 108
		[NullableContext(0)]
		public class DefendBombSite
		{
			// Token: 0x17000196 RID: 406
			// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000BAA8 File Offset: 0x00009CA8
			// (set) Token: 0x06000442 RID: 1090 RVA: 0x0000BAB0 File Offset: 0x00009CB0
			public int idleTimeMillis { get; set; }

			// Token: 0x17000197 RID: 407
			// (get) Token: 0x06000443 RID: 1091 RVA: 0x0000BAB9 File Offset: 0x00009CB9
			// (set) Token: 0x06000444 RID: 1092 RVA: 0x0000BAC1 File Offset: 0x00009CC1
			public int objectiveCompleteTimeMillis { get; set; }

			// Token: 0x17000198 RID: 408
			// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000BACA File Offset: 0x00009CCA
			// (set) Token: 0x06000446 RID: 1094 RVA: 0x0000BAD2 File Offset: 0x00009CD2
			public bool success { get; set; }
		}

		// Token: 0x0200006D RID: 109
		[NullableContext(0)]
		public class SettingStatus
		{
			// Token: 0x17000199 RID: 409
			// (get) Token: 0x06000448 RID: 1096 RVA: 0x0000BAE3 File Offset: 0x00009CE3
			// (set) Token: 0x06000449 RID: 1097 RVA: 0x0000BAEB File Offset: 0x00009CEB
			public bool isMouseSensitivityDefault { get; set; }

			// Token: 0x1700019A RID: 410
			// (get) Token: 0x0600044A RID: 1098 RVA: 0x0000BAF4 File Offset: 0x00009CF4
			// (set) Token: 0x0600044B RID: 1099 RVA: 0x0000BAFC File Offset: 0x00009CFC
			public bool isCrosshairDefault { get; set; }
		}

		// Token: 0x0200006E RID: 110
		[Nullable(0)]
		public class NewPlayerExperienceDetails
		{
			// Token: 0x1700019B RID: 411
			// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000BB0D File Offset: 0x00009D0D
			// (set) Token: 0x0600044E RID: 1102 RVA: 0x0000BB15 File Offset: 0x00009D15
			public MatchData.BasicMovement basicMovement { get; set; }

			// Token: 0x1700019C RID: 412
			// (get) Token: 0x0600044F RID: 1103 RVA: 0x0000BB1E File Offset: 0x00009D1E
			// (set) Token: 0x06000450 RID: 1104 RVA: 0x0000BB26 File Offset: 0x00009D26
			public MatchData.BasicGunSkill basicGunSkill { get; set; }

			// Token: 0x1700019D RID: 413
			// (get) Token: 0x06000451 RID: 1105 RVA: 0x0000BB2F File Offset: 0x00009D2F
			// (set) Token: 0x06000452 RID: 1106 RVA: 0x0000BB37 File Offset: 0x00009D37
			public MatchData.AdaptiveBots adaptiveBots { get; set; }

			// Token: 0x1700019E RID: 414
			// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000BB40 File Offset: 0x00009D40
			// (set) Token: 0x06000454 RID: 1108 RVA: 0x0000BB48 File Offset: 0x00009D48
			public MatchData.Ability ability { get; set; }

			// Token: 0x1700019F RID: 415
			// (get) Token: 0x06000455 RID: 1109 RVA: 0x0000BB51 File Offset: 0x00009D51
			// (set) Token: 0x06000456 RID: 1110 RVA: 0x0000BB59 File Offset: 0x00009D59
			public MatchData.BombPlant bombPlant { get; set; }

			// Token: 0x170001A0 RID: 416
			// (get) Token: 0x06000457 RID: 1111 RVA: 0x0000BB62 File Offset: 0x00009D62
			// (set) Token: 0x06000458 RID: 1112 RVA: 0x0000BB6A File Offset: 0x00009D6A
			public MatchData.DefendBombSite defendBombSite { get; set; }

			// Token: 0x170001A1 RID: 417
			// (get) Token: 0x06000459 RID: 1113 RVA: 0x0000BB73 File Offset: 0x00009D73
			// (set) Token: 0x0600045A RID: 1114 RVA: 0x0000BB7B File Offset: 0x00009D7B
			public MatchData.SettingStatus settingStatus { get; set; }
		}

		// Token: 0x0200006F RID: 111
		[Nullable(0)]
		public class Player
		{
			// Token: 0x170001A2 RID: 418
			// (get) Token: 0x0600045C RID: 1116 RVA: 0x0000BB8C File Offset: 0x00009D8C
			// (set) Token: 0x0600045D RID: 1117 RVA: 0x0000BB94 File Offset: 0x00009D94
			public string subject { get; set; }

			// Token: 0x170001A3 RID: 419
			// (get) Token: 0x0600045E RID: 1118 RVA: 0x0000BB9D File Offset: 0x00009D9D
			// (set) Token: 0x0600045F RID: 1119 RVA: 0x0000BBA5 File Offset: 0x00009DA5
			public string gameName { get; set; }

			// Token: 0x170001A4 RID: 420
			// (get) Token: 0x06000460 RID: 1120 RVA: 0x0000BBAE File Offset: 0x00009DAE
			// (set) Token: 0x06000461 RID: 1121 RVA: 0x0000BBB6 File Offset: 0x00009DB6
			public string tagLine { get; set; }

			// Token: 0x170001A5 RID: 421
			// (get) Token: 0x06000462 RID: 1122 RVA: 0x0000BBBF File Offset: 0x00009DBF
			// (set) Token: 0x06000463 RID: 1123 RVA: 0x0000BBC7 File Offset: 0x00009DC7
			public MatchData.PlatformInfo platformInfo { get; set; }

			// Token: 0x170001A6 RID: 422
			// (get) Token: 0x06000464 RID: 1124 RVA: 0x0000BBD0 File Offset: 0x00009DD0
			// (set) Token: 0x06000465 RID: 1125 RVA: 0x0000BBD8 File Offset: 0x00009DD8
			public string teamId { get; set; }

			// Token: 0x170001A7 RID: 423
			// (get) Token: 0x06000466 RID: 1126 RVA: 0x0000BBE1 File Offset: 0x00009DE1
			// (set) Token: 0x06000467 RID: 1127 RVA: 0x0000BBE9 File Offset: 0x00009DE9
			public string partyId { get; set; }

			// Token: 0x170001A8 RID: 424
			// (get) Token: 0x06000468 RID: 1128 RVA: 0x0000BBF2 File Offset: 0x00009DF2
			// (set) Token: 0x06000469 RID: 1129 RVA: 0x0000BBFA File Offset: 0x00009DFA
			public string characterId { get; set; }

			// Token: 0x170001A9 RID: 425
			// (get) Token: 0x0600046A RID: 1130 RVA: 0x0000BC03 File Offset: 0x00009E03
			// (set) Token: 0x0600046B RID: 1131 RVA: 0x0000BC0B File Offset: 0x00009E0B
			public MatchData.Stats stats { get; set; }

			// Token: 0x170001AA RID: 426
			// (get) Token: 0x0600046C RID: 1132 RVA: 0x0000BC14 File Offset: 0x00009E14
			// (set) Token: 0x0600046D RID: 1133 RVA: 0x0000BC1C File Offset: 0x00009E1C
			public object roundDamage { get; set; }

			// Token: 0x170001AB RID: 427
			// (get) Token: 0x0600046E RID: 1134 RVA: 0x0000BC25 File Offset: 0x00009E25
			// (set) Token: 0x0600046F RID: 1135 RVA: 0x0000BC2D File Offset: 0x00009E2D
			public int competitiveTier { get; set; }

			// Token: 0x170001AC RID: 428
			// (get) Token: 0x06000470 RID: 1136 RVA: 0x0000BC36 File Offset: 0x00009E36
			// (set) Token: 0x06000471 RID: 1137 RVA: 0x0000BC3E File Offset: 0x00009E3E
			public string playerCard { get; set; }

			// Token: 0x170001AD RID: 429
			// (get) Token: 0x06000472 RID: 1138 RVA: 0x0000BC47 File Offset: 0x00009E47
			// (set) Token: 0x06000473 RID: 1139 RVA: 0x0000BC4F File Offset: 0x00009E4F
			public string playerTitle { get; set; }

			// Token: 0x170001AE RID: 430
			// (get) Token: 0x06000474 RID: 1140 RVA: 0x0000BC58 File Offset: 0x00009E58
			// (set) Token: 0x06000475 RID: 1141 RVA: 0x0000BC60 File Offset: 0x00009E60
			public int sessionPlaytimeMinutes { get; set; }

			// Token: 0x170001AF RID: 431
			// (get) Token: 0x06000476 RID: 1142 RVA: 0x0000BC69 File Offset: 0x00009E69
			// (set) Token: 0x06000477 RID: 1143 RVA: 0x0000BC71 File Offset: 0x00009E71
			public MatchData.NewPlayerExperienceDetails newPlayerExperienceDetails { get; set; }
		}

		// Token: 0x02000070 RID: 112
		[Nullable(0)]
		public class Team
		{
			// Token: 0x170001B0 RID: 432
			// (get) Token: 0x06000479 RID: 1145 RVA: 0x0000BC82 File Offset: 0x00009E82
			// (set) Token: 0x0600047A RID: 1146 RVA: 0x0000BC8A File Offset: 0x00009E8A
			public string teamId { get; set; }

			// Token: 0x170001B1 RID: 433
			// (get) Token: 0x0600047B RID: 1147 RVA: 0x0000BC93 File Offset: 0x00009E93
			// (set) Token: 0x0600047C RID: 1148 RVA: 0x0000BC9B File Offset: 0x00009E9B
			public bool won { get; set; }

			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x0600047D RID: 1149 RVA: 0x0000BCA4 File Offset: 0x00009EA4
			// (set) Token: 0x0600047E RID: 1150 RVA: 0x0000BCAC File Offset: 0x00009EAC
			public int roundsPlayed { get; set; }

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x0600047F RID: 1151 RVA: 0x0000BCB5 File Offset: 0x00009EB5
			// (set) Token: 0x06000480 RID: 1152 RVA: 0x0000BCBD File Offset: 0x00009EBD
			public int roundsWon { get; set; }

			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000BCC6 File Offset: 0x00009EC6
			// (set) Token: 0x06000482 RID: 1154 RVA: 0x0000BCCE File Offset: 0x00009ECE
			public int numPoints { get; set; }
		}

		// Token: 0x02000071 RID: 113
		[NullableContext(0)]
		public class PlantLocation
		{
			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x06000484 RID: 1156 RVA: 0x0000BCDF File Offset: 0x00009EDF
			// (set) Token: 0x06000485 RID: 1157 RVA: 0x0000BCE7 File Offset: 0x00009EE7
			public int x { get; set; }

			// Token: 0x170001B6 RID: 438
			// (get) Token: 0x06000486 RID: 1158 RVA: 0x0000BCF0 File Offset: 0x00009EF0
			// (set) Token: 0x06000487 RID: 1159 RVA: 0x0000BCF8 File Offset: 0x00009EF8
			public int y { get; set; }
		}

		// Token: 0x02000072 RID: 114
		[NullableContext(0)]
		public class DefuseLocation
		{
			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x06000489 RID: 1161 RVA: 0x0000BD09 File Offset: 0x00009F09
			// (set) Token: 0x0600048A RID: 1162 RVA: 0x0000BD11 File Offset: 0x00009F11
			public int x { get; set; }

			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x0600048B RID: 1163 RVA: 0x0000BD1A File Offset: 0x00009F1A
			// (set) Token: 0x0600048C RID: 1164 RVA: 0x0000BD22 File Offset: 0x00009F22
			public int y { get; set; }
		}

		// Token: 0x02000073 RID: 115
		[NullableContext(0)]
		public class VictimLocation
		{
			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x0600048E RID: 1166 RVA: 0x0000BD33 File Offset: 0x00009F33
			// (set) Token: 0x0600048F RID: 1167 RVA: 0x0000BD3B File Offset: 0x00009F3B
			public int x { get; set; }

			// Token: 0x170001BA RID: 442
			// (get) Token: 0x06000490 RID: 1168 RVA: 0x0000BD44 File Offset: 0x00009F44
			// (set) Token: 0x06000491 RID: 1169 RVA: 0x0000BD4C File Offset: 0x00009F4C
			public int y { get; set; }
		}

		// Token: 0x02000074 RID: 116
		[Nullable(0)]
		public class FinishingDamage
		{
			// Token: 0x170001BB RID: 443
			// (get) Token: 0x06000493 RID: 1171 RVA: 0x0000BD5D File Offset: 0x00009F5D
			// (set) Token: 0x06000494 RID: 1172 RVA: 0x0000BD65 File Offset: 0x00009F65
			public string damageType { get; set; }

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x06000495 RID: 1173 RVA: 0x0000BD6E File Offset: 0x00009F6E
			// (set) Token: 0x06000496 RID: 1174 RVA: 0x0000BD76 File Offset: 0x00009F76
			public string damageItem { get; set; }

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000BD7F File Offset: 0x00009F7F
			// (set) Token: 0x06000498 RID: 1176 RVA: 0x0000BD87 File Offset: 0x00009F87
			public bool isSecondaryFireMode { get; set; }
		}

		// Token: 0x02000075 RID: 117
		[Nullable(0)]
		public class Kill
		{
			// Token: 0x170001BE RID: 446
			// (get) Token: 0x0600049A RID: 1178 RVA: 0x0000BD98 File Offset: 0x00009F98
			// (set) Token: 0x0600049B RID: 1179 RVA: 0x0000BDA0 File Offset: 0x00009FA0
			public int gameTime { get; set; }

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x0600049C RID: 1180 RVA: 0x0000BDA9 File Offset: 0x00009FA9
			// (set) Token: 0x0600049D RID: 1181 RVA: 0x0000BDB1 File Offset: 0x00009FB1
			public int roundTime { get; set; }

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x0600049E RID: 1182 RVA: 0x0000BDBA File Offset: 0x00009FBA
			// (set) Token: 0x0600049F RID: 1183 RVA: 0x0000BDC2 File Offset: 0x00009FC2
			public string killer { get; set; }

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0000BDCB File Offset: 0x00009FCB
			// (set) Token: 0x060004A1 RID: 1185 RVA: 0x0000BDD3 File Offset: 0x00009FD3
			public string victim { get; set; }

			// Token: 0x170001C2 RID: 450
			// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000BDDC File Offset: 0x00009FDC
			// (set) Token: 0x060004A3 RID: 1187 RVA: 0x0000BDE4 File Offset: 0x00009FE4
			public MatchData.VictimLocation victimLocation { get; set; }

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0000BDED File Offset: 0x00009FED
			// (set) Token: 0x060004A5 RID: 1189 RVA: 0x0000BDF5 File Offset: 0x00009FF5
			public List<string> assistants { get; set; }

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000BDFE File Offset: 0x00009FFE
			// (set) Token: 0x060004A7 RID: 1191 RVA: 0x0000BE06 File Offset: 0x0000A006
			public List<object> playerLocations { get; set; }

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0000BE0F File Offset: 0x0000A00F
			// (set) Token: 0x060004A9 RID: 1193 RVA: 0x0000BE17 File Offset: 0x0000A017
			public MatchData.FinishingDamage finishingDamage { get; set; }

			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x060004AA RID: 1194 RVA: 0x0000BE20 File Offset: 0x0000A020
			// (set) Token: 0x060004AB RID: 1195 RVA: 0x0000BE28 File Offset: 0x0000A028
			public int round { get; set; }
		}

		// Token: 0x02000076 RID: 118
		[Nullable(0)]
		public class Economy
		{
			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000BE39 File Offset: 0x0000A039
			// (set) Token: 0x060004AE RID: 1198 RVA: 0x0000BE41 File Offset: 0x0000A041
			public int loadoutValue { get; set; }

			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x060004AF RID: 1199 RVA: 0x0000BE4A File Offset: 0x0000A04A
			// (set) Token: 0x060004B0 RID: 1200 RVA: 0x0000BE52 File Offset: 0x0000A052
			public string weapon { get; set; }

			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0000BE5B File Offset: 0x0000A05B
			// (set) Token: 0x060004B2 RID: 1202 RVA: 0x0000BE63 File Offset: 0x0000A063
			public string armor { get; set; }

			// Token: 0x170001CA RID: 458
			// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0000BE6C File Offset: 0x0000A06C
			// (set) Token: 0x060004B4 RID: 1204 RVA: 0x0000BE74 File Offset: 0x0000A074
			public int remaining { get; set; }

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x060004B5 RID: 1205 RVA: 0x0000BE7D File Offset: 0x0000A07D
			// (set) Token: 0x060004B6 RID: 1206 RVA: 0x0000BE85 File Offset: 0x0000A085
			public int spent { get; set; }
		}

		// Token: 0x02000077 RID: 119
		[Nullable(0)]
		public class PlayerStat
		{
			// Token: 0x170001CC RID: 460
			// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000BE96 File Offset: 0x0000A096
			// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0000BE9E File Offset: 0x0000A09E
			public string subject { get; set; }

			// Token: 0x170001CD RID: 461
			// (get) Token: 0x060004BA RID: 1210 RVA: 0x0000BEA7 File Offset: 0x0000A0A7
			// (set) Token: 0x060004BB RID: 1211 RVA: 0x0000BEAF File Offset: 0x0000A0AF
			public List<MatchData.Kill> kills { get; set; }

			// Token: 0x170001CE RID: 462
			// (get) Token: 0x060004BC RID: 1212 RVA: 0x0000BEB8 File Offset: 0x0000A0B8
			// (set) Token: 0x060004BD RID: 1213 RVA: 0x0000BEC0 File Offset: 0x0000A0C0
			public List<object> damage { get; set; }

			// Token: 0x170001CF RID: 463
			// (get) Token: 0x060004BE RID: 1214 RVA: 0x0000BEC9 File Offset: 0x0000A0C9
			// (set) Token: 0x060004BF RID: 1215 RVA: 0x0000BED1 File Offset: 0x0000A0D1
			public int score { get; set; }

			// Token: 0x170001D0 RID: 464
			// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0000BEDA File Offset: 0x0000A0DA
			// (set) Token: 0x060004C1 RID: 1217 RVA: 0x0000BEE2 File Offset: 0x0000A0E2
			public MatchData.Economy economy { get; set; }

			// Token: 0x170001D1 RID: 465
			// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0000BEEB File Offset: 0x0000A0EB
			// (set) Token: 0x060004C3 RID: 1219 RVA: 0x0000BEF3 File Offset: 0x0000A0F3
			public MatchData.Ability ability { get; set; }

			// Token: 0x170001D2 RID: 466
			// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0000BEFC File Offset: 0x0000A0FC
			// (set) Token: 0x060004C5 RID: 1221 RVA: 0x0000BF04 File Offset: 0x0000A104
			public bool wasAfk { get; set; }

			// Token: 0x170001D3 RID: 467
			// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0000BF0D File Offset: 0x0000A10D
			// (set) Token: 0x060004C7 RID: 1223 RVA: 0x0000BF15 File Offset: 0x0000A115
			public bool wasPenalized { get; set; }

			// Token: 0x170001D4 RID: 468
			// (get) Token: 0x060004C8 RID: 1224 RVA: 0x0000BF1E File Offset: 0x0000A11E
			// (set) Token: 0x060004C9 RID: 1225 RVA: 0x0000BF26 File Offset: 0x0000A126
			public bool stayedInSpawn { get; set; }
		}

		// Token: 0x02000078 RID: 120
		[Nullable(0)]
		public class RoundResult
		{
			// Token: 0x170001D5 RID: 469
			// (get) Token: 0x060004CB RID: 1227 RVA: 0x0000BF37 File Offset: 0x0000A137
			// (set) Token: 0x060004CC RID: 1228 RVA: 0x0000BF3F File Offset: 0x0000A13F
			public int roundNum { get; set; }

			// Token: 0x170001D6 RID: 470
			// (get) Token: 0x060004CD RID: 1229 RVA: 0x0000BF48 File Offset: 0x0000A148
			// (set) Token: 0x060004CE RID: 1230 RVA: 0x0000BF50 File Offset: 0x0000A150
			public string roundResult { get; set; }

			// Token: 0x170001D7 RID: 471
			// (get) Token: 0x060004CF RID: 1231 RVA: 0x0000BF59 File Offset: 0x0000A159
			// (set) Token: 0x060004D0 RID: 1232 RVA: 0x0000BF61 File Offset: 0x0000A161
			public string roundCeremony { get; set; }

			// Token: 0x170001D8 RID: 472
			// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0000BF6A File Offset: 0x0000A16A
			// (set) Token: 0x060004D2 RID: 1234 RVA: 0x0000BF72 File Offset: 0x0000A172
			public string winningTeam { get; set; }

			// Token: 0x170001D9 RID: 473
			// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0000BF7B File Offset: 0x0000A17B
			// (set) Token: 0x060004D4 RID: 1236 RVA: 0x0000BF83 File Offset: 0x0000A183
			public int plantRoundTime { get; set; }

			// Token: 0x170001DA RID: 474
			// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0000BF8C File Offset: 0x0000A18C
			// (set) Token: 0x060004D6 RID: 1238 RVA: 0x0000BF94 File Offset: 0x0000A194
			public object plantPlayerLocations { get; set; }

			// Token: 0x170001DB RID: 475
			// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0000BF9D File Offset: 0x0000A19D
			// (set) Token: 0x060004D8 RID: 1240 RVA: 0x0000BFA5 File Offset: 0x0000A1A5
			public MatchData.PlantLocation plantLocation { get; set; }

			// Token: 0x170001DC RID: 476
			// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0000BFAE File Offset: 0x0000A1AE
			// (set) Token: 0x060004DA RID: 1242 RVA: 0x0000BFB6 File Offset: 0x0000A1B6
			public string plantSite { get; set; }

			// Token: 0x170001DD RID: 477
			// (get) Token: 0x060004DB RID: 1243 RVA: 0x0000BFBF File Offset: 0x0000A1BF
			// (set) Token: 0x060004DC RID: 1244 RVA: 0x0000BFC7 File Offset: 0x0000A1C7
			public int defuseRoundTime { get; set; }

			// Token: 0x170001DE RID: 478
			// (get) Token: 0x060004DD RID: 1245 RVA: 0x0000BFD0 File Offset: 0x0000A1D0
			// (set) Token: 0x060004DE RID: 1246 RVA: 0x0000BFD8 File Offset: 0x0000A1D8
			public object defusePlayerLocations { get; set; }

			// Token: 0x170001DF RID: 479
			// (get) Token: 0x060004DF RID: 1247 RVA: 0x0000BFE1 File Offset: 0x0000A1E1
			// (set) Token: 0x060004E0 RID: 1248 RVA: 0x0000BFE9 File Offset: 0x0000A1E9
			public MatchData.DefuseLocation defuseLocation { get; set; }

			// Token: 0x170001E0 RID: 480
			// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0000BFF2 File Offset: 0x0000A1F2
			// (set) Token: 0x060004E2 RID: 1250 RVA: 0x0000BFFA File Offset: 0x0000A1FA
			public List<MatchData.PlayerStat> playerStats { get; set; }

			// Token: 0x170001E1 RID: 481
			// (get) Token: 0x060004E3 RID: 1251 RVA: 0x0000C003 File Offset: 0x0000A203
			// (set) Token: 0x060004E4 RID: 1252 RVA: 0x0000C00B File Offset: 0x0000A20B
			public string roundResultCode { get; set; }

			// Token: 0x170001E2 RID: 482
			// (get) Token: 0x060004E5 RID: 1253 RVA: 0x0000C014 File Offset: 0x0000A214
			// (set) Token: 0x060004E6 RID: 1254 RVA: 0x0000C01C File Offset: 0x0000A21C
			public object playerEconomies { get; set; }

			// Token: 0x170001E3 RID: 483
			// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0000C025 File Offset: 0x0000A225
			// (set) Token: 0x060004E8 RID: 1256 RVA: 0x0000C02D File Offset: 0x0000A22D
			public object playerScores { get; set; }
		}
	}
}
