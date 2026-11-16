using System;
using System.Collections.Generic;

namespace FrontierDispatch.Core
{
    public sealed class WorldData
    {
        private readonly Location[] _locations;
        private readonly Connection[] _connections;
        private readonly Dictionary<int, Location> _locationDictionary;
        private readonly Dictionary<int, List<int>> _connectionDictionary;


        public WorldData(IEnumerable<Location> locations, IEnumerable<Connection> connections)
        {
            if (locations == null) throw new ArgumentNullException(nameof(locations));
            if (connections == null) throw new ArgumentNullException(nameof(connections));
            _locations = new List<Location>(locations).ToArray();
            _connections = new List<Connection>(connections).ToArray();
            _locationDictionary = new Dictionary<int, Location>();
            _connectionDictionary = new Dictionary<int, List<int>>();
            AddLocation(_locations);
            AddConnection(_connections);
        }

        public IReadOnlyList<Location> Locations => _locations;
        public IReadOnlyList<Connection> Connections => _connections;
        public IReadOnlyDictionary<int, Location> LocationDictionary => _locationDictionary;
        public IReadOnlyDictionary<int, List<int>> ConnectionDictionary => _connectionDictionary;
            
            
        public void AddLocation(Location[] _incomingLocation)
        {
            foreach (Location locations in _incomingLocation)
            {
                _locationDictionary.Add(locations.Id, locations);
            }
        }

        // Change to ForEach
        private void AddConnection(Connection[] _incomingConnection)
        {
            foreach (Connection connections in _incomingConnection)
            {
                if (!_connectionDictionary.ContainsKey(connections.FromLocationId))
                {
                List<int> toLocations = new List<int>();
                toLocations.Add(connections.ToLocationId);
                }
                


                _connectionDictionary.Add(connections.FromLocationId, toLocations);
            }

            //for (int i = 0; i < _incomingConnection.Length; ++i)
            //{
            //    Connection connection = _incomingConnection[i];
            //    List<int> toLocations = new List<int>();
            //    int id = 

            //    for (int j = 0; j < connection.; ++j)
            //    {
            //        toLocations.Add();
            //    }

            //    _connectionDictionary.Add(id, toLocations);
            //}
        }
    }
}
