using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000011 RID: 17
	[NullableContext(1)]
	[Nullable(0)]
	public class CoreGetPlayer
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600009E RID: 158 RVA: 0x000030F8 File Offset: 0x000012F8
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00003100 File Offset: 0x00001300
		public string Subject { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003109 File Offset: 0x00001309
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00003111 File Offset: 0x00001311
		public string MatchID { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000311A File Offset: 0x0000131A
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00003122 File Offset: 0x00001322
		public long Version { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x0000312B File Offset: 0x0000132B
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00003133 File Offset: 0x00001333
		public int StatusCode { get; set; }

		// Token: 0x060000A6 RID: 166 RVA: 0x0000313C File Offset: 0x0000133C
		public static CoreGetPlayer GetPlayer(Auth au, string playerid = "useauth")
		{
			new CoreGetPlayer();
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
				".a.pvp.net/core-game/v1/players/",
				playerid
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			CoreGetPlayer coreGetPlayer = JsonConvert.DeserializeObject<CoreGetPlayer>(responce.Content);
			coreGetPlayer.StatusCode = (int)responce.StatusCode;
			return coreGetPlayer;
		}
	}
}
