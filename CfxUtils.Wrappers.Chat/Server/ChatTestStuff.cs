#if false
using System.Drawing;
using System.Linq;
using CfxUtils.Server.Extensions;
using CfxUtils.Shared.Extensions;
using CitizenFX.Core;

namespace CfxUtils.Wrappers.Chat
{
    public class ChatTestStuff : BaseScript
    {
        [Command("mute_chat")]
        private void TestChatMute(Player source)
        {
            var value = source.State["isChatMuted"] ?? false;

            source.State["isChatMuted"] = !value;

            Debug.WriteLine($"Chat has been {(source.State["isChatMuted"] ? "muted" : "unmuted")}");
        }


        [Command("test_stuff")]
        private void TestCommand()
        {
            Chat.RegisterMessageHook((source, message, hooks) =>
            {
                if (!message.Message.StartsWith("/"))
                {
                    return;
                }

                source.AddMessage(new ChatMessage
                {
                    Author = "[Server]",
                    Message = $"The command {message.Message.Split(' ')[0]} doesn't exist"
                });

                hooks.Cancel();
            });

            Chat.RegisterMode(new()
            {
                DisplayName = "Help",
                Color = Color.FromArgb(255, 20, 147),
                MessageCallback = (source, message, hooks) =>
                {
                    /*if (source.IsChatMuted())
                    {
                        source.SendChatMessage("[Server]", $"You are currently muted in this channel", ConstantColours.Log);
                        hooks.Cancel();

                        return;
                    }*/

                    hooks.SetRouting(Players.Where(o => !(o.State["isChatMuted"] ?? false)));

                    hooks.UpdateMessage(new()
                    {
                        Author = $"^{message.Mode.Color.ToHex()}[{message.Author} - Help]",
                        Message = message.Message
                    });
                }
            });

            Chat.RegisterMode(new()
            {
                DisplayName = "Admin",
                Color = Color.FromArgb(255, 255, 200),
                SeObject = "admin.chat",
                MessageCallback = (source, message, hooks) =>
                {
                    hooks.UpdateMessage(new()
                    {
                        Author = $"^{message.Mode.Color.ToHex()}[{message.Author} - Admin - {source.Handle}]",
                        Message = message.Message
                    });

                    hooks.SetSeObject("admin.chat");
                }
            });
        }
    }
}
#endif
