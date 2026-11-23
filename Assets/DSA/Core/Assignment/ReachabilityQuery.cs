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
            var frontier = new MinPriorityQueue<int>();

            bestCost[startLocationId] = 0;
            frontier.Enqueue(startLocationId, 0);

            while (frontier.Count > 0)
            {
                MinPriorityQueue<int>.Entry current = frontier.Peek();
                frontier.Dequeue();


                if (current.Priority > bestCost[current.Item]) 
                {
                    continue;
                }


                foreach (Connection connection in _world.ConnectionDictionary[current.Item])
                {
                    int currentCost = bestCost[connection.FromLocationId] + connection.TravelCost;

                    // If
                    // 1. bestCost doesn't contain a Key for the ToLocationId of "connection" OR currentCost is less than the value of the ToLocationId of the connection in bestCost
                    // AND
                    // 2. currentCost is less or equal to maxTravelCost
                    if ((!bestCost.ContainsKey(connection.ToLocationId) || currentCost < bestCost[connection.ToLocationId]) && currentCost <= maxTravelCost)
                    {
                        // Change the value of the ToLocationId of the connection in bestCost
                        bestCost[connection.ToLocationId] = currentCost;

                        // Enqueue a new Entry in frontier, where the number of the ToLocationId of the connection, from the foreach-loop, is the Item and
                        // the number of the ToLocationId of the connection, from the dictionary bestCost, is the Priority
                        frontier.Enqueue(connection.ToLocationId, bestCost[connection.ToLocationId]);      
                    }

                }
            }

            return bestCost;
        }
    }
}
