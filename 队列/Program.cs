using System;
using System.Collections.Concurrent;

namespace 队列
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            {
                ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
                queue.Enqueue(1);
                //ArrayQueue<int> queue = new ArrayQueue<int>();
                //Console.WriteLine("capacity:" + queue.Capacity);
                //Console.WriteLine("count:" + queue.Count);
                //queue.Enqueue(1);
                //queue.Enqueue(2);
                //queue.Enqueue(3);
                //queue.Enqueue(4);
                //Console.WriteLine(queue.Dequeue() + " dequeue");
                //queue.Enqueue(5);
                //queue.Enqueue(6);
                //queue.Enqueue(7);
                //queue.Enqueue(8);
                //Console.WriteLine("capacity:" + queue.Capacity);
                //Console.WriteLine("count:" + queue.Count);
                //while (queue.Count > 0)
                //{
                //    Console.WriteLine(queue.Dequeue());
                //}
            }

            {
                //LinkedQueue<int> queue = new LinkedQueue<int>();
                //Console.WriteLine("count:" + queue.Count);
                //queue.Enqueue(1);
                //queue.Enqueue(2);
                //queue.Enqueue(3);
                //queue.Enqueue(4);
                //Console.WriteLine(queue.Dequeue() + " dequeue");
                //queue.Enqueue(5);
                //queue.Enqueue(6);
                //queue.Enqueue(7);
                //queue.Enqueue(8);
                //Console.WriteLine("count:" + queue.Count);
                //while (queue.Count > 0)
                //{
                //    Console.WriteLine(queue.Dequeue());
                //}
            }

            {
                ArrayCircleQueue<int> queue = new ArrayCircleQueue<int>();
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);
                queue.Enqueue(4);
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");

                queue.Enqueue(5);
                queue.Enqueue(6);
                queue.Enqueue(7);
                queue.Enqueue(8);
                queue.Enqueue(9);
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");
                while (queue.Count > 0)
                {
                    Console.WriteLine(queue.Dequeue());
                }
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);
                queue.Enqueue(4);
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine(queue.Dequeue() + " dequeue");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
