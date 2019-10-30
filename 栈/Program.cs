using System;
using System.Collections.Generic;

namespace 栈
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(1);
                stack.Pop();
            }

            {
                ArrayStack<int> stack = new ArrayStack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);
                stack.Push(31);
            }

            {
                LinkedStack<int> stack = new LinkedStack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);
                stack.Push(5);
                Console.WriteLine(stack.Count);
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
            }


            Console.ReadKey();
        }
    }
}
