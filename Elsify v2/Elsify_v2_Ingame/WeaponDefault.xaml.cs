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

namespace Elsify_v2_Ingame
{
	// Token: 0x02000031 RID: 49
	public partial class WeaponDefault : UserControl
	{
		// Token: 0x060001F6 RID: 502 RVA: 0x00007910 File Offset: 0x00005B10
		[NullableContext(1)]
		public WeaponDefault(string imageURL, string itemname, string gunID)
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
			string path = "";
			try
			{
				path = ImageFolder + "\\Images\\" + imageURL.Remove(0, "https://".Length).Replace("/", "");
			}
			catch (Exception)
			{
			}
			if (!File.Exists(path))
			{
				new WebClient().DownloadFile(new Uri(imageURL), path);
			}
			this.itemNameLabel.Content = itemname;
			this.swaptoimage.Source = new BitmapImage(new Uri(imageURL));
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x000079F0 File Offset: 0x00005BF0
		[NullableContext(1)]
		private void itemPicture_MouseEnter(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ItemHoverScale"]).Begin();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00007A0C File Offset: 0x00005C0C
		[NullableContext(1)]
		private void itemPicture_MouseLeave(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ItemHoverScaleReverse"]).Begin();
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00007A28 File Offset: 0x00005C28
		[NullableContext(1)]
		private void swapto_MouseEnter(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ItemImageHoverScale"]).Begin();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00007A44 File Offset: 0x00005C44
		[NullableContext(1)]
		private void swapto_MouseLeave(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ItemImageHoverScaleReverse"]).Begin();
		}
	}
}
