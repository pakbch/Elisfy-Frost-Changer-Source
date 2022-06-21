using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using RestSharp;
using ValAPINet;

namespace Elsify_v2_Ingame.Shop
{
	// Token: 0x0200003D RID: 61
	public partial class ShopUC : UserControl
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0000A31C File Offset: 0x0000851C
		[NullableContext(1)]
		public ShopUC(Auth au)
		{
			this.InitializeComponent();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 2);
			defaultInterpolatedStringHandler.AppendLiteral("https://pd.");
			defaultInterpolatedStringHandler.AppendFormatted<Region>(au.region);
			defaultInterpolatedStringHandler.AppendLiteral(".a.pvp.net/store/v2/storefront/");
			defaultInterpolatedStringHandler.AppendFormatted(au.subject);
			RestClient restClient = new RestClient(defaultInterpolatedStringHandler.ToStringAndClear());
			RestRequest request = new RestRequest(Method.GET);
			request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken ?? "");
			request.AddHeader("Authorization", "Bearer " + au.AccessToken);
			JObject einzed = JObject.Parse(restClient.Execute(request).Content);
			string url2 = "https://valorant-api.com/v1/weapons/skinlevels/" + einzed["SkinsPanelLayout"]["SingleItemOffers"][0].ToString();
			string url3 = "https://valorant-api.com/v1/weapons/skinlevels/" + einzed["SkinsPanelLayout"]["SingleItemOffers"][1].ToString();
			string url4 = "https://valorant-api.com/v1/weapons/skinlevels/" + einzed["SkinsPanelLayout"]["SingleItemOffers"][2].ToString();
			string url5 = "https://valorant-api.com/v1/weapons/skinlevels/" + einzed["SkinsPanelLayout"]["SingleItemOffers"][3].ToString();
			JObject firstGun = JObject.Parse(new WebClient().DownloadString(url2));
			this.item1.Source = new BitmapImage(new Uri(firstGun["data"]["displayIcon"].ToString()));
			this.labelitem1.Content = firstGun["data"]["displayName"].ToString();
			JObject firstGun2 = JObject.Parse(new WebClient().DownloadString(url3));
			this.item2.Source = new BitmapImage(new Uri(firstGun2["data"]["displayIcon"].ToString()));
			this.labelitem2.Content = firstGun2["data"]["displayName"].ToString();
			JObject firstGun3 = JObject.Parse(new WebClient().DownloadString(url4));
			this.item3.Source = new BitmapImage(new Uri(firstGun3["data"]["displayIcon"].ToString()));
			this.labelitem3.Content = firstGun3["data"]["displayName"].ToString();
			JObject firstGun4 = JObject.Parse(new WebClient().DownloadString(url5));
			this.item4.Source = new BitmapImage(new Uri(firstGun4["data"]["displayIcon"].ToString()));
			this.labelitem4.Content = firstGun4["data"]["displayName"].ToString();
		}

		// Token: 0x04000146 RID: 326
		[Nullable(1)]
		public static JObject allSKins = JObject.Parse(new WebClient().DownloadString("https://valorant-api.com/v1/weapons/skins"));
	}
}
