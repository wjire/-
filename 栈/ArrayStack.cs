using System;

namespace 栈
{

    /// <summary>
    /// 顺序栈
    /// </summary>
    public class ArrayStack<T> where T : IComparable<T>
    {
        private T[] items;
        private int length;
        public int Count { get; set; }


        public ArrayStack() : this(4)
        {

        }

        public ArrayStack(int capacity)
        {
            items = new T[capacity];
            length = items.Length;
        }


        public void Push(T item)
        {
            if (Count == length)
            {
                T[] newItems = new T[length * 2];
                Array.Copy(items, newItems, length);
                items = newItems;
                length = newItems.Length;
            }
            items[Count] = item;
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("the stack is empty");
            }
            T item = items[Count - 1];
            Count--;
            return item;
        }
    }
}
