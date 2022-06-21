using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using Elsify_v2_Ingame.UserAuth;
using log4net;

namespace Elsify_v2_Ingame
{
	// Token: 0x02000027 RID: 39
	[NullableContext(1)]
	[Nullable(0)]
	public partial class App : Application
	{
		// Token: 0x060001B9 RID: 441 RVA: 0x00006148 File Offset: 0x00004348
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			Config.InitConfig();
			if (long.Parse(new WebClient().DownloadString("https://pastebin.com/raw/MzNqjD6W")) > 5L)
			{
				MessageBox.Show("There is a New Elsify Version! \nPlease download the newest Version!", "Elsify");
				string DownloadLink = "https://direct-link.net/26814/valorant-skin-changer";
				Process.Start(new ProcessStartInfo
				{
					FileName = DownloadLink,
					UseShellExecute = true
				});
				Environment.Exit(0);
			}
			OnProgramStart.Initialize("Elsify", "947481", "JGePQPYbMl2w7U4q5OHqbMGD1WIxj0K4dc6", "1.0");
			DiscordRPC.InitializeRPC();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000061CC File Offset: 0x000043CC
		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			Config.SaveConfig();
		}

		// Token: 0x040000E2 RID: 226
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
	}
}
