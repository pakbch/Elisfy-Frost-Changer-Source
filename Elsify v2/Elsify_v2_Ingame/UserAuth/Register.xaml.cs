using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Elsify_v2_Ingame.UserAuth
{
	// Token: 0x0200003C RID: 60
	public partial class Register : Window
	{
		// Token: 0x0600026A RID: 618 RVA: 0x0000A0D7 File Offset: 0x000082D7
		public Register()
		{
			this.InitializeComponent();
			DiscordRPC.setState("Register");
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000A0F0 File Offset: 0x000082F0
		[NullableContext(1)]
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (API.Register(this.userNameBox.Text, this.passwordBox.Password, this.emailBox.Text, this.keyBox.Text))
			{
				MessageBox.Show("Register has been successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000A143 File Offset: 0x00008343
		[NullableContext(1)]
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000A14B File Offset: 0x0000834B
		[NullableContext(1)]
		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			base.Hide();
			new Login().Show();
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000A15D File Offset: 0x0000835D
		[NullableContext(1)]
		private void Image_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				base.DragMove();
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000A170 File Offset: 0x00008370
		[NullableContext(1)]
		private void loginLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (API.Register(this.userNameBox.Text, this.passwordBox.Password, this.emailBox.Text, this.keyBox.Text))
			{
				MessageBox.Show("Register has been successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000A1C3 File Offset: 0x000083C3
		[NullableContext(1)]
		private void regLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.Hide();
			new Login().Show();
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000A1D5 File Offset: 0x000083D5
		[NullableContext(1)]
		private void closeLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000A1DD File Offset: 0x000083DD
		[NullableContext(1)]
		private void backToLoginLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			base.Hide();
			new Login().Show();
		}
	}
}
