using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CfxUtils.Shared.Extensions;

namespace CfxUtils.Wrappers.Chat
{
    /// <summary>
    /// Represents a message that will be shown in chat
    /// </summary>
    public class ChatMessage
    {
        /// <summary>
        /// The author of the message, this will be displayed before the actual message in chat. Can be blank
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// The message that will be displayed in chat
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The template the message will be formatted in. Can be left blank for default behaviour
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Used to populate named placeholders in the specified template
        /// </summary>
        public Dictionary<string, string> Params { get; set; } = new ();

        /// <summary>
        /// Determines if the message can be displayed on multiple lines
        /// </summary>
        public bool Multiline { get; set; } = true;

        public ChatMode Mode { get; }

        public ChatMessage()
        {

        }

        public ChatMessage(IDictionary<string, dynamic> messageData)
        {
            if (messageData.TryGetValue("args", out var args))
            {
                var argsList = args as List<object>;

                if (argsList!.Count == 1)
                {
                    Message = argsList[0] as string;
                }
                else
                {
                    Author = argsList[0] as string;
                    Message = argsList[1] as string;
                }
            }

            if (messageData.TryGetValue("multiline", out var multiline))
            {
                Multiline = multiline;
            }

            if (messageData.TryGetValue("mode", out var modeName))
            {
                if (modeName == null)
                {
                    return;
                }

                Mode = Chat.GetMode(modeName);

#if SERVER
                if (Mode == null)
#endif
                {
                    Mode = new ()
                    {
                        Name = modeName
                    };
                }
            }
        }

        /// <summary>
        /// Formats this <see cref="ChatMessage"/> so it can be send through an event
        /// </summary>
        /// <returns>The formatting dictionary that will be sent</returns>
        public Dictionary<string, dynamic> EventFormat()
        {
            var returnDict = new Dictionary<string, dynamic>();
            var args = new List<string>();

            if (!string.IsNullOrEmpty(Author))
            {
                args.Add(Author);
            }

            args.Add(Message);

            returnDict.Add("args", args.ToArray());

            if (!string.IsNullOrEmpty(Template))
            {
                returnDict.Add("template", Template);
            }

            if (Params is { Count: > 0 })
            {
                returnDict.Add("params", Params);
            }

            if (Mode != null)
            {
                returnDict.Add("mode", Mode.Name);
            }

            return returnDict;
        }
    }
}
