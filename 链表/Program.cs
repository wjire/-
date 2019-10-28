using System;
using System.Collections.Generic;

namespace 链表
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> link = new LinkedList<int>(new List<int> {1, 2, 3});
            SingleLinkedList<int> single = new SingleLinkedList<int>(new List<int> {1, 2, 3, 4});
            Console.WriteLine(single.First.Value);


            Console.ReadKey();
        }
    }
}
