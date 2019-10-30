using System;
using System.Collections.Generic;

namespace 链表
{

    /// <summary>
    /// 单链表
    /// </summary>
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        public readonly SingleLinkedListNode<T> Head = new SingleLinkedListNode<T>();

        public SingleLinkedListNode<T> First => Head.Next;

        public int Count { get; private set; }


        public SingleLinkedList()
        {

        }

        public SingleLinkedList(IEnumerable<T> source)
        {
            SingleLinkedListNode<T> temp = Head;
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
            SingleLinkedListNode<T> node = Head;
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
                Head.Next = newNode;
            }
            else
            {
                newNode.Next = First;
                Head.Next = newNode;
            }
            Count++;
        }

        public SingleLinkedListNode<T> Find(T value)
        {
            SingleLinkedListNode<T> node = First;
            while (node != null)
            {
                if (node.Value.CompareTo(value) == 0)
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }


        public void Remove(T value)
        {
            SingleLinkedListNode<T> node = Head;
            while (node.Next != null)
            {
                if (node.Next.Value.CompareTo(value) == 0)
                {
                    node.Next = node.Next.Next;
                    return;
                }
                node = node.Next;
            }
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


        /// <summary>
        /// 在知道长度的情况下，删除链表倒数第 n 个结点
        /// </summary>
        /// <param name="n"></param>
        public void RemoveNodeFromEnd(int n)
        {
            if (n < 1 || n > Count)
            {
                throw new ArgumentException();
            }

            int asc = Count - n;
            int index = 1;
            SingleLinkedListNode<T> node = First;
            while (index < asc)
            {
                node = node.Next;
                index++;
            }
            node.Next = node.Next.Next;
        }


        /// <summary>
        /// 在不知道长度的情况下，使用快慢指针删除链表倒数第 n 个结点
        /// </summary>
        /// <param name="n"></param>
        public void RemoveNodeFromEndStartOnHead(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException();
            }

            //SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
            //SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });

            /*
             * 假设长度 h，倒数第 n 个 ，再走 h-n 步就到头了，等价于
             * 正数第 n 个，再走 h-n 步就到尾了。
             * 所以，快指针先走到第 n 个，然后和慢指针一起，一步一步走，当快指针走到尾时，慢指针指向的节点即为倒数第 n 个节点。
             *
             */
            SingleLinkedListNode<T> fast = Head;
            for (int i = 0; i < n; i++)
            {
                fast = fast.Next;
            }
            SingleLinkedListNode<T> slow = Head;
            while (fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            slow.Next = slow.Next.Next;
        }


        /// <summary>
        /// 在不知道长度的情况下，使用快慢指针删除链表倒数第 n 个结点
        /// </summary>
        /// <param name="n"></param>
        public void RemoveNodeFromEndStartOnFirst(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException();
            }

            //SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
            //SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });

            /*
             * 假设长度 h，倒数第 n 个 ，再走 h-n 步就到头了，等价于
             * 正数第 n 个，再走 h-n 步就到尾了。
             * 所以，快指针先走到第 n 个，然后和慢指针一起，一步一步走，当快指针走到尾时，慢指针指向的节点即为倒数第 n 个节点。
             *
             */
            SingleLinkedListNode<T> fast = First;
            for (int i = 0; i < n; i++)
            {
                fast = fast.Next;
            }

            if (fast == null)
            {
                Head.Next = First.Next;
                return;
            }
            SingleLinkedListNode<T> slow = First;
            while (fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            slow.Next = slow.Next.Next;
        }


        /// <summary>
        /// 找出中间节点,如果有两个， 返回第2个
        /// </summary>
        /// <returns></returns>
        public SingleLinkedListNode<T> GetMidNode()
        {
            //SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
            //SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });


            //方法一，从哨兵开始
            //SingleLinkedListNode<T> fast = Head;
            //SingleLinkedListNode<T> slow = Head;
            //while (fast.Next?.Next != null)
            //{
            //    slow = slow.Next;
            //    fast = fast.Next?.Next;
            //}
            //return slow.Next;

            //方法二，从第一个节点开始
            SingleLinkedListNode<T> fast = First;
            SingleLinkedListNode<T> slow = First;
            while (fast?.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next?.Next;
            }
            return slow;
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
