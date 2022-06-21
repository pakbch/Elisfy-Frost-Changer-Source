using System;
using System.Runtime.CompilerServices;

namespace ValAPINet
{
	// Token: 0x0200000E RID: 14
	public class Ranks
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00002C6C File Offset: 0x00000E6C
		[NullableContext(1)]
		public static string GetRankFormatted(int rank)
		{
			return (new string[]
			{
				"Unrated",
				"none",
				"none",
				"Iron 1",
				"Iron 2",
				"Iron 3",
				"Bronze 1",
				"Bronze 2",
				"Bronze 3",
				"Silver 1",
				"Silver 2",
				"Silver 3",
				"Gold 1",
				"Gold 2",
				"Gold 3",
				"Platinum 1",
				"Platinum 2",
				"Platinum 3",
				"Diamond 1",
				"Diamond 2",
				"Diamond 3",
				"Immortal",
				"none",
				"none",
				"Radiant"
			})[rank];
		}
	}
}
