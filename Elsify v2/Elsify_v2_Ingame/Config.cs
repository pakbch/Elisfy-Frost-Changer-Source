using System;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using ValAPINet;

namespace Elsify_v2_Ingame
{
	// Token: 0x02000028 RID: 40
	[NullableContext(1)]
	[Nullable(0)]
	public class Config
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001BF RID: 447 RVA: 0x0000624E File Offset: 0x0000444E
		private static string ConfigPath
		{
			get
			{
				return Config.Folder + "\\config.json";
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00006260 File Offset: 0x00004460
		public static void InitConfig()
		{
			if (!Directory.Exists(Config.Folder))
			{
				Directory.CreateDirectory(Config.Folder);
			}
			if (!File.Exists(Config.ConfigPath))
			{
				File.WriteAllText(Config.ConfigPath, Config.ToJson(new Config.ConfigObj()));
			}
			Config.CurrentConfig = Config.FromJSON<Config.ConfigObj>(File.ReadAllText(Config.ConfigPath));
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000062B8 File Offset: 0x000044B8
		public static void SaveConfig()
		{
			File.WriteAllText(Config.ConfigPath, Config.ToJson(Config.CurrentConfig));
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000062CE File Offset: 0x000044CE
		public static T FromJSON<[Nullable(2)] T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000062D6 File Offset: 0x000044D6
		public static string ToJson(object config)
		{
			return JsonConvert.SerializeObject(config);
		}

		// Token: 0x040000E4 RID: 228
		public static string Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\elsifyv2";

		// Token: 0x040000E5 RID: 229
		public static Config.ConfigObj CurrentConfig;

		// Token: 0x020000A6 RID: 166
		[Nullable(0)]
		public class ConfigObj
		{
			// Token: 0x170002A1 RID: 673
			// (get) Token: 0x06000699 RID: 1689 RVA: 0x0000D1DD File Offset: 0x0000B3DD
			// (set) Token: 0x0600069A RID: 1690 RVA: 0x0000D1E5 File Offset: 0x0000B3E5
			public Auth CurrentAuth { get; set; } = new Auth
			{
				cookies = null,
				AccessToken = "",
				EntitlementToken = "",
				subject = "invalid",
				region = Region.NA,
				version = null
			};
		}
	}
}
