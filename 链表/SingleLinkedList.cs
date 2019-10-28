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


        public SingleLinkedList() : this(null)
        {

        }

        public SingleLinkedList(IEnumerable<T> source)
        {
            SingleLinkedListNode<T> temp = head;
            foreach (T item in source)
            {
                SingleLinkedListNode<T> newNode = new SingleLinkedListNode<T> { Value = item };
                AddLast(temp, newNode);
                temp = newNode;
            }
        }

        private void AddLast(SingleLinkedListNode<T> node, SingleLinkedListNode<T> newNode)
        {
            node.Next = newNode;
        }
    }

    public class SingleLinkedListNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public SingleLinkedListNode<T> Next { get; set; }
    }
}
