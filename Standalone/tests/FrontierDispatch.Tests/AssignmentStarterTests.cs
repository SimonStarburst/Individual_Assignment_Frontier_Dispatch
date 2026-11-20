using System;
using NUnit.Framework;
using FrontierDispatch.Core;

namespace FrontierDispatch.Tests
{
    /// <summary>
    /// Small contract examples for later assignment phases.
    ///
    /// These are not an exhaustive assignment test suite.
    /// Students are expected to enable the relevant tests as they reach each
    /// phase and add meaningful tests of their own, including edge cases.
    /// </summary>
    public sealed class AssignmentStarterTests
    {
        // These tests document later assignment contracts without making the
        // untouched baseline red. Remove Ignore when you reach the named phase.


        #region Phase 3 Tests

        [Test]
        public void PriorityQueue_EnqueueAndDequeue_ReturnsLowestPriorityFirst()
        {
            var queue = new MinPriorityQueue<string>();
            queue.Enqueue("expensive", 9);
            queue.Enqueue("cheap", 2);
            queue.Enqueue("medium", 5);
            Assert.That(queue.Dequeue(), Is.EqualTo("cheap"));
        }

        [Test]
        public void PriorityQueue_Peek_PeekLowestPriority()
        {
            var queue = new MinPriorityQueue<string>();
            queue.Enqueue("expensive", 9);
            queue.Enqueue("cheap", 2);
            queue.Enqueue("medium", 5);
            Assert.That(queue.Peek(), Is.EqualTo("cheap"));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 5, 8, 1, 4, 9, 2, 3, 7, 6 })]
        public void PriorityQueue_EnqueueAndDequeue_TestSeveralQueues(int[] priorities)
        {
            var queue = new MinPriorityQueue<int>();

            foreach (int value in priorities)
            {
                queue.Enqueue(value, value);
            }

            var actual = queue.Dequeue();
            Assert.That(actual, Is.EqualTo(1));
        }

        #endregion

        #region Phase 4 Tests

        [Test]
        public void Dijkstra_StartEqualsGoal_ReturnsZeroCostRoute_CreateSmall()
        {
            var finder = new DijkstraRouteFinder(WorldDatasetFactory.CreateSmall());
            RouteResult result = finder.FindRoute(0, 0);
            Assert.That(result.Found, Is.True);
            Assert.That(result.TotalCost, Is.EqualTo(0));
            Assert.That(result.LocationIds, Is.EqualTo(new[] { 0 }));
        }

        [Test]
        public void Dijkstra_StartEqualsGoal_ReturnsZeroCostRoute_CreateLarge()
        {
            var finder = new DijkstraRouteFinder(WorldDatasetFactory.CreateLarge());
            RouteResult result = finder.FindRoute(0, 0);
            Assert.That(result.Found, Is.True);
            Assert.That(result.TotalCost, Is.EqualTo(0));
            Assert.That(result.LocationIds, Is.EqualTo(new[] { 0 }));
        }

        [Test]
        public void Dijkstra_PathNotFound_CreateSmall()
        {
            var finder = new DijkstraRouteFinder(WorldDatasetFactory.CreateSmall());
            RouteResult result = finder.FindRoute(0, 6);
            Assert.That(result.Found, Is.False);
        }

        #endregion

        #region Phase 5 Tests

        [Test]
        public void Reachability_ZeroBudget_IncludesStartAtZeroCost()
        {
            var query = new ReachabilityQuery(WorldDatasetFactory.CreateSmall());
            var result = query.FindReachable(0, 0);
            Assert.That(result.ContainsKey(0), Is.True);
            Assert.That(result[0], Is.EqualTo(0));
        }
        #endregion

    }
}
