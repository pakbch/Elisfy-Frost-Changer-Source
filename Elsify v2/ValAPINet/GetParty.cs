using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000010 RID: 16
	[NullableContext(1)]
	[Nullable(0)]
	public class GetParty
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00002F77 File Offset: 0x00001177
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00002F7F File Offset: 0x0000117F
		public string Subject { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00002F88 File Offset: 0x00001188
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00002F90 File Offset: 0x00001190
		public long Version { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00002F99 File Offset: 0x00001199
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00002FA1 File Offset: 0x000011A1
		public string CurrentPartyID { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00002FAA File Offset: 0x000011AA
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00002FB2 File Offset: 0x000011B2
		public object Invites { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00002FBB File Offset: 0x000011BB
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00002FC3 File Offset: 0x000011C3
		public List<object> Requests { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00002FCC File Offset: 0x000011CC
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00002FD4 File Offset: 0x000011D4
		public GetParty.PlatformInfoobj PlatformInfo { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00002FDD File Offset: 0x000011DD
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00002FE5 File Offset: 0x000011E5
		public int StatusCode { get; set; }

		// Token: 0x0600009C RID: 156 RVA: 0x00002FF0 File Offset: 0x000011F0
		public static GetParty Party(Auth au)
		{
			new GetParty();
			RestClient restClient = new RestClient(string.Concat(new string[]
			{
				"https://glz-",
				au.region.ToString(),
				"-1.",
				au.region.ToString(),
				".a.pvp.net/parties/v1/players/",
				au.subject
			}));
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", au.version ?? "");
			IRestResponse responce = restClient.Execute(request);
			GetParty getParty = JsonConvert.DeserializeObject<GetParty>(responce.Content);
			getParty.StatusCode = (int)responce.StatusCode;
			return getParty;
		}

		// Token: 0x0200005D RID: 93
		[Nullable(0)]
		public class PlatformInfoobj
		{
			// Token: 0x17000149 RID: 329
			// (get) Token: 0x06000398 RID: 920 RVA: 0x0000B513 File Offset: 0x00009713
			// (set) Token: 0x06000399 RID: 921 RVA: 0x0000B51B File Offset: 0x0000971B
			public string platformType { get; set; }

			// Token: 0x1700014A RID: 330
			// (get) Token: 0x0600039A RID: 922 RVA: 0x0000B524 File Offset: 0x00009724
			// (set) Token: 0x0600039B RID: 923 RVA: 0x0000B52C File Offset: 0x0000972C
			public string platformOS { get; set; }

			// Token: 0x1700014B RID: 331
			// (get) Token: 0x0600039C RID: 924 RVA: 0x0000B535 File Offset: 0x00009735
			// (set) Token: 0x0600039D RID: 925 RVA: 0x0000B53D File Offset: 0x0000973D
			public string platformOSVersion { get; set; }

			// Token: 0x1700014C RID: 332
			// (get) Token: 0x0600039E RID: 926 RVA: 0x0000B546 File Offset: 0x00009746
			// (set) Token: 0x0600039F RID: 927 RVA: 0x0000B54E File Offset: 0x0000974E
			public string platformChipset { get; set; }
		}
	}
}
