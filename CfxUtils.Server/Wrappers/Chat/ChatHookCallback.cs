using CfxUtils.Wrappers.Chat;
using CitizenFX.Core;

namespace CfxUtils.Wrappers.Chat
{
    /// <summary>
    /// Delegate that will be ran whenever a message is sent in chat
    /// </summary>
    /// <param name="source">The player who sent the message</param>
    /// <param name="message">The message that was sent</param>
    /// <param name="messageHooks">The hooks to use to edit the message</param>
    public delegate void ChatHookCallback(Player source, ChatMessage message, ChatMessageHooks messageHooks);
}
