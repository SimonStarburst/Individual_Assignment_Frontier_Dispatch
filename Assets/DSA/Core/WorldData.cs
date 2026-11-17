using System;
using System.Collections.Generic;

namespace FrontierDispatch.Core
{
    public sealed class WorldData
    {
        private readonly Location[] _locations;
        private readonly Connection[] _connections;
        private readonly Dictionary<int, Location> _locationDictionary;
        private readonly Dictionary<int, List<Connection>> _connectionDictionary;


        public WorldData(IEnumerable<Location> locations, IEnumerable<Connection> connections)
        {
            if (locations == null) throw new ArgumentNullException(nameof(locations));
            if (connections == null) throw new ArgumentNullException(nameof(connections));
            _locations = new List<Location>(locations).ToArray();
            _connections = new List<Connection>(connections).ToArray();
            _locationDictionary = new Dictionary<int, Location>();
            _connectionDictionary = new Dictionary<int, List<Connection>>();
            AddLocation(_locations);
            AddConnection(_connections);
        }

        public IReadOnlyList<Location> Locations => _locations;
        public IReadOnlyList<Connection> Connections => _connections;
        public IReadOnlyDictionary<int, Location> LocationDictionary => _locationDictionary;
        public IReadOnlyDictionary<int, List<Connection>> ConnectionDictionary => _connectionDictionary;
            
            
        public void AddLocation(Location[] _incomingLocation)
        {
            foreach (Location locations in _incomingLocation)
            {
                _locationDictionary.Add(locations.Id, locations);
            }
        }

        private void AddConnection(Connection[] _incomingConnections)
        {                   
            int id = 0;
            
            foreach (Connection connection in _incomingConnections)
            {
                var toLocations = new List<Connection>();
                _connectionDictionary.Add(id, toLocations);
            }

            //for (int i = 0; i < _incomingConnections.Length; i++)
            //{           
            //    var toLocations = new List<Connection>();
                
                
                
                
            //    _connectionDictionary.Add(i, toLocations);  
            //}

        }
    }
}
