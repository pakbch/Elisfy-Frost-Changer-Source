using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Elsify_v2.ValAPINet;
using ValAPINet;
using Woe.ValAPINet;

namespace Elsify_v2.CurrentGame
{
	// Token: 0x02000026 RID: 38
	public partial class CurrentGameUC : UserControl
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x00005CD0 File Offset: 0x00003ED0
		[NullableContext(1)]
		public CurrentGameUC(Auth au)
		{
			CurrentGameUC.<>c__DisplayClass2_0 CS$<>8__locals1 = new CurrentGameUC.<>c__DisplayClass2_0();
			CS$<>8__locals1.au = au;
			base..ctor();
			CS$<>8__locals1.<>4__this = this;
			this.InitializeComponent();
			CurrentGameUC.matchID = "";
			CurrentGameUC.pregameMatchID = "";
			using (List<Agents.agent>.Enumerator enumerator = Agents.GetAgents().data.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Agents.agent current = enumerator.Current;
					CurrentGamePlayer d = new CurrentGamePlayer(current.displayIcon, current.displayName, true);
					d.labelitem2.MouseLeftButtonDown += delegate(object <p0>, MouseButtonEventArgs <p1>)
					{
						SelectAgent.LockAgent(CS$<>8__locals1.au, CurrentGameUC.pregameMatchID, current.uuid);
						MessageBox.Show("Locked " + current.displayName, "Elsify v2", MessageBoxButton.OK, MessageBoxImage.Asterisk);
					};
					this.flowlayoutPanel1.Children.Add(d);
				}
			}
			DispatcherTimer dt = new DispatcherTimer();
			dt.Interval = new TimeSpan(0, 0, 5);
			dt.Tick += delegate([Nullable(2)] object <p0>, EventArgs <p1>)
			{
				try
				{
					RichPresence richPresence = RichPresence.GetRichPresence(CS$<>8__locals1.au);
					if (richPresence.loopState.ToLower().Contains("menus"))
					{
						CS$<>8__locals1.<>4__this.NotInGameGrid.Visibility = Visibility.Visible;
						CS$<>8__locals1.<>4__this.PreGameGrid.Visibility = Visibility.Hidden;
						CS$<>8__locals1.<>4__this.IngameGrid.Visibility = Visibility.Hidden;
					}
					else
					{
						CS$<>8__locals1.<>4__this.NotInGameGrid.Visibility = Visibility.Hidden;
						CS$<>8__locals1.<>4__this.PreGameGrid.Visibility = Visibility.Hidden;
						CS$<>8__locals1.<>4__this.IngameGrid.Visibility = Visibility.Hidden;
						if (richPresence.loopState.ToLower().Contains("pregame"))
						{
							PregameGetPlayer player2 = PregameGetPlayer.GetPlayer(CS$<>8__locals1.au, "useauth");
							if (CurrentGameUC.pregameMatchID != player2.MatchID)
							{
								CurrentGameUC.pregameMatchID = player2.MatchID;
								CS$<>8__locals1.<>4__this.pregameID.Content = "Pregame MatchID: " + player2.MatchID;
							}
							CS$<>8__locals1.<>4__this.PreGameGrid.Visibility = Visibility.Visible;
						}
						else
						{
							CoreGetPlayer player3 = CoreGetPlayer.GetPlayer(CS$<>8__locals1.au, "useauth");
							if (CurrentGameUC.matchID != player3.MatchID)
							{
								CS$<>8__locals1.<>4__this.flowlayoutPanel.Children.Clear();
								CurrentGameUC.matchID = player3.MatchID;
								CS$<>8__locals1.<>4__this.gameID.Content = "MatchID: " + player3.MatchID;
								CoreGetMatch match = CoreGetMatch.GetMatch(CS$<>8__locals1.au, player3.MatchID);
								foreach (CoreGetMatch.Player player4 in match.Players)
								{
									Username username = Username.GetUsername(CS$<>8__locals1.au, player4.Subject);
									string image = "";
									foreach (Agents.agent current in Agents.GetAgents().data)
									{
										if (current.uuid == player4.CharacterID)
										{
											string displayName = current.displayName;
											image = current.displayIcon;
										}
									}
									CurrentGamePlayer currentGamePlayer = new CurrentGamePlayer(image, username.GameName + "#" + username.TagLine, false);
									CS$<>8__locals1.<>4__this.flowlayoutPanel.Children.Add(currentGamePlayer);
								}
								CS$<>8__locals1.<>4__this.gamdeModeLabel.Content = "Mode: " + CurrentGameUC.GetModeName(match.ModeID);
								CS$<>8__locals1.<>4__this.mapName.Content = "Map: " + CS$<>8__locals1.<>4__this.GetMapName(match.MapID);
							}
							CS$<>8__locals1.<>4__this.IngameGrid.Visibility = Visibility.Visible;
						}
					}
				}
				catch (Exception)
				{
				}
			};
			using (BackgroundWorker bg = new BackgroundWorker())
			{
				bg.DoWork += delegate([Nullable(2)] object <p0>, DoWorkEventArgs <p1>)
				{
					dt.Start();
				};
				bg.RunWorkerAsync();
			}
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00005E34 File Offset: 0x00004034
		[NullableContext(1)]
		public string GetMapName(string mapid)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(mapid);
			if (num <= 1705436070U)
			{
				if (num <= 380974160U)
				{
					if (num != 63002916U)
					{
						if (num == 380974160U)
						{
							if (mapid == "/Game/Maps/Bonsai/Bonsai")
							{
								return "Split";
							}
						}
					}
					else if (mapid == "/Game/Maps/Canyon/Canyon")
					{
						return "Fracture";
					}
				}
				else if (num != 1502904922U)
				{
					if (num == 1705436070U)
					{
						if (mapid == "/Game/Maps/Port/Port")
						{
							return "Icebox";
						}
					}
				}
				else if (mapid == "/Game/Maps/Foxtrot/Foxtrot")
				{
					return "Breeze";
				}
			}
			else if (num <= 2348827294U)
			{
				if (num != 2254727300U)
				{
					if (num == 2348827294U)
					{
						if (mapid == "/Game/Maps/Duality/Duality")
						{
							return "Bind";
						}
					}
				}
				else if (mapid == "/Game/Maps/Poveglia/Range")
				{
					return "The Range";
				}
			}
			else if (num != 2876087826U)
			{
				if (num == 3019506032U)
				{
					if (mapid == "/Game/Maps/Ascent/Ascent")
					{
						return "Ascent";
					}
				}
			}
			else if (mapid == "/Game/Maps/Triad/Triad")
			{
				return "Haven";
			}
			return mapid;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00005F80 File Offset: 0x00004180
		[NullableContext(1)]
		public static string GetModeName(string mode)
		{
			string result;
			if (!(mode == "/Game/GameModes/Bomb/BombGameMode.BombGameMode_C"))
			{
				if (!(mode == "/Game/GameModes/Deathmatch/DeathmatchGameMode.DeathmatchGameMode_C"))
				{
					if (!(mode == "/Game/GameModes/GunGame/GunGameTeamsGameMode.GunGameTeamsGameMode_C"))
					{
						if (!(mode == "/Game/GameModes/OneForAll/OneForAll_GameMode.OneForAll_GameMode_C"))
						{
							if (!(mode == "/Game/GameModes/QuickBomb/QuickBombGameMode.QuickBombGameMode_C"))
							{
								if (!(mode == "/Game/GameModes/ShootingRange/ShootingRangeGameMode.ShootingRangeGameMode_C"))
								{
									result = "Unknown Mode";
								}
								else
								{
									result = "Shooting Range";
								}
							}
							else
							{
								result = "Spike Rush";
							}
						}
						else
						{
							result = "Replication";
						}
					}
					else
					{
						result = "Escalation";
					}
				}
				else
				{
					result = "Deathmatch";
				}
			}
			else
			{
				result = "Unrated";
			}
			return result;
		}

		// Token: 0x040000D3 RID: 211
		[Nullable(1)]
		public static string matchID = "";

		// Token: 0x040000D4 RID: 212
		[Nullable(1)]
		public static string pregameMatchID = "";
	}
}
