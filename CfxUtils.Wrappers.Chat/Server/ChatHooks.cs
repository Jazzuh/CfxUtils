using System.Collections.Generic;
using System.Linq;
using CitizenFX.Server;

namespace CfxUtils.Wrappers.Chat
{
    /// <summary>
    /// Wrapper class for the chat hooks object sent in the message callback, to edit the currently sending message
    /// </summary>
    public class ChatMessageHooks
    {
        private readonly dynamic _hookObj;

        public ChatMessageHooks(dynamic hookObject)
        {
            _hookObj = hookObject;
        }

        /// <summary>
        /// Updates the message data of the specified <see cref="ChatMessage"/>
        /// </summary>
        /// <param name="message">The message to use to update the message</param>
        public void UpdateMessage(ChatMessage message)
        {
            _hookObj.updateMessage(message.EventFormat());
        }

        /// <summary>
        /// Cancels the sending of the message
        /// </summary>
        public void Cancel()
        {
            _hookObj.cancel();
        }

        /// <summary>
        /// Sets the ACE permission string that is needed to see this message
        /// </summary>
        /// <param name="seObject">The ACE permission string</param>
        public void SetSeObject(string seObject)
        {
            _hookObj.setSeObject(seObject);
        }

        /// <summary>
        /// Sets the message to only route to the specified player
        /// </summary>
        /// <param name="target">The player to route the message to</param>
        public void SetRouting(Player target)
        {
            _hookObj.setRouting(target.Handle);
        }

        /// <summary>
        /// Sets the message to only route to the specified players
        /// </summary>
        /// <param name="targets">The players to route the message to</param>
        public void SetRouting(IEnumerable<Player> targets)
        {
            _hookObj.setRouting(targets.Select(o => o.Handle).ToArray());
        }
    }
}
