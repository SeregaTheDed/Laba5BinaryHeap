using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Laba5BinaryHeap
{
    internal class BigCollection<T>
        :IEnumerable<T>
    {
        LinkedList<IEnumerable<T>> collections;
        public BigCollection() 
        {
            collections = new LinkedList<IEnumerable<T>>();
        }

        public void AddNewCollection(IEnumerable<T> newCollection)
        {
            collections.AddLast(newCollection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var collection in collections)
            {
                foreach (var item in collection)
                {
                    yield return item;
                }
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
