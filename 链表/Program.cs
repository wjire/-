using System;
using System.Collections.Generic;

namespace 链表
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            {
                //.net 提供的 链表 内部是双向循环链表，但对外呈现的是双向链表，而非循环
                链表.LinkedList<int> list = new 链表.LinkedList<int>();
                链表.LinkedListNode<int> node = list.AddLast(1);
            }

            {
                ////单链表测试
                SingleLinkedList<int> single1 = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7 });
                SingleLinkedList<int> single2 = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
                //SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
                //single.Print();
                //single.RemoveNodeFromEndStartOnFirst(1);
                //Console.WriteLine("after remove");
                SingleLinkedListNode<int> node1 = single1.GetMidNode();
                SingleLinkedListNode<int> node2 = single2.GetMidNode();
                Console.WriteLine(node1.Value);
                Console.WriteLine(node2.Value);


                //Console.WriteLine("count:" + single.Count);
                //single.AddLast(100);
                //single.AddLast(101);
                //single.AddFirst(123);
                //single.AddFirst(1);
                //single.AddLast(9);
                ////Console.WriteLine("count:" + single.Count);
                //single.Print();
                ////Console.WriteLine("Head:" + single.First.Value);
                //Console.WriteLine("Reverse:");
                //SingleLinkedList<int> newSingle = single.Reverse();
                //Console.WriteLine("first:" + newSingle.First.Value);
                //Console.WriteLine();
                //newSingle.Print();
            }


            {
                ////循环单链表测试
                //CircleSingleLinkedList<int> circleSingle = new CircleSingleLinkedList<int>();
                ////CircleSingleLinkedList<int> circleSingle = new CircleSingleLinkedList<int>();
                //Console.WriteLine("count:" + circleSingle.Count);
                ////circleSingle.AddAfter(2);
                ////circleSingle.AddAfter(3);
                ////circleSingle.Print();
                ////Console.WriteLine(circleSingle.First.Value);
                ////circleSingle.AddLast(1);
                ////circleSingle.AddLast(2);
                ////circleSingle.AddLast(3);
                //circleSingle.AddFirst(3);
                //circleSingle.AddLast(4);
                //circleSingle.AddFirst(2);
                //circleSingle.AddLast(5);
                //circleSingle.AddFirst(1);
                //Console.WriteLine("count:" + circleSingle.Count);
                //circleSingle.Print();
            }

            {
                //SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> { 1 });
                //Console.WriteLine(HasCircle(single));
                //single.AddLast(6);
                //Console.WriteLine(HasCircle(single));
                //CircleSingleLinkedList<int> circle = new CircleSingleLinkedList<int>(new List<int> { 1 });
                //Console.WriteLine(HasCircle(circle));
                //circle.AddLast(6);
                //Console.WriteLine(HasCircle(circle));
            }


            {
                //SingleLinkedList<int> list1 = new SingleLinkedList<int>(new List<int> { 1, 13, 15 });
                //SingleLinkedList<int> list2 = new SingleLinkedList<int>(new List<int> { 2, 14, });
                //SingleLinkedList<int> result = MergeSortedLinkedList(list1, list2);
                //result.Print();
            }


            Console.ReadKey();
        }


        /// <summary>
        /// 是否有环
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        private static bool HasCircle<T>(SingleLinkedList<T> list) where T : IComparable<T>
        {
            if (list.Count == 0)
            {
                return false;
            }

            if (list.Count == 1)
            {
                return list.First.Next == list.First;
            }

            SingleLinkedListNode<T> slow = list.First.Next;
            SingleLinkedListNode<T> fast = list.First.Next.Next;
            while (slow != fast && slow != null && fast != null)
            {
                slow = slow.Next;
                fast = fast.Next?.Next;
            }
            return slow == fast;
        }


        /// <summary>
        /// 是否有环
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        private static bool HasCircle<T>(CircleSingleLinkedList<T> list) where T : IComparable<T>
        {
            if (list.Count == 0)
            {
                return false;
            }
            if (list.Count == 1)
            {
                return list.First.Next == list.First;
            }
            CircleSingleLinkedListNode<T> slow = list.First.Next;
            CircleSingleLinkedListNode<T> fast = list.First.Next.Next;
            while (slow != fast && slow != null && fast != null)
            {
                slow = slow.Next;
                fast = fast.Next?.Next;
            }
            return slow == fast;
        }


        /// <summary>
        /// 合并两个有序单链表
        /// </summary>
        private static SingleLinkedList<T> MergeSortedLinkedList<T>(SingleLinkedList<T> list1, SingleLinkedList<T> list2) where T : IComparable<T>
        {
            if (list1.Count == 0 && list2.Count > 0)
            {
                return list2;
            }

            if (list1.Count > 0 && list2.Count == 0)
            {
                return list1;
            }

            if (list1.Count == 0 && list2.Count == 0)
            {
                throw new ArgumentNullException();
            }

            SingleLinkedList<T> result = new SingleLinkedList<T>();
            SingleLinkedListNode<T> node = result.Head;
            SingleLinkedListNode<T> node1 = list1.First;
            SingleLinkedListNode<T> node2 = list2.First;

            while (node1 != null && node2 != null)
            {
                if (node1.Value.CompareTo(node2.Value) < 0)
                {
                    node.Next = node1;
                    node1 = node1.Next;
                }
                else
                {
                    node.Next = node2;
                    node2 = node2.Next;
                }
                node = node.Next;
            }

            if (node1 != null)
            {
                node.Next = node1;
            }

            if (node2 != null)
            {
                node.Next = node2;
            }

            return result;
        }
    }
}
