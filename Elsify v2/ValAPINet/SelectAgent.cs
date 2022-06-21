using System;
using System.Runtime.CompilerServices;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200001C RID: 28
	[NullableContext(1)]
	[Nullable(0)]
	public class SelectAgent
	{
		// Token: 0x06000175 RID: 373 RVA: 0x000047D8 File Offset: 0x000029D8
		public static void ChooseAgent(Auth au, string matchid, string agent)
		{
			new SelectAgent();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://glz-",
				au.region.ToString(),
				"-1.",
				au.region.ToString(),
				".a.pvp.net/pregame/v1/matches/",
				matchid,
				"/select/",
				agent
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			string content = restClient.Execute(request).Content;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000048D0 File Offset: 0x00002AD0
		public static void LockAgent(Auth au, string matchid, string agent)
		{
			new SelectAgent();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://glz-",
				au.region.ToString(),
				"-1.",
				au.region.ToString(),
				".a.pvp.net/pregame/v1/matches/",
				matchid,
				"/lock/",
				agent
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.POST);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			string content = restClient.Execute(request).Content;
		}
	}
}
