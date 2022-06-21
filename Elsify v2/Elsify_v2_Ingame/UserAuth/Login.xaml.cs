using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Elsify_v2.UserAuth;

namespace Elsify_v2_Ingame.UserAuth
{
	// Token: 0x0200003B RID: 59
	[NullableContext(1)]
	[Nullable(0)]
	public partial class Login : Window
	{
		// Token: 0x0600025D RID: 605 RVA: 0x00009E87 File Offset: 0x00008087
		public Login()
		{
			this.InitializeComponent();
			DiscordRPC.setState("Login");
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00009EA0 File Offset: 0x000080A0
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (API.Login("", ""))
			{
				MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				API.Log(User.Username, "Signed in");
				new MainWindow().Show();
				base.Hide();
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00009EF0 File Offset: 0x000080F0
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00009EF8 File Offset: 0x000080F8
		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00009EFA File Offset: 0x000080FA
		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				base.DragMove();
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00009F0A File Offset: 0x0000810A
		private void Image_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				base.DragMove();
			}
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00009F1A File Offset: 0x0000811A
		private void Button_Click(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00009F1C File Offset: 0x0000811C
		private void FreeLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			new FreeUser().Show();
			base.Hide();
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00009F30 File Offset: 0x00008130
		private void loginLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (API.Login(this.userNameBox.Text, this.passwordBox.Password))
			{
				MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				API.Log(User.Username, "Signed in");
				new MainWindow().Show();
				base.Hide();
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00009F8C File Offset: 0x0000818C
		private void regLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.Hide();
			new Register().Show();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00009F9E File Offset: 0x0000819E
		private void closeLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
