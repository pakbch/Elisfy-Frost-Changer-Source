using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Elsify_v2_Ingame
{
	// Token: 0x02000030 RID: 48
	public static class Utiels
	{
		// Token: 0x060001F5 RID: 501 RVA: 0x000078D9 File Offset: 0x00005AD9
		[NullableContext(1)]
		public static void UrlStart(this string url)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/C start " + url,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true
			});
		}
	}
}
