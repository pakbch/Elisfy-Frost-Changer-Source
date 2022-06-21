using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Elsify_v2.CurrentGame;
using Elsify_v2_Ingame.Home;
using Elsify_v2_Ingame.Shop;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using ValAPINet;
using Woe.Skin_Changer;
using Woe.ValAPINet;

namespace Elsify_v2_Ingame
{
	// Token: 0x0200002D RID: 45
	[NullableContext(1)]
	[Nullable(0)]
	public partial class MainWindow : Window
	{
		// Token: 0x060001D8 RID: 472 RVA: 0x00006698 File Offset: 0x00004898
		public MainWindow()
		{
			this.InitializeComponent();
			bool flag = Process.GetProcessesByName("VALORANT").Length != 0;
			bool a = false;
			if (!flag)
			{
				this.StartValorant();
				MessageBox.Show("We detected you didn't open VALORANT. We'll open the game now. Once it's loaded Elsify v2 will load!");
				while (!a)
				{
					Thread.Sleep(1000);
					if (Process.GetProcessesByName("VALORANT").Length != 0)
					{
						a = true;
					}
				}
			}
			Auth au = Websocket.GetAuthLocal(true);
			MainWindow.currentAuth = au;
			Config.CurrentConfig.CurrentAuth = au;
			Username userName = Username.GetUsername(au, null);
			this.GameNameLabel.Content = userName.GameName;
			this.TagLabel.Content = "#" + userName.TagLine;
			Inventory inv = Inventory.GetInventory(au);
			inventoryitems.Playercard p = inventoryitems.getPlayerCard(inv.Identity.PlayerCardID);
			this.playerCardImage.ImageSource = new BitmapImage(new Uri(p.displayIcon));
			this.PlayerTitleLabel.Content = inventoryitems.getPlayerTitle(inv.Identity.PlayerTitleID);
			Balance balance = Balance.GetBalance(au);
			this.valorantPointsLabel.Content = balance.ValorantPoints.ToString();
			this.radiantePointsLabel.Content = balance.RadianitePoints.ToString();
			this.homeUc = new HomeUC(MainWindow.currentAuth);
			this.cardUc = new EmptyUC();
			this.titleuc = new EmptyUC();
			foreach (JToken jtoken in ((IEnumerable<JToken>)JObject.Parse(new WebClient().DownloadString("https://valorant-api.com/v1/playertitles"))["data"]))
			{
				JObject card = (JObject)jtoken;
				if (card["titleText"].ToString() != "")
				{
					this.titleuc.itemPanel.Children.Add(new PlayerTitle(MainWindow.currentAuth, card["titleText"].ToString(), card["uuid"].ToString()));
				}
			}
			foreach (JToken jtoken2 in ((IEnumerable<JToken>)JObject.Parse(new WebClient().DownloadString("https://valorant-api.com/v1/playercards"))["data"]))
			{
				JObject card2 = (JObject)jtoken2;
				this.cardUc.itemPanel.Children.Add(new ItemCard(card2["displayIcon"].ToString(), card2["displayName"].ToString(), card2["uuid"].ToString(), MainWindow.currentAuth));
			}
			this.itemPanel.Children.Add(this.homeUc);
			MainWindow.mw = this;
			DiscordRPC.setState("Menu");
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00006980 File Offset: 0x00004B80
		public void StartValorant()
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

		// Token: 0x060001DA RID: 474 RVA: 0x000069DF File Offset: 0x00004BDF
		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				base.DragMove();
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000069EF File Offset: 0x00004BEF
		private void image_MouseEnter(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["DiscordButtonHover"]).Begin();
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00006A0B File Offset: 0x00004C0B
		private void image_MouseLeave(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["DiscordButtonHoverReverse"]).Begin();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00006A27 File Offset: 0x00004C27
		private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			"https://discord.gg/jh2zFyYWCY".UrlStart();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00006A34 File Offset: 0x00004C34
		private void homeLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.homeLabel.Foreground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.skinLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.cardLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.titleLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.shopLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.currentGameLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.scroll.ScrollToTop();
			this.itemPanel.Children.Clear();
			this.itemPanel.Children.Add(this.homeUc);
			DiscordRPC.setState("Menu");
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00006B44 File Offset: 0x00004D44
		private void swapLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DiscordRPC.setState("Skins");
			this.skinLabel.Foreground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.homeLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.cardLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.titleLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.shopLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.currentGameLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.scroll.ScrollToTop();
			this.itemPanel.Children.Clear();
			using (IEnumerator<JToken> enumerator = ((IEnumerable<JToken>)JObject.Parse(new WebClient().DownloadString("https://valorant-api.com/v1/weapons"))["data"]).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					JObject card = (JObject)enumerator.Current;
					WeaponDefault wp = new WeaponDefault(card["displayIcon"].ToString(), card["displayName"].ToString(), card["uuid"].ToString());
					wp.swaptoimage.MouseLeftButtonDown += delegate(object <p0>, MouseButtonEventArgs <p1>)
					{
						this.itemPanel.Children.Clear();
						this.scroll.ScrollToTop();
						List<object> list = new List<object>();
						foreach (JToken current in ((IEnumerable<JToken>)card["skins"]))
						{
							list.Add(current);
						}
						using (List<object>.Enumerator enumerator3 = list.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								dynamic d = enumerator3.Current;
								if (MainWindow.<>o__13.<>p__8 == null)
								{
									MainWindow.<>o__13.<>p__8 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, bool> target = MainWindow.<>o__13.<>p__8.Target;
								CallSite <>p__ = MainWindow.<>o__13.<>p__8;
								if (MainWindow.<>o__13.<>p__2 == null)
								{
									MainWindow.<>o__13.<>p__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(MainWindow), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								Func<CallSite, object, string, object> target2 = MainWindow.<>o__13.<>p__2.Target;
								CallSite <>p__2 = MainWindow.<>o__13.<>p__2;
								if (MainWindow.<>o__13.<>p__1 == null)
								{
									MainWindow.<>o__13.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, object> target3 = MainWindow.<>o__13.<>p__1.Target;
								CallSite <>p__3 = MainWindow.<>o__13.<>p__1;
								if (MainWindow.<>o__13.<>p__0 == null)
								{
									MainWindow.<>o__13.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayIcon", typeof(MainWindow), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								object obj = target2(<>p__2, target3(<>p__3, MainWindow.<>o__13.<>p__0.Target(MainWindow.<>o__13.<>p__0, d)), "");
								if (MainWindow.<>o__13.<>p__7 == null)
								{
									MainWindow.<>o__13.<>p__7 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(MainWindow), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								object arg2;
								if (!MainWindow.<>o__13.<>p__7.Target(MainWindow.<>o__13.<>p__7, obj))
								{
									if (MainWindow.<>o__13.<>p__6 == null)
									{
										MainWindow.<>o__13.<>p__6 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(MainWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, object, object> target4 = MainWindow.<>o__13.<>p__6.Target;
									CallSite <>p__4 = MainWindow.<>o__13.<>p__6;
									object arg = obj;
									if (MainWindow.<>o__13.<>p__5 == null)
									{
										MainWindow.<>o__13.<>p__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(MainWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									Func<CallSite, object, string, object> target5 = MainWindow.<>o__13.<>p__5.Target;
									CallSite <>p__5 = MainWindow.<>o__13.<>p__5;
									if (MainWindow.<>o__13.<>p__4 == null)
									{
										MainWindow.<>o__13.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, object> target6 = MainWindow.<>o__13.<>p__4.Target;
									CallSite <>p__6 = MainWindow.<>o__13.<>p__4;
									if (MainWindow.<>o__13.<>p__3 == null)
									{
										MainWindow.<>o__13.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									arg2 = target4(<>p__4, arg, target5(<>p__5, target6(<>p__6, MainWindow.<>o__13.<>p__3.Target(MainWindow.<>o__13.<>p__3, d)), ""));
								}
								else
								{
									arg2 = obj;
								}
								if (target(<>p__, arg2))
								{
									if (MainWindow.<>o__13.<>p__12 == null)
									{
										MainWindow.<>o__13.<>p__12 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, bool> target7 = MainWindow.<>o__13.<>p__12.Target;
									CallSite <>p__7 = MainWindow.<>o__13.<>p__12;
									if (MainWindow.<>o__13.<>p__11 == null)
									{
										MainWindow.<>o__13.<>p__11 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Contains", null, typeof(MainWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									Func<CallSite, object, string, object> target8 = MainWindow.<>o__13.<>p__11.Target;
									CallSite <>p__8 = MainWindow.<>o__13.<>p__11;
									if (MainWindow.<>o__13.<>p__10 == null)
									{
										MainWindow.<>o__13.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, object> target9 = MainWindow.<>o__13.<>p__10.Target;
									CallSite <>p__9 = MainWindow.<>o__13.<>p__10;
									if (MainWindow.<>o__13.<>p__9 == null)
									{
										MainWindow.<>o__13.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									if (target7(<>p__7, target8(<>p__8, target9(<>p__9, MainWindow.<>o__13.<>p__9.Target(MainWindow.<>o__13.<>p__9, d)), "Standard")))
									{
										if (MainWindow.<>o__13.<>p__17 == null)
										{
											MainWindow.<>o__13.<>p__17 = CallSite<Func<CallSite, Type, string, object, object, WeaponDefault>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, Type, string, object, object, WeaponDefault> target10 = MainWindow.<>o__13.<>p__17.Target;
										CallSite <>p__10 = MainWindow.<>o__13.<>p__17;
										Type typeFromHandle = typeof(WeaponDefault);
										string arg3 = card["displayIcon"].ToString();
										if (MainWindow.<>o__13.<>p__14 == null)
										{
											MainWindow.<>o__13.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> target11 = MainWindow.<>o__13.<>p__14.Target;
										CallSite <>p__11 = MainWindow.<>o__13.<>p__14;
										if (MainWindow.<>o__13.<>p__13 == null)
										{
											MainWindow.<>o__13.<>p__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										object arg4 = target11(<>p__11, MainWindow.<>o__13.<>p__13.Target(MainWindow.<>o__13.<>p__13, d));
										if (MainWindow.<>o__13.<>p__16 == null)
										{
											MainWindow.<>o__13.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> target12 = MainWindow.<>o__13.<>p__16.Target;
										CallSite <>p__12 = MainWindow.<>o__13.<>p__16;
										if (MainWindow.<>o__13.<>p__15 == null)
										{
											MainWindow.<>o__13.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "uuid", typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										WeaponDefault element = target10(<>p__10, typeFromHandle, arg3, arg4, target12(<>p__12, MainWindow.<>o__13.<>p__15.Target(MainWindow.<>o__13.<>p__15, d)));
										this.itemPanel.Children.Add(element);
									}
									else
									{
										if (MainWindow.<>o__13.<>p__20 == null)
										{
											MainWindow.<>o__13.<>p__20 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(MainWindow)));
										}
										Func<CallSite, object, string> target13 = MainWindow.<>o__13.<>p__20.Target;
										CallSite <>p__13 = MainWindow.<>o__13.<>p__20;
										if (MainWindow.<>o__13.<>p__19 == null)
										{
											MainWindow.<>o__13.<>p__19 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> target14 = MainWindow.<>o__13.<>p__19.Target;
										CallSite <>p__14 = MainWindow.<>o__13.<>p__19;
										if (MainWindow.<>o__13.<>p__18 == null)
										{
											MainWindow.<>o__13.<>p__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayIcon", typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										string text = target13(<>p__13, target14(<>p__14, MainWindow.<>o__13.<>p__18.Target(MainWindow.<>o__13.<>p__18, d)));
										if (MainWindow.<>o__13.<>p__24 == null)
										{
											MainWindow.<>o__13.<>p__24 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, bool> target15 = MainWindow.<>o__13.<>p__24.Target;
										CallSite <>p__15 = MainWindow.<>o__13.<>p__24;
										if (MainWindow.<>o__13.<>p__23 == null)
										{
											MainWindow.<>o__13.<>p__23 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Contains", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target16 = MainWindow.<>o__13.<>p__23.Target;
										CallSite <>p__16 = MainWindow.<>o__13.<>p__23;
										if (MainWindow.<>o__13.<>p__22 == null)
										{
											MainWindow.<>o__13.<>p__22 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> target17 = MainWindow.<>o__13.<>p__22.Target;
										CallSite <>p__17 = MainWindow.<>o__13.<>p__22;
										if (MainWindow.<>o__13.<>p__21 == null)
										{
											MainWindow.<>o__13.<>p__21 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										if (target15(<>p__15, target16(<>p__16, target17(<>p__17, MainWindow.<>o__13.<>p__21.Target(MainWindow.<>o__13.<>p__21, d)), "Sovereign Marshal")))
										{
											text = "https://media.valorant-api.com/weaponskinchromas/18c67b9a-419d-aa6d-224f-869f7e541fff/displayicon.png";
										}
										else
										{
											if (MainWindow.<>o__13.<>p__28 == null)
											{
												MainWindow.<>o__13.<>p__28 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											Func<CallSite, object, bool> target18 = MainWindow.<>o__13.<>p__28.Target;
											CallSite <>p__18 = MainWindow.<>o__13.<>p__28;
											if (MainWindow.<>o__13.<>p__27 == null)
											{
												MainWindow.<>o__13.<>p__27 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Contains", null, typeof(MainWindow), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
												}));
											}
											Func<CallSite, object, string, object> target19 = MainWindow.<>o__13.<>p__27.Target;
											CallSite <>p__19 = MainWindow.<>o__13.<>p__27;
											if (MainWindow.<>o__13.<>p__26 == null)
											{
												MainWindow.<>o__13.<>p__26 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											Func<CallSite, object, object> target20 = MainWindow.<>o__13.<>p__26.Target;
											CallSite <>p__20 = MainWindow.<>o__13.<>p__26;
											if (MainWindow.<>o__13.<>p__25 == null)
											{
												MainWindow.<>o__13.<>p__25 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											if (target18(<>p__18, target19(<>p__19, target20(<>p__20, MainWindow.<>o__13.<>p__25.Target(MainWindow.<>o__13.<>p__25, d)), "Sovereign Guardian")))
											{
												text = "https://media.valorant-api.com/weaponskinchromas/df1786b2-4f3d-f207-b92c-0780f4dffb79/displayicon.png";
											}
											else
											{
												if (MainWindow.<>o__13.<>p__32 == null)
												{
													MainWindow.<>o__13.<>p__32 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, object, bool> target21 = MainWindow.<>o__13.<>p__32.Target;
												CallSite <>p__21 = MainWindow.<>o__13.<>p__32;
												if (MainWindow.<>o__13.<>p__31 == null)
												{
													MainWindow.<>o__13.<>p__31 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Contains", null, typeof(MainWindow), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
													}));
												}
												Func<CallSite, object, string, object> target22 = MainWindow.<>o__13.<>p__31.Target;
												CallSite <>p__22 = MainWindow.<>o__13.<>p__31;
												if (MainWindow.<>o__13.<>p__30 == null)
												{
													MainWindow.<>o__13.<>p__30 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, object, object> target23 = MainWindow.<>o__13.<>p__30.Target;
												CallSite <>p__23 = MainWindow.<>o__13.<>p__30;
												if (MainWindow.<>o__13.<>p__29 == null)
												{
													MainWindow.<>o__13.<>p__29 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												if (target21(<>p__21, target22(<>p__22, target23(<>p__23, MainWindow.<>o__13.<>p__29.Target(MainWindow.<>o__13.<>p__29, d)), "Prime Guardian")))
												{
													text = "https://media.valorant-api.com/weaponskinchromas/e2f5a979-4e9a-f931-7f52-d99f0ec4a61b/displayicon.png";
												}
											}
										}
										if (MainWindow.<>o__13.<>p__36 == null)
										{
											MainWindow.<>o__13.<>p__36 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, bool> target24 = MainWindow.<>o__13.<>p__36.Target;
										CallSite <>p__24 = MainWindow.<>o__13.<>p__36;
										if (MainWindow.<>o__13.<>p__35 == null)
										{
											MainWindow.<>o__13.<>p__35 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target25 = MainWindow.<>o__13.<>p__35.Target;
										CallSite <>p__25 = MainWindow.<>o__13.<>p__35;
										if (MainWindow.<>o__13.<>p__34 == null)
										{
											MainWindow.<>o__13.<>p__34 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> target26 = MainWindow.<>o__13.<>p__34.Target;
										CallSite <>p__26 = MainWindow.<>o__13.<>p__34;
										if (MainWindow.<>o__13.<>p__33 == null)
										{
											MainWindow.<>o__13.<>p__33 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										if (target24(<>p__24, target25(<>p__25, target26(<>p__26, MainWindow.<>o__13.<>p__33.Target(MainWindow.<>o__13.<>p__33, d)), "Melee")))
										{
											text = "https://media.valorant-api.com/weapons/2f59173c-4bed-b6c3-2191-dea9b58be9c7/displayicon.png";
										}
										if (MainWindow.<>o__13.<>p__40 == null)
										{
											MainWindow.<>o__13.<>p__40 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, bool> target27 = MainWindow.<>o__13.<>p__40.Target;
										CallSite <>p__27 = MainWindow.<>o__13.<>p__40;
										if (MainWindow.<>o__13.<>p__39 == null)
										{
											MainWindow.<>o__13.<>p__39 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
											}));
										}
										Func<CallSite, object, string, object> target28 = MainWindow.<>o__13.<>p__39.Target;
										CallSite <>p__28 = MainWindow.<>o__13.<>p__39;
										if (MainWindow.<>o__13.<>p__38 == null)
										{
											MainWindow.<>o__13.<>p__38 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> target29 = MainWindow.<>o__13.<>p__38.Target;
										CallSite <>p__29 = MainWindow.<>o__13.<>p__38;
										if (MainWindow.<>o__13.<>p__37 == null)
										{
											MainWindow.<>o__13.<>p__37 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										if (target27(<>p__27, target28(<>p__28, target29(<>p__29, MainWindow.<>o__13.<>p__37.Target(MainWindow.<>o__13.<>p__37, d)), "Luxe Knife")))
										{
											text = "https://media.valorant-api.com/weaponskinchromas/6226d393-49d1-4a15-cb52-c8bce5fc135a/fullrender.png";
										}
										if (MainWindow.<>o__13.<>p__45 == null)
										{
											MainWindow.<>o__13.<>p__45 = CallSite<Func<CallSite, Type, string, object, object, WeaponDefault>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, Type, string, object, object, WeaponDefault> target30 = MainWindow.<>o__13.<>p__45.Target;
										CallSite <>p__30 = MainWindow.<>o__13.<>p__45;
										Type typeFromHandle2 = typeof(WeaponDefault);
										string arg5 = text;
										if (MainWindow.<>o__13.<>p__42 == null)
										{
											MainWindow.<>o__13.<>p__42 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> target31 = MainWindow.<>o__13.<>p__42.Target;
										CallSite <>p__31 = MainWindow.<>o__13.<>p__42;
										if (MainWindow.<>o__13.<>p__41 == null)
										{
											MainWindow.<>o__13.<>p__41 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										object arg6 = target31(<>p__31, MainWindow.<>o__13.<>p__41.Target(MainWindow.<>o__13.<>p__41, d));
										if (MainWindow.<>o__13.<>p__44 == null)
										{
											MainWindow.<>o__13.<>p__44 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> target32 = MainWindow.<>o__13.<>p__44.Target;
										CallSite <>p__32 = MainWindow.<>o__13.<>p__44;
										if (MainWindow.<>o__13.<>p__43 == null)
										{
											MainWindow.<>o__13.<>p__43 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "uuid", typeof(MainWindow), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										WeaponDefault weaponDefault = target30(<>p__30, typeFromHandle2, arg5, arg6, target32(<>p__32, MainWindow.<>o__13.<>p__43.Target(MainWindow.<>o__13.<>p__43, d)));
										weaponDefault.swaptoimage.MouseLeftButtonDown += delegate(object <p0>, MouseButtonEventArgs <p1>)
										{
											if (MainWindow.<>o__13.<>p__47 == null)
											{
												MainWindow.<>o__13.<>p__47 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(MainWindow)));
											}
											Func<CallSite, object, int> target33 = MainWindow.<>o__13.<>p__47.Target;
											CallSite <>p__33 = MainWindow.<>o__13.<>p__47;
											if (MainWindow.<>o__13.<>p__46 == null)
											{
												MainWindow.<>o__13.<>p__46 = CallSite<Func<CallSite, MainWindow, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName, "getColorOptionsAmount", null, typeof(MainWindow), new CSharpArgumentInfo[]
												{
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
													CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
												}));
											}
											if (target33(<>p__33, MainWindow.<>o__13.<>p__46.Target(MainWindow.<>o__13.<>p__46, this, d)) != 1)
											{
												this.itemPanel.Children.Clear();
												this.scroll.ScrollToTop();
												if (MainWindow.<>o__13.<>p__74 == null)
												{
													MainWindow.<>o__13.<>p__74 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(MainWindow)));
												}
												Func<CallSite, object, IEnumerable> target34 = MainWindow.<>o__13.<>p__74.Target;
												CallSite <>p__34 = MainWindow.<>o__13.<>p__74;
												if (MainWindow.<>o__13.<>p__48 == null)
												{
													MainWindow.<>o__13.<>p__48 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "chromas", typeof(MainWindow), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												using (IEnumerator enumerator4 = target34(<>p__34, MainWindow.<>o__13.<>p__48.Target(MainWindow.<>o__13.<>p__48, d)).GetEnumerator())
												{
													while (enumerator4.MoveNext())
													{
														dynamic option = enumerator4.Current;
														if (MainWindow.<>o__13.<>p__51 == null)
														{
															MainWindow.<>o__13.<>p__51 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
															}));
														}
														Func<CallSite, object, string, object> target35 = MainWindow.<>o__13.<>p__51.Target;
														CallSite <>p__35 = MainWindow.<>o__13.<>p__51;
														if (MainWindow.<>o__13.<>p__50 == null)
														{
															MainWindow.<>o__13.<>p__50 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, object> target36 = MainWindow.<>o__13.<>p__50.Target;
														CallSite <>p__36 = MainWindow.<>o__13.<>p__50;
														if (MainWindow.<>o__13.<>p__49 == null)
														{
															MainWindow.<>o__13.<>p__49 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayIcon", typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														object obj2 = target35(<>p__35, target36(<>p__36, MainWindow.<>o__13.<>p__49.Target(MainWindow.<>o__13.<>p__49, option)), "");
														if (MainWindow.<>o__13.<>p__56 == null)
														{
															MainWindow.<>o__13.<>p__56 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														if (MainWindow.<>o__13.<>p__56.Target(MainWindow.<>o__13.<>p__56, obj2))
														{
															goto IL_411;
														}
														if (MainWindow.<>o__13.<>p__55 == null)
														{
															MainWindow.<>o__13.<>p__55 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, bool> target37 = MainWindow.<>o__13.<>p__55.Target;
														CallSite <>p__37 = MainWindow.<>o__13.<>p__55;
														if (MainWindow.<>o__13.<>p__54 == null)
														{
															MainWindow.<>o__13.<>p__54 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.Or, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, object, object> target38 = MainWindow.<>o__13.<>p__54.Target;
														CallSite <>p__38 = MainWindow.<>o__13.<>p__54;
														object arg7 = obj2;
														if (MainWindow.<>o__13.<>p__53 == null)
														{
															MainWindow.<>o__13.<>p__53 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
															}));
														}
														Func<CallSite, object, object, object> target39 = MainWindow.<>o__13.<>p__53.Target;
														CallSite <>p__39 = MainWindow.<>o__13.<>p__53;
														if (MainWindow.<>o__13.<>p__52 == null)
														{
															MainWindow.<>o__13.<>p__52 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayIcon", typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														if (target37(<>p__37, target38(<>p__38, arg7, target39(<>p__39, MainWindow.<>o__13.<>p__52.Target(MainWindow.<>o__13.<>p__52, option), null))))
														{
															goto IL_411;
														}
														if (MainWindow.<>o__13.<>p__62 == null)
														{
															MainWindow.<>o__13.<>p__62 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(MainWindow)));
														}
														Func<CallSite, object, string> target40 = MainWindow.<>o__13.<>p__62.Target;
														CallSite <>p__40 = MainWindow.<>o__13.<>p__62;
														if (MainWindow.<>o__13.<>p__61 == null)
														{
															MainWindow.<>o__13.<>p__61 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, object> target41 = MainWindow.<>o__13.<>p__61.Target;
														CallSite <>p__41 = MainWindow.<>o__13.<>p__61;
														if (MainWindow.<>o__13.<>p__60 == null)
														{
															MainWindow.<>o__13.<>p__60 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayIcon", typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														string shimo = target40(<>p__40, target41(<>p__41, MainWindow.<>o__13.<>p__60.Target(MainWindow.<>o__13.<>p__60, option)));
														IL_5CC:
														if (MainWindow.<>o__13.<>p__65 == null)
														{
															MainWindow.<>o__13.<>p__65 = CallSite<Func<CallSite, Type, string, object, string, WeaponDefault>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
															}));
														}
														Func<CallSite, Type, string, object, string, WeaponDefault> target42 = MainWindow.<>o__13.<>p__65.Target;
														CallSite <>p__42 = MainWindow.<>o__13.<>p__65;
														Type typeFromHandle3 = typeof(WeaponDefault);
														string arg8 = shimo;
														if (MainWindow.<>o__13.<>p__64 == null)
														{
															MainWindow.<>o__13.<>p__64 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, object> target43 = MainWindow.<>o__13.<>p__64.Target;
														CallSite <>p__43 = MainWindow.<>o__13.<>p__64;
														if (MainWindow.<>o__13.<>p__63 == null)
														{
															MainWindow.<>o__13.<>p__63 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														WeaponDefault optionC = target42(<>p__42, typeFromHandle3, arg8, target43(<>p__43, MainWindow.<>o__13.<>p__63.Target(MainWindow.<>o__13.<>p__63, option)), "");
														this.itemPanel.Children.Add(optionC);
														optionC.swaptoimage.MouseLeftButtonDown += delegate(object <p0>, MouseButtonEventArgs <p1>)
														{
															RiotClient.Root playerLoadout2 = RiotClient.GetPlayerLoadout(MainWindow.currentAuth);
															foreach (RiotClient.Gun current3 in playerLoadout2.Guns)
															{
																if (current3.ID == card["uuid"].ToString())
																{
																	RiotClient.Gun gun2 = current3;
																	if (MainWindow.<>o__13.<>p__68 == null)
																	{
																		MainWindow.<>o__13.<>p__68 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(MainWindow)));
																	}
																	Func<CallSite, object, string> target49 = MainWindow.<>o__13.<>p__68.Target;
																	CallSite <>p__49 = MainWindow.<>o__13.<>p__68;
																	if (MainWindow.<>o__13.<>p__67 == null)
																	{
																		MainWindow.<>o__13.<>p__67 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
																		{
																			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																		}));
																	}
																	Func<CallSite, object, object> target50 = MainWindow.<>o__13.<>p__67.Target;
																	CallSite <>p__50 = MainWindow.<>o__13.<>p__67;
																	if (MainWindow.<>o__13.<>p__66 == null)
																	{
																		MainWindow.<>o__13.<>p__66 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "uuid", typeof(MainWindow), new CSharpArgumentInfo[]
																		{
																			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																		}));
																	}
																	gun2.SkinID = target49(<>p__49, target50(<>p__50, MainWindow.<>o__13.<>p__66.Target(MainWindow.<>o__13.<>p__66, d)));
																	RiotClient.Gun gun3 = current3;
																	if (MainWindow.<>o__13.<>p__71 == null)
																	{
																		MainWindow.<>o__13.<>p__71 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(MainWindow)));
																	}
																	Func<CallSite, object, string> target51 = MainWindow.<>o__13.<>p__71.Target;
																	CallSite <>p__51 = MainWindow.<>o__13.<>p__71;
																	if (MainWindow.<>o__13.<>p__70 == null)
																	{
																		MainWindow.<>o__13.<>p__70 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
																		{
																			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																		}));
																	}
																	Func<CallSite, object, object> target52 = MainWindow.<>o__13.<>p__70.Target;
																	CallSite <>p__52 = MainWindow.<>o__13.<>p__70;
																	if (MainWindow.<>o__13.<>p__69 == null)
																	{
																		MainWindow.<>o__13.<>p__69 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "uuid", typeof(MainWindow), new CSharpArgumentInfo[]
																		{
																			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																		}));
																	}
																	gun3.ChromaID = target51(<>p__51, target52(<>p__52, MainWindow.<>o__13.<>p__69.Target(MainWindow.<>o__13.<>p__69, option)));
																}
															}
															if (MainWindow.SetLoadout(playerLoadout2, MainWindow.currentAuth))
															{
																DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(30, 2);
																defaultInterpolatedStringHandler2.AppendLiteral("Successfully changed ");
																defaultInterpolatedStringHandler2.AppendFormatted<object>(wp.itemNameLabel.Content);
																defaultInterpolatedStringHandler2.AppendLiteral(" Skin to ");
																if (MainWindow.<>o__13.<>p__73 == null)
																{
																	MainWindow.<>o__13.<>p__73 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
																	{
																		CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																	}));
																}
																Func<CallSite, object, object> target53 = MainWindow.<>o__13.<>p__73.Target;
																CallSite <>p__53 = MainWindow.<>o__13.<>p__73;
																if (MainWindow.<>o__13.<>p__72 == null)
																{
																	MainWindow.<>o__13.<>p__72 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
																	{
																		CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																	}));
																}
																defaultInterpolatedStringHandler2.AppendFormatted<object>(target53(<>p__53, MainWindow.<>o__13.<>p__72.Target(MainWindow.<>o__13.<>p__72, d)));
																MessageBox.Show(defaultInterpolatedStringHandler2.ToStringAndClear(), "Elsify");
															}
														};
														continue;
														IL_411:
														if (MainWindow.<>o__13.<>p__59 == null)
														{
															MainWindow.<>o__13.<>p__59 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(MainWindow)));
														}
														Func<CallSite, object, string> target44 = MainWindow.<>o__13.<>p__59.Target;
														CallSite <>p__44 = MainWindow.<>o__13.<>p__59;
														if (MainWindow.<>o__13.<>p__58 == null)
														{
															MainWindow.<>o__13.<>p__58 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, object> target45 = MainWindow.<>o__13.<>p__58.Target;
														CallSite <>p__45 = MainWindow.<>o__13.<>p__58;
														if (MainWindow.<>o__13.<>p__57 == null)
														{
															MainWindow.<>o__13.<>p__57 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "fullRender", typeof(MainWindow), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														shimo = target44(<>p__44, target45(<>p__45, MainWindow.<>o__13.<>p__57.Target(MainWindow.<>o__13.<>p__57, option)));
														goto IL_5CC;
													}
													return;
												}
											}
											RiotClient.Root playerLoadout = RiotClient.GetPlayerLoadout(MainWindow.currentAuth);
											foreach (RiotClient.Gun current2 in playerLoadout.Guns)
											{
												if (current2.ID == card["uuid"].ToString())
												{
													RiotClient.Gun gun = current2;
													if (MainWindow.<>o__13.<>p__77 == null)
													{
														MainWindow.<>o__13.<>p__77 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(MainWindow)));
													}
													Func<CallSite, object, string> target46 = MainWindow.<>o__13.<>p__77.Target;
													CallSite <>p__46 = MainWindow.<>o__13.<>p__77;
													if (MainWindow.<>o__13.<>p__76 == null)
													{
														MainWindow.<>o__13.<>p__76 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
														{
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
														}));
													}
													Func<CallSite, object, object> target47 = MainWindow.<>o__13.<>p__76.Target;
													CallSite <>p__47 = MainWindow.<>o__13.<>p__76;
													if (MainWindow.<>o__13.<>p__75 == null)
													{
														MainWindow.<>o__13.<>p__75 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "uuid", typeof(MainWindow), new CSharpArgumentInfo[]
														{
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
														}));
													}
													gun.SkinID = target46(<>p__46, target47(<>p__47, MainWindow.<>o__13.<>p__75.Target(MainWindow.<>o__13.<>p__75, d)));
													current2.ChromaID = "";
													current2.SkinLevelID = "";
												}
											}
											if (MainWindow.SetLoadout(playerLoadout, MainWindow.currentAuth))
											{
												DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
												defaultInterpolatedStringHandler.AppendLiteral("Successfully changed ");
												defaultInterpolatedStringHandler.AppendFormatted<object>(wp.itemNameLabel.Content);
												defaultInterpolatedStringHandler.AppendLiteral(" Skin to ");
												if (MainWindow.<>o__13.<>p__79 == null)
												{
													MainWindow.<>o__13.<>p__79 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(MainWindow), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Func<CallSite, object, object> target48 = MainWindow.<>o__13.<>p__79.Target;
												CallSite <>p__48 = MainWindow.<>o__13.<>p__79;
												if (MainWindow.<>o__13.<>p__78 == null)
												{
													MainWindow.<>o__13.<>p__78 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "displayName", typeof(MainWindow), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												defaultInterpolatedStringHandler.AppendFormatted<object>(target48(<>p__48, MainWindow.<>o__13.<>p__78.Target(MainWindow.<>o__13.<>p__78, d)));
												MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear(), "Elsify");
											}
										};
										this.itemPanel.Children.Add(weaponDefault);
									}
								}
							}
						}
					};
					this.itemPanel.Children.Add(wp);
				}
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00006D28 File Offset: 0x00004F28
		public int getColorOptionsAmount(dynamic d)
		{
			int i = -1;
			if (MainWindow.<>o__14.<>p__1 == null)
			{
				MainWindow.<>o__14.<>p__1 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(MainWindow)));
			}
			Func<CallSite, object, IEnumerable> target = MainWindow.<>o__14.<>p__1.Target;
			CallSite <>p__ = MainWindow.<>o__14.<>p__1;
			if (MainWindow.<>o__14.<>p__0 == null)
			{
				MainWindow.<>o__14.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "chromas", typeof(MainWindow), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			foreach (object obj in target(<>p__, MainWindow.<>o__14.<>p__0.Target(MainWindow.<>o__14.<>p__0, d)))
			{
				i++;
			}
			return i;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00006E00 File Offset: 0x00005000
		public int getLevelOptionsAmount(dynamic d)
		{
			if (MainWindow.<>o__15.<>p__2 == null)
			{
				MainWindow.<>o__15.<>p__2 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(MainWindow)));
			}
			Func<CallSite, object, int> target = MainWindow.<>o__15.<>p__2.Target;
			CallSite <>p__ = MainWindow.<>o__15.<>p__2;
			if (MainWindow.<>o__15.<>p__1 == null)
			{
				MainWindow.<>o__15.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Count", typeof(MainWindow), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object> target2 = MainWindow.<>o__15.<>p__1.Target;
			CallSite <>p__2 = MainWindow.<>o__15.<>p__1;
			if (MainWindow.<>o__15.<>p__0 == null)
			{
				MainWindow.<>o__15.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "levels", typeof(MainWindow), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			return target(<>p__, target2(<>p__2, MainWindow.<>o__15.<>p__0.Target(MainWindow.<>o__15.<>p__0, d)));
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00006EE1 File Offset: 0x000050E1
		public static bool SetLoadout(RiotClient.Root value, Auth au)
		{
			return RiotClient.SetPlayerLoadout(value, au);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00006EEC File Offset: 0x000050EC
		private void settingsLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DiscordRPC.setState("Settings");
			this.settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.skinLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.homeLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.cardLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.titleLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.shopLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.currentGameLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.scroll.ScrollToTop();
			this.itemPanel.Children.Clear();
			this.itemPanel.Children.Add(new SettingsUc());
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00006FFC File Offset: 0x000051FC
		private void titleLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DiscordRPC.setState("Player Titles");
			this.titleLabel.Foreground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.skinLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.homeLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.cardLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.shopLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.currentGameLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.itemPanel.Children.Clear();
			this.scroll.ScrollToTop();
			this.itemPanel.Children.Add(this.titleuc);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000710C File Offset: 0x0000530C
		private void cardLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DiscordRPC.setState("Player Cards");
			this.cardLabel.Foreground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.skinLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.homeLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.titleLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.shopLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.currentGameLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.scroll.ScrollToTop();
			this.itemPanel.Children.Clear();
			this.itemPanel.Children.Add(this.cardUc);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000721C File Offset: 0x0000541C
		private void shopLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DiscordRPC.setState("Shop");
			this.shopLabel.Foreground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.skinLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.homeLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.titleLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.cardLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.currentGameLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.scroll.ScrollToTop();
			this.itemPanel.Children.Clear();
			this.itemPanel.Children.Add(new ShopUC(MainWindow.currentAuth));
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000732F File Offset: 0x0000552F
		private void exitButton_MouseEnter(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ExitButtonHover"]).Begin();
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000734B File Offset: 0x0000554B
		private void exitButton_MouseLeave(object sender, MouseEventArgs e)
		{
			((Storyboard)base.Resources["ExitButtonHoverReverse"]).Begin();
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00007367 File Offset: 0x00005567
		private void exitButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00007370 File Offset: 0x00005570
		private void currentGameLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (this.currentGame == null)
			{
				this.currentGame = new CurrentGameUC(MainWindow.currentAuth);
			}
			DiscordRPC.setState("Current Game");
			this.currentGameLabel.Foreground = new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
			this.skinLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.homeLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.titleLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.cardLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.shopLabel.Foreground = new SolidColorBrush(Color.FromRgb(113, 115, 119));
			this.scroll.ScrollToTop();
			this.itemPanel.Children.Clear();
			this.itemPanel.Children.Add(this.currentGame);
		}

		// Token: 0x040000ED RID: 237
		public static Auth currentAuth;

		// Token: 0x040000EE RID: 238
		public HomeUC homeUc;

		// Token: 0x040000EF RID: 239
		public EmptyUC cardUc;

		// Token: 0x040000F0 RID: 240
		public EmptyUC titleuc;

		// Token: 0x040000F1 RID: 241
		public CurrentGameUC currentGame;

		// Token: 0x040000F2 RID: 242
		public static MainWindow mw;
	}
}
