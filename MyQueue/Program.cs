using System;

namespace MyQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * 队列和栈一样,底层也是数组
             * 核心点:
             *  当队列为空时，队列的头指针等于队列的尾指针；
                当数组满员时，队列的头指针等于队列的尾指针；
             *
             */
            //Queue<int> q1 = new Queue<int>();
            //q1.Enqueue(1);
            //q1.Enqueue(2);
            //q1.Enqueue(3);
            //q1.Enqueue(4);
            ////q1.Enqueue(4);
            ////Console.WriteLine(q1.Count);
            ////int res = q1.Dequeue();
            ////Console.WriteLine(res);
            MyQueue<int> q = new MyQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            int res = q.Dequeue();
            Console.WriteLine(res);
            q.Enqueue(5);
            q.Enqueue(6);

            Console.ReadKey();
        }
    }
}
