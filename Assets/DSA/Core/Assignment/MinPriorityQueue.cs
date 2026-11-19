using System;
using System.Collections.Generic;

namespace FrontierDispatch.Core
{
    // Assignment Phase 3. Implement as a binary min-heap.

    /// <summary>
    /// A minimum-priority queue implemented as a binary min-heap.
    ///
    /// Items with lower integer priority values should be returned before
    /// items with higher priority values.
    ///
    /// This class is intentionally incomplete in the assignment starter.
    /// </summary>
    public sealed class MinPriorityQueue<T>
    {
        // The list stores the physical representation of the binary heap.
        // Your implementation is responsible for preserving the min-heap invariant.
        private readonly List<Entry> _heap = new List<Entry>();

        /// <summary>
        /// Number of items currently stored in the queue.
        /// </summary>
        public int Count => _heap.Count;

        /// <summary>
        /// Adds an item with the supplied priority.
        /// Lower priority values are removed before higher priority values.
        /// </summary>
        public void Enqueue(T item, int priority)
        {
            _heap.Add(new Entry(item, priority));
            SiftUp(_heap.Count - 1);
        }

        /// <summary>
        /// Returns the minimum-priority item without removing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Peek()
        {
            // Message showing when queue is empty.
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _heap[0].Item;
        }

        /// <summary>
        /// Removes and returns the minimum-priority item.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Dequeue()
        {
            // Message showing when queue is empty.
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            // The result of the dequeuing is the first item in the queue
            Entry result = _heap[0];

            // the number of the last index in the queue is the amount of items in the queue
            // minus 1, since the index count starts at 0
            int lastIndex = _heap.Count - 1;

            if (lastIndex == 0)
            {
                _heap.RemoveAt(0);
                return result;
            }

            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            SiftDown(0);
            return result;

        }

        private void SiftUp(int index)
        {
            // While the incoming index is more than 0
            while (index > 0)
            {
                // int parent is the incoming index, minus 1 and then divided in 2
                int parent = ParentIndex(index);

                // If the priority of the number "parent" in the _heap is less or equals
                // the priority of number "index" in the _heap, return.
                if (_heap[parent].Priority <= _heap[index].Priority)
                {
                    return;
                }
                
                // Switches place of index and parent for sorting purposes
                Swap(parent, index);
                index = parent;
            }
        }

        private void SiftDown(int index)
        {
            while (true)
            {
                // int left is the incoming index times 2 and then add 1
                int left = LeftChildIndex(index);
                
                if (left >= _heap.Count)
                {
                    return;
                }

                // int right is the incoming index times 2 and then add 2
                int right = RightChildIndex(index);
                int smallerChild = left;

                // If the int right is less than the amount of indexes in _heap while ALSO if
                // the priority of index number "right" of _heap is less than the priority of
                // index number "left" of _heap
                if (right < _heap.Count && _heap[right].Priority < _heap[left].Priority)
                {
                    smallerChild = right;
                }

                if (_heap[index].Priority <= _heap[smallerChild].Priority)
                {
                    return;
                }

                Swap(index, smallerChild);
                index = smallerChild;

            }
        }

        private static int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int index1, int index2)
        {
            Entry temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }

        /// <summary>
        /// Stores one item together with the priority used by the heap.
        /// </summary>
        private readonly struct Entry
        {
            public Entry(T item, int priority)
            {
                Item = item;
                Priority = priority;
            }

            public T Item { get; }
            public int Priority { get; }
        }
    }
}
