using System.Collections.Generic;

namespace CfxUtils.Wrappers.Map
{
    /// <summary>
    /// Represents a map resource
    /// </summary>
    public class Map
    {
        private readonly string _name;

        /// <summary>
        /// The name of the map
        /// </summary>
        public string Name
        {
            get => string.IsNullOrEmpty(_name) ? Resource : _name;
            init => _name = value;
        }

        /// <summary>
        /// The resource name of this map
        /// </summary>
        public string Resource { get; }

        /// <summary>
        /// The game types this map supports
        /// </summary>
        public IReadOnlyList<GameType> GameTypes { get; }

#if SERVER
        /// <summary>
        /// Whether or not this map is the one that is currently being played
        /// </summary>
        public bool IsCurrent => MapManager.GetCurrentMap() == this;
#endif

        internal Map(string mapResourceName)
        {
            Resource = mapResourceName;
            GameTypes = new List<GameType>();
        }

        internal Map(string mapResourceName, IDictionary<string, object> mapData)
        {
            if (!mapData.TryGetValue("name", out var mapName))
            {
                mapName = mapResourceName;
            }

            Name = mapName.ToString();
            Resource = mapResourceName;

            var gameTypes = new List<GameType>();

            if (mapData.TryGetValue("gameTypes", out var gameTypeData))
            {
                foreach (var kvp in (IDictionary<string, object>)gameTypeData)
                {
                    gameTypes.Add(new GameType(kvp.Key));
                }
            }

            GameTypes = gameTypes;
        }

#if SERVER
        /// <summary>
        /// Checks if this map supports a <see cref="GameType"/>
        /// </summary>
        /// <param name="type">The game type to check</param>
        /// <returns>Whether or not this map supports the game type</returns>
        public bool SupportsGameType(GameType type)
        {
            return MapManager.DoesMapSupportGameType(type, this);
        }
#endif

        public override int GetHashCode()
        {
            return Resource.GetHashCode();
        }

        public static bool operator ==(Map left, Map right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Map left, Map right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Map)obj);
        }

        public bool Equals(Map other)
        {
            return Resource == other.Resource;
        }
    }
}