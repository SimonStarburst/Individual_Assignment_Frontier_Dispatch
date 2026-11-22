using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FrontierDispatch.Core
{
    // Assignment Phase 5. Adapt shortest-path reasoning to a travel-cost budget.

    /// <summary>
    /// Finds locations that can be reached from a starting location without
    /// exceeding a maximum total travel cost.
    ///
    /// This is an adaptation of shortest-path reasoning: instead of searching
    /// for one goal, the query determines the cheapest known cost to every
    /// location that fits within the supplied budget.
    ///
    /// This class is intentionally incomplete in the assignment starter.
    ///
    /// What do we mean by "query"? In this context, a query is simply a one-time search for information.
    /// </summary>
    public sealed class ReachabilityQuery
    {
        private readonly WorldData _world;

        /// <summary>
        /// Creates a reachability query operating on the supplied world.
        /// </summary>
        public ReachabilityQuery(WorldData world)
        {
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }

        /// <summary>
        /// Returns reachable location IDs mapped to their cheapest known
        /// travel cost from the starting location.
        ///
        /// Only locations whose cheapest cost is within maxTravelCost should
        /// be included. The starting location has cost 0.
        /// </summary>
        public IReadOnlyDictionary<int, int> FindReachable(int startLocationId, int maxTravelCost)
        {
            // TODO: adapt shortest-path reasoning to the travel-cost budget.

            // Message showing when startLocationId or maxTravelCost are 0, since Dijkstra
            // doesn't like negative numbers.
            if (startLocationId < 0 || maxTravelCost < 0)
            {
                throw new InvalidOperationException("Start location Id and/or Travel Cost cannot be less than 0");
            }

            var bestCost = new Dictionary<int, int>();
            var cameFrom = new Dictionary<int, int>();
            var queue = new MinPriorityQueue<int>();
            var notFound = new Dictionary<int, int>();

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

                if (current == maxTravelCost)   // This is not working, it just finishes within one loop!
                {
                    return ReverseBuild(startLocationId, currentBest, expandedNodes, cameFrom);
                }

                foreach (Connection connection in _world.ConnectionDictionary[current])
                {
                    int toLocationId = connection.ToLocationId;
                    int candidate = checked(currentBest + connection.TravelCost);

                    if (!bestCost.TryGetValue(toLocationId, out int known) || candidate < known)
                    {
                        bestCost[toLocationId] = candidate;
                        cameFrom[toLocationId] = current;
                        queue.Enqueue(toLocationId, candidate);
                    }
                }

            }
            return notFound;    // This return is not working, it should return if location was not found within 
                                // maxTravelCost, but I can't figure it out...
        }

        private static Dictionary<int, int> ReverseBuild(            
            int startLocationId, 
            int totalCost, 
            int expandedNodes,
            Dictionary<int, int> cameFrom)
        {
            if (cameFrom == null)
            {
                throw new ArgumentNullException(nameof(cameFrom));
            }

            var reversed = new Dictionary<int, int>();
            int current = totalCost;
            reversed.Add(current, totalCost);

            while (current != startLocationId)
            {
                current = cameFrom[current];
                reversed.Add(current, totalCost);
            }

            reversed.Reverse();
            return reversed;

        }
    }
}
