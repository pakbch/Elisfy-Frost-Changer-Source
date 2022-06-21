using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using ValAPINet;
using Woe.Skin_Changer;
using Woe.ValAPINet;

namespace Elsify_v2_Ingame
{
	// Token: 0x0200002E RID: 46
	public partial class PlayerTitle : UserControl
	{
		// Token: 0x060001ED RID: 493 RVA: 0x00007764 File Offset: 0x00005964
		[NullableContext(1)]
		public PlayerTitle(Auth au, string itemname, string titleID)
		{
			this.InitializeComponent();
			this.itemNameLabel.Content = itemname;
			this.itemNameLabel.MouseLeftButtonDown += delegate(object <p0>, MouseButtonEventArgs <p1>)
			{
				RiotClient.Root playerLoadout = RiotClient.GetPlayerLoadout(au);
				playerLoadout.Identity.PlayerTitleID = titleID;
				if (PlayerTitle.SetLoadout(playerLoadout, au))
				{
					Inventory inv = Inventory.GetInventory(au);
					inventoryitems.getPlayerCard(inv.Identity.PlayerCardID);
					MainWindow.mw.PlayerTitleLabel.Content = inventoryitems.getPlayerTitle(inv.Identity.PlayerTitleID);
					MessageBox.Show("Successfully changed your Player Title to " + itemname, "Elsify");
				}
			};
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000077C0 File Offset: 0x000059C0
		[NullableContext(1)]
		public static bool SetLoadout(RiotClient.Root value, Auth au)
		{
			return RiotClient.SetPlayerLoadout(value, au);
		}
	}
}
