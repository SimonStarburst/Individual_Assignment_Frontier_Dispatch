#nullable enable

using System;
using System.Collections.Generic;

namespace FrontierDispatch.Core
{
    /// <summary>
    /// Straightforward queries over the supplied WorldData.
    ///
    /// The starter project intentionally performs these queries directly over the stored
    /// collections. The implementation is correct, but students should analyze
    /// how its work scales as the world becomes larger and queries are repeated.
    ///
    /// Do not assume that every method must be replaced. Identify the operations
    /// that matter first, then justify any representation changes.
    /// </summary>
    public sealed class WorldQueries
    {
        private readonly WorldData _world;
        private readonly Dictionary<int, Location> _locationDictionary = new Dictionary<int, Location>();


        public WorldQueries(WorldData world)
        {
            _world = world ?? throw new ArgumentNullException(nameof(world));
            AddToDictionary(_locationDictionary<>);
        }

        public Location? FindLocationById(int id)
        {
            Location foundLocation;
            if (_locationDictionary.TryGetValue(id, out var location))
            {
                foundLocation = location;
                return foundLocation;
            }
            else
            {
                return null;
            }

            //for (int i = 0; i < _world.Locations.Count; ++i)
            //{
            //    Location location = _world.Locations[i];
            //    if (location.Id == id)
            //    {
            //        return location;
            //    }
            //}

            //return null;
        }

        public IReadOnlyList<Connection> FindOutgoingConnections(int fromLocationId)
        {
            var result = new List<Connection>();
            for (int i = 0; i < _world.Connections.Count; ++i)
            {
                Connection connection = _world.Connections[i];
                if (connection.FromLocationId == fromLocationId)
                {
                    result.Add(connection);
                }
            }

            return result;
        }

        public void AddToDictionary(Dictionary<int, Location>)
        {
            for (int i = 0; i < _world.Locations.Count; ++i)
            {
                Location location = _world.Locations[i];
                int id = location.Id;
                _locationDictionary.Add(id, location);
            }
        }

        //public static void InsertionSort(int[] array)
        //{
        //    if (array == null)
        //    {
        //        throw new ArgumentNullException(nameof(array));
        //    }

        //    for (int i = 1; i < array.Length; ++i)
        //    {
        //        int key = array[i];
        //        int j = i - 1;

        //        while (j >= 0 && array[j] > key)
        //        {
        //            array[j + 1] = array[j];
        //            --j;
        //        }

        //        array[j + 1] = key;
        //    }
        //}
    }
}
