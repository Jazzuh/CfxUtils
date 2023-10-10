using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.FiveM;


namespace CfxUtils.Wrappers.SpawnManager
{
    public class SpawnPoint
    {
        /// <summary>
        /// The location of where to spawn the player
        /// </summary>
        public Vector3 SpawnLocation { get; set; }

        /// <summary>
        /// The heading to set the player to when they spawn
        /// </summary>
        public float Heading { get; set; }

        /// <summary>
        /// The index of this spawn point in the global spawn point list
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The model to set this player to when spawning them
        /// </summary>
        public PedHash Model { get; set; }

        /// <summary>
        /// Decides if the players screen should fade in while spawning them at this point
        /// </summary>
        public bool SkipFade { get; set; }

        public SpawnPoint()
        {

        }

        public SpawnPoint(IDictionary<string, dynamic> spawnObj)
        {
            if (spawnObj.TryGetValue("x", out var x) && spawnObj.TryGetValue("y", out var y) && spawnObj.TryGetValue("z", out var z))
            {
                SpawnLocation = new Vector3(Convert.ToSingle(x), Convert.ToSingle(y), Convert.ToSingle(z));
            }

            if (spawnObj.TryGetValue("heading", out var heading))
            {
                Heading = heading;
            }

            if (spawnObj.TryGetValue("idx", out var idx))
            {
                Index = idx;
            }

            if (spawnObj.TryGetValue("model", out var model))
            {
                Model = (PedHash)model;
            }

            if (spawnObj.TryGetValue("skipFade", out var skipFade))
            {
                SkipFade = skipFade;
            }
        }

        public Dictionary<string, dynamic> GetEventData()
        {
            var dict = new Dictionary<string, dynamic>
            {
                ["x"] = SpawnLocation.X,
                ["y"] = SpawnLocation.Y,
                ["z"] = SpawnLocation.Z,
                ["heading"] = Heading,
                ["idx"] = Index,
                ["model"] = Model,
                ["skipFade"] = SkipFade
            };

            return dict;
        }
    }
}
