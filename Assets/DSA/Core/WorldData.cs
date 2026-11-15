using System;
using System.Collections.Generic;

namespace FrontierDispatch.Core
{
    public sealed class WorldData
    {
        private readonly Location[] _locations;
        private readonly Connection[] _connections;
        private readonly Dictionary<int, Location> _locationDictionary = new Dictionary<int, Location>();
        private readonly Dictionary<int, List<T>> _connectionDictionary = new Dictionary<int, List<T>>();


        public WorldData(IEnumerable<Location> locations, IEnumerable<Connection> connections)
        {
            if (locations == null) throw new ArgumentNullException(nameof(locations));
            if (connections == null) throw new ArgumentNullException(nameof(connections));
            _locations = new List<Location>(locations).ToArray();
            _connections = new List<Connection>(connections).ToArray();
            AddLocation(_locations);
            AddConnection(_connections);
        }

        public IReadOnlyList<Location> Locations => _locations;
        public IReadOnlyList<Connection> Connections => _connections;
        public IReadOnlyDictionary<int, Location> LocationDictionary => _locationDictionary;
        public IReadOnlyDictionary<int, List<>>
        
        public void AddLocation(Location[] incomingLocation)
        {
            for (int i = 0; i < incomingLocation.Length; ++i)
            {
                Location location = incomingLocation[i];
                int id = location.Id;
                _locationDictionary.Add(id, location);
            }
        }

        public void AddConnection(Connection[] incomingConnection)
        {


            for (int i = 0; i < incomingConnection.Length; ++i)
            {
                Connection connection = incomingConnection[i];
                List<int> toLocations = new List<int>();
                int id = 

                for (int j = 0; j < connection.; ++j)
                {
                    toLocations.Add();
                }

                _connectionDictionary.Add(id, toLocations);
            }
        }
    }
}
