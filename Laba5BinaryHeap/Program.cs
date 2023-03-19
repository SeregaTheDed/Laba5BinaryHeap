using BinaryHeap;
using System.Diagnostics;

namespace Laba5BinaryHeap
{
    public class SpeedTester
    {
        private readonly BigCollection<int> _bigCollection;
        private const int collectionNumber = 10;
        private const int n = 10000;
        public SpeedTester() 
        {
            _bigCollection = new BigCollection<int>();
            FillBigCollection();
        }

        private void FillBigCollection()
        {
            for (int i = 0; i < collectionNumber; i++)
            {
                _bigCollection.AddNewCollection(Enumerable.Range(0, n));
            }
        }

        private long GetHeapSortTime()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            BinaryHeap<int>.GetSortedList(_bigCollection);
            timer.Stop();
            return timer.ElapsedMilliseconds;

        }
        private int[] BubbleSortArray(int[] array)
        {
            int length = array.Length;
            int temp = array[0];
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }
        private long GetBubbleSortArraytTime()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            BubbleSortArray(_bigCollection.ToArray());
            timer.Stop();
            return timer.ElapsedMilliseconds;

        }

        public void PrintTest() 
        {
            Console.WriteLine("BubbleSortArrayTime: " + GetBubbleSortArraytTime());
            Console.WriteLine("HeapSortTime: " + GetHeapSortTime());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SpeedTester speedTester = new SpeedTester();
            speedTester.PrintTest();
        }
    }
}