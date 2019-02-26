using System;
using System.Collections.Generic;

namespace MyDictionary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyDictionary<int, int> myDic = new MyDictionary<int, int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();
            myDic.Add(2, 22);
            myDic.Add(1, 11);
            myDic.Add(4, 44);
            dic.Add(1, 1);
            dic.Remove(1);
            bool res = dic.ContainsKey(1);
            res = myDic.Contains(1);
            myDic.Remove(1);
            Console.Read();
        }
    }
}
