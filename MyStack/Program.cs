using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyStack
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //MyStack<int> stack = new MyStack<int>();
            //stack.Push(11);
            //stack.Push(231);
            //stack.Push(33);
            //Console.WriteLine(stack.Count);
            //Console.WriteLine(stack.Peek());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Count);
            //Console.WriteLine(stack.Peek());
            //stack.Clear();
            //Console.WriteLine(stack.Count);
            //stack.Push(999);
            //Console.WriteLine(stack.Peek());


            string t1 = "sees";
            Console.WriteLine(IsHuiWen(t1));
            t1 = "hello";
            Console.WriteLine(IsHuiWen(t1));


            Console.ReadKey();
        }


        //利用栈来解决回文算法.
        public static bool IsHuiWen(string target)
        {
            Stack<char> stack = new Stack<char>(target);
            foreach (char t in target)
            {
                if (t != stack.Pop())
                {
                    return false;
                }
            }
            return true;
        }


        //利用栈进行四则运算
        public static int Cal(string exp)
        {
            // 9+(3-1)*3+10/2
            //1+2*3-4/2
            int result = 0;
            Stack<int> numberStack = new Stack<int>();
            Stack<string> operatorStack = new Stack<string>();


            return result;
        }


        private static bool IsNumeric(string input)
        {
            bool flag = true;
            string pattern = (@"^\d+$");
            Regex validate = new Regex(pattern);
            if (!validate.IsMatch(input))
            {
                flag = false;
            }
            return flag;
        }
    }
}
