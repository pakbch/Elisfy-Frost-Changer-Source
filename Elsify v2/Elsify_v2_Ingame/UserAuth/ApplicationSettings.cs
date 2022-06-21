using System;
using System.Runtime.CompilerServices;

namespace Elsify_v2_Ingame.UserAuth
{
	// Token: 0x02000035 RID: 53
	[NullableContext(1)]
	[Nullable(0)]
	internal class ApplicationSettings
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000225 RID: 549 RVA: 0x00007CF2 File Offset: 0x00005EF2
		// (set) Token: 0x06000226 RID: 550 RVA: 0x00007CF9 File Offset: 0x00005EF9
		public static bool Status { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00007D01 File Offset: 0x00005F01
		// (set) Token: 0x06000228 RID: 552 RVA: 0x00007D08 File Offset: 0x00005F08
		public static bool DeveloperMode { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00007D10 File Offset: 0x00005F10
		// (set) Token: 0x0600022A RID: 554 RVA: 0x00007D17 File Offset: 0x00005F17
		public static string Hash { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00007D1F File Offset: 0x00005F1F
		// (set) Token: 0x0600022C RID: 556 RVA: 0x00007D26 File Offset: 0x00005F26
		public static string Version { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600022D RID: 557 RVA: 0x00007D2E File Offset: 0x00005F2E
		// (set) Token: 0x0600022E RID: 558 RVA: 0x00007D35 File Offset: 0x00005F35
		public static string Update_Link { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00007D3D File Offset: 0x00005F3D
		// (set) Token: 0x06000230 RID: 560 RVA: 0x00007D44 File Offset: 0x00005F44
		public static bool Freemode { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00007D4C File Offset: 0x00005F4C
		// (set) Token: 0x06000232 RID: 562 RVA: 0x00007D53 File Offset: 0x00005F53
		public static bool Login { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000233 RID: 563 RVA: 0x00007D5B File Offset: 0x00005F5B
		// (set) Token: 0x06000234 RID: 564 RVA: 0x00007D62 File Offset: 0x00005F62
		public static string Name { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000235 RID: 565 RVA: 0x00007D6A File Offset: 0x00005F6A
		// (set) Token: 0x06000236 RID: 566 RVA: 0x00007D71 File Offset: 0x00005F71
		public static bool Register { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00007D79 File Offset: 0x00005F79
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00007D80 File Offset: 0x00005F80
		public static string TotalUsers { get; set; }
	}
}
