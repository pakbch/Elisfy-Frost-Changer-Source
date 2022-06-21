using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;
using ValAPINet;

namespace Woe.ValAPINet
{
	// Token: 0x02000021 RID: 33
	[NullableContext(1)]
	[Nullable(0)]
	public class RichPresence
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0000559C File Offset: 0x0000379C
		// (set) Token: 0x06000198 RID: 408 RVA: 0x000055A4 File Offset: 0x000037A4
		public string subject { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000199 RID: 409 RVA: 0x000055AD File Offset: 0x000037AD
		// (set) Token: 0x0600019A RID: 410 RVA: 0x000055B5 File Offset: 0x000037B5
		public string loopState { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600019B RID: 411 RVA: 0x000055BE File Offset: 0x000037BE
		// (set) Token: 0x0600019C RID: 412 RVA: 0x000055C6 File Offset: 0x000037C6
		public string loopStateMetadata { get; set; }

		// Token: 0x0600019D RID: 413 RVA: 0x000055D0 File Offset: 0x000037D0
		public static RichPresence GetRichPresence(Auth au)
		{
			new RichPresence();
			RestClient restClient = new RestClient(string.Format("https://glz-{0}-1.{1}.a.pvp.net/session/v1/sessions/{2}", au.region, au.region, au.subject));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			return JsonConvert.DeserializeObject<RichPresence>(restClient.Execute(request).Content);
		}
	}
}
