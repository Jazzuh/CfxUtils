using System;
using System.Collections.Generic;
using System.Drawing;

namespace CfxUtils.Wrappers.Chat
{
    /// <summary>
    /// Represents a mode that can be accessed from the chat
    /// </summary>
    public class ChatMode
    {
        /// <summary>
        /// The unique name of this mode
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name that will be displayed in chat for this mode
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// That color of the display name for this mode
        /// </summary>
        public Color Color { get; set; } = Color.FromArgb(255, 255, 255);

        /// <summary>
        /// The ACE permission string that is needed to access this mode. Can be left empty to be accessible by everyone
        /// </summary>
        public string SeObject { get; set; }

#if SERVER
        /// <summary>
        /// The callback ran each time a message is sent in this mode
        /// </summary>
        public ChatHookCallback MessageCallback { get; set; }
#endif

        private Action<int, dynamic, dynamic> _onMessageInternal;

        public ChatMode()
        {
#if SERVER
            _onMessageInternal = (source, outMessage, hookRef) =>
            {
                MessageCallback?.Invoke(Chat.Players[source], new ChatMessage(outMessage), new ChatMessageHooks(hookRef));
            };
#endif
        }

        /// <summary>
        /// Formats this <see cref="ChatMode"/> so it can be send through an event
        /// </summary>
        /// <returns>The formatting dictionary that will be sent</returns>
        public Dictionary<string, dynamic> EventFormat()
        {
            var returnDict = new Dictionary<string, dynamic>
            {
                { "name", Name },
                { "displayName", DisplayName },
                { "color", Color.ToHex() },
                { "cb", _onMessageInternal }
            };

            if (!string.IsNullOrEmpty(SeObject))
            {
                returnDict["seObject"] = SeObject;
            }

            return returnDict;
        }
    }
}
