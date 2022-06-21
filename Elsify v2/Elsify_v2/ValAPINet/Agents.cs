using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Elsify_v2.ValAPINet
{
	// Token: 0x02000023 RID: 35
	[NullableContext(1)]
	[Nullable(0)]
	public class Agents
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x000058F4 File Offset: 0x00003AF4
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x000058FC File Offset: 0x00003AFC
		public List<Agents.agent> data { get; set; }

		// Token: 0x060001A4 RID: 420 RVA: 0x00005905 File Offset: 0x00003B05
		public static Agents GetAgents()
		{
			return JsonConvert.DeserializeObject<Agents>(new WebClient().DownloadString("https://valorant-api.com/v1/agents?isPlayableCharacter=true"));
		}

		// Token: 0x020000A2 RID: 162
		[Nullable(0)]
		public class agent
		{
			// Token: 0x1700029D RID: 669
			// (get) Token: 0x0600068A RID: 1674 RVA: 0x0000CDEB File Offset: 0x0000AFEB
			// (set) Token: 0x0600068B RID: 1675 RVA: 0x0000CDF3 File Offset: 0x0000AFF3
			public string displayName { get; set; }

			// Token: 0x1700029E RID: 670
			// (get) Token: 0x0600068C RID: 1676 RVA: 0x0000CDFC File Offset: 0x0000AFFC
			// (set) Token: 0x0600068D RID: 1677 RVA: 0x0000CE04 File Offset: 0x0000B004
			public string uuid { get; set; }

			// Token: 0x1700029F RID: 671
			// (get) Token: 0x0600068E RID: 1678 RVA: 0x0000CE0D File Offset: 0x0000B00D
			// (set) Token: 0x0600068F RID: 1679 RVA: 0x0000CE15 File Offset: 0x0000B015
			public string description { get; set; }

			// Token: 0x170002A0 RID: 672
			// (get) Token: 0x06000690 RID: 1680 RVA: 0x0000CE1E File Offset: 0x0000B01E
			// (set) Token: 0x06000691 RID: 1681 RVA: 0x0000CE26 File Offset: 0x0000B026
			public string displayIcon { get; set; }
		}
	}
}
