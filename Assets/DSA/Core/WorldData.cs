using System;
using System.Collections.Generic;

namespace FrontierDispatch.Core
{
    public sealed class WorldData
    {
        private readonly Location[] _locations;
        private readonly Connection[] _connections;
        private readonly Dictionary<int, Location> _locationDictionary = new Dictionary<int, Location>();


        public WorldData(IEnumerable<Location> locations, IEnumerable<Connection> connections)
        {
            if (locations == null) throw new ArgumentNullException(nameof(locations));
            if (connections == null) throw new ArgumentNullException(nameof(connections));
            _locations = new List<Location>(locations).ToArray();
            _connections = new List<Connection>(connections).ToArray();
            AddToDictionary(_locations);
        }

        public IReadOnlyList<Location> Locations => _locations;
        public IReadOnlyList<Connection> Connections => _connections;
        public IReadOnlyDictionary<int, Location> LocationDictionary => _locationDictionary;
        
        public void AddToDictionary(Location[] incomingLocation)
        {
            for (int i = 0; i < incomingLocation.Length; ++i)
            {
                Location location = incomingLocation[i];
                int id = location.Id;
                _locationDictionary.Add(id, location);
            }
        }
    }
}
