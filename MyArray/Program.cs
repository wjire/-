using System;
using System.Collections.Generic;
using System.Linq;

namespace MyArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //二维数组
            int[,] grades = new int[,]
            {
                {1, 99, 23, 44},
                {2, 99, 23, 441},
                {3, 99, 23, 44},
                {4, 991, 23, 44},
            };
            Console.WriteLine(grades[1, 3]);

            int[][] jagged = new int[12][];//锯齿状数组,一共12行,每一行又是一个数组,但是每一行的数组长度不定.

            List<int> list = new List<int>();
        }
    }
}
