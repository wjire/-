using System.Collections.Generic;

namespace 栈
{

    /// <summary>
    /// LeetCode 155
    /// </summary>
    public class MinStack
    {

        private readonly Stack<int> stack = new Stack<int>();
        private int min = int.MaxValue;

        public MinStack()
        {

        }


        public void Push(int x)
        {
            stack.Push(min);
            if (x < min)
            {
                min = x;
            }
            stack.Push(x);
        }


        public void Pop()
        {
            bool flag = stack.TryPop(out int result);
            if (flag == true)
            {
                min = stack.Pop();
            }
        }

        public int Top()
        {
            bool flag = stack.TryPeek(out int res);
            if (flag)
            {
                return res;
            }
            return 0;
        }

        public int GetMin()
        {
            return min;
        }
    }
}
