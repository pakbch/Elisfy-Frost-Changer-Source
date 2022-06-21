using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using ValAPINet;

namespace Elsify_v2_Ingame.Home
{
	// Token: 0x0200003E RID: 62
	public partial class HomeUC : UserControl
	{
		// Token: 0x06000279 RID: 633 RVA: 0x0000A734 File Offset: 0x00008934
		[NullableContext(1)]
		public HomeUC(Auth au)
		{
			this.InitializeComponent();
			Username userName = Username.GetUsername(au, null);
			this.te.Text = "Welcome " + userName.GameName;
			this.patchnotes.Content = "• Initial Release of Elsify v2\n• Added Collection Changer\n• Performance issues for certain devices got fixed\n• Updated the SSL Certificate for the Auth System";
			JObject a = JObject.Parse(new WebClient().DownloadString("https://api.henrikdev.xyz/valorant/v1/website/en-us"));
			using (List<object>.Enumerator enumerator = new List<object>
			{
				a["data"][0],
				a["data"][1],
				a["data"][2],
				a["data"][3],
				a["data"][4],
				a["data"][5],
				a["data"][6],
				a["data"][7]
			}.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					dynamic info = enumerator.Current;
					if (HomeUC.<>o__0.<>p__4 == null)
					{
						HomeUC.<>o__0.<>p__4 = CallSite<Func<CallSite, Type, object, object, string, WeaponDefault>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(HomeUC), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, Type, object, object, string, WeaponDefault> target = HomeUC.<>o__0.<>p__4.Target;
					CallSite <>p__ = HomeUC.<>o__0.<>p__4;
					Type typeFromHandle = typeof(WeaponDefault);
					if (HomeUC.<>o__0.<>p__1 == null)
					{
						HomeUC.<>o__0.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(HomeUC), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> target2 = HomeUC.<>o__0.<>p__1.Target;
					CallSite <>p__2 = HomeUC.<>o__0.<>p__1;
					if (HomeUC.<>o__0.<>p__0 == null)
					{
						HomeUC.<>o__0.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(HomeUC), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					object arg = target2(<>p__2, HomeUC.<>o__0.<>p__0.Target(HomeUC.<>o__0.<>p__0, info, "banner_url"));
					if (HomeUC.<>o__0.<>p__3 == null)
					{
						HomeUC.<>o__0.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(HomeUC), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> target3 = HomeUC.<>o__0.<>p__3.Target;
					CallSite <>p__3 = HomeUC.<>o__0.<>p__3;
					if (HomeUC.<>o__0.<>p__2 == null)
					{
						HomeUC.<>o__0.<>p__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(HomeUC), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					WeaponDefault b = target(<>p__, typeFromHandle, arg, target3(<>p__3, HomeUC.<>o__0.<>p__2.Target(HomeUC.<>o__0.<>p__2, info, "title")), "");
					b.itemNameLabel.FontSize = 8.0;
					b.swaptoimage.MouseLeftButtonDown += delegate(object <p0>, MouseButtonEventArgs <p1>)
					{
						if (HomeUC.<>o__0.<>p__7 == null)
						{
							HomeUC.<>o__0.<>p__7 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(HomeUC), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, bool> target4 = HomeUC.<>o__0.<>p__7.Target;
						CallSite <>p__4 = HomeUC.<>o__0.<>p__7;
						if (HomeUC.<>o__0.<>p__6 == null)
						{
							HomeUC.<>o__0.<>p__6 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(HomeUC), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, object, object> target5 = HomeUC.<>o__0.<>p__6.Target;
						CallSite <>p__5 = HomeUC.<>o__0.<>p__6;
						if (HomeUC.<>o__0.<>p__5 == null)
						{
							HomeUC.<>o__0.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "external_link", typeof(HomeUC), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						if (target4(<>p__4, target5(<>p__5, HomeUC.<>o__0.<>p__5.Target(HomeUC.<>o__0.<>p__5, info), null)))
						{
							if (HomeUC.<>o__0.<>p__10 == null)
							{
								HomeUC.<>o__0.<>p__10 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "UrlStart", null, typeof(HomeUC), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Action<CallSite, Type, object> target6 = HomeUC.<>o__0.<>p__10.Target;
							CallSite <>p__6 = HomeUC.<>o__0.<>p__10;
							Type typeFromHandle2 = typeof(Utiels);
							if (HomeUC.<>o__0.<>p__9 == null)
							{
								HomeUC.<>o__0.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(HomeUC), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object> target7 = HomeUC.<>o__0.<>p__9.Target;
							CallSite <>p__7 = HomeUC.<>o__0.<>p__9;
							if (HomeUC.<>o__0.<>p__8 == null)
							{
								HomeUC.<>o__0.<>p__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(HomeUC), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							target6(<>p__6, typeFromHandle2, target7(<>p__7, HomeUC.<>o__0.<>p__8.Target(HomeUC.<>o__0.<>p__8, info, "url")));
							return;
						}
						if (HomeUC.<>o__0.<>p__13 == null)
						{
							HomeUC.<>o__0.<>p__13 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "UrlStart", null, typeof(HomeUC), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Action<CallSite, Type, object> target8 = HomeUC.<>o__0.<>p__13.Target;
						CallSite <>p__8 = HomeUC.<>o__0.<>p__13;
						Type typeFromHandle3 = typeof(Utiels);
						if (HomeUC.<>o__0.<>p__12 == null)
						{
							HomeUC.<>o__0.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(HomeUC), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object> target9 = HomeUC.<>o__0.<>p__12.Target;
						CallSite <>p__9 = HomeUC.<>o__0.<>p__12;
						if (HomeUC.<>o__0.<>p__11 == null)
						{
							HomeUC.<>o__0.<>p__11 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(HomeUC), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						target8(<>p__8, typeFromHandle3, target9(<>p__9, HomeUC.<>o__0.<>p__11.Target(HomeUC.<>o__0.<>p__11, info, "external_link")));
					};
					this.itemPanel.Children.Add(b);
				}
			}
		}
	}
}
