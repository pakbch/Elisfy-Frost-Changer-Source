using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200001A RID: 26
	[NullableContext(1)]
	[Nullable(0)]
	public class PregameGetPlayer
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0000424F File Offset: 0x0000244F
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00004257 File Offset: 0x00002457
		public string Subject { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00004260 File Offset: 0x00002460
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00004268 File Offset: 0x00002468
		public string MatchID { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00004271 File Offset: 0x00002471
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00004279 File Offset: 0x00002479
		public long Version { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00004282 File Offset: 0x00002482
		// (set) Token: 0x0600016F RID: 367 RVA: 0x0000428A File Offset: 0x0000248A
		public int StatusCode { get; set; }

		// Token: 0x06000170 RID: 368 RVA: 0x00004294 File Offset: 0x00002494
		public static PregameGetPlayer GetPlayer(Auth au, string playerid = "useauth")
		{
			new PregameGetPlayer();
			if (playerid == "useauth")
			{
				playerid = au.subject;
			}
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://glz-",
				au.region.ToString(),
				"-1.",
				au.region.ToString(),
				".a.pvp.net/pregame/v1/players/",
				playerid
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			PregameGetPlayer pregameGetPlayer = JsonConvert.DeserializeObject<PregameGetPlayer>(responce.Content);
			pregameGetPlayer.StatusCode = (int)responce.StatusCode;
			return pregameGetPlayer;
		}
	}
}
