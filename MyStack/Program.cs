using System;
using System.Collections.Generic;

namespace MyStack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * 栈的底层是数组,这点和 List 一样.
             */

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);

            //int[] i = new int[10];
            //Console.WriteLine(i.Length);
            Console.ReadKey();
        }
    }
}
