using System;
using System.Collections.Generic;

namespace 栈
{
    public class LeetCode224
    {

        private int count = 0;

        public int Calculate(string s)
        {
            //1+2-3+(3-2+5-2)-3+3
            //1+(2-3+(4-5)+6)
            //(1)
            //" "
            //"0"
            //123+321
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            if (s.Length == 1)
            {
                return Convert.ToInt32(s);
            }

            Stack<int> intStack = new Stack<int>();
            Stack<char> symbolStack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (c == '+' || c == '-')
                {
                    bool f = symbolStack.TryPeek(out char topSymbol);
                    if (f == false)
                    {
                        symbolStack.Push(c);
                        continue;
                    }

                    if (topSymbol == '(')
                    {
                        symbolStack.Push(c);
                        continue;
                    }

                    topSymbol = symbolStack.Pop();
                    int newInt = Calculate(intStack.Pop(), topSymbol, intStack.Pop());
                    intStack.Push(newInt);
                    symbolStack.Push(c);
                }
                else if (c == '(')
                {
                    symbolStack.Push(c);
                }
                else if (c == ')')
                {
                    char topSymbol = symbolStack.Pop();
                    while (topSymbol != '(')
                    {
                        int newInt = Calculate(intStack.Pop(), topSymbol, intStack.Pop());
                        intStack.Push(newInt);
                        topSymbol = symbolStack.Pop();
                    }
                }
                else
                {
                    intStack.Push(Convert.ToInt32(c.ToString()));
                }
            }

            if (symbolStack.Count > 0)
            {
                return Calculate(intStack.Pop(), symbolStack.Pop(), intStack.Pop());
            }

            if (intStack.Count == 1)
            {
                return intStack.Pop();
            }

            return Convert.ToInt32(s);
        }

        public int Calculate(int x, char c, int y)
        {
            if (c == '+')
            {
                return x + y;
            }
            else
            {
                return y - x;
            }
        }
    }
}
