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
using Elsify_v2_Ingame;
using Elsify_v2_Ingame.UserAuth;

namespace Elsify_v2.UserAuth
{
	// Token: 0x02000024 RID: 36
	public partial class FreeUser : Window
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x00005923 File Offset: 0x00003B23
		public FreeUser()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00005931 File Offset: 0x00003B31
		[NullableContext(1)]
		private void KeyAuth_Click(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00005934 File Offset: 0x00003B34
		[NullableContext(1)]
		private void GetKey_Click(object sender, RoutedEventArgs e)
		{
			string url = "https://link-hub.net/26814/elsify-v2-key";
			Process.Start(new ProcessStartInfo
			{
				UseShellExecute = true,
				FileName = url
			});
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00005960 File Offset: 0x00003B60
		[NullableContext(1)]
		private void Image_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				base.DragMove();
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00005970 File Offset: 0x00003B70
		[NullableContext(1)]
		private void closeLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00005978 File Offset: 0x00003B78
		[NullableContext(1)]
		private void Getkey_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			string url = "https://link-hub.net/26814/elsify-v2-key";
			Process.Start(new ProcessStartInfo
			{
				UseShellExecute = true,
				FileName = url
			});
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000059A4 File Offset: 0x00003BA4
		[NullableContext(1)]
		private void useKey_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (this.keyBox.Text.Length > 1)
			{
				Stream responseStream = WebRequest.Create("https://frostonacid.github.io/KeySystem/key.html").GetResponse().GetResponseStream();
				string html = string.Empty;
				using (StreamReader sr = new StreamReader(responseStream))
				{
					html = sr.ReadToEnd();
				}
				if (html.Contains(this.keyBox.Text))
				{
					MessageBox.Show("Correct Key, Enjoy Elsify  v2!");
					base.Hide();
					new MainWindow().Show();
					return;
				}
				MessageBox.Show("Please enter a valid Key!");
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00005A44 File Offset: 0x00003C44
		[NullableContext(1)]
		private void back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.Hide();
			new Login().Show();
		}
	}
}
