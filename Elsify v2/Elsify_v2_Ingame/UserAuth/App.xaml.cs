using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Elsify_v2_Ingame.UserAuth
{
	// Token: 0x02000032 RID: 50
	[NullableContext(1)]
	[Nullable(0)]
	internal partial class App
	{
		// Token: 0x060001FD RID: 509 RVA: 0x00007AF8 File Offset: 0x00005CF8
		public static string GrabVariable(string name)
		{
			string result;
			try
			{
				if (User.ID != null || User.HWID != null || User.IP != null || !Constants.Breached)
				{
					result = App.Variables[name];
				}
				else
				{
					Constants.Breached = true;
					result = "User is not logged in, possible breach detected!";
				}
			}
			catch
			{
				result = "N/A";
			}
			return result;
		}

		// Token: 0x0400010C RID: 268
		public static string Error = null;

		// Token: 0x0400010D RID: 269
		public static Dictionary<string, string> Variables = new Dictionary<string, string>();
	}
}
