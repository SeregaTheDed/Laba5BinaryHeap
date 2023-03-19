using BinaryHeap;

namespace TestBinaryHeap
{
    [TestClass]
    public class UnitTest1
    {
        const int n = 100000;

        [TestMethod]
        public void TestCountEqualZeroAfterInit()
        {
            BinaryHeap<string> binaryHeap = new BinaryHeap<string>();
            Assert.AreEqual(0, binaryHeap.Count);
        }

        [TestMethod]
        public void TestCountAfterAddedIncrement()
        {
            BinaryHeap<string> binaryHeap = new BinaryHeap<string>();
            binaryHeap.Add("123");
            Assert.AreEqual(1, binaryHeap.Count);
        }

        [TestMethod]
        public void TestCountEqualZeroAfterAddedAndRemove()
        {
            BinaryHeap<string> binaryHeap = new BinaryHeap<string>();
            binaryHeap.Add("123");
            binaryHeap.PopMax();
            Assert.AreEqual(0, binaryHeap.Count);
        }

        [TestMethod]
        public void TestAddCountEqualCountAddedElements()
        {
            BinaryHeap<string> binaryHeap = new BinaryHeap<string>();
            for (int i = 0; i < n; i++)
            {
                binaryHeap.Add(i.ToString());
            }
            Assert.AreEqual(n, binaryHeap.Count);
        }

        [TestMethod]
        public void TestCountEqualZeroAfterAddedAndRemoveSomeElements()
        {
            BinaryHeap<string> binaryHeap = new BinaryHeap<string>();
            for (int i = 0; i < n; i++)
            {
                binaryHeap.Add(i.ToString());
            }
            for (int i = 0; i < n; i++)
            {
                binaryHeap.PopMax();
            }

            Assert.AreEqual(0, binaryHeap.Count);
        }

        [TestMethod]
        public void TestPopMaxValuesEqualsAddedValues()
        {
            BinaryHeap<int> binaryHeap = new BinaryHeap<int>();
            for (int i = 0; i < n; i++)
            {
                binaryHeap.Add(i);
            }
            int GuessedMaxes = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                int value = binaryHeap.PopMax();
                if (value == i)
                    GuessedMaxes++;
            }

            Assert.AreEqual(n, GuessedMaxes);
        }

        [TestMethod]
        public void TestGetSortedList()
        {
            Random rnd = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(rnd.Next());
            }
            List<int> gottedList = BinaryHeap<int>.GetSortedList(list);
            list.Sort();
            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(list[i], gottedList[i]);
            }
        }
    }
}