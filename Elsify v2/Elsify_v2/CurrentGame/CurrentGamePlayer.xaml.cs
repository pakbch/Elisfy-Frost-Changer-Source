using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Elsify_v2.CurrentGame
{
	// Token: 0x02000025 RID: 37
	public partial class CurrentGamePlayer : UserControl
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x00005B78 File Offset: 0x00003D78
		[NullableContext(1)]
		public CurrentGamePlayer(string image, string username, bool lockVisible = false)
		{
			this.InitializeComponent();
			if (!lockVisible)
			{
				this.labelitem2.Visibility = Visibility.Hidden;
			}
			string ImageFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\elsifyv2";
			if (!Directory.Exists(ImageFolder))
			{
				Directory.CreateDirectory(ImageFolder);
			}
			if (!Directory.Exists(ImageFolder + "\\Images"))
			{
				Directory.CreateDirectory(ImageFolder + "\\Images");
			}
			string path = ImageFolder + "\\Images\\" + image.Remove(0, "https://".Length).Replace("/", "");
			if (!File.Exists(path))
			{
				new WebClient().DownloadFile(new Uri(image), path);
			}
			this.item1.Source = new BitmapImage(new Uri(image));
			this.labelitem1.Content = username;
		}
	}
}
