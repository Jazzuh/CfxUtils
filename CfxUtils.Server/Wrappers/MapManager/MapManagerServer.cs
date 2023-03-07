using System;
using System.Collections.Generic;
using CitizenFX.Core;

namespace CfxUtils.Wrappers.MapManager
{
    public partial class MapManager
    {
        /// <summary>
        /// Gets the current game type
        /// </summary>
        /// <returns>The current game type</returns>
        public static GameType GetCurrentGameType()
        {
            var gameTypeResource =  _mapManagerExport.getCurrentGameType();

            return new GameType(gameTypeResource);
        }

        /// <summary>
        /// Gets the current map
        /// </summary>
        /// <returns>The current map</returns>
        public static Map GetCurrentMap()
        {
            var mapResource = _mapManagerExport.getCurrentMap();
            
            return new Map(mapResource);
        }

        /// <summary>
        /// Gets all the currently available maps 
        /// </summary>
        /// <returns>All currently available maps</returns>
        public static IEnumerable<Map> GetMaps()
        {
            var maps = _mapManagerExport.getMaps();

            foreach (var kvp in (IDictionary<string, object>)maps)
            {
                yield return new Map(kvp.Key, (IDictionary<string, object>)kvp.Value);
            }
        }

        /// <summary>
        /// Checks if the a <see cref="Map"/> supports a <see cref="GameType"/>
        /// </summary>
        /// <param name="gameType">The game type to check</param>
        /// <param name="map">The map to check</param>
        /// <returns>Whether or not the map supports the game type</returns>
        public static bool DoesMapSupportGameType(GameType gameType, Map map)
        {
            if (gameType == null || map == null)
            {
                return false;
            }

            return _mapManagerExport.doesMapSupportGameType(gameType.Resource, map.Resource);
        }

        /// <summary>
        /// Changes the current map
        /// </summary>
        /// <param name="map">The map to change to</param>
        public static void ChangeMap(Map map)
        {
            if (map == null)
            {
                return;
            }

            _mapManagerExport.changeMap(map.Resource);
        }

        /// <summary>
        /// Ends the current round
        /// </summary>
        public static void RoundEnded()
        {
            _mapManagerExport.roundEnded();
        }
    }
}
