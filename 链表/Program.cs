using System;
using System.Collections.Generic;

namespace 链表
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            {
                //单链表测试
                //SingleLinkedList<int> single = new SingleLinkedList<int>();
                //Console.WriteLine("count:" + single.Count);
                //single.AddAfter(100);
                //single.AddAfter(101);
                //single.AddFirst(123);
                //single.AddFirst(1);
                //single.AddAfter(9);
                //Console.WriteLine("count:" + single.Count);
                //single.Print();
                //Console.WriteLine("head:" + single.First.Value);
                //Console.WriteLine("Reverse:");
                //SingleLinkedList<int> newSingle = single.Reverse();
                //newSingle.Print();
            }


            {
                //循环单链表测试
                CircleSingleLinkedList<int> circleSingle = new CircleSingleLinkedList<int>(new List<int> { 3});
                //CircleSingleLinkedList<int> circleSingle = new CircleSingleLinkedList<int>();
                Console.WriteLine("count:" + circleSingle.Count);
                //circleSingle.AddAfter(2);
                //circleSingle.AddAfter(3);
                //circleSingle.Print();
                //Console.WriteLine(circleSingle.First.Value);
                //circleSingle.AddLast(1);
                //circleSingle.AddLast(2);
                //circleSingle.AddLast(3);
                circleSingle.AddLast(4);
                circleSingle.AddFirst(2);
                circleSingle.AddLast(5);
                circleSingle.AddFirst(1);
                Console.WriteLine("count:" + circleSingle.Count);
                circleSingle.Print();
            }


            Console.ReadKey();
        }
    }
}
