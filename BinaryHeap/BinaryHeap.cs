using System.Collections;
using System.Collections.Generic;

namespace BinaryHeap
{
    public class BinaryHeap<T>
        where T : IComparable<T>
    {
        private List<T> _list = new List<T>();
        public int Count
        {
            get
            {
                return _list.Count();
            }
        }

        public BinaryHeap() { }
        public BinaryHeap(IEnumerable<T> collection)
        {
            _list = collection.ToList();
            for (int i = Count / 2; i >= 0; i--)
            {
                ReturnHeapProperty(_list, i);
            }
        }

        public void Add(T value)
        {
            _list.Add(value);
            int i = Count - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && _list[parent].CompareTo(_list[i]) == -1)
            {
                T temp = _list[i];
                _list[i] = _list[parent];
                _list[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public T PopMax()
        {
            T result = _list[0];
            _list[0] = _list[Count - 1];
            _list.RemoveAt(Count - 1);
            ReturnHeapProperty(_list, 0);
            return result;
        }

        private static void ReturnHeapProperty(List<T> list, int i)
        {
            int leftChildIndex;
            int rightChildIndex;
            int largestChildIndex;

            while(true)
            {
                leftChildIndex = 2 * i + 1;
                rightChildIndex = 2 * i + 2;
                largestChildIndex = i;

                if (leftChildIndex < list.Count && list[leftChildIndex].CompareTo(list[largestChildIndex]) == 1)
                {
                    largestChildIndex = leftChildIndex;
                }

                if (rightChildIndex < list.Count && list[rightChildIndex].CompareTo(list[largestChildIndex]) == 1)
                {
                    largestChildIndex = rightChildIndex;
                }

                if (largestChildIndex == i)
                {
                    break;
                }

                T temp = list[i];
                list[i] = list[largestChildIndex];
                list[largestChildIndex] = temp;
                i = largestChildIndex;
            }
        }

        public static List<T> GetSortedList(IEnumerable<T> collection)
        {
            BinaryHeap<T> heap = new BinaryHeap<T>(collection);
            var list = new List<T>(collection.Count());
            for (int i = collection.Count()-1; i >= 0; i--)
            {
                list.Add(heap.PopMax());
                //ReturnHeapProperty(heap._list, 0);
            }
            list.Reverse();
            return list;
        }

    }
}