using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;

namespace EclipseLauncher
{
    public class Discord
    {
        public static void StartRPC()
        {

            // PLEASE DON'T USE THIS ONE AS I WILL REMOVE THE APP, CREATE YOUR OWN!

            var client = new DiscordRpcClient("1251985429176258582");

            client.OnReady += (sender, e) =>
            {
                
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                
            };

            client.Initialize();


            client.SetPresence(new RichPresence()
            {
                Details = "Eclipse - #1 Fortnite Dev",
                State = "discord.gg/ecl1pse",
                Assets = new Assets()
                {
                    LargeImageKey = "h",
                    LargeImageText = "Eclipse",
                    SmallImageKey = "nombre_imagen_pequeña"
                },
                Buttons = new[]
                {
                new Button { Label = "Join Discord", Url = "https://discord.gg/ecl1pse" }
                }
            });

        }
    }
}
