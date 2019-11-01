using System;
using System.Collections.Generic;

namespace 栈
{
    public class LeetCode682
    {
        public int CalPoints(string[] ops)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < ops.Length; i++)
            {
                switch (ops[i])
                {
                    case "C":
                        stack.Pop();
                        break;
                    case "D":
                        bool flag = stack.TryPeek(out int grade);
                        if (flag)
                        {
                            stack.Push(grade * 2);
                        }
                        break;
                    case "+":
                        bool res = stack.TryPeek(out int g1);
                        if (res)
                        {
                            stack.Pop();
                            res = stack.TryPeek(out int g2);
                            int g = g1;
                            if (res)
                            {
                                g = g1 + g2;
                            }
                            stack.Push(g1);
                            stack.Push(g);
                        }
                        break;
                    default:
                        int n = Convert.ToInt32(ops[i]);
                        stack.Push(n);
                        break;
                }
            }
            int result = 0;
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }
            return result;
        }
    }
}
