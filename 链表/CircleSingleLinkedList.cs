using System;
using System.Collections.Generic;
using System.Threading;

namespace 链表
{

    /// <summary>
    /// 循环链表
    /// 通常指的是循环单链表，区别于双向循环链表
    /// </summary>
    public class CircleSingleLinkedList<T> where T : IComparable<T>
    {
        private readonly CircleSingleLinkedListNode<T> head = new CircleSingleLinkedListNode<T>();
        public CircleSingleLinkedListNode<T> First => head.Next;

        public int Count { get; private set; }

        public CircleSingleLinkedList()
        {

        }

        public CircleSingleLinkedList(IEnumerable<T> source)
        {
            CircleSingleLinkedListNode<T> temp = head;
            foreach (T item in source)
            {
                if (temp.Next == null)
                {
                    head.Next = new CircleSingleLinkedListNode<T> { Value = item };
                    head.Next.Next = head.Next;
                    temp = head.Next;
                    Count++;
                }
                else
                {
                    CircleSingleLinkedListNode<T> newNode = new CircleSingleLinkedListNode<T> { Value = item };
                    AddAfter(temp, newNode);
                    temp = newNode;
                }
            }
        }


        public void AddAfter(CircleSingleLinkedListNode<T> node, CircleSingleLinkedListNode<T> newNode)
        {
            newNode.Next = node.Next;
            node.Next = newNode;
            Count++;
        }


        public void AddLast(T value)
        {
            CircleSingleLinkedListNode<T> newNode = new CircleSingleLinkedListNode<T> { Value = value };
            AddLast(newNode);
        }


        public void AddLast(CircleSingleLinkedListNode<T> newNode)
        {
            if (First == null)
            {
                AddToEmptyLinkedList(newNode);
                return;
            }

            CircleSingleLinkedListNode<T> node = FindLastNode();
            newNode.Next = node.Next;
            node.Next = newNode;
            Count++;
        }


        public void AddFirst(T value)
        {
            CircleSingleLinkedListNode<T> newNode = new CircleSingleLinkedListNode<T> { Value = value };
            AddFirst(newNode);
        }


        public void AddFirst(CircleSingleLinkedListNode<T> newNode)
        {
            if (First == null)
            {
                AddToEmptyLinkedList(newNode);
                return;
            }

            CircleSingleLinkedListNode<T> node = FindLastNode();
            newNode.Next = First;
            head.Next = newNode;
            node.Next = newNode;
            Count++;
        }


        private void AddToEmptyLinkedList(CircleSingleLinkedListNode<T> newNode)
        {
            head.Next = newNode;
            head.Next.Next = head.Next;
            Count++;
        }


        private CircleSingleLinkedListNode<T> FindLastNode()
        {
            CircleSingleLinkedListNode<T> node = First;
            while (node.Next != First && Count > 1)
            {
                node = node.Next;
            }
            return node;
        }


        public void Print()
        {
            CircleSingleLinkedListNode<T> node = First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
                Thread.Sleep(1000);
            }
        }
    }



    public class CircleSingleLinkedListNode<T> where T : IComparable<T>
    {

        public T Value { get; set; }

        public CircleSingleLinkedListNode<T> Next { get; set; }
    }
}
