using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MyDictionary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyDictionary<int, int> myDic = new MyDictionary<int, int>();
            //Dictionary<int, int> dic = new Dictionary<int, int>();
            myDic.Add(2, 22);
            myDic.Add(1, 11);
            myDic.Add(4, 44);
            myDic.Add(6, 44);
            //myDic.Add(4, 44);
            //dic.Remove(1);
            //bool res = dic.ContainsKey(1);
            //res = myDic.Contains(1);
            //myDic.Remove(1);

            //IEnumerable<int>
            //Queue<int> q = new Queue<int>();

            HashSet<int> hs = new HashSet<int>
            {
                1
            };
            //SortedList<int>
            //SortedDictionary<int,int>
            //SortedSet<int>

            ConcurrentDictionary<int, int> dic = new ConcurrentDictionary<int, int>();
            dic.TryGetValue(1, out int temp);


            Console.Read();
        }
    }
}
