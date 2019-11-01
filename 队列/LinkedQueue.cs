using System;
using System.Collections.Generic;

namespace 队列
{

    /// <summary>
    /// 链式队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedQueue<T> where T : IComparable<T>
    {
        private LinkedList<T> items = new LinkedList<T>();
        public int Count => items.Count;


        public void Enqueue(T item)
        {
            items.AddLast(item);
        }

        public T Dequeue()
        {
            T item = items.First.Value;
            items.RemoveFirst();
            return item;
        }
    }
}
