using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000018 RID: 24
	[NullableContext(1)]
	[Nullable(0)]
	public class PartyInfo
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00003D38 File Offset: 0x00001F38
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00003D40 File Offset: 0x00001F40
		public int StatusCode { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00003D49 File Offset: 0x00001F49
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00003D51 File Offset: 0x00001F51
		public string ID { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00003D5A File Offset: 0x00001F5A
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00003D62 File Offset: 0x00001F62
		public string MUCName { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00003D6B File Offset: 0x00001F6B
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00003D73 File Offset: 0x00001F73
		public string VoiceRoomID { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00003D7C File Offset: 0x00001F7C
		// (set) Token: 0x06000111 RID: 273 RVA: 0x00003D84 File Offset: 0x00001F84
		public long Version { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00003D8D File Offset: 0x00001F8D
		// (set) Token: 0x06000113 RID: 275 RVA: 0x00003D95 File Offset: 0x00001F95
		public string ClientVersion { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00003D9E File Offset: 0x00001F9E
		// (set) Token: 0x06000115 RID: 277 RVA: 0x00003DA6 File Offset: 0x00001FA6
		public List<PartyInfo.Member> Members { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00003DAF File Offset: 0x00001FAF
		// (set) Token: 0x06000117 RID: 279 RVA: 0x00003DB7 File Offset: 0x00001FB7
		public string State { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00003DC0 File Offset: 0x00001FC0
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00003DC8 File Offset: 0x00001FC8
		public string PreviousState { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00003DD1 File Offset: 0x00001FD1
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00003DD9 File Offset: 0x00001FD9
		public string StateTransitionReason { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00003DE2 File Offset: 0x00001FE2
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00003DEA File Offset: 0x00001FEA
		public string Accessibility { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00003DF3 File Offset: 0x00001FF3
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00003DFB File Offset: 0x00001FFB
		public PartyInfo.CustomGameDataobj CustomGameData { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00003E04 File Offset: 0x00002004
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00003E0C File Offset: 0x0000200C
		public PartyInfo.MatchmakingDataobj MatchmakingData { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00003E15 File Offset: 0x00002015
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00003E1D File Offset: 0x0000201D
		public string Name { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00003E26 File Offset: 0x00002026
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00003E2E File Offset: 0x0000202E
		public object Invites { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00003E37 File Offset: 0x00002037
		// (set) Token: 0x06000127 RID: 295 RVA: 0x00003E3F File Offset: 0x0000203F
		public List<object> Requests { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00003E48 File Offset: 0x00002048
		// (set) Token: 0x06000129 RID: 297 RVA: 0x00003E50 File Offset: 0x00002050
		public DateTime QueueEntryTime { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00003E59 File Offset: 0x00002059
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00003E61 File Offset: 0x00002061
		public PartyInfo.ErrorNotificationobj ErrorNotification { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00003E6A File Offset: 0x0000206A
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00003E72 File Offset: 0x00002072
		public int RestrictedSeconds { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00003E7B File Offset: 0x0000207B
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00003E83 File Offset: 0x00002083
		public List<string> EligibleQueues { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00003E8C File Offset: 0x0000208C
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00003E94 File Offset: 0x00002094
		public string PlatformType { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00003E9D File Offset: 0x0000209D
		// (set) Token: 0x06000133 RID: 307 RVA: 0x00003EA5 File Offset: 0x000020A5
		public List<object> QueueIneligibilities { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00003EAE File Offset: 0x000020AE
		// (set) Token: 0x06000135 RID: 309 RVA: 0x00003EB6 File Offset: 0x000020B6
		public PartyInfo.CheatDataobj CheatData { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00003EBF File Offset: 0x000020BF
		// (set) Token: 0x06000137 RID: 311 RVA: 0x00003EC7 File Offset: 0x000020C7
		public List<object> XPBonuses { get; set; }

		// Token: 0x06000138 RID: 312 RVA: 0x00003ED0 File Offset: 0x000020D0
		public static PartyInfo Party(Auth au, string partyID)
		{
			new PartyInfo();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://glz-",
				au.region.ToString(),
				"-1.",
				au.region.ToString(),
				".a.pvp.net/parties/v1/parties/",
				partyID
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			PartyInfo partyInfo = JsonConvert.DeserializeObject<PartyInfo>(responce.Content);
			partyInfo.StatusCode = (int)responce.StatusCode;
			return partyInfo;
		}

		// Token: 0x0200007E RID: 126
		[Nullable(0)]
		public class PlayerIdentity
		{
			// Token: 0x170001F2 RID: 498
			// (get) Token: 0x0600050B RID: 1291 RVA: 0x0000C154 File Offset: 0x0000A354
			// (set) Token: 0x0600050C RID: 1292 RVA: 0x0000C15C File Offset: 0x0000A35C
			public string Subject { get; set; }

			// Token: 0x170001F3 RID: 499
			// (get) Token: 0x0600050D RID: 1293 RVA: 0x0000C165 File Offset: 0x0000A365
			// (set) Token: 0x0600050E RID: 1294 RVA: 0x0000C16D File Offset: 0x0000A36D
			public string PlayerCardID { get; set; }

			// Token: 0x170001F4 RID: 500
			// (get) Token: 0x0600050F RID: 1295 RVA: 0x0000C176 File Offset: 0x0000A376
			// (set) Token: 0x06000510 RID: 1296 RVA: 0x0000C17E File Offset: 0x0000A37E
			public string PlayerTitleID { get; set; }

			// Token: 0x170001F5 RID: 501
			// (get) Token: 0x06000511 RID: 1297 RVA: 0x0000C187 File Offset: 0x0000A387
			// (set) Token: 0x06000512 RID: 1298 RVA: 0x0000C18F File Offset: 0x0000A38F
			public bool Incognito { get; set; }
		}

		// Token: 0x0200007F RID: 127
		[Nullable(0)]
		public class SeasonalBadgeInfo
		{
			// Token: 0x170001F6 RID: 502
			// (get) Token: 0x06000514 RID: 1300 RVA: 0x0000C1A0 File Offset: 0x0000A3A0
			// (set) Token: 0x06000515 RID: 1301 RVA: 0x0000C1A8 File Offset: 0x0000A3A8
			public string SeasonID { get; set; }

			// Token: 0x170001F7 RID: 503
			// (get) Token: 0x06000516 RID: 1302 RVA: 0x0000C1B1 File Offset: 0x0000A3B1
			// (set) Token: 0x06000517 RID: 1303 RVA: 0x0000C1B9 File Offset: 0x0000A3B9
			public int NumberOfWins { get; set; }

			// Token: 0x170001F8 RID: 504
			// (get) Token: 0x06000518 RID: 1304 RVA: 0x0000C1C2 File Offset: 0x0000A3C2
			// (set) Token: 0x06000519 RID: 1305 RVA: 0x0000C1CA File Offset: 0x0000A3CA
			public object WinsByTier { get; set; }

			// Token: 0x170001F9 RID: 505
			// (get) Token: 0x0600051A RID: 1306 RVA: 0x0000C1D3 File Offset: 0x0000A3D3
			// (set) Token: 0x0600051B RID: 1307 RVA: 0x0000C1DB File Offset: 0x0000A3DB
			public int Rank { get; set; }

			// Token: 0x170001FA RID: 506
			// (get) Token: 0x0600051C RID: 1308 RVA: 0x0000C1E4 File Offset: 0x0000A3E4
			// (set) Token: 0x0600051D RID: 1309 RVA: 0x0000C1EC File Offset: 0x0000A3EC
			public int LeaderboardRank { get; set; }
		}

		// Token: 0x02000080 RID: 128
		[Nullable(0)]
		public class Ping
		{
			// Token: 0x170001FB RID: 507
			// (get) Token: 0x0600051F RID: 1311 RVA: 0x0000C1FD File Offset: 0x0000A3FD
			// (set) Token: 0x06000520 RID: 1312 RVA: 0x0000C205 File Offset: 0x0000A405
			public int ping { get; set; }

			// Token: 0x170001FC RID: 508
			// (get) Token: 0x06000521 RID: 1313 RVA: 0x0000C20E File Offset: 0x0000A40E
			// (set) Token: 0x06000522 RID: 1314 RVA: 0x0000C216 File Offset: 0x0000A416
			public string GamePodID { get; set; }
		}

		// Token: 0x02000081 RID: 129
		[Nullable(0)]
		public class Member
		{
			// Token: 0x170001FD RID: 509
			// (get) Token: 0x06000524 RID: 1316 RVA: 0x0000C227 File Offset: 0x0000A427
			// (set) Token: 0x06000525 RID: 1317 RVA: 0x0000C22F File Offset: 0x0000A42F
			public string Subject { get; set; }

			// Token: 0x170001FE RID: 510
			// (get) Token: 0x06000526 RID: 1318 RVA: 0x0000C238 File Offset: 0x0000A438
			// (set) Token: 0x06000527 RID: 1319 RVA: 0x0000C240 File Offset: 0x0000A440
			public int CompetitiveTier { get; set; }

			// Token: 0x170001FF RID: 511
			// (get) Token: 0x06000528 RID: 1320 RVA: 0x0000C249 File Offset: 0x0000A449
			// (set) Token: 0x06000529 RID: 1321 RVA: 0x0000C251 File Offset: 0x0000A451
			public PartyInfo.PlayerIdentity PlayerIdentity { get; set; }

			// Token: 0x17000200 RID: 512
			// (get) Token: 0x0600052A RID: 1322 RVA: 0x0000C25A File Offset: 0x0000A45A
			// (set) Token: 0x0600052B RID: 1323 RVA: 0x0000C262 File Offset: 0x0000A462
			public PartyInfo.SeasonalBadgeInfo SeasonalBadgeInfo { get; set; }

			// Token: 0x17000201 RID: 513
			// (get) Token: 0x0600052C RID: 1324 RVA: 0x0000C26B File Offset: 0x0000A46B
			// (set) Token: 0x0600052D RID: 1325 RVA: 0x0000C273 File Offset: 0x0000A473
			public bool IsOwner { get; set; }

			// Token: 0x17000202 RID: 514
			// (get) Token: 0x0600052E RID: 1326 RVA: 0x0000C27C File Offset: 0x0000A47C
			// (set) Token: 0x0600052F RID: 1327 RVA: 0x0000C284 File Offset: 0x0000A484
			public int QueueEligibleRemainingGames { get; set; }

			// Token: 0x17000203 RID: 515
			// (get) Token: 0x06000530 RID: 1328 RVA: 0x0000C28D File Offset: 0x0000A48D
			// (set) Token: 0x06000531 RID: 1329 RVA: 0x0000C295 File Offset: 0x0000A495
			public int QueueEligibleRemainingWins { get; set; }

			// Token: 0x17000204 RID: 516
			// (get) Token: 0x06000532 RID: 1330 RVA: 0x0000C29E File Offset: 0x0000A49E
			// (set) Token: 0x06000533 RID: 1331 RVA: 0x0000C2A6 File Offset: 0x0000A4A6
			public List<PartyInfo.Ping> Pings { get; set; }

			// Token: 0x17000205 RID: 517
			// (get) Token: 0x06000534 RID: 1332 RVA: 0x0000C2AF File Offset: 0x0000A4AF
			// (set) Token: 0x06000535 RID: 1333 RVA: 0x0000C2B7 File Offset: 0x0000A4B7
			public bool IsReady { get; set; }

			// Token: 0x17000206 RID: 518
			// (get) Token: 0x06000536 RID: 1334 RVA: 0x0000C2C0 File Offset: 0x0000A4C0
			// (set) Token: 0x06000537 RID: 1335 RVA: 0x0000C2C8 File Offset: 0x0000A4C8
			public bool IsModerator { get; set; }

			// Token: 0x17000207 RID: 519
			// (get) Token: 0x06000538 RID: 1336 RVA: 0x0000C2D1 File Offset: 0x0000A4D1
			// (set) Token: 0x06000539 RID: 1337 RVA: 0x0000C2D9 File Offset: 0x0000A4D9
			public bool UseBroadcastHUD { get; set; }

			// Token: 0x17000208 RID: 520
			// (get) Token: 0x0600053A RID: 1338 RVA: 0x0000C2E2 File Offset: 0x0000A4E2
			// (set) Token: 0x0600053B RID: 1339 RVA: 0x0000C2EA File Offset: 0x0000A4EA
			public string PlatformType { get; set; }
		}

		// Token: 0x02000082 RID: 130
		[Nullable(0)]
		public class Settings
		{
			// Token: 0x17000209 RID: 521
			// (get) Token: 0x0600053D RID: 1341 RVA: 0x0000C2FB File Offset: 0x0000A4FB
			// (set) Token: 0x0600053E RID: 1342 RVA: 0x0000C303 File Offset: 0x0000A503
			public string Map { get; set; }

			// Token: 0x1700020A RID: 522
			// (get) Token: 0x0600053F RID: 1343 RVA: 0x0000C30C File Offset: 0x0000A50C
			// (set) Token: 0x06000540 RID: 1344 RVA: 0x0000C314 File Offset: 0x0000A514
			public string Mode { get; set; }

			// Token: 0x1700020B RID: 523
			// (get) Token: 0x06000541 RID: 1345 RVA: 0x0000C31D File Offset: 0x0000A51D
			// (set) Token: 0x06000542 RID: 1346 RVA: 0x0000C325 File Offset: 0x0000A525
			public bool UseBots { get; set; }

			// Token: 0x1700020C RID: 524
			// (get) Token: 0x06000543 RID: 1347 RVA: 0x0000C32E File Offset: 0x0000A52E
			// (set) Token: 0x06000544 RID: 1348 RVA: 0x0000C336 File Offset: 0x0000A536
			public string GamePod { get; set; }

			// Token: 0x1700020D RID: 525
			// (get) Token: 0x06000545 RID: 1349 RVA: 0x0000C33F File Offset: 0x0000A53F
			// (set) Token: 0x06000546 RID: 1350 RVA: 0x0000C347 File Offset: 0x0000A547
			public object GameRules { get; set; }
		}

		// Token: 0x02000083 RID: 131
		[Nullable(0)]
		public class Membership
		{
			// Token: 0x1700020E RID: 526
			// (get) Token: 0x06000548 RID: 1352 RVA: 0x0000C358 File Offset: 0x0000A558
			// (set) Token: 0x06000549 RID: 1353 RVA: 0x0000C360 File Offset: 0x0000A560
			public object teamOne { get; set; }

			// Token: 0x1700020F RID: 527
			// (get) Token: 0x0600054A RID: 1354 RVA: 0x0000C369 File Offset: 0x0000A569
			// (set) Token: 0x0600054B RID: 1355 RVA: 0x0000C371 File Offset: 0x0000A571
			public object teamTwo { get; set; }

			// Token: 0x17000210 RID: 528
			// (get) Token: 0x0600054C RID: 1356 RVA: 0x0000C37A File Offset: 0x0000A57A
			// (set) Token: 0x0600054D RID: 1357 RVA: 0x0000C382 File Offset: 0x0000A582
			public object teamSpectate { get; set; }

			// Token: 0x17000211 RID: 529
			// (get) Token: 0x0600054E RID: 1358 RVA: 0x0000C38B File Offset: 0x0000A58B
			// (set) Token: 0x0600054F RID: 1359 RVA: 0x0000C393 File Offset: 0x0000A593
			public object teamOneCoaches { get; set; }

			// Token: 0x17000212 RID: 530
			// (get) Token: 0x06000550 RID: 1360 RVA: 0x0000C39C File Offset: 0x0000A59C
			// (set) Token: 0x06000551 RID: 1361 RVA: 0x0000C3A4 File Offset: 0x0000A5A4
			public object teamTwoCoaches { get; set; }
		}

		// Token: 0x02000084 RID: 132
		[Nullable(0)]
		public class CustomGameDataobj
		{
			// Token: 0x17000213 RID: 531
			// (get) Token: 0x06000553 RID: 1363 RVA: 0x0000C3B5 File Offset: 0x0000A5B5
			// (set) Token: 0x06000554 RID: 1364 RVA: 0x0000C3BD File Offset: 0x0000A5BD
			public PartyInfo.Settings Settings { get; set; }

			// Token: 0x17000214 RID: 532
			// (get) Token: 0x06000555 RID: 1365 RVA: 0x0000C3C6 File Offset: 0x0000A5C6
			// (set) Token: 0x06000556 RID: 1366 RVA: 0x0000C3CE File Offset: 0x0000A5CE
			public PartyInfo.Membership Membership { get; set; }

			// Token: 0x17000215 RID: 533
			// (get) Token: 0x06000557 RID: 1367 RVA: 0x0000C3D7 File Offset: 0x0000A5D7
			// (set) Token: 0x06000558 RID: 1368 RVA: 0x0000C3DF File Offset: 0x0000A5DF
			public int MaxPartySize { get; set; }
		}

		// Token: 0x02000085 RID: 133
		[Nullable(0)]
		public class MatchmakingDataobj
		{
			// Token: 0x17000216 RID: 534
			// (get) Token: 0x0600055A RID: 1370 RVA: 0x0000C3F0 File Offset: 0x0000A5F0
			// (set) Token: 0x0600055B RID: 1371 RVA: 0x0000C3F8 File Offset: 0x0000A5F8
			public string QueueID { get; set; }

			// Token: 0x17000217 RID: 535
			// (get) Token: 0x0600055C RID: 1372 RVA: 0x0000C401 File Offset: 0x0000A601
			// (set) Token: 0x0600055D RID: 1373 RVA: 0x0000C409 File Offset: 0x0000A609
			public List<object> PreferredGamePods { get; set; }
		}

		// Token: 0x02000086 RID: 134
		[Nullable(0)]
		public class ErrorNotificationobj
		{
			// Token: 0x17000218 RID: 536
			// (get) Token: 0x0600055F RID: 1375 RVA: 0x0000C41A File Offset: 0x0000A61A
			// (set) Token: 0x06000560 RID: 1376 RVA: 0x0000C422 File Offset: 0x0000A622
			public string ErrorType { get; set; }

			// Token: 0x17000219 RID: 537
			// (get) Token: 0x06000561 RID: 1377 RVA: 0x0000C42B File Offset: 0x0000A62B
			// (set) Token: 0x06000562 RID: 1378 RVA: 0x0000C433 File Offset: 0x0000A633
			public object ErroredPlayers { get; set; }
		}

		// Token: 0x02000087 RID: 135
		[Nullable(0)]
		public class CheatDataobj
		{
			// Token: 0x1700021A RID: 538
			// (get) Token: 0x06000564 RID: 1380 RVA: 0x0000C444 File Offset: 0x0000A644
			// (set) Token: 0x06000565 RID: 1381 RVA: 0x0000C44C File Offset: 0x0000A64C
			public string GamePodOverride { get; set; }

			// Token: 0x1700021B RID: 539
			// (get) Token: 0x06000566 RID: 1382 RVA: 0x0000C455 File Offset: 0x0000A655
			// (set) Token: 0x06000567 RID: 1383 RVA: 0x0000C45D File Offset: 0x0000A65D
			public bool ForcePostGameProcessing { get; set; }
		}
	}
}
