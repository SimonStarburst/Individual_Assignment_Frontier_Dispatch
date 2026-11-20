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
            var queue = new MinPriorityQueue<int>();

            bestCost[startLocationId] = 0;
            queue.Enqueue(startLocationId, 0);

            int expandedNodes = 0;

            while (queue.Count > 0)
            {                
                int current = queue.Dequeue();

                if (!bestCost.TryGetValue(current, out int currentBest) || current != currentBest)
                {
                    continue;
                }

                ++expandedNodes;

                // If the int current is the same as the int goalLocationId, return with the following data:

                // - Boolean for if location has been found returning as true.
                // - A list of locationIds.
                // - The total cost.
                // - How many "nodes" have been expanded.

                if (current == goalLocationId)
                {
                    return new RouteResult(true, new[] { startLocationId }, 0, expandedNodes);
                }

            }

            // Returns following RouteResult if path was not found.
            return new RouteResult(false, Array.Empty<int>(), 0, expandedNodes);
        }
    }
}
