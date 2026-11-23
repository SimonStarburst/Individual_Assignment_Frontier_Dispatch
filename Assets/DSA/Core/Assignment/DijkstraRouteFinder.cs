using System;
using System.Collections.Generic;

namespace FrontierDispatch.Core
{
    // Assignment Phase 4.

    /// <summary>
    /// Finds minimum-total-cost routes through a Frontier Dispatch world
    /// using Dijkstra's shortest-path algorithm.
    ///
    /// This class is intentionally incomplete in the assignment starter.
    /// It should eventually use the student's prepared world representation
    /// and MinPriorityQueue implementation.
    /// </summary>
    public sealed class DijkstraRouteFinder
    {
        private readonly WorldData _world;

        /// <summary>
        /// Constructor. Creates a route finder operating on the supplied world.
        /// </summary>
        public DijkstraRouteFinder(WorldData world)
        {
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }

        /// <summary>
        /// Finds a minimum-total-travel-cost route from the start location
        /// to the goal location.
        ///
        /// A successful RouteResult should contain the route as location IDs,
        /// including both the start and goal locations.
        /// </summary>
        public RouteResult FindRoute(int startLocationId, int goalLocationId)
        {

            if (startLocationId == goalLocationId)
            {
                return new RouteResult(true, new[] { startLocationId }, 0, 0);
            }

            var bestCost = new Dictionary<int, int>();
            var cameFrom = new Dictionary<int, int>();
            var frontier = new MinPriorityQueue<int>();

            bestCost[startLocationId] = 0;
            frontier.Enqueue(startLocationId, 0);

            int expandedNodes = 0;

            while (frontier.Count > 0)
            {
                MinPriorityQueue<int>.Entry current = frontier.Peek();
                frontier.Dequeue();

                if (current.Priority > bestCost[current.Item])
                {
                    continue;
                }

                ++expandedNodes;


                if (current.Item == goalLocationId)
                {
                    return RouteResult.Success(Path(), bestCost[goalLocationId], expandedNodes);
                }

                foreach (Connection connection in _world.ConnectionDictionary[current.Item])
                {
                    int currentCost = bestCost[connection.FromLocationId] + connection.TravelCost;

                    if (!bestCost.ContainsKey(connection.ToLocationId) || currentCost < bestCost[connection.ToLocationId])
                    {
                        bestCost[connection.ToLocationId] = currentCost;
                        cameFrom[connection.ToLocationId] = connection.FromLocationId;
                        frontier.Enqueue(connection.ToLocationId, bestCost[connection.ToLocationId]);
                    }
                }
            }

            return RouteResult.NotFound(expandedNodes);      


            IReadOnlyList<int> Path()        
            {           
                List<int> path = new();
                int current = goalLocationId;
                path.Add(current);
                while (current != startLocationId)            
                {              
                    current = cameFrom[current];                
                    path.Add(current);            
                }
                            
                path.Reverse();            
                return path;        
            }        
        }
    }
}
