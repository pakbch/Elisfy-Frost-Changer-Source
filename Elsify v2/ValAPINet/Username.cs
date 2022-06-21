using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200001E RID: 30
	[NullableContext(1)]
	[Nullable(0)]
	public class Username
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00004AEE File Offset: 0x00002CEE
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00004AF6 File Offset: 0x00002CF6
		public string DisplayName { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00004AFF File Offset: 0x00002CFF
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00004B07 File Offset: 0x00002D07
		public string Subject { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00004B10 File Offset: 0x00002D10
		// (set) Token: 0x06000187 RID: 391 RVA: 0x00004B18 File Offset: 0x00002D18
		public string GameName { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00004B21 File Offset: 0x00002D21
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00004B29 File Offset: 0x00002D29
		public string TagLine { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00004B32 File Offset: 0x00002D32
		// (set) Token: 0x0600018B RID: 395 RVA: 0x00004B3A File Offset: 0x00002D3A
		public int StatusCode { get; set; }

		// Token: 0x0600018C RID: 396 RVA: 0x00004B44 File Offset: 0x00002D44
		public static Username GetUsername(Auth au, string playerid = null)
		{
			new Username();
			if (playerid == null)
			{
				playerid = au.subject;
			}
			RestClient restClient = new RestClient("https://pd." + au.region.ToString() + ".a.pvp.net/name-service/v2/players");
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.PUT);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			request.AddJsonBody(new List<string>
			{
				playerid
			});
			return JsonConvert.DeserializeObject<List<Username>>(restClient.Execute(request).Content)[0];
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00004C28 File Offset: 0x00002E28
		public static List<Username> GetUsername(Auth au, List<string> playerids)
		{
			RestClient restClient = new RestClient("https://pd." + au.region.ToString() + ".a.pvp.net/name-service/v2/players");
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.PUT);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			request.AddJsonBody(playerids);
			IRestResponse responce = restClient.Execute(request);
			List<Username> list = JsonConvert.DeserializeObject<List<Username>>(responce.Content);
			list[0].StatusCode = (int)responce.StatusCode;
			return list;
		}
	}
}
