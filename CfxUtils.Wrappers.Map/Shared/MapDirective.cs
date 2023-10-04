namespace CfxUtils.Wrappers.Map
{
    /// <summary>
    /// Represents a map directive
    /// </summary>
    public abstract class MapDirective
    {
        /// <summary>
        /// Processes the data from a map directive entry 
        /// </summary>
        /// <param name="state">The <see cref="DirectiveState"/> of the current directive</param>
        /// <param name="data">Data of the current directive</param>
        /// <returns></returns>
        public abstract dynamic Do(DirectiveState state, dynamic data);

        /// <summary>
        /// Undo the action performed in <see cref="MapDirective.Do"/>
        /// </summary>
        /// <param name="state">The state of the directive</param>
        public abstract void Undo(dynamic state);
    }
}
