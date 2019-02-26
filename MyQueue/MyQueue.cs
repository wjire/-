using System;

namespace MyQueue
{
    public class MyQueue<T>
    {
        private static T[] _emptyArray = new T[0];
        private T[] _array;
        private int _head;
        private int _tail;
        private int _size;
        private int _version;
        [NonSerialized]
        private object _syncRoot;
        private const int _MinimumGrow = 4;
        private const int _ShrinkThreshold = 32;
        private const int _GrowFactor = 200;
        private const int _DefaultCapacity = 4;

        public MyQueue()
        {
            _array = MyQueue<T>._emptyArray;
        }

        public void Enqueue(T item)
        {
            if (_size == _array.Length)
            {
                int capacity = (_array.Length * 2);
                if (capacity < _array.Length + 4)
                {
                    capacity = _array.Length + 4;
                }

                SetCapacity(capacity);
            }
            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            ++_size;
            ++_version;
        }

        private void SetCapacity(int capacity)
        {
            T[] objArray = new T[capacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy((Array)_array, _head, (Array)objArray, 0, _size);
                }
                else
                {
                    Array.Copy((Array)_array, _head, (Array)objArray, 0, _array.Length - _head);
                    Array.Copy((Array)_array, 0, (Array)objArray, _array.Length - _head, _tail);
                }
            }
            _array = objArray;
            _head = 0;
            _tail = _size == capacity ? 0 : _size;
            ++_version;
        }


        public T Dequeue()
        {
            //if (this._size == 0)
            //    ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EmptyQueue);
            T obj = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _array.Length;
            --_size;
            ++_version;
            return obj;
        }
    }
}
