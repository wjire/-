using System;
using System.Collections.Generic;

namespace MyDictionary
{

    /*
     * 先将 key 和 bucket 的长度一起,经过简单的 hash 算法计算出元素应该放在哪个 bucket .
     * 但是,元素并不是放在 bucket 里面的,bucket 只是对元素存放位置的第一次计算, 它其实是为了解决 hash 冲突设计的,它并不存放我们添加的元素.
     * 当确定了 bucket 后,再将元素存放在 Entry[] 中, 这个数组才是实际存放元素的容器.并且所有元素都存放在这个数组中.
     * 因此,当 Dictionary 需要扩容的时候,不仅 bucket 需要扩容, Entry[] 也需要扩容,当然,数组长度是不能变的,肯定是新建一个容量更大的,然后 copy 一份老的数据过去.
     * 前面说了,hash 会冲突,比如 1%3=1 , 4%3=1 ,那么这时候,1 和 4 这两个数作为 key ,就会导致 hash 冲突,它们两个通过计算后,都会选择 bucket[1] 这个"桶",
     * 那么,问题来了,
     * bucket[1] = ? , 如果没有 hash 冲突,这个值完全可以用来存储 key 对应的 value.但是现在有两个"相同的" key 对应的 value 都需要存到这里,怎么办呢?
     * 答案是"栈"+"链表",之所以加个引号,是因为不是真正用的栈和链表,而是借用了它们的思想.
     * bucket 里面存储的是当前 bucket "里面" 最后添加的那个元素在 Entry[] 中的下标.
     * 比如,我们先添加一个 dic.Add(1,value) ,那么,这时候,Entry[] 就有1个元素了,Entry[0] 
     * 我们假设通过 hash 计算,这个键值对元素应该放在 bucket[1] 这个桶里面,因此这时候 bucket[0] = 0 ,等号右边的 0 表示 Entry[] 的下标.
     * 我们再 Add(4,value),这时候,Entry[] 有2个元素,Entry[0] 和 Entry[1],
     * 并且我们假设通过 hash 计算,这个键值对元素也应该放在 bucket[1] 这个桶里面,
     * 那么,这时候 bucket[0] 就不在 = 0了,而是 = 1,
     * 并且 Entry[1] 中的元素(Entry 类型)有个 next 字段,其值 = 0,  这个 0 就是 Entry[] 的索引,表示该元素的下个元素是 Entry[0] ,进一步说就是
     * 桶1里面有两个元素,最上面的(第2次放进去的)是 Entry[1] ,第2个(第1次放进去的那个)是 Entry[0],并且通过 Entry[1] 是可以找到 Entry[0] 的.
     * 到这里,突然发现 bucket 这个命名很形象.
     * 桶有什么特点呢?桶就好比是一个栈,"先进后出",最先进去的在最下面.
     * 也就是说,一个桶第一次装进去的那个元素的 next 永远 = -1
     * 第2次进去的指向第1个,第3次进去的指向第2个......
     * 感觉这个设计好巧妙!!!
     *
     */
    public class MyDictionary<TKey, TValue>
    {
        private int[] buckets;//确定元素存放位置的桶
        private MyDictionary<TKey, TValue>.Entry[] entries;//实际存放元素的数组.
        private int count;
        private int version;
        private int freeList;
        private int freeCount;
        private IEqualityComparer<TKey> comparer;
        private Dictionary<TKey, TValue>.KeyCollection keys;
        private Dictionary<TKey, TValue>.ValueCollection values;
        private object _syncRoot;
        private const string VersionName = "Version";
        private const string HashSizeName = "HashSize";
        private const string KeyValuePairsName = "KeyValuePairs";
        private const string ComparerName = "Comparer";

        public MyDictionary() : this(0)
        {

        }

        public MyDictionary(int capacity)
        {
            Initialize(capacity);
        }

        private void Initialize(int capacity)
        {
            int prime = MyHashHelpers.GetPrime(capacity);
            buckets = new int[prime];
            for (int index = 0; index < buckets.Length; ++index)
            {
                buckets[index] = -1;
            }

            entries = new MyDictionary<TKey, TValue>.Entry[prime];
            freeList = -1;
        }


        public void Add(TKey key, TValue value)
        {
            if (buckets == null)
            {
                Initialize(0);
            }

            int num1 = key.GetHashCode() & int.MaxValue;
            int index1 = num1 % buckets.Length;
            int num2 = 0;
            for (int index2 = buckets[index1]; index2 >= 0; index2 = entries[index2].next)
            {
                if (entries[index2].hashCode == num1 && entries[index2].key.Equals(key))
                {
                    throw new Exception("不能添加相同的元素");
                }
                ++num2;
            }
            int index3;
            if (freeCount > 0)
            {
                index3 = freeList;
                freeList = entries[index3].next;
                --freeCount;
            }
            else
            {
                if (count == entries.Length)
                {
                    Resize();
                    index1 = num1 % buckets.Length;
                }
                index3 = count;
                ++count;
            }
            entries[index3].hashCode = num1;
            entries[index3].next = buckets[index1];
            entries[index3].key = key;
            entries[index3].value = value;
            buckets[index1] = index3;
            ++version;
            if (num2 <= 100)
            {
                return;
            }
            //this.comparer = (IEqualityComparer<TKey>)MyHashHelpers.GetRandomizedEqualityComparer((object)this.comparer);
            Resize(entries.Length, true);
        }


        private void Resize()
        {
            Resize(MyHashHelpers.ExpandPrime(count), false);
        }

        private void Resize(int newSize, bool forceNewHashCodes)
        {
            int[] numArray = new int[newSize];
            for (int index = 0; index < numArray.Length; ++index)
            {
                numArray[index] = -1;
            }

            MyDictionary<TKey, TValue>.Entry[] entryArray = new MyDictionary<TKey, TValue>.Entry[newSize];
            Array.Copy((Array)entries, 0, (Array)entryArray, 0, count);
            if (forceNewHashCodes)
            {
                for (int index = 0; index < count; ++index)
                {
                    if (entryArray[index].hashCode != -1)
                    {
                        entryArray[index].hashCode = entryArray[index].key.GetHashCode() & int.MaxValue;
                    }
                }
            }
            for (int index1 = 0; index1 < count; ++index1)
            {
                if (entryArray[index1].hashCode >= 0)
                {
                    int index2 = entryArray[index1].hashCode % newSize;
                    entryArray[index1].next = numArray[index2];
                    numArray[index2] = index1;
                }
            }
            buckets = numArray;
            entries = entryArray;
        }

        public bool Contains(int key)
        {
            if (buckets != null)
            {
                int num = key.GetHashCode() & int.MaxValue;
                for (int index = buckets[num % buckets.Length]; index >= 0; index = entries[index].next)
                {
                    if (entries[index].hashCode == num && entries[index].key.Equals(key))
                    {
                        return index >= 0;
                    }
                }
            }
            return false;
        }


        public bool Remove(TKey key)
        {
            if (buckets != null)
            {
                int num = key.GetHashCode() & int.MaxValue;
                int index1 = num % buckets.Length;
                int index2 = -1;
                for (int index3 = buckets[index1]; index3 >= 0; index3 = entries[index3].next)
                {
                    if (entries[index3].hashCode == num && (entries[index3].key.Equals(key)))
                    {
                        if (index2 < 0)
                        {
                            buckets[index1] = entries[index3].next;
                        }
                        else
                        {
                            entries[index2].next = entries[index3].next;
                        }

                        entries[index3].hashCode = -1;
                        entries[index3].next = freeList;
                        entries[index3].key = default(TKey);
                        entries[index3].value = default(TValue);
                        freeList = index3;
                        ++freeCount;
                        ++version;
                        return true;
                    }
                    index2 = index3;
                }
            }
            return false;
        }

        private struct Entry
        {
            public int hashCode;
            public int next;
            public TKey key;
            public TValue value;
        }
    }
}
