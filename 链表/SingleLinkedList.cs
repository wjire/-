using System;
using System.Collections.Generic;

namespace 链表
{

    /// <summary>
    /// 单链表
    /// </summary>
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        private readonly SingleLinkedListNode<T> head = new SingleLinkedListNode<T>();

        public SingleLinkedListNode<T> First => head.Next;

        public int Count { get; private set; }


        public SingleLinkedList()
        {

        }

        public SingleLinkedList(IEnumerable<T> source)
        {
            SingleLinkedListNode<T> temp = head;
            foreach (T item in source)
            {
                SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T> { Value = item };
                AddAfter(temp, newNode);
                temp = newNode;
            }
        }

        public void AddLast(T newValue)
        {
            SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T> { Value = newValue };
            AddLast(newNode);
        }

        public void AddLast(SingleLinkedListNode<T> newNode)
        {
            SingleLinkedListNode<T> node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = newNode;
            Count++;
        }

        public void AddAfter(SingleLinkedListNode<T> node, SingleLinkedListNode<T> newNode)
        {
            node.Next = newNode;
            Count++;
        }

        public void AddFirst(T newValue)
        {
            SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T> { Value = newValue };
            AddFirst(newNode);
        }

        public void AddFirst(SingleLinkedListNode<T> newNode)
        {
            if (First == null)
            {
                head.Next = newNode;
            }
            else
            {
                newNode.Next = First;
                head.Next = newNode;
            }
            Count++;
        }


        /// <summary>
        /// 翻转单链表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public SingleLinkedList<T> Reverse()
        {
            if (Count == 1)
            {
                return this;
            }
            SingleLinkedList<T> result = new SingleLinkedList<T>();
            SingleLinkedListNode<T> node = First;
            result.AddLast(node.Value);
            while (node.Next != null)
            {
                result.AddFirst(new SingleLinkedListNode<T> { Value = node.Next.Value });
                node = node.Next;
            }
            return result;
        }


        public void Print()
        {
            SingleLinkedListNode<T> node = First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }


    public class SingleLinkedListNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public SingleLinkedListNode<T> Next { get; set; }
    }
}
