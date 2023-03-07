using System;
using System.Collections.Generic;
using System.Linq;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace CfxUtils.Wrappers.SpawnManager
{
    /// <summary>
    /// Delegate that is ran after a player has successfully spawned 
    /// </summary>
    /// <param name="point">The spawn point where the player has spawned</param>
    public delegate void SpawnCallback(SpawnPoint point);

    /// <summary>
    /// Delegate that is ran after a player dies to control how they respawn
    /// </summary>
    public delegate void AutoSpawnCallback();

    /// <summary>
    /// Wrapper class for the spawnmanager resource
    /// </summary>
    public class SpawnManager : BaseScript
    {
        private static dynamic _spawnmanagerExport;

        public SpawnManager()
        {
            _spawnmanagerExport = Exports["spawnmanager"];
        }

        /// <summary>
        /// Spawns the player
        /// </summary>
        /// <param name="spawnPoint">The data of where to spawn the player</param>
        /// <param name="cb">The callback that is called once the player has been successfully spawned </param>
        public static void SpawnPlayer(SpawnPoint spawnPoint, SpawnCallback cb = null)
        {
            _spawnmanagerExport.spawnPlayer(spawnPoint.GetEventData(), new Action<dynamic>(data =>
            {
                cb?.Invoke(new SpawnPoint(data));
            }));
        }

        /// <summary>
        /// Spawns the player
        /// </summary>
        /// <param name="spawnIdx">The index of the spawn point where you wish to spawn the player. Can be obtained from <see cref="AddSpawnPoint"/></param>
        /// <param name="cb">The callback that is called once the player has been successfully spawned </param>
        public static void SpawnPlayer(int spawnIdx, SpawnCallback cb = null)
        {
            _spawnmanagerExport.spawnPlayer(spawnIdx, new Action<dynamic>(data =>
            {
                cb?.Invoke(new SpawnPoint(data));
            }));
        }

        /// <summary>
        /// Spawns the player at a random <see cref="SpawnPoint"/>
        /// </summary>
        /// <param name="cb">The callback that is called once the player has been successfully spawned </param>
        public static void SpawnPlayer(SpawnCallback cb = null)
        {
            _spawnmanagerExport.spawnPlayer(null, new Action<dynamic>(data =>
            {
                cb?.Invoke(new SpawnPoint(data));
            }));
        }

        /// <summary>
        /// Adds a spawn point to the global spawn point list
        /// </summary>
        /// <param name="spawnPoint">The data of the spawn point</param>
        /// <returns>The <see cref="SpawnPoint"/>, containing the index of the spawn in the global spawn list</returns>
        public static SpawnPoint AddSpawnPoint(SpawnPoint spawnPoint)
        {
            var spawnIdx = _spawnmanagerExport.addSpawnPoint(spawnPoint.GetEventData());

            spawnPoint.Index = spawnIdx;

            return spawnPoint;
        }

        /// <summary>
        /// Removes a spawn point from the global spawn point list
        /// </summary>
        /// <param name="spawnIdx"></param>
        public static void RemoveSpawnPoint(int spawnIdx)
        {
            _spawnmanagerExport.removeSpawnPoint(spawnIdx);
        }

        /// <summary>
        /// Adds a list of <see cref="SpawnPoint"/> to the global spawn point list
        /// </summary>
        /// <param name="spawnPoints">The spawn points to add to the list</param>
        public static void LoadSpawns(List<SpawnPoint> spawnPoints)
        {
            _spawnmanagerExport.loadSpawns(JsonConvert.SerializeObject(new
            {
                spawns = spawnPoints.Select(o => o.GetEventData())
            }));
        }

        /// <summary>
        /// Sets if auto spawning should be enabled or not
        /// </summary>
        /// <param name="autoSpawn">The state of auto spawning</param>
        public static void SetAutoSpawn(bool autoSpawn)
        {
            _spawnmanagerExport.setAutoSpawn(autoSpawn);
        }

        /// <summary>
        /// Sets a custom callback to be ran when the player is auto spawned
        /// </summary>
        /// <param name="cb">The callback to run</param>
        public static void SetAutoSpawnCallback(AutoSpawnCallback cb)
        {
            _spawnmanagerExport.setAutoSpawn(cb);
        }

        /// <summary>
        /// Forces the player to respawn
        /// </summary>
        public static void ForceRespawn()
        {
            _spawnmanagerExport.forceRespawn();
        }
    }
}
