#if false
using System;
using System.Collections.Generic;
using System.Linq;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace CfxUtils.Wrappers.MapManager
{
    public class TestDirective : MapDirective
    {
        public class Data
        {
            public int One { get; set; }
            public string Two { get; set; }
            public Vector3 Pos { get; set; }
        }

        public IEnumerable<Data> DataValues => _data.Values;

        private Dictionary<int, Data> _data = new Dictionary<int, Data>();
        private int _index = 0;

        public override dynamic Do(DirectiveState state, dynamic data)
        {
            try
            {
                Debug.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));

                _index++;

                _data[_index] = new Data()
                {
                    One = data.one,
                    Two = data.two,
                    Pos = data.pos,
                };

                state.Add("key", _index);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }

            return null;
        }

        public override void Undo(dynamic state)
        {
            _data.Remove(state.key);
        }
    }


    public class MapManagerTesting : BaseScript
    {

        public MapManagerTesting()
        {
            MapManager.RegisterDirective("test_directive", new TestDirective());
        }

        [Command("testmap")]
        private void testmap()
        {
            var maps = MapManager.GetMaps();

            Debug.WriteLine(maps.Count().ToString());

            foreach (var map in maps)
            {
                Debug.WriteLine("START MAP\n");

                Debug.WriteLine("Name: " + map.Name);
                Debug.WriteLine("Resource: " + map.Resource);
                Debug.WriteLine("Is Current: " + map.IsCurrent);

                foreach (var gameType in map.GameTypes)
                {
                    Debug.WriteLine("\nSTART GAME TYPES\n");

                    Debug.WriteLine("Name: " + gameType.Name);
                    Debug.WriteLine("Resource: " + gameType.Resource);
                    Debug.WriteLine("Is Current: " + gameType.IsCurrent);
                    Debug.WriteLine("Map supports : " + map.SupportsGameType(gameType));

                    Debug.WriteLine("END GAME TYPES\n");
                }

                Debug.WriteLine("END MAP\n");
            }

            Debug.WriteLine("");

            Debug.WriteLine($"Current map is {MapManager.GetCurrentMap().Name}");
            Debug.WriteLine($"Current game type is {MapManager.GetCurrentGameType().Name}");

            Debug.WriteLine("");

            Debug.WriteLine("test_directive:");

            foreach (var value in MapManager.GetDirective<TestDirective>("test_directive").DataValues)
            {
                Debug.WriteLine($"{value.One} - {value.Two} - {value.Pos}");
            }
        }
    }
}
#endif