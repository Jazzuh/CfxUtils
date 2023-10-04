using System;
using System.Collections.Generic;
using CitizenFX.Core;

namespace CfxUtils.Wrappers.Map
{
    /// <summary>
    /// Wrapper class for the mapmanager resource
    /// </summary>
    public partial class MapManager : BaseScript
    {
        private static Dictionary<string, MapDirective> _mapDirectives = new Dictionary<string, MapDirective>();

        private static dynamic _mapManagerExport;

        public MapManager()
        {
            _mapManagerExport = Exports["mapmanager"];
        }

        /// <summary>
        /// Registers a map directive
        /// </summary>
        /// <param name="key">The name of the directive</param>
        /// <param name="directive">The map directive handler class associated with it</param>
        public static void RegisterDirective(string key, MapDirective directive)
        {
            _mapDirectives[key] = directive;
        }

        /// <summary>
        /// Gets a map directive
        /// </summary>
        /// <typeparam name="TMapDirective">The type of map directive</typeparam>
        /// <param name="directiveName">The name of the directive</param>
        /// <returns>The specified map directive or <see langword="null"/> if not found</returns>
        /// <remarks>This will only ever return directives which have been registered from within the resource that is currently referencing this assembly. It will not be able to return directives outside of the current resource</remarks>
        public static TMapDirective GetDirective<TMapDirective>(string directiveName) where TMapDirective : MapDirective
        {
            return _mapDirectives.TryGetValue(directiveName, out var directive) ? directive as TMapDirective : null;
        }

        [EventHandler("getMapDirectives")]
        private void getMapDirectives(dynamic add)
        {
            foreach (var directive in _mapDirectives)
            {
                var action = directive.Value;

                Debug.WriteLine($"Registering directive: {directive.Key}");

                add(directive.Key, new Func<dynamic, dynamic, dynamic>((state, data) =>
                {
                    return action.Do(new DirectiveState(state), data);
                }), new Action<dynamic>(state =>
                {
                    action.Undo(state);
                }));
            }
        }
    }
}
