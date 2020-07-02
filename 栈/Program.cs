using System;
using System.Collections.Generic;

namespace 栈
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            {
                //Stack<int> stack = new Stack<int>();
                //stack.Peek();
            }

            //{
            //    ArrayStack<int> stack = new ArrayStack<int>();
            //    stack.Push(1);
            //    stack.Push(2);
            //    stack.Push(3);
            //    stack.Push(4);
            //    stack.Push(31);
            //}

            //{
            //    LinkedStack<int> stack = new LinkedStack<int>();
            //    stack.Push(1);
            //    stack.Push(2);
            //    stack.Push(3);
            //    stack.Push(4);
            //    stack.Push(5);
            //    Console.WriteLine(stack.Count);
            //    Console.WriteLine(stack.Pop());
            //    Console.WriteLine(stack.Pop());
            //    Console.WriteLine(stack.Pop());
            //    Console.WriteLine(stack.Pop());
            //    Console.WriteLine(stack.Pop());
            //    Console.WriteLine(stack.Pop());
            //}

            {
                //Console.WriteLine(IsValid("{[]}"));
            }

            {
                //var minStack = new MinStack();
                //minStack.Push(-2);
                //minStack.Push(0);
                //minStack.Push(-3);
                //Console.WriteLine(minStack.GetMin());
                //minStack.Pop();
                //Console.WriteLine(minStack.Top());
                //Console.WriteLine(minStack.GetMin());
            }


            {
                //var code = new LeetCode844();
                //var s = "gtc#uz#";
                //var t = "gtcm##uz#";
                //var res = code.BackspaceCompare(s, t);
                //Console.WriteLine(res);
            }

            {
                //LeetCode224 code = new LeetCode224();
                //int re = code.Calculate("1+(2+(3+(4-3)))+((1))+123");
                //Console.WriteLine(re);
            }

            {
            }

            Console.ReadKey();
        }


        /// <summary>
        /// LeetCode 20
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool IsValid(string s)
        {
            Stack<char> stackLeft = new Stack<char>();
            if (string.IsNullOrWhiteSpace(s))
            {
                return true;
            }

            if (s[0] == ']' || s[0] == '}' || s[0] == ')')
            {
                return false;
            }
            foreach (char c in s)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    stackLeft.Push(c);
                }
                else
                {
                    bool res = stackLeft.TryPop(out char left);
                    if (res == false)
                    {
                        return false;
                    }
                    if (c == '}' && left != '{')
                    {
                        return false;
                    }
                    if (c == ']' && left != '[')
                    {
                        return false;
                    }
                    if (c == ')' && left != '(')
                    {
                        return false;
                    }
                }
            }
            if (stackLeft.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
