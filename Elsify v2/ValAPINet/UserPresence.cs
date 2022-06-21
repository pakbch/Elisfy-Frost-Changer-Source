using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200001B RID: 27
	[NullableContext(1)]
	[Nullable(0)]
	public class UserPresence
	{
		// Token: 0x06000172 RID: 370 RVA: 0x000043AC File Offset: 0x000025AC
		public static UserPresence GetPresence()
		{
			string lockfile = "";
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
				return null;
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
			RestClient restClient2 = new RestClient(new Uri("https://127.0.0.1:" + lf[2] + "/chat/v4/presences"));
			restClient2.RemoteCertificateValidationCallback = (([Nullable(1)] object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
			RestRequest GetRequest = new RestRequest(Method.GET);
			GetRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("riot:" + lf[3])));
			GetRequest.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			GetRequest.AddHeader("X-Riot-ClientVersion", versionformat);
			IRestResponse getResp = restClient2.Get(GetRequest);
			new JObject();
			if (getResp.IsSuccessful)
			{
				JObject.Parse(getResp.Content);
				UserPresence au = JsonConvert.DeserializeObject<UserPresence>(getResp.Content);
				au.presences[0].privinfo = JsonConvert.DeserializeObject<UserPresence.priv>(Encoding.UTF8.GetString(Convert.FromBase64String(au.presences[0].@private)));
				return au;
			}
			return null;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00004608 File Offset: 0x00002808
		public static UserPresence.Presence GetPresence(string id)
		{
			string lockfile = "";
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
				return null;
			}
			string[] lf = lockfile.Split(':', StringSplitOptions.None);
			RestClient restClient = new RestClient(new Uri("https://127.0.0.1:" + lf[2] + "/chat/v4/presences"));
			restClient.RemoteCertificateValidationCallback = (([Nullable(1)] object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
			RestRequest GetRequest = new RestRequest(Method.GET);
			GetRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("riot:" + lf[3])));
			IRestResponse getResp = restClient.Get(GetRequest);
			new JObject();
			if (!getResp.IsSuccessful)
			{
				return null;
			}
			JObject.Parse(getResp.Content);
			UserPresence userPresence = JsonConvert.DeserializeObject<UserPresence>(getResp.Content);
			UserPresence.Presence ret = null;
			foreach (UserPresence.Presence pres in userPresence.presences)
			{
				if (pres.puuid == id)
				{
					ret = pres;
				}
			}
			if (ret == null)
			{
				return null;
			}
			ret.privinfo = JsonConvert.DeserializeObject<UserPresence.priv>(Encoding.UTF8.GetString(Convert.FromBase64String(ret.@private)));
			return ret;
		}

		// Token: 0x040000BB RID: 187
		public List<UserPresence.Presence> presences;

		// Token: 0x0200008D RID: 141
		[Nullable(0)]
		public class Presence
		{
			// Token: 0x17000230 RID: 560
			// (get) Token: 0x06000596 RID: 1430 RVA: 0x0000C5EA File Offset: 0x0000A7EA
			// (set) Token: 0x06000597 RID: 1431 RVA: 0x0000C5F2 File Offset: 0x0000A7F2
			public string actor { get; set; }

			// Token: 0x17000231 RID: 561
			// (get) Token: 0x06000598 RID: 1432 RVA: 0x0000C5FB File Offset: 0x0000A7FB
			// (set) Token: 0x06000599 RID: 1433 RVA: 0x0000C603 File Offset: 0x0000A803
			public string basic { get; set; }

			// Token: 0x17000232 RID: 562
			// (get) Token: 0x0600059A RID: 1434 RVA: 0x0000C60C File Offset: 0x0000A80C
			// (set) Token: 0x0600059B RID: 1435 RVA: 0x0000C614 File Offset: 0x0000A814
			public string details { get; set; }

			// Token: 0x17000233 RID: 563
			// (get) Token: 0x0600059C RID: 1436 RVA: 0x0000C61D File Offset: 0x0000A81D
			// (set) Token: 0x0600059D RID: 1437 RVA: 0x0000C625 File Offset: 0x0000A825
			public string game_name { get; set; }

			// Token: 0x17000234 RID: 564
			// (get) Token: 0x0600059E RID: 1438 RVA: 0x0000C62E File Offset: 0x0000A82E
			// (set) Token: 0x0600059F RID: 1439 RVA: 0x0000C636 File Offset: 0x0000A836
			public string game_tag { get; set; }

			// Token: 0x17000235 RID: 565
			// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0000C63F File Offset: 0x0000A83F
			// (set) Token: 0x060005A1 RID: 1441 RVA: 0x0000C647 File Offset: 0x0000A847
			public string location { get; set; }

			// Token: 0x17000236 RID: 566
			// (get) Token: 0x060005A2 RID: 1442 RVA: 0x0000C650 File Offset: 0x0000A850
			// (set) Token: 0x060005A3 RID: 1443 RVA: 0x0000C658 File Offset: 0x0000A858
			public string msg { get; set; }

			// Token: 0x17000237 RID: 567
			// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0000C661 File Offset: 0x0000A861
			// (set) Token: 0x060005A5 RID: 1445 RVA: 0x0000C669 File Offset: 0x0000A869
			public string name { get; set; }

			// Token: 0x17000238 RID: 568
			// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0000C672 File Offset: 0x0000A872
			// (set) Token: 0x060005A7 RID: 1447 RVA: 0x0000C67A File Offset: 0x0000A87A
			public object patchline { get; set; }

			// Token: 0x17000239 RID: 569
			// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0000C683 File Offset: 0x0000A883
			// (set) Token: 0x060005A9 RID: 1449 RVA: 0x0000C68B File Offset: 0x0000A88B
			public string pid { get; set; }

			// Token: 0x1700023A RID: 570
			// (get) Token: 0x060005AA RID: 1450 RVA: 0x0000C694 File Offset: 0x0000A894
			// (set) Token: 0x060005AB RID: 1451 RVA: 0x0000C69C File Offset: 0x0000A89C
			public object platform { get; set; }

			// Token: 0x1700023B RID: 571
			// (get) Token: 0x060005AC RID: 1452 RVA: 0x0000C6A5 File Offset: 0x0000A8A5
			// (set) Token: 0x060005AD RID: 1453 RVA: 0x0000C6AD File Offset: 0x0000A8AD
			public string @private { get; set; }

			// Token: 0x1700023C RID: 572
			// (get) Token: 0x060005AE RID: 1454 RVA: 0x0000C6B6 File Offset: 0x0000A8B6
			// (set) Token: 0x060005AF RID: 1455 RVA: 0x0000C6BE File Offset: 0x0000A8BE
			public object privateJwt { get; set; }

			// Token: 0x1700023D RID: 573
			// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0000C6C7 File Offset: 0x0000A8C7
			// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0000C6CF File Offset: 0x0000A8CF
			public string product { get; set; }

			// Token: 0x1700023E RID: 574
			// (get) Token: 0x060005B2 RID: 1458 RVA: 0x0000C6D8 File Offset: 0x0000A8D8
			// (set) Token: 0x060005B3 RID: 1459 RVA: 0x0000C6E0 File Offset: 0x0000A8E0
			public string puuid { get; set; }

			// Token: 0x1700023F RID: 575
			// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0000C6E9 File Offset: 0x0000A8E9
			// (set) Token: 0x060005B5 RID: 1461 RVA: 0x0000C6F1 File Offset: 0x0000A8F1
			public string region { get; set; }

			// Token: 0x17000240 RID: 576
			// (get) Token: 0x060005B6 RID: 1462 RVA: 0x0000C6FA File Offset: 0x0000A8FA
			// (set) Token: 0x060005B7 RID: 1463 RVA: 0x0000C702 File Offset: 0x0000A902
			public string resource { get; set; }

			// Token: 0x17000241 RID: 577
			// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0000C70B File Offset: 0x0000A90B
			// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0000C713 File Offset: 0x0000A913
			public string state { get; set; }

			// Token: 0x17000242 RID: 578
			// (get) Token: 0x060005BA RID: 1466 RVA: 0x0000C71C File Offset: 0x0000A91C
			// (set) Token: 0x060005BB RID: 1467 RVA: 0x0000C724 File Offset: 0x0000A924
			public string summary { get; set; }

			// Token: 0x17000243 RID: 579
			// (get) Token: 0x060005BC RID: 1468 RVA: 0x0000C72D File Offset: 0x0000A92D
			// (set) Token: 0x060005BD RID: 1469 RVA: 0x0000C735 File Offset: 0x0000A935
			public object time { get; set; }

			// Token: 0x17000244 RID: 580
			// (get) Token: 0x060005BE RID: 1470 RVA: 0x0000C73E File Offset: 0x0000A93E
			// (set) Token: 0x060005BF RID: 1471 RVA: 0x0000C746 File Offset: 0x0000A946
			public UserPresence.priv privinfo { get; set; }
		}

		// Token: 0x0200008E RID: 142
		[Nullable(0)]
		public class priv
		{
			// Token: 0x17000245 RID: 581
			// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0000C757 File Offset: 0x0000A957
			// (set) Token: 0x060005C2 RID: 1474 RVA: 0x0000C75F File Offset: 0x0000A95F
			public bool isValid { get; set; }

			// Token: 0x17000246 RID: 582
			// (get) Token: 0x060005C3 RID: 1475 RVA: 0x0000C768 File Offset: 0x0000A968
			// (set) Token: 0x060005C4 RID: 1476 RVA: 0x0000C770 File Offset: 0x0000A970
			public string sessionLoopState { get; set; }

			// Token: 0x17000247 RID: 583
			// (get) Token: 0x060005C5 RID: 1477 RVA: 0x0000C779 File Offset: 0x0000A979
			// (set) Token: 0x060005C6 RID: 1478 RVA: 0x0000C781 File Offset: 0x0000A981
			public string partyOwnerSessionLoopState { get; set; }

			// Token: 0x17000248 RID: 584
			// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0000C78A File Offset: 0x0000A98A
			// (set) Token: 0x060005C8 RID: 1480 RVA: 0x0000C792 File Offset: 0x0000A992
			public string customGameName { get; set; }

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000C79B File Offset: 0x0000A99B
			// (set) Token: 0x060005CA RID: 1482 RVA: 0x0000C7A3 File Offset: 0x0000A9A3
			public string customGameTeam { get; set; }

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x060005CB RID: 1483 RVA: 0x0000C7AC File Offset: 0x0000A9AC
			// (set) Token: 0x060005CC RID: 1484 RVA: 0x0000C7B4 File Offset: 0x0000A9B4
			public string partyOwnerMatchMap { get; set; }

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000C7BD File Offset: 0x0000A9BD
			// (set) Token: 0x060005CE RID: 1486 RVA: 0x0000C7C5 File Offset: 0x0000A9C5
			public string partyOwnerMatchCurrentTeam { get; set; }

			// Token: 0x1700024C RID: 588
			// (get) Token: 0x060005CF RID: 1487 RVA: 0x0000C7CE File Offset: 0x0000A9CE
			// (set) Token: 0x060005D0 RID: 1488 RVA: 0x0000C7D6 File Offset: 0x0000A9D6
			public int partyOwnerMatchScoreAllyTeam { get; set; }

			// Token: 0x1700024D RID: 589
			// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0000C7DF File Offset: 0x0000A9DF
			// (set) Token: 0x060005D2 RID: 1490 RVA: 0x0000C7E7 File Offset: 0x0000A9E7
			public int partyOwnerMatchScoreEnemyTeam { get; set; }

			// Token: 0x1700024E RID: 590
			// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0000C7F0 File Offset: 0x0000A9F0
			// (set) Token: 0x060005D4 RID: 1492 RVA: 0x0000C7F8 File Offset: 0x0000A9F8
			public string partyOwnerProvisioningFlow { get; set; }

			// Token: 0x1700024F RID: 591
			// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0000C801 File Offset: 0x0000AA01
			// (set) Token: 0x060005D6 RID: 1494 RVA: 0x0000C809 File Offset: 0x0000AA09
			public string provisioningFlow { get; set; }

			// Token: 0x17000250 RID: 592
			// (get) Token: 0x060005D7 RID: 1495 RVA: 0x0000C812 File Offset: 0x0000AA12
			// (set) Token: 0x060005D8 RID: 1496 RVA: 0x0000C81A File Offset: 0x0000AA1A
			public string matchMap { get; set; }

			// Token: 0x17000251 RID: 593
			// (get) Token: 0x060005D9 RID: 1497 RVA: 0x0000C823 File Offset: 0x0000AA23
			// (set) Token: 0x060005DA RID: 1498 RVA: 0x0000C82B File Offset: 0x0000AA2B
			public string partyId { get; set; }

			// Token: 0x17000252 RID: 594
			// (get) Token: 0x060005DB RID: 1499 RVA: 0x0000C834 File Offset: 0x0000AA34
			// (set) Token: 0x060005DC RID: 1500 RVA: 0x0000C83C File Offset: 0x0000AA3C
			public bool isPartyOwner { get; set; }

			// Token: 0x17000253 RID: 595
			// (get) Token: 0x060005DD RID: 1501 RVA: 0x0000C845 File Offset: 0x0000AA45
			// (set) Token: 0x060005DE RID: 1502 RVA: 0x0000C84D File Offset: 0x0000AA4D
			public string partyName { get; set; }

			// Token: 0x17000254 RID: 596
			// (get) Token: 0x060005DF RID: 1503 RVA: 0x0000C856 File Offset: 0x0000AA56
			// (set) Token: 0x060005E0 RID: 1504 RVA: 0x0000C85E File Offset: 0x0000AA5E
			public string partyState { get; set; }

			// Token: 0x17000255 RID: 597
			// (get) Token: 0x060005E1 RID: 1505 RVA: 0x0000C867 File Offset: 0x0000AA67
			// (set) Token: 0x060005E2 RID: 1506 RVA: 0x0000C86F File Offset: 0x0000AA6F
			public string partyAccessibility { get; set; }

			// Token: 0x17000256 RID: 598
			// (get) Token: 0x060005E3 RID: 1507 RVA: 0x0000C878 File Offset: 0x0000AA78
			// (set) Token: 0x060005E4 RID: 1508 RVA: 0x0000C880 File Offset: 0x0000AA80
			public int maxPartySize { get; set; }

			// Token: 0x17000257 RID: 599
			// (get) Token: 0x060005E5 RID: 1509 RVA: 0x0000C889 File Offset: 0x0000AA89
			// (set) Token: 0x060005E6 RID: 1510 RVA: 0x0000C891 File Offset: 0x0000AA91
			public string queueId { get; set; }

			// Token: 0x17000258 RID: 600
			// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0000C89A File Offset: 0x0000AA9A
			// (set) Token: 0x060005E8 RID: 1512 RVA: 0x0000C8A2 File Offset: 0x0000AAA2
			public bool partyLFM { get; set; }

			// Token: 0x17000259 RID: 601
			// (get) Token: 0x060005E9 RID: 1513 RVA: 0x0000C8AB File Offset: 0x0000AAAB
			// (set) Token: 0x060005EA RID: 1514 RVA: 0x0000C8B3 File Offset: 0x0000AAB3
			public string partyClientVersion { get; set; }

			// Token: 0x1700025A RID: 602
			// (get) Token: 0x060005EB RID: 1515 RVA: 0x0000C8BC File Offset: 0x0000AABC
			// (set) Token: 0x060005EC RID: 1516 RVA: 0x0000C8C4 File Offset: 0x0000AAC4
			public int partySize { get; set; }

			// Token: 0x1700025B RID: 603
			// (get) Token: 0x060005ED RID: 1517 RVA: 0x0000C8CD File Offset: 0x0000AACD
			// (set) Token: 0x060005EE RID: 1518 RVA: 0x0000C8D5 File Offset: 0x0000AAD5
			public long partyVersion { get; set; }

			// Token: 0x1700025C RID: 604
			// (get) Token: 0x060005EF RID: 1519 RVA: 0x0000C8DE File Offset: 0x0000AADE
			// (set) Token: 0x060005F0 RID: 1520 RVA: 0x0000C8E6 File Offset: 0x0000AAE6
			public string queueEntryTime { get; set; }

			// Token: 0x1700025D RID: 605
			// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0000C8EF File Offset: 0x0000AAEF
			// (set) Token: 0x060005F2 RID: 1522 RVA: 0x0000C8F7 File Offset: 0x0000AAF7
			public string playerCardId { get; set; }

			// Token: 0x1700025E RID: 606
			// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0000C900 File Offset: 0x0000AB00
			// (set) Token: 0x060005F4 RID: 1524 RVA: 0x0000C908 File Offset: 0x0000AB08
			public string playerTitleId { get; set; }

			// Token: 0x1700025F RID: 607
			// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000C911 File Offset: 0x0000AB11
			// (set) Token: 0x060005F6 RID: 1526 RVA: 0x0000C919 File Offset: 0x0000AB19
			public bool isIdle { get; set; }
		}
	}
}
