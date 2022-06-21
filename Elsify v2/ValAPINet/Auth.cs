using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x02000007 RID: 7
	[NullableContext(1)]
	[Nullable(0)]
	public class Auth
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002292 File Offset: 0x00000492
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000229A File Offset: 0x0000049A
		public string EntitlementToken { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000022A3 File Offset: 0x000004A3
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000022AB File Offset: 0x000004AB
		public string AccessToken { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000022B4 File Offset: 0x000004B4
		// (set) Token: 0x0600001F RID: 31 RVA: 0x000022BC File Offset: 0x000004BC
		public string subject { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000022C5 File Offset: 0x000004C5
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000022CD File Offset: 0x000004CD
		public CookieContainer cookies { get; set; }

		// Token: 0x06000022 RID: 34 RVA: 0x000022D8 File Offset: 0x000004D8
		public static Auth Login(string username, string password, Region reg)
		{
			Auth au = new Auth();
			au.region = reg;
			au.cookies = new CookieContainer();
			RestClient restClient = new RestClient("https://auth.riotgames.com/api/v1/authorization");
			restClient.CookieContainer = au.cookies;
			RestRequest request = new RestRequest(Method.POST);
			string body = "{\"client_id\":\"play-valorant-web-prod\",\"nonce\":\"1\",\"redirect_uri\":\"https://playvalorant.com/opt_in\",\"response_type\":\"token id_token\",\"scope\":\"account openid\"}";
			request.AddJsonBody(body);
			restClient.Execute(request);
			RestClient authclient = new RestClient("https://auth.riotgames.com/api/v1/authorization");
			authclient.CookieContainer = au.cookies;
			RestRequest authrequest = new RestRequest(Method.PUT);
			string authbody = string.Concat(new string[]
			{
				"{\"type\":\"auth\",\"username\":\"",
				username,
				"\",\"password\":\"",
				password,
				"\"}"
			});
			authrequest.AddJsonBody(authbody);
			string content = authclient.Execute(authrequest).Content;
			JToken authObj = JObject.FromObject(JsonConvert.DeserializeObject(content));
			if (content.Contains("auth_failure"))
			{
				return new Auth();
			}
			string AccessToken = Regex.Match(authObj["response"]["parameters"]["uri"].Value<string>(), "access_token=(.+?)&scope=").Groups[1].Value ?? "";
			RestClient restClient2 = new RestClient(new Uri("https://entitlements.auth.riotgames.com/api/token/v1"));
			RestRequest entitlementrequest = new RestRequest(Method.POST);
			entitlementrequest.AddHeader("Authorization", "Bearer " + AccessToken);
			entitlementrequest.AddJsonBody("{}");
			restClient2.CookieContainer = au.cookies;
			string EntitlementToken = JObject.FromObject(JsonConvert.DeserializeObject(restClient2.Execute(entitlementrequest).Content))["entitlements_token"].Value<string>();
			au.AccessToken = AccessToken;
			au.EntitlementToken = EntitlementToken;
			JsonWebToken jsonWebToken = new JsonWebToken(AccessToken);
			au.subject = jsonWebToken.Subject;
			RestClient restClient3 = new RestClient("https://valorant-api.com/v1/version");
			RestRequest versionrequest = new RestRequest(Method.GET);
			JToken versiondata = JObject.FromObject(JObject.FromObject(JsonConvert.DeserializeObject(restClient3.Execute(versionrequest).Content))["data"]);
			string versionformat = string.Concat(new string[]
			{
				versiondata["branch"].Value<string>(),
				"-shipping-",
				versiondata["buildVersion"].Value<string>(),
				"-",
				versiondata["version"].Value<string>().Substring(versiondata["version"].Value<string>().Length - 6)
			});
			au.version = versionformat;
			return au;
		}

		// Token: 0x0400000F RID: 15
		public string version;

		// Token: 0x04000010 RID: 16
		public Region region;
	}
}
