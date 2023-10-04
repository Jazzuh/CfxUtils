namespace CfxUtils.Wrappers.Map
{
    /// <summary>
    /// Wrapper class for the state object passed through the getMapDirectives event
    /// </summary>
    public class DirectiveState
    {
        private readonly dynamic _state;

        internal DirectiveState(dynamic state)
        {
            _state = state;
        }

        public void Add(string key, object value)
        {
            _state.add(key, value);
        }
    }
}
