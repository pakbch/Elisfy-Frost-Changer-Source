using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000016 RID: 22
	[NullableContext(1)]
	[Nullable(0)]
	public class MMR
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000381E File Offset: 0x00001A1E
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x00003826 File Offset: 0x00001A26
		public string SeasonID { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x0000382F File Offset: 0x00001A2F
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x00003837 File Offset: 0x00001A37
		public int NumberOfWins { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00003840 File Offset: 0x00001A40
		// (set) Token: 0x060000EB RID: 235 RVA: 0x00003848 File Offset: 0x00001A48
		public int NumberOfWinsWithPlacements { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00003851 File Offset: 0x00001A51
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00003859 File Offset: 0x00001A59
		public int NumberOfGames { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00003862 File Offset: 0x00001A62
		// (set) Token: 0x060000EF RID: 239 RVA: 0x0000386A File Offset: 0x00001A6A
		public int Rank { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00003873 File Offset: 0x00001A73
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x0000387B File Offset: 0x00001A7B
		public int CapstoneWins { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00003884 File Offset: 0x00001A84
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x0000388C File Offset: 0x00001A8C
		public int LeaderboardRank { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00003895 File Offset: 0x00001A95
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x0000389D File Offset: 0x00001A9D
		public int CompetitiveTier { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x000038A6 File Offset: 0x00001AA6
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x000038AE File Offset: 0x00001AAE
		public int RankedRating { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x000038B7 File Offset: 0x00001AB7
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x000038BF File Offset: 0x00001ABF
		public int GamesNeededForRating { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000FA RID: 250 RVA: 0x000038C8 File Offset: 0x00001AC8
		// (set) Token: 0x060000FB RID: 251 RVA: 0x000038D0 File Offset: 0x00001AD0
		public int TotalWinsNeededForRank { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060000FC RID: 252 RVA: 0x000038D9 File Offset: 0x00001AD9
		// (set) Token: 0x060000FD RID: 253 RVA: 0x000038E1 File Offset: 0x00001AE1
		public int StatusCode { get; set; }

		// Token: 0x060000FE RID: 254 RVA: 0x000038EC File Offset: 0x00001AEC
		public static MMR GetMMR(Auth au, string playerid = null)
		{
			MMR mmr = new MMR();
			if (playerid == null)
			{
				playerid = au.subject;
			}
			RestClient restClient = new RestClient("https://pd." + au.region.ToString() + ".a.pvp.net/mmr/v1/players/" + playerid);
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			JObject obj = JObject.FromObject(JsonConvert.DeserializeObject(responce.Content));
			string season = obj["LatestCompetitiveUpdate"].Value<string>("SeasonID");
			mmr.SeasonID = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<string>("SeasonID");
			mmr.NumberOfWins = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("NumberOfWins");
			mmr.NumberOfWinsWithPlacements = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("NumberOfWinsWithPlacements");
			mmr.NumberOfGames = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("NumberOfGames");
			mmr.Rank = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("Rank");
			mmr.CapstoneWins = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("CapstoneWins");
			mmr.LeaderboardRank = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("LeaderboardRank");
			mmr.CompetitiveTier = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("CompetitiveTier");
			mmr.RankedRating = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("RankedRating");
			mmr.GamesNeededForRating = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("GamesNeededForRating");
			mmr.TotalWinsNeededForRank = obj["QueueSkills"]["competitive"]["SeasonalInfoBySeasonID"][season].Value<int>("TotalWinsNeededForRank");
			mmr.StatusCode = (int)responce.StatusCode;
			return mmr;
		}
	}
}
