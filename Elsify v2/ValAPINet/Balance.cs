using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000008 RID: 8
	public class Balance
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002550 File Offset: 0x00000750
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002558 File Offset: 0x00000758
		public int ValorantPoints { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002561 File Offset: 0x00000761
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002569 File Offset: 0x00000769
		public int RadianitePoints { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002572 File Offset: 0x00000772
		// (set) Token: 0x06000029 RID: 41 RVA: 0x0000257A File Offset: 0x0000077A
		public int FreeAgents { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002583 File Offset: 0x00000783
		// (set) Token: 0x0600002B RID: 43 RVA: 0x0000258B File Offset: 0x0000078B
		public int StatusCode { get; set; }

		// Token: 0x0600002C RID: 44 RVA: 0x00002594 File Offset: 0x00000794
		[NullableContext(1)]
		public static Balance GetBalance(Auth au)
		{
			Balance balance = new Balance();
			RestClient restClient = new RestClient("https://pd." + au.region.ToString() + ".a.pvp.net/store/v1/wallet/" + au.subject);
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			JObject obj = JObject.FromObject(JsonConvert.DeserializeObject(responce.Content));
			balance.ValorantPoints = obj["Balances"].Value<int>("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741");
			balance.RadianitePoints = obj["Balances"].Value<int>("e59aa87c-4cbf-517a-5983-6e81511be9b7");
			balance.FreeAgents = obj["Balances"].Value<int>("f08d4ae3-939c-4576-ab26-09ce1f23bb37");
			balance.StatusCode = (int)responce.StatusCode;
			return balance;
		}
	}
}
