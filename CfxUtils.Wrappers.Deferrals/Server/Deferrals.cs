using System;
using System.Collections.Generic;

namespace CfxUtils.Wrappers.Deferrals
{
    /// <summary>
    /// Callback which is called when a user selects an Action.Submit input on their adaptive card
    /// </summary>
    /// <param name="data">Data that has been inputted by the user</param>
    /// <param name="rawData">Data inputted by the user in JSON format</param>
    public delegate void AdaptiveCardCallback(IDictionary<string, object> data, string rawData);

    /// <summary>
    /// Wrapper class for deferrals 
    /// </summary>
    public class Deferrals
    {
        private readonly dynamic _deferralsObj;
        private bool _hasDeferred;

        public Deferrals(dynamic deferralsObj)
        {
            _deferralsObj = deferralsObj;
        }

        /// <summary>
        /// Defers the current connection
        /// </summary>
        public void Defer()
        {
            if (_hasDeferred)
            {
                return;
            }

            _hasDeferred = true;
            _deferralsObj.defer();
        }

        /// <summary>
        /// Sends an update message to the client
        /// </summary>
        /// <param name="message">The message to update the client with</param>
        public void Update(string message)
        {
            _deferralsObj.update(message);
        }

        public void PresentCard(string cardJson, AdaptiveCardCallback cb)
        {
            _deferralsObj.presentCard(cardJson, new Action<dynamic, string>((data, rawData) =>
            {
                cb((IDictionary<string, object>)data, rawData);
            }));
        }

        /// <summary>
        /// Completes the deferred connection. Providing a message will cause the client to not join the server
        /// </summary>
        /// <param name="message">The message to show the client. This will cancel the connection and not let the client join. Leave this blank to allow them to enter the server</param>
        public void Done(string message = "")
        {
            if (string.IsNullOrEmpty(message))
            {
                _deferralsObj.done();
            }
            else
            {
                _deferralsObj.done(message);
            }
        }
    }
}
