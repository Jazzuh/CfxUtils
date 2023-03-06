using System;
using System.Collections.Generic;
using CfxUtils.Shared.Convar;
using CitizenFX.Core;

namespace CfxUtils.Wrappers.Chat
{
    /// <summary>
    /// Wrapper class for the chat resource
    /// </summary>
    public class Chat : BaseScript
    {
        public new PlayerList Players => base.Players;

        internal static Chat Instance { get; set; }

#if SERVER
        /// <summary>
        /// Gets or sets if player joining notifications will be shown in chat
        /// </summary>
        public static bool ShowJoins
        {
            get => _showJoinsConvar.Value;
            set => _showJoinsConvar.Value = value;
        }

        /// <summary>
        /// Gets or sets if player quit notifications will be shown in chat
        /// </summary>
        public static bool ShowQuits
        {
            get => _showQuitsConvar.Value;
            set => _showQuitsConvar.Value = value;
        }

        private static Convar<bool> _showJoinsConvar = new("chat_showJoins", true);
        private static Convar<bool> _showQuitsConvar = new("chat_showQuits", true);
#endif

        private static dynamic _chatExport;
        private static Dictionary<string, ChatMode> _chatModes;
        private static int _modeIdx;

        public Chat()
        {
            Instance = this;

            _chatExport = Exports["chat"];
            _chatModes = new();
        }

        /// <summary>
        /// Sends a <see cref="ChatMessage"/> to all connected players
        /// </summary>
        /// <param name="message">The message to send</param>
        public static void AddMessage(ChatMessage message)
        {
#if CLIENT
            TriggerEvent("chat:addMessage", message.EventFormat());
#elif SERVER
            TriggerClientEvent("chat:addMessage", message.EventFormat());
#endif
        }

        /// <summary>
        /// Sends a message to all connected players
        /// </summary>
        /// <param name="message">The message to send</param>
        public static void AddMessage(string message)
        {
#if CLIENT
            TriggerEvent("chat:addMessage", message);
#elif SERVER
            TriggerClientEvent("chat:addMessage", message);
#endif
        }

#if SERVER
        /// <summary>
        /// Sends a <see cref="ChatMessage"/> to the specified <see cref="Player"/>
        /// </summary>
        /// <param name="target">The player to send the message to</param>
        /// <param name="message">The message to send to the player</param>
        public static void AddMessage(Player target, ChatMessage message)
        {
            target.TriggerEvent("chat:addMessage", message.EventFormat());
        }

        /// <summary>
        /// Sends a message to the specified <see cref="Player"/>
        /// </summary>
        /// <param name="target">The player to send the message to</param>
        /// <param name="message">The message to send to the player</param>
        public static void AddMessage(Player target, string message)
        {
            target.TriggerEvent("chat:addMessage", message);
        }

        /// <summary>
        /// Registers a <see cref="ChatHookCallback"/> that will be ran whenever a message is sent
        /// </summary>
        /// <param name="cb">The message hook to run</param>
        public static void RegisterMessageHook(ChatHookCallback cb)
        {
            _chatExport.registerMessageHook(new Action<int, dynamic, dynamic>((source, outMessage, hookRefs) =>
            {
                cb(Instance.Players[source], new ChatMessage(outMessage), new ChatMessageHooks(hookRefs));
            }));
        }

        /// <summary>
        /// Registers a new <see cref="ChatMode"/> to the chat
        /// </summary>
        /// <param name="mode">The mode to register to chat</param>
        /// <returns>If the mode was successfully registered</returns>
        public static bool RegisterMode(ChatMode mode)
        {
            var modeIdx = _modeIdx++;

            if (string.IsNullOrEmpty(mode.Name))
            {
                mode.Name = $"chat_mode_{modeIdx}";
            }

            if (string.IsNullOrEmpty(mode.DisplayName))
            {
                mode.DisplayName = $"Mode {modeIdx}";
            }

            mode.MessageCallback ??= (_, _, _) => { };

            _chatModes[mode.Name] = mode;

            return _chatExport.registerMode(mode.EventFormat());
        }
#endif

        /// <summary>
        /// Gets the specified <see cref="ChatMode"/> if it is currently cached
        /// </summary>
        /// <param name="modeName">The name of the mode</param>
        /// <returns>The <see cref="ChatMode"/> or <see langword="null"/> if the mode isn't found</returns>
        /// <remarks>This will only ever return modes which have been registered from within the resource that is currently referencing this assembly. It will not be able to return modes outside of the current resource</remarks>
        public static ChatMode GetMode(string modeName)
        {
            return _chatModes.TryGetValue(modeName, out var mode) ? mode : null;
        }
    }
}
