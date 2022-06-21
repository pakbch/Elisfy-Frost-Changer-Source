using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using ValAPINet;
using Woe.Skin_Changer;
using Woe.ValAPINet;

namespace Elsify_v2_Ingame
{
	// Token: 0x0200002C RID: 44
	[NullableContext(1)]
	[Nullable(0)]
	public partial class ItemCard : UserControl
	{
		// Token: 0x060001CF RID: 463 RVA: 0x00006480 File Offset: 0x00004680
		public ItemCard(string imageURL, string itemname, string cardID, Auth au)
		{
			this.InitializeComponent();
			string ImageFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\elsifyv2";
			if (!Directory.Exists(ImageFolder))
			{
				Directory.CreateDirectory(ImageFolder);
			}
			if (!Directory.Exists(ImageFolder + "\\Images"))
			{
				Directory.CreateDirectory(ImageFolder + "\\Images");
			}
			string path = ImageFolder + "\\Images\\" + imageURL.Remove(0, "https://".Length).Replace("/", "");
			if (!File.Exists(path))
			{
				new WebClient().DownloadFile(new Uri(imageURL), path);
			}
			this.itemNameLabel.Content = itemname;
			this.swaptoimage.Source = new BitmapImage(new Uri(imageURL));
			this.swaptoimage.MouseLeftButtonDown += delegate(object <p0>, MouseButtonEventArgs <p1>)
			{
				RiotClient.Root playerLoadout = RiotClient.GetPlayerLoadout(au);
				playerLoadout.Identity.PlayerCardID = cardID;
				if (ItemCard.SetLoadout(playerLoadout, au))
				{
					inventoryitems.Playercard p = inventoryitems.getPlayerCard(Inventory.GetInventory(au).Identity.PlayerCardID);
					MainWindow.mw.playerCardImage.ImageSource = new BitmapImage(new Uri(p.displayIcon));
					MessageBox.Show("Successfully changed your Player Card to " + itemname, "Elsify");
				}
			};
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00006585 File Offset: 0x00004785
		private void itemPicture_MouseEnter(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ItemHoverScale"]).Begin();
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000065A1 File Offset: 0x000047A1
		private void itemPicture_MouseLeave(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ItemHoverScaleReverse"]).Begin();
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000065BD File Offset: 0x000047BD
		private void swapto_MouseEnter(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ItemImageHoverScale"]).Begin();
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000065D9 File Offset: 0x000047D9
		private void swapto_MouseLeave(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ItemImageHoverScaleReverse"]).Begin();
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000065F5 File Offset: 0x000047F5
		private void swaptoimage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000065F7 File Offset: 0x000047F7
		public static bool SetLoadout(RiotClient.Root value, Auth au)
		{
			return RiotClient.SetPlayerLoadout(value, au);
		}
	}
}
