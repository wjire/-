using System;
using System.Collections.Generic;

namespace 栈
{

    /// <summary>
    /// 链式栈
    /// </summary>
    public class LinkedStack<T> where T : IComparable<T>
    {
        private readonly LinkedList<T> items = new LinkedList<T>();
        public int Count => items.Count;

        public void Push(T item)
        {
            items.AddLast(item);
        }

        public T Pop()
        {
            LinkedListNode<T> item = items.Last;
            if (item == null)
            {
                throw new Exception("the stack is empty");
            }

            items.RemoveLast();
            return item.Value;
        }
    }
}
