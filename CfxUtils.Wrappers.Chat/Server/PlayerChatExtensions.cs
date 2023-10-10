using CitizenFX.Server;

namespace CfxUtils.Wrappers.Chat
{
    public static class PlayerChatExtensions
    {
        /// <summary>
        /// Sends a <see cref="ChatMessage"/> to this <see cref="Player"/>
        /// </summary>
        /// <param name="player">The player to send the message to</param>
        /// <param name="message">The <see cref="ChatMessage"/> to send</param>
        public static void AddMessage(this Player player, ChatMessage message)
        {
            Chat.AddMessage(player, message);
        }

        /// <summary>
        /// Sends a message to this <see cref="Player"/>
        /// </summary>
        /// <param name="player">The player to send the message to</param>
        /// <param name="message">The message to send</param>
        public static void AddMessage(this Player player, string message)
        {
            Chat.AddMessage(player, message);
        }
    }
}
