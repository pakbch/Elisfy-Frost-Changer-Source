using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ValAPINet
{
	// Token: 0x0200000A RID: 10
	[NullableContext(1)]
	[Nullable(0)]
	public class Content
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000282E File Offset: 0x00000A2E
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002836 File Offset: 0x00000A36
		public List<Content.Character> Characters { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003A RID: 58 RVA: 0x0000283F File Offset: 0x00000A3F
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002847 File Offset: 0x00000A47
		public List<Content.Map> Maps { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002850 File Offset: 0x00000A50
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002858 File Offset: 0x00000A58
		public List<Content.Chroma> Chromas { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002861 File Offset: 0x00000A61
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002869 File Offset: 0x00000A69
		public List<Content.Skin> Skins { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002872 File Offset: 0x00000A72
		// (set) Token: 0x06000041 RID: 65 RVA: 0x0000287A File Offset: 0x00000A7A
		public List<Content.SkinLevel> SkinLevels { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002883 File Offset: 0x00000A83
		// (set) Token: 0x06000043 RID: 67 RVA: 0x0000288B File Offset: 0x00000A8B
		public List<Content.Attachment> Attachments { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002894 File Offset: 0x00000A94
		// (set) Token: 0x06000045 RID: 69 RVA: 0x0000289C File Offset: 0x00000A9C
		public List<Content.Equip> Equips { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000028A5 File Offset: 0x00000AA5
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000028AD File Offset: 0x00000AAD
		public List<Content.Theme> Themes { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000028B6 File Offset: 0x00000AB6
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000028BE File Offset: 0x00000ABE
		public List<Content.GameMode> GameModes { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000028C7 File Offset: 0x00000AC7
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000028CF File Offset: 0x00000ACF
		public List<Content.Spray> Sprays { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000028D8 File Offset: 0x00000AD8
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000028E0 File Offset: 0x00000AE0
		public List<Content.SprayLevel> SprayLevels { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000028E9 File Offset: 0x00000AE9
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000028F1 File Offset: 0x00000AF1
		public List<Content.Charm> Charms { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000028FA File Offset: 0x00000AFA
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00002902 File Offset: 0x00000B02
		public List<Content.CharmLevel> CharmLevels { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000052 RID: 82 RVA: 0x0000290B File Offset: 0x00000B0B
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00002913 File Offset: 0x00000B13
		public List<Content.PlayerCard> PlayerCards { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000054 RID: 84 RVA: 0x0000291C File Offset: 0x00000B1C
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002924 File Offset: 0x00000B24
		public List<Content.PlayerTitle> PlayerTitles { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000056 RID: 86 RVA: 0x0000292D File Offset: 0x00000B2D
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002935 File Offset: 0x00000B35
		public List<Content.StorefrontItem> StorefrontItems { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000293E File Offset: 0x00000B3E
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002946 File Offset: 0x00000B46
		public List<Content.Season> Seasons { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000294F File Offset: 0x00000B4F
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002957 File Offset: 0x00000B57
		public List<Content.CompetitiveSeason> CompetitiveSeasons { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002960 File Offset: 0x00000B60
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002968 File Offset: 0x00000B68
		public int StatusCode { get; set; }

		// Token: 0x0600005E RID: 94 RVA: 0x00002974 File Offset: 0x00000B74
		public static Content GetContent(Region re)
		{
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
			new Content();
			RestClient restClient2 = new RestClient("https://shared." + re.ToString() + ".a.pvp.net/content-service/v2/content");
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("X-Riot-ClientPlatform", "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
			request.AddHeader("X-Riot-ClientVersion", versionformat ?? "");
			IRestResponse responce = restClient2.Execute(request);
			Content content = JsonConvert.DeserializeObject<Content>(responce.Content);
			content.StatusCode = (int)responce.StatusCode;
			return content;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002AA0 File Offset: 0x00000CA0
		public static string GetSeason(Region re)
		{
			Content content = Content.GetContent(re);
			string season = "";
			foreach (Content.CompetitiveSeason seasn in content.CompetitiveSeasons)
			{
				if (seasn.StartTime.CompareTo(DateTime.UtcNow) < 0 && seasn.EndTime.CompareTo(DateTime.UtcNow) > 0)
				{
					season = seasn.SeasonID;
					break;
				}
			}
			return season;
		}

		// Token: 0x02000046 RID: 70
		[Nullable(0)]
		public class Character
		{
			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000ADB7 File Offset: 0x00008FB7
			// (set) Token: 0x060002BA RID: 698 RVA: 0x0000ADBF File Offset: 0x00008FBF
			public string Name { get; set; }

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x060002BB RID: 699 RVA: 0x0000ADC8 File Offset: 0x00008FC8
			// (set) Token: 0x060002BC RID: 700 RVA: 0x0000ADD0 File Offset: 0x00008FD0
			public string ID { get; set; }

			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x060002BD RID: 701 RVA: 0x0000ADD9 File Offset: 0x00008FD9
			// (set) Token: 0x060002BE RID: 702 RVA: 0x0000ADE1 File Offset: 0x00008FE1
			public string AssetName { get; set; }

			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x060002BF RID: 703 RVA: 0x0000ADEA File Offset: 0x00008FEA
			// (set) Token: 0x060002C0 RID: 704 RVA: 0x0000ADF2 File Offset: 0x00008FF2
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000047 RID: 71
		[Nullable(0)]
		public class Map
		{
			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x060002C2 RID: 706 RVA: 0x0000AE03 File Offset: 0x00009003
			// (set) Token: 0x060002C3 RID: 707 RVA: 0x0000AE0B File Offset: 0x0000900B
			public string Name { get; set; }

			// Token: 0x170000EA RID: 234
			// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000AE14 File Offset: 0x00009014
			// (set) Token: 0x060002C5 RID: 709 RVA: 0x0000AE1C File Offset: 0x0000901C
			public string ID { get; set; }

			// Token: 0x170000EB RID: 235
			// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000AE25 File Offset: 0x00009025
			// (set) Token: 0x060002C7 RID: 711 RVA: 0x0000AE2D File Offset: 0x0000902D
			public string AssetName { get; set; }

			// Token: 0x170000EC RID: 236
			// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000AE36 File Offset: 0x00009036
			// (set) Token: 0x060002C9 RID: 713 RVA: 0x0000AE3E File Offset: 0x0000903E
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000048 RID: 72
		[Nullable(0)]
		public class Chroma
		{
			// Token: 0x170000ED RID: 237
			// (get) Token: 0x060002CB RID: 715 RVA: 0x0000AE4F File Offset: 0x0000904F
			// (set) Token: 0x060002CC RID: 716 RVA: 0x0000AE57 File Offset: 0x00009057
			public string Name { get; set; }

			// Token: 0x170000EE RID: 238
			// (get) Token: 0x060002CD RID: 717 RVA: 0x0000AE60 File Offset: 0x00009060
			// (set) Token: 0x060002CE RID: 718 RVA: 0x0000AE68 File Offset: 0x00009068
			public string ID { get; set; }

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x060002CF RID: 719 RVA: 0x0000AE71 File Offset: 0x00009071
			// (set) Token: 0x060002D0 RID: 720 RVA: 0x0000AE79 File Offset: 0x00009079
			public string AssetName { get; set; }

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x060002D1 RID: 721 RVA: 0x0000AE82 File Offset: 0x00009082
			// (set) Token: 0x060002D2 RID: 722 RVA: 0x0000AE8A File Offset: 0x0000908A
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000049 RID: 73
		[Nullable(0)]
		public class Skin
		{
			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x060002D4 RID: 724 RVA: 0x0000AE9B File Offset: 0x0000909B
			// (set) Token: 0x060002D5 RID: 725 RVA: 0x0000AEA3 File Offset: 0x000090A3
			public string Name { get; set; }

			// Token: 0x170000F2 RID: 242
			// (get) Token: 0x060002D6 RID: 726 RVA: 0x0000AEAC File Offset: 0x000090AC
			// (set) Token: 0x060002D7 RID: 727 RVA: 0x0000AEB4 File Offset: 0x000090B4
			public string ID { get; set; }

			// Token: 0x170000F3 RID: 243
			// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000AEBD File Offset: 0x000090BD
			// (set) Token: 0x060002D9 RID: 729 RVA: 0x0000AEC5 File Offset: 0x000090C5
			public string AssetName { get; set; }

			// Token: 0x170000F4 RID: 244
			// (get) Token: 0x060002DA RID: 730 RVA: 0x0000AECE File Offset: 0x000090CE
			// (set) Token: 0x060002DB RID: 731 RVA: 0x0000AED6 File Offset: 0x000090D6
			public bool IsEnabled { get; set; }
		}

		// Token: 0x0200004A RID: 74
		[Nullable(0)]
		public class SkinLevel
		{
			// Token: 0x170000F5 RID: 245
			// (get) Token: 0x060002DD RID: 733 RVA: 0x0000AEE7 File Offset: 0x000090E7
			// (set) Token: 0x060002DE RID: 734 RVA: 0x0000AEEF File Offset: 0x000090EF
			public string Name { get; set; }

			// Token: 0x170000F6 RID: 246
			// (get) Token: 0x060002DF RID: 735 RVA: 0x0000AEF8 File Offset: 0x000090F8
			// (set) Token: 0x060002E0 RID: 736 RVA: 0x0000AF00 File Offset: 0x00009100
			public string ID { get; set; }

			// Token: 0x170000F7 RID: 247
			// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000AF09 File Offset: 0x00009109
			// (set) Token: 0x060002E2 RID: 738 RVA: 0x0000AF11 File Offset: 0x00009111
			public string AssetName { get; set; }

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x060002E3 RID: 739 RVA: 0x0000AF1A File Offset: 0x0000911A
			// (set) Token: 0x060002E4 RID: 740 RVA: 0x0000AF22 File Offset: 0x00009122
			public bool IsEnabled { get; set; }
		}

		// Token: 0x0200004B RID: 75
		[Nullable(0)]
		public class Attachment
		{
			// Token: 0x170000F9 RID: 249
			// (get) Token: 0x060002E6 RID: 742 RVA: 0x0000AF33 File Offset: 0x00009133
			// (set) Token: 0x060002E7 RID: 743 RVA: 0x0000AF3B File Offset: 0x0000913B
			public string Name { get; set; }

			// Token: 0x170000FA RID: 250
			// (get) Token: 0x060002E8 RID: 744 RVA: 0x0000AF44 File Offset: 0x00009144
			// (set) Token: 0x060002E9 RID: 745 RVA: 0x0000AF4C File Offset: 0x0000914C
			public string ID { get; set; }

			// Token: 0x170000FB RID: 251
			// (get) Token: 0x060002EA RID: 746 RVA: 0x0000AF55 File Offset: 0x00009155
			// (set) Token: 0x060002EB RID: 747 RVA: 0x0000AF5D File Offset: 0x0000915D
			public string AssetName { get; set; }

			// Token: 0x170000FC RID: 252
			// (get) Token: 0x060002EC RID: 748 RVA: 0x0000AF66 File Offset: 0x00009166
			// (set) Token: 0x060002ED RID: 749 RVA: 0x0000AF6E File Offset: 0x0000916E
			public bool IsEnabled { get; set; }
		}

		// Token: 0x0200004C RID: 76
		[Nullable(0)]
		public class Equip
		{
			// Token: 0x170000FD RID: 253
			// (get) Token: 0x060002EF RID: 751 RVA: 0x0000AF7F File Offset: 0x0000917F
			// (set) Token: 0x060002F0 RID: 752 RVA: 0x0000AF87 File Offset: 0x00009187
			public string Name { get; set; }

			// Token: 0x170000FE RID: 254
			// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000AF90 File Offset: 0x00009190
			// (set) Token: 0x060002F2 RID: 754 RVA: 0x0000AF98 File Offset: 0x00009198
			public string ID { get; set; }

			// Token: 0x170000FF RID: 255
			// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000AFA1 File Offset: 0x000091A1
			// (set) Token: 0x060002F4 RID: 756 RVA: 0x0000AFA9 File Offset: 0x000091A9
			public string AssetName { get; set; }

			// Token: 0x17000100 RID: 256
			// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000AFB2 File Offset: 0x000091B2
			// (set) Token: 0x060002F6 RID: 758 RVA: 0x0000AFBA File Offset: 0x000091BA
			public bool IsEnabled { get; set; }
		}

		// Token: 0x0200004D RID: 77
		[Nullable(0)]
		public class Theme
		{
			// Token: 0x17000101 RID: 257
			// (get) Token: 0x060002F8 RID: 760 RVA: 0x0000AFCB File Offset: 0x000091CB
			// (set) Token: 0x060002F9 RID: 761 RVA: 0x0000AFD3 File Offset: 0x000091D3
			public string Name { get; set; }

			// Token: 0x17000102 RID: 258
			// (get) Token: 0x060002FA RID: 762 RVA: 0x0000AFDC File Offset: 0x000091DC
			// (set) Token: 0x060002FB RID: 763 RVA: 0x0000AFE4 File Offset: 0x000091E4
			public string ID { get; set; }

			// Token: 0x17000103 RID: 259
			// (get) Token: 0x060002FC RID: 764 RVA: 0x0000AFED File Offset: 0x000091ED
			// (set) Token: 0x060002FD RID: 765 RVA: 0x0000AFF5 File Offset: 0x000091F5
			public string AssetName { get; set; }

			// Token: 0x17000104 RID: 260
			// (get) Token: 0x060002FE RID: 766 RVA: 0x0000AFFE File Offset: 0x000091FE
			// (set) Token: 0x060002FF RID: 767 RVA: 0x0000B006 File Offset: 0x00009206
			public bool IsEnabled { get; set; }
		}

		// Token: 0x0200004E RID: 78
		[Nullable(0)]
		public class GameMode
		{
			// Token: 0x17000105 RID: 261
			// (get) Token: 0x06000301 RID: 769 RVA: 0x0000B017 File Offset: 0x00009217
			// (set) Token: 0x06000302 RID: 770 RVA: 0x0000B01F File Offset: 0x0000921F
			public string Name { get; set; }

			// Token: 0x17000106 RID: 262
			// (get) Token: 0x06000303 RID: 771 RVA: 0x0000B028 File Offset: 0x00009228
			// (set) Token: 0x06000304 RID: 772 RVA: 0x0000B030 File Offset: 0x00009230
			public string ID { get; set; }

			// Token: 0x17000107 RID: 263
			// (get) Token: 0x06000305 RID: 773 RVA: 0x0000B039 File Offset: 0x00009239
			// (set) Token: 0x06000306 RID: 774 RVA: 0x0000B041 File Offset: 0x00009241
			public string AssetName { get; set; }

			// Token: 0x17000108 RID: 264
			// (get) Token: 0x06000307 RID: 775 RVA: 0x0000B04A File Offset: 0x0000924A
			// (set) Token: 0x06000308 RID: 776 RVA: 0x0000B052 File Offset: 0x00009252
			public bool IsEnabled { get; set; }
		}

		// Token: 0x0200004F RID: 79
		[Nullable(0)]
		public class Spray
		{
			// Token: 0x17000109 RID: 265
			// (get) Token: 0x0600030A RID: 778 RVA: 0x0000B063 File Offset: 0x00009263
			// (set) Token: 0x0600030B RID: 779 RVA: 0x0000B06B File Offset: 0x0000926B
			public string Name { get; set; }

			// Token: 0x1700010A RID: 266
			// (get) Token: 0x0600030C RID: 780 RVA: 0x0000B074 File Offset: 0x00009274
			// (set) Token: 0x0600030D RID: 781 RVA: 0x0000B07C File Offset: 0x0000927C
			public string ID { get; set; }

			// Token: 0x1700010B RID: 267
			// (get) Token: 0x0600030E RID: 782 RVA: 0x0000B085 File Offset: 0x00009285
			// (set) Token: 0x0600030F RID: 783 RVA: 0x0000B08D File Offset: 0x0000928D
			public string AssetName { get; set; }

			// Token: 0x1700010C RID: 268
			// (get) Token: 0x06000310 RID: 784 RVA: 0x0000B096 File Offset: 0x00009296
			// (set) Token: 0x06000311 RID: 785 RVA: 0x0000B09E File Offset: 0x0000929E
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000050 RID: 80
		[Nullable(0)]
		public class SprayLevel
		{
			// Token: 0x1700010D RID: 269
			// (get) Token: 0x06000313 RID: 787 RVA: 0x0000B0AF File Offset: 0x000092AF
			// (set) Token: 0x06000314 RID: 788 RVA: 0x0000B0B7 File Offset: 0x000092B7
			public string Name { get; set; }

			// Token: 0x1700010E RID: 270
			// (get) Token: 0x06000315 RID: 789 RVA: 0x0000B0C0 File Offset: 0x000092C0
			// (set) Token: 0x06000316 RID: 790 RVA: 0x0000B0C8 File Offset: 0x000092C8
			public string ID { get; set; }

			// Token: 0x1700010F RID: 271
			// (get) Token: 0x06000317 RID: 791 RVA: 0x0000B0D1 File Offset: 0x000092D1
			// (set) Token: 0x06000318 RID: 792 RVA: 0x0000B0D9 File Offset: 0x000092D9
			public string AssetName { get; set; }

			// Token: 0x17000110 RID: 272
			// (get) Token: 0x06000319 RID: 793 RVA: 0x0000B0E2 File Offset: 0x000092E2
			// (set) Token: 0x0600031A RID: 794 RVA: 0x0000B0EA File Offset: 0x000092EA
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000051 RID: 81
		[Nullable(0)]
		public class Charm
		{
			// Token: 0x17000111 RID: 273
			// (get) Token: 0x0600031C RID: 796 RVA: 0x0000B0FB File Offset: 0x000092FB
			// (set) Token: 0x0600031D RID: 797 RVA: 0x0000B103 File Offset: 0x00009303
			public string Name { get; set; }

			// Token: 0x17000112 RID: 274
			// (get) Token: 0x0600031E RID: 798 RVA: 0x0000B10C File Offset: 0x0000930C
			// (set) Token: 0x0600031F RID: 799 RVA: 0x0000B114 File Offset: 0x00009314
			public string ID { get; set; }

			// Token: 0x17000113 RID: 275
			// (get) Token: 0x06000320 RID: 800 RVA: 0x0000B11D File Offset: 0x0000931D
			// (set) Token: 0x06000321 RID: 801 RVA: 0x0000B125 File Offset: 0x00009325
			public string AssetName { get; set; }

			// Token: 0x17000114 RID: 276
			// (get) Token: 0x06000322 RID: 802 RVA: 0x0000B12E File Offset: 0x0000932E
			// (set) Token: 0x06000323 RID: 803 RVA: 0x0000B136 File Offset: 0x00009336
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000052 RID: 82
		[Nullable(0)]
		public class CharmLevel
		{
			// Token: 0x17000115 RID: 277
			// (get) Token: 0x06000325 RID: 805 RVA: 0x0000B147 File Offset: 0x00009347
			// (set) Token: 0x06000326 RID: 806 RVA: 0x0000B14F File Offset: 0x0000934F
			public string Name { get; set; }

			// Token: 0x17000116 RID: 278
			// (get) Token: 0x06000327 RID: 807 RVA: 0x0000B158 File Offset: 0x00009358
			// (set) Token: 0x06000328 RID: 808 RVA: 0x0000B160 File Offset: 0x00009360
			public string ID { get; set; }

			// Token: 0x17000117 RID: 279
			// (get) Token: 0x06000329 RID: 809 RVA: 0x0000B169 File Offset: 0x00009369
			// (set) Token: 0x0600032A RID: 810 RVA: 0x0000B171 File Offset: 0x00009371
			public string AssetName { get; set; }

			// Token: 0x17000118 RID: 280
			// (get) Token: 0x0600032B RID: 811 RVA: 0x0000B17A File Offset: 0x0000937A
			// (set) Token: 0x0600032C RID: 812 RVA: 0x0000B182 File Offset: 0x00009382
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000053 RID: 83
		[Nullable(0)]
		public class PlayerCard
		{
			// Token: 0x17000119 RID: 281
			// (get) Token: 0x0600032E RID: 814 RVA: 0x0000B193 File Offset: 0x00009393
			// (set) Token: 0x0600032F RID: 815 RVA: 0x0000B19B File Offset: 0x0000939B
			public string Name { get; set; }

			// Token: 0x1700011A RID: 282
			// (get) Token: 0x06000330 RID: 816 RVA: 0x0000B1A4 File Offset: 0x000093A4
			// (set) Token: 0x06000331 RID: 817 RVA: 0x0000B1AC File Offset: 0x000093AC
			public string ID { get; set; }

			// Token: 0x1700011B RID: 283
			// (get) Token: 0x06000332 RID: 818 RVA: 0x0000B1B5 File Offset: 0x000093B5
			// (set) Token: 0x06000333 RID: 819 RVA: 0x0000B1BD File Offset: 0x000093BD
			public string AssetName { get; set; }

			// Token: 0x1700011C RID: 284
			// (get) Token: 0x06000334 RID: 820 RVA: 0x0000B1C6 File Offset: 0x000093C6
			// (set) Token: 0x06000335 RID: 821 RVA: 0x0000B1CE File Offset: 0x000093CE
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000054 RID: 84
		[Nullable(0)]
		public class PlayerTitle
		{
			// Token: 0x1700011D RID: 285
			// (get) Token: 0x06000337 RID: 823 RVA: 0x0000B1DF File Offset: 0x000093DF
			// (set) Token: 0x06000338 RID: 824 RVA: 0x0000B1E7 File Offset: 0x000093E7
			public string Name { get; set; }

			// Token: 0x1700011E RID: 286
			// (get) Token: 0x06000339 RID: 825 RVA: 0x0000B1F0 File Offset: 0x000093F0
			// (set) Token: 0x0600033A RID: 826 RVA: 0x0000B1F8 File Offset: 0x000093F8
			public string ID { get; set; }

			// Token: 0x1700011F RID: 287
			// (get) Token: 0x0600033B RID: 827 RVA: 0x0000B201 File Offset: 0x00009401
			// (set) Token: 0x0600033C RID: 828 RVA: 0x0000B209 File Offset: 0x00009409
			public string AssetName { get; set; }

			// Token: 0x17000120 RID: 288
			// (get) Token: 0x0600033D RID: 829 RVA: 0x0000B212 File Offset: 0x00009412
			// (set) Token: 0x0600033E RID: 830 RVA: 0x0000B21A File Offset: 0x0000941A
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000055 RID: 85
		[Nullable(0)]
		public class StorefrontItem
		{
			// Token: 0x17000121 RID: 289
			// (get) Token: 0x06000340 RID: 832 RVA: 0x0000B22B File Offset: 0x0000942B
			// (set) Token: 0x06000341 RID: 833 RVA: 0x0000B233 File Offset: 0x00009433
			public string Name { get; set; }

			// Token: 0x17000122 RID: 290
			// (get) Token: 0x06000342 RID: 834 RVA: 0x0000B23C File Offset: 0x0000943C
			// (set) Token: 0x06000343 RID: 835 RVA: 0x0000B244 File Offset: 0x00009444
			public string ID { get; set; }

			// Token: 0x17000123 RID: 291
			// (get) Token: 0x06000344 RID: 836 RVA: 0x0000B24D File Offset: 0x0000944D
			// (set) Token: 0x06000345 RID: 837 RVA: 0x0000B255 File Offset: 0x00009455
			public string AssetName { get; set; }

			// Token: 0x17000124 RID: 292
			// (get) Token: 0x06000346 RID: 838 RVA: 0x0000B25E File Offset: 0x0000945E
			// (set) Token: 0x06000347 RID: 839 RVA: 0x0000B266 File Offset: 0x00009466
			public bool IsEnabled { get; set; }
		}

		// Token: 0x02000056 RID: 86
		[Nullable(0)]
		public class Season
		{
			// Token: 0x17000125 RID: 293
			// (get) Token: 0x06000349 RID: 841 RVA: 0x0000B277 File Offset: 0x00009477
			// (set) Token: 0x0600034A RID: 842 RVA: 0x0000B27F File Offset: 0x0000947F
			public string ID { get; set; }

			// Token: 0x17000126 RID: 294
			// (get) Token: 0x0600034B RID: 843 RVA: 0x0000B288 File Offset: 0x00009488
			// (set) Token: 0x0600034C RID: 844 RVA: 0x0000B290 File Offset: 0x00009490
			public string Name { get; set; }

			// Token: 0x17000127 RID: 295
			// (get) Token: 0x0600034D RID: 845 RVA: 0x0000B299 File Offset: 0x00009499
			// (set) Token: 0x0600034E RID: 846 RVA: 0x0000B2A1 File Offset: 0x000094A1
			public string Type { get; set; }

			// Token: 0x17000128 RID: 296
			// (get) Token: 0x0600034F RID: 847 RVA: 0x0000B2AA File Offset: 0x000094AA
			// (set) Token: 0x06000350 RID: 848 RVA: 0x0000B2B2 File Offset: 0x000094B2
			public DateTime StartTime { get; set; }

			// Token: 0x17000129 RID: 297
			// (get) Token: 0x06000351 RID: 849 RVA: 0x0000B2BB File Offset: 0x000094BB
			// (set) Token: 0x06000352 RID: 850 RVA: 0x0000B2C3 File Offset: 0x000094C3
			public DateTime EndTime { get; set; }

			// Token: 0x1700012A RID: 298
			// (get) Token: 0x06000353 RID: 851 RVA: 0x0000B2CC File Offset: 0x000094CC
			// (set) Token: 0x06000354 RID: 852 RVA: 0x0000B2D4 File Offset: 0x000094D4
			public bool IsEnabled { get; set; }

			// Token: 0x1700012B RID: 299
			// (get) Token: 0x06000355 RID: 853 RVA: 0x0000B2DD File Offset: 0x000094DD
			// (set) Token: 0x06000356 RID: 854 RVA: 0x0000B2E5 File Offset: 0x000094E5
			public bool IsActive { get; set; }

			// Token: 0x1700012C RID: 300
			// (get) Token: 0x06000357 RID: 855 RVA: 0x0000B2EE File Offset: 0x000094EE
			// (set) Token: 0x06000358 RID: 856 RVA: 0x0000B2F6 File Offset: 0x000094F6
			public bool DevelopmentOnly { get; set; }
		}

		// Token: 0x02000057 RID: 87
		[Nullable(0)]
		public class CompetitiveSeason
		{
			// Token: 0x1700012D RID: 301
			// (get) Token: 0x0600035A RID: 858 RVA: 0x0000B307 File Offset: 0x00009507
			// (set) Token: 0x0600035B RID: 859 RVA: 0x0000B30F File Offset: 0x0000950F
			public string ID { get; set; }

			// Token: 0x1700012E RID: 302
			// (get) Token: 0x0600035C RID: 860 RVA: 0x0000B318 File Offset: 0x00009518
			// (set) Token: 0x0600035D RID: 861 RVA: 0x0000B320 File Offset: 0x00009520
			public string SeasonID { get; set; }

			// Token: 0x1700012F RID: 303
			// (get) Token: 0x0600035E RID: 862 RVA: 0x0000B329 File Offset: 0x00009529
			// (set) Token: 0x0600035F RID: 863 RVA: 0x0000B331 File Offset: 0x00009531
			public DateTime StartTime { get; set; }

			// Token: 0x17000130 RID: 304
			// (get) Token: 0x06000360 RID: 864 RVA: 0x0000B33A File Offset: 0x0000953A
			// (set) Token: 0x06000361 RID: 865 RVA: 0x0000B342 File Offset: 0x00009542
			public DateTime EndTime { get; set; }

			// Token: 0x17000131 RID: 305
			// (get) Token: 0x06000362 RID: 866 RVA: 0x0000B34B File Offset: 0x0000954B
			// (set) Token: 0x06000363 RID: 867 RVA: 0x0000B353 File Offset: 0x00009553
			public bool DevelopmentOnly { get; set; }
		}
	}
}
