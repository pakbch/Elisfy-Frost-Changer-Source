using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using ValAPINet;

namespace Woe.Skin_Changer
{
	// Token: 0x02000022 RID: 34
	[NullableContext(1)]
	[Nullable(0)]
	public static class RiotClient
	{
		// Token: 0x0600019F RID: 415 RVA: 0x0000569C File Offset: 0x0000389C
		public static RiotClient.Root GetPlayerLoadout(Auth au)
		{
			RiotClient.Root result;
			using (WebClient wc = new WebClient())
			{
				wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + au.AccessToken);
				wc.Headers.Add("X-Riot-Entitlements-JWT", au.EntitlementToken);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 2);
				defaultInterpolatedStringHandler.AppendLiteral("https://pd.");
				defaultInterpolatedStringHandler.AppendFormatted<Region>(au.region);
				defaultInterpolatedStringHandler.AppendLiteral(".a.pvp.net/personalization/v2/players/");
				defaultInterpolatedStringHandler.AppendFormatted(au.subject);
				defaultInterpolatedStringHandler.AppendLiteral("/playerloadout");
				string url = defaultInterpolatedStringHandler.ToStringAndClear();
				result = JsonConvert.DeserializeObject<RiotClient.Root>(wc.DownloadString(url));
			}
			return result;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000575C File Offset: 0x0000395C
		public static RiotClient.Root GetPlayerLoadout(string id, Auth au)
		{
			RiotClient.Root result;
			using (WebClient wc = new WebClient())
			{
				wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + au.AccessToken);
				wc.Headers.Add("X-Riot-Entitlements-JWT", au.EntitlementToken);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 2);
				defaultInterpolatedStringHandler.AppendLiteral("https://pd.");
				defaultInterpolatedStringHandler.AppendFormatted<Region>(au.region);
				defaultInterpolatedStringHandler.AppendLiteral(".a.pvp.net/personalization/v2/players/");
				defaultInterpolatedStringHandler.AppendFormatted(id);
				defaultInterpolatedStringHandler.AppendLiteral("/playerloadout");
				string url = defaultInterpolatedStringHandler.ToStringAndClear();
				result = JsonConvert.DeserializeObject<RiotClient.Root>(wc.DownloadString(url));
			}
			return result;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00005818 File Offset: 0x00003A18
		public static bool SetPlayerLoadout(RiotClient.Root loadout, Auth au)
		{
			bool result;
			try
			{
				using (WebClient wc = new WebClient())
				{
					wc.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + au.AccessToken);
					wc.Headers.Add("X-Riot-Entitlements-JWT", au.EntitlementToken);
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 2);
					defaultInterpolatedStringHandler.AppendLiteral("https://pd.");
					defaultInterpolatedStringHandler.AppendFormatted<Region>(au.region);
					defaultInterpolatedStringHandler.AppendLiteral(".a.pvp.net/personalization/v2/players/");
					defaultInterpolatedStringHandler.AppendFormatted(au.subject);
					defaultInterpolatedStringHandler.AppendLiteral("/playerloadout");
					string url = defaultInterpolatedStringHandler.ToStringAndClear();
					wc.UploadString(url, "PUT", JsonConvert.SerializeObject(loadout));
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0200009E RID: 158
		[Nullable(0)]
		public class Gun
		{
			// Token: 0x17000287 RID: 647
			// (get) Token: 0x0600065A RID: 1626 RVA: 0x0000CC55 File Offset: 0x0000AE55
			// (set) Token: 0x0600065B RID: 1627 RVA: 0x0000CC5D File Offset: 0x0000AE5D
			public string ID { get; set; }

			// Token: 0x17000288 RID: 648
			// (get) Token: 0x0600065C RID: 1628 RVA: 0x0000CC66 File Offset: 0x0000AE66
			// (set) Token: 0x0600065D RID: 1629 RVA: 0x0000CC6E File Offset: 0x0000AE6E
			public string SkinID { get; set; }

			// Token: 0x17000289 RID: 649
			// (get) Token: 0x0600065E RID: 1630 RVA: 0x0000CC77 File Offset: 0x0000AE77
			// (set) Token: 0x0600065F RID: 1631 RVA: 0x0000CC7F File Offset: 0x0000AE7F
			public string SkinLevelID { get; set; }

			// Token: 0x1700028A RID: 650
			// (get) Token: 0x06000660 RID: 1632 RVA: 0x0000CC88 File Offset: 0x0000AE88
			// (set) Token: 0x06000661 RID: 1633 RVA: 0x0000CC90 File Offset: 0x0000AE90
			public string ChromaID { get; set; }

			// Token: 0x1700028B RID: 651
			// (get) Token: 0x06000662 RID: 1634 RVA: 0x0000CC99 File Offset: 0x0000AE99
			// (set) Token: 0x06000663 RID: 1635 RVA: 0x0000CCA1 File Offset: 0x0000AEA1
			public string CharmInstanceID { get; set; }

			// Token: 0x1700028C RID: 652
			// (get) Token: 0x06000664 RID: 1636 RVA: 0x0000CCAA File Offset: 0x0000AEAA
			// (set) Token: 0x06000665 RID: 1637 RVA: 0x0000CCB2 File Offset: 0x0000AEB2
			public string CharmID { get; set; }

			// Token: 0x1700028D RID: 653
			// (get) Token: 0x06000666 RID: 1638 RVA: 0x0000CCBB File Offset: 0x0000AEBB
			// (set) Token: 0x06000667 RID: 1639 RVA: 0x0000CCC3 File Offset: 0x0000AEC3
			public string CharmLevelID { get; set; }

			// Token: 0x1700028E RID: 654
			// (get) Token: 0x06000668 RID: 1640 RVA: 0x0000CCCC File Offset: 0x0000AECC
			// (set) Token: 0x06000669 RID: 1641 RVA: 0x0000CCD4 File Offset: 0x0000AED4
			public List<object> Attachments { get; set; }
		}

		// Token: 0x0200009F RID: 159
		[Nullable(0)]
		public class Spray
		{
			// Token: 0x1700028F RID: 655
			// (get) Token: 0x0600066B RID: 1643 RVA: 0x0000CCE5 File Offset: 0x0000AEE5
			// (set) Token: 0x0600066C RID: 1644 RVA: 0x0000CCED File Offset: 0x0000AEED
			public string EquipSlotID { get; set; }

			// Token: 0x17000290 RID: 656
			// (get) Token: 0x0600066D RID: 1645 RVA: 0x0000CCF6 File Offset: 0x0000AEF6
			// (set) Token: 0x0600066E RID: 1646 RVA: 0x0000CCFE File Offset: 0x0000AEFE
			public string SprayID { get; set; }

			// Token: 0x17000291 RID: 657
			// (get) Token: 0x0600066F RID: 1647 RVA: 0x0000CD07 File Offset: 0x0000AF07
			// (set) Token: 0x06000670 RID: 1648 RVA: 0x0000CD0F File Offset: 0x0000AF0F
			public object SprayLevelID { get; set; }
		}

		// Token: 0x020000A0 RID: 160
		[Nullable(0)]
		public class Identity
		{
			// Token: 0x17000292 RID: 658
			// (get) Token: 0x06000672 RID: 1650 RVA: 0x0000CD20 File Offset: 0x0000AF20
			// (set) Token: 0x06000673 RID: 1651 RVA: 0x0000CD28 File Offset: 0x0000AF28
			public string PlayerCardID { get; set; }

			// Token: 0x17000293 RID: 659
			// (get) Token: 0x06000674 RID: 1652 RVA: 0x0000CD31 File Offset: 0x0000AF31
			// (set) Token: 0x06000675 RID: 1653 RVA: 0x0000CD39 File Offset: 0x0000AF39
			public string PlayerTitleID { get; set; }

			// Token: 0x17000294 RID: 660
			// (get) Token: 0x06000676 RID: 1654 RVA: 0x0000CD42 File Offset: 0x0000AF42
			// (set) Token: 0x06000677 RID: 1655 RVA: 0x0000CD4A File Offset: 0x0000AF4A
			public int AccountLevel { get; set; }

			// Token: 0x17000295 RID: 661
			// (get) Token: 0x06000678 RID: 1656 RVA: 0x0000CD53 File Offset: 0x0000AF53
			// (set) Token: 0x06000679 RID: 1657 RVA: 0x0000CD5B File Offset: 0x0000AF5B
			public string PreferredLevelBorderID { get; set; }

			// Token: 0x17000296 RID: 662
			// (get) Token: 0x0600067A RID: 1658 RVA: 0x0000CD64 File Offset: 0x0000AF64
			// (set) Token: 0x0600067B RID: 1659 RVA: 0x0000CD6C File Offset: 0x0000AF6C
			public bool HideAccountLevel { get; set; }
		}

		// Token: 0x020000A1 RID: 161
		[Nullable(0)]
		public class Root
		{
			// Token: 0x17000297 RID: 663
			// (get) Token: 0x0600067D RID: 1661 RVA: 0x0000CD7D File Offset: 0x0000AF7D
			// (set) Token: 0x0600067E RID: 1662 RVA: 0x0000CD85 File Offset: 0x0000AF85
			public string Subject { get; set; }

			// Token: 0x17000298 RID: 664
			// (get) Token: 0x0600067F RID: 1663 RVA: 0x0000CD8E File Offset: 0x0000AF8E
			// (set) Token: 0x06000680 RID: 1664 RVA: 0x0000CD96 File Offset: 0x0000AF96
			public int Version { get; set; }

			// Token: 0x17000299 RID: 665
			// (get) Token: 0x06000681 RID: 1665 RVA: 0x0000CD9F File Offset: 0x0000AF9F
			// (set) Token: 0x06000682 RID: 1666 RVA: 0x0000CDA7 File Offset: 0x0000AFA7
			public List<RiotClient.Gun> Guns { get; set; }

			// Token: 0x1700029A RID: 666
			// (get) Token: 0x06000683 RID: 1667 RVA: 0x0000CDB0 File Offset: 0x0000AFB0
			// (set) Token: 0x06000684 RID: 1668 RVA: 0x0000CDB8 File Offset: 0x0000AFB8
			public List<RiotClient.Spray> Sprays { get; set; }

			// Token: 0x1700029B RID: 667
			// (get) Token: 0x06000685 RID: 1669 RVA: 0x0000CDC1 File Offset: 0x0000AFC1
			// (set) Token: 0x06000686 RID: 1670 RVA: 0x0000CDC9 File Offset: 0x0000AFC9
			public RiotClient.Identity Identity { get; set; }

			// Token: 0x1700029C RID: 668
			// (get) Token: 0x06000687 RID: 1671 RVA: 0x0000CDD2 File Offset: 0x0000AFD2
			// (set) Token: 0x06000688 RID: 1672 RVA: 0x0000CDDA File Offset: 0x0000AFDA
			public bool Incognito { get; set; }
		}
	}
}
