using System;

namespace 队列
{

    /// <summary>
    /// 顺序队列(非循环）
    /// </summary>
    public class ArrayQueue<T> where T : IComparable<T>
    {
        private T[] items;
        private int capacity;
        private int head;
        private int tail;
        private int count;
        public int Count => count;
        public int Capacity => capacity;

        public ArrayQueue() : this(4)
        {

        }

        public ArrayQueue(int capacity)
        {
            items = new T[capacity];
            this.capacity = capacity;
        }


        public void Enqueue(T item)
        {
            if (tail == capacity)
            {
                if (head == 0)//说明满了
                {
                    int newCapacity = capacity * 2;
                    T[] newItems = new T[newCapacity];
                    Array.Copy(items, newItems, capacity);
                    capacity = newCapacity;
                    items = newItems;
                }
                else //没满，则做数据迁移
                {
                    for (int i = head; i < tail; i++)
                    {
                        items[i - head] = items[i];
                    }

                    tail = tail - head;
                    head = 0;
                }
            }
            items[tail] = item;
            tail++;
            count++;
        }

        public T Dequeue()
        {
            if (head == tail)
            {
                throw new Exception("the queue is empty");
            }
            T item = items[head];
            items[head] = default(T);
            count--;
            head++;
            return item;
        }
    }
}
