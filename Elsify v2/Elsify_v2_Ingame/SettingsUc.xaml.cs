using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Newtonsoft.Json.Linq;

namespace Elsify_v2_Ingame
{
	// Token: 0x0200002F RID: 47
	public partial class SettingsUc : UserControl
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x00007816 File Offset: 0x00005A16
		public SettingsUc()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00007824 File Offset: 0x00005A24
		[NullableContext(1)]
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string rc_default = JObject.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Riot Games\\RiotClientInstalls.json"))["rc_default"].ToString();
			new Process
			{
				StartInfo = 
				{
					FileName = rc_default,
					Arguments = "--launch-product=valorant --launch-patchline=live"
				}
			}.Start();
		}
	}
}
