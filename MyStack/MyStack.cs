using System.Collections.Generic;

namespace MyStack
{

    public class MyStack<T>
    {
        private readonly List<T> _dataList;
        private int _index = -1;
        public int Count => _dataList.Count;

        public MyStack() : this(null)
        {

        }

        public MyStack(List<T> dataList)
        {
            _dataList = dataList ?? new List<T>();
        }

        public void Push(T data)
        {
            _dataList.Add(data);
            _index++;
        }

        public T Pop()
        {
            var data = _dataList[_index];
            _dataList.RemoveAt(_index);
            _index--;
            return data;
        }

        public T Peek()
        {
            return _dataList[_index];
        }

        public void Clear()
        {
            _index = -1;
            _dataList.Clear();
        }
    }
}
