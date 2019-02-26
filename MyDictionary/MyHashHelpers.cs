﻿using System;
using System.Collections.Generic;

namespace MyDictionary
{
    public class MyHashHelpers
    {
        public static readonly int[] primes = new int[72]
        {
            3,
            7,
            11,
            17,
            23,
            29,
            37,
            47,
            59,
            71,
            89,
            107,
            131,
            163,
            197,
            239,
            293,
            353,
            431,
            521,
            631,
            761,
            919,
            1103,
            1327,
            1597,
            1931,
            2333,
            2801,
            3371,
            4049,
            4861,
            5839,
            7013,
            8419,
            10103,
            12143,
            14591,
            17519,
            21023,
            25229,
            30293,
            36353,
            43627,
            52361,
            62851,
            75431,
            90523,
            108631,
            130363,
            156437,
            187751,
            225307,
            270371,
            324449,
            389357,
            467237,
            560689,
            672827,
            807403,
            968897,
            1162687,
            1395263,
            1674319,
            2009191,
            2411033,
            2893249,
            3471899,
            4166287,
            4999559,
            5999471,
            7199369
        };

        public static int GetPrime(int min)
        {
            if (min < 0)
            {
                throw new ArgumentException("Arg_HTCapacityOverflow");
            }

            for (int index = 0; index < MyHashHelpers.primes.Length; ++index)
            {
                int prime = MyHashHelpers.primes[index];
                if (prime >= min)
                {
                    return prime;
                }
            }
            int candidate = min | 1;
            while (candidate < int.MaxValue)
            {
                if (MyHashHelpers.IsPrime(candidate) && (candidate - 1) % 101 != 0)
                {
                    return candidate;
                }

                candidate += 2;
            }
            return min;
        }


        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
                return candidate == 2;
            int num1 = (int)Math.Sqrt((double)candidate);
            int num2 = 3;
            while (num2 <= num1)
            {
                if (candidate % num2 == 0)
                    return false;
                num2 += 2;
            }
            return true;
        }


        public static int ExpandPrime(int oldSize)
        {
            int min = 2 * oldSize;
            if ((uint)min > 2146435069U && 2146435069 > oldSize)
                return 2146435069;
            return MyHashHelpers.GetPrime(min);
        }

        public static bool IsWellKnownEqualityComparer(object comparer)
        {
            if (comparer != null && comparer != EqualityComparer<string>.Default)
                return true; //return comparer is IWellKnownStringEqualityComparer;
            return true;
        }
    }
}
