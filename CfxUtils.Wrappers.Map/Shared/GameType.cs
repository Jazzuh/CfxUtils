using System.Collections.Generic;

namespace CfxUtils.Wrappers.Map
{
    /// <summary>
    /// Represents a game type resource
    /// </summary>
    public class GameType
    {
        private readonly string _name;

        /// <summary>
        /// The name of the game type
        /// </summary>
        public string Name
        {
            get => string.IsNullOrEmpty(_name) ? Resource : _name;
            init => _name = value;
        }

        /// <summary>
        /// The resource name of this game type
        /// </summary>
        public string Resource { get; }

#if SERVER
        /// <summary>
        /// Whether or not this game type is the one that is currently being played
        /// </summary>
        public bool IsCurrent => MapManager.GetCurrentGameType() == this;
#endif

        internal GameType(string gameTypeResourceName)
        {
            Resource = gameTypeResourceName;
        }

        internal GameType(string gameTypeResourceName, IDictionary<string, object> mapData)
        {
            if (!mapData.TryGetValue("name", out var gameTypeName))
            {
                gameTypeName = gameTypeResourceName;
            }

            Name = gameTypeName.ToString();
            Resource = gameTypeResourceName;
        }

        public override int GetHashCode()
        {
            return Resource.GetHashCode();
        }

        public static bool operator ==(GameType left, GameType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameType left, GameType right)
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

            return Equals((GameType)obj);
        }

        public bool Equals(GameType other)
        {
            return Resource == other.Resource;
        }
    }
}