using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

namespace Woe.ValAPINet
{
	// Token: 0x02000020 RID: 32
	[NullableContext(1)]
	[Nullable(0)]
	public class inventoryitems
	{
		// Token: 0x06000193 RID: 403 RVA: 0x0000522C File Offset: 0x0000342C
		public static inventoryitems.Playercard getPlayerCard(string id)
		{
			inventoryitems.Playercard playercard = new inventoryitems.Playercard();
			JObject parsed = JObject.Parse(new WebClient().DownloadString("https://valorant-api.com/v1/playercards/" + id));
			playercard.uuid = parsed["data"]["uuid"].ToString();
			playercard.displayName = parsed["data"]["displayName"].ToString();
			playercard.displayIcon = parsed["data"]["displayIcon"].ToString();
			playercard.smallArt = parsed["data"]["smallArt"].ToString();
			playercard.wideArt = parsed["data"]["wideArt"].ToString();
			playercard.largeArt = parsed["data"]["largeArt"].ToString();
			return playercard;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000531C File Offset: 0x0000351C
		public static string getPlayerTitle(string id)
		{
			id == "00000000-0000-0000-0000-000000000000";
			string returning;
			if (id == "d13e579c-435e-44d4-cec2-6eae5a3c5ed4" || id == "00000000-0000-0000-0000-000000000000")
			{
				returning = "No Title";
			}
			else
			{
				returning = JObject.Parse(new WebClient().DownloadString("https://valorant-api.com/v1/playertitles/" + id))["data"]["titleText"].ToString();
			}
			return returning;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000538C File Offset: 0x0000358C
		[return: Dynamic(new bool[]
		{
			false,
			true
		})]
		public static List<dynamic> getSkinsByName(string gunType)
		{
			List<object> list = new List<object>();
			foreach (object d in ((IEnumerable<JToken>)JObject.Parse(new WebClient().DownloadString("https://valorant-api.com/v1/weapons/skins"))["data"]))
			{
				if (inventoryitems.<>o__2.<>p__3 == null)
				{
					inventoryitems.<>o__2.<>p__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(inventoryitems), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target = inventoryitems.<>o__2.<>p__3.Target;
				CallSite <>p__ = inventoryitems.<>o__2.<>p__3;
				if (inventoryitems.<>o__2.<>p__2 == null)
				{
					inventoryitems.<>o__2.<>p__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Contains", null, typeof(inventoryitems), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Func<CallSite, object, string, object> target2 = inventoryitems.<>o__2.<>p__2.Target;
				CallSite <>p__2 = inventoryitems.<>o__2.<>p__2;
				if (inventoryitems.<>o__2.<>p__1 == null)
				{
					inventoryitems.<>o__2.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(inventoryitems), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, object> target3 = inventoryitems.<>o__2.<>p__1.Target;
				CallSite <>p__3 = inventoryitems.<>o__2.<>p__1;
				if (inventoryitems.<>o__2.<>p__0 == null)
				{
					inventoryitems.<>o__2.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(inventoryitems), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				if (target(<>p__, target2(<>p__2, target3(<>p__3, inventoryitems.<>o__2.<>p__0.Target(inventoryitems.<>o__2.<>p__0, d)), gunType)))
				{
					if (inventoryitems.<>o__2.<>p__4 == null)
					{
						inventoryitems.<>o__2.<>p__4 = CallSite<Action<CallSite, List<object>, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", null, typeof(inventoryitems), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					inventoryitems.<>o__2.<>p__4.Target(inventoryitems.<>o__2.<>p__4, list, d);
				}
			}
			return list;
		}

		// Token: 0x0200009C RID: 156
		[Nullable(0)]
		public class Playercard
		{
			// Token: 0x17000281 RID: 641
			// (get) Token: 0x0600064D RID: 1613 RVA: 0x0000CBE7 File Offset: 0x0000ADE7
			// (set) Token: 0x0600064E RID: 1614 RVA: 0x0000CBEF File Offset: 0x0000ADEF
			public string uuid { get; set; }

			// Token: 0x17000282 RID: 642
			// (get) Token: 0x0600064F RID: 1615 RVA: 0x0000CBF8 File Offset: 0x0000ADF8
			// (set) Token: 0x06000650 RID: 1616 RVA: 0x0000CC00 File Offset: 0x0000AE00
			public string displayName { get; set; }

			// Token: 0x17000283 RID: 643
			// (get) Token: 0x06000651 RID: 1617 RVA: 0x0000CC09 File Offset: 0x0000AE09
			// (set) Token: 0x06000652 RID: 1618 RVA: 0x0000CC11 File Offset: 0x0000AE11
			public string displayIcon { get; set; }

			// Token: 0x17000284 RID: 644
			// (get) Token: 0x06000653 RID: 1619 RVA: 0x0000CC1A File Offset: 0x0000AE1A
			// (set) Token: 0x06000654 RID: 1620 RVA: 0x0000CC22 File Offset: 0x0000AE22
			public string smallArt { get; set; }

			// Token: 0x17000285 RID: 645
			// (get) Token: 0x06000655 RID: 1621 RVA: 0x0000CC2B File Offset: 0x0000AE2B
			// (set) Token: 0x06000656 RID: 1622 RVA: 0x0000CC33 File Offset: 0x0000AE33
			public string wideArt { get; set; }

			// Token: 0x17000286 RID: 646
			// (get) Token: 0x06000657 RID: 1623 RVA: 0x0000CC3C File Offset: 0x0000AE3C
			// (set) Token: 0x06000658 RID: 1624 RVA: 0x0000CC44 File Offset: 0x0000AE44
			public string largeArt { get; set; }
		}
	}
}
