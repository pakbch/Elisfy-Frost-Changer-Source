using System;
using System.Net;
using System.Runtime.CompilerServices;
using DiscordRPC;

namespace Elsify_v2_Ingame
{
	// Token: 0x02000029 RID: 41
	[NullableContext(1)]
	[Nullable(0)]
	internal class DiscordRPC
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x000062FE File Offset: 0x000044FE
		public static void InitializeRPC()
		{
			DiscordRPC.client = new DiscordRpcClient("914553067096129607");
			DiscordRPC.client.Initialize();
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000631C File Offset: 0x0000451C
		public static void setState(string state)
		{
			new WebClient();
			Button[] buttons = new Button[]
			{
				new Button
				{
					Label = "Discord",
					Url = "https://discord.gg/KHjmDZ8DJD"
				},
				new Button
				{
					Label = "Download",
					Url = "https://frostchanger.de"
				}
			};
			DiscordRPC.client.SetPresence(new RichPresence
			{
				Details = "Valorant Skin Changer",
				State = state,
				Buttons = buttons,
				Timestamps = new Timestamps
				{
					Start = new DateTime?(DateTime.UtcNow)
				},
				Assets = new Assets
				{
					LargeImageKey = "elsafy_icon",
					LargeImageText = "⚡Elsify v2⚡"
				}
			});
		}

		// Token: 0x040000E6 RID: 230
		public static DiscordRpcClient client;
	}
}
