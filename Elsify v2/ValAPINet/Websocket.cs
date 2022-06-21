using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200001F RID: 31
	[NullableContext(1)]
	[Nullable(0)]
	public class Websocket
	{
		// Token: 0x0600018F RID: 399 RVA: 0x00004D04 File Offset: 0x00002F04
		public static Auth GetAuthLocal(bool WaitForLockfile = true)
		{
			string lockfile = "";
			if (WaitForLockfile)
			{
				while (lockfile == "")
				{
					try
					{
						using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Riot Games\\Riot Client\\Config\\lockfile", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
						{
							using (StreamReader sr = new StreamReader(fs, Encoding.Default))
							{
								lockfile = sr.ReadToEnd();
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			else
			{
				try
				{
					using (FileStream fs2 = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Riot Games\\Riot Client\\Config\\lockfile", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						using (StreamReader sr2 = new StreamReader(fs2, Encoding.Default))
						{
							lockfile = sr2.ReadToEnd();
						}
					}
				}
				catch (Exception)
				{
					return null;
				}
			}
			RestClient restClient = new RestClient("https://valorant-api.com/v1/version");
			RestRequest versionrequest = new RestRequest(Method.GET);
			JToken versiondata = JObject.FromObject(JObject.FromObject(JsonConvert.DeserializeObject(restClient.Execute(versionrequest).Content))["data"]);
			string versionformat = string.Concat(new string[]
			{
				versiondata["branch"].Value<string>(),
				"-shipping-",
				versiondata["buildVersion"].Value<string>(),
				"-",
				versiondata["version"].Value<string>().Substring(versiondata["version"].Value<string>().Length - 6)
			});
			string[] lf = lockfile.Split(":", StringSplitOptions.None);
			RestClient restClient2 = new RestClient(new Uri("https://127.0.0.1:" + lf[2] + "/entitlements/v1/token"));
			restClient2.RemoteCertificateValidationCallback = (([Nullable(1)] object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
			RestRequest GetRequest = new RestRequest(Method.GET);
			GetRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("riot:" + lf[3])));
			GetRequest.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			GetRequest.AddHeader("X-Riot-ClientVersion", "release-02.06-shipping-14-540727");
			IRestResponse getResp = restClient2.Get(GetRequest);
			JObject obj = new JObject();
			if (getResp.IsSuccessful)
			{
				obj = JObject.Parse(getResp.Content);
				Auth au = new Auth();
				au.AccessToken = (string)obj["accessToken"];
				au.EntitlementToken = (string)obj["token"];
				au.subject = (string)obj["subject"];
				au.version = versionformat;
				au.cookies = new CookieContainer();
				RestClient restClient3 = new RestClient(new Uri("https://127.0.0.1:" + lf[2] + "/player-affinity/product/v1/token"));
				((IRestClient)restClient3).RemoteCertificateValidationCallback = (([Nullable(1)] object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
				IRestRequest RegRequest = new RestRequest(Method.POST);
				RegRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("riot:" + lf[3])));
				var valorantData = new
				{
					product = "valorant"
				};
				RegRequest.AddJsonBody(JsonConvert.SerializeObject(valorantData));
				JObject.Parse(restClient3.Post(RegRequest).Content);
				string reg = "eu";
				try
				{
					reg = Websocket.GetRegion();
				}
				catch (Exception)
				{
					MessageBox.Show("Unable to fetch region. Please retry in a few minutes", "Elsify");
					Environment.Exit(0);
				}
				if (reg.ToLower() == "na")
				{
					au.region = Region.NA;
				}
				else if (reg.ToLower() == "ap")
				{
					au.region = Region.AP;
				}
				else if (reg.ToLower() == "eu")
				{
					au.region = Region.EU;
				}
				else if (reg.ToLower() == "ko")
				{
					au.region = Region.KO;
				}
				return au;
			}
			return null;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00005160 File Offset: 0x00003360
		public static Auth StartAndGetAuthLocal()
		{
			new Process
			{
				StartInfo = 
				{
					FileName = "C:\\Riot Games\\Riot Client\\RiotClientServices.exe",
					Arguments = "--launch-product=valorant --launch-patchline=live"
				}
			}.Start();
			return Websocket.GetAuthLocal(true);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00005194 File Offset: 0x00003394
		public static string GetRegion()
		{
			string result;
			using (StreamReader sr = new StreamReader(File.Open(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\VALORANT\\Saved\\Logs\\ShooterGame.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
			{
				string currentLine;
				do
				{
					currentLine = sr.ReadLine();
				}
				while (!currentLine.Contains("[GET https://shared."));
				string tmp2 = currentLine.Substring(currentLine.IndexOf("[GET https://shared.")).Remove(0, "[GET https://shared.".Length);
				result = tmp2.Substring(0, tmp2.IndexOf('.'));
			}
			return result;
		}
	}
}
