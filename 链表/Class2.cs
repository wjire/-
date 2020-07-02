using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace 链表
{
    public class LinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback
    {
        internal LinkedListNode<T> head;
        internal int count;
        internal int version;
        private object _syncRoot;
        private SerializationInfo _siInfo;

        public LinkedList()
        {
        }

        public LinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (T obj in collection)
            {
                AddLast(obj);
            }
        }

        protected LinkedList(SerializationInfo info, StreamingContext context)
        {
            _siInfo = info;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public LinkedListNode<T> First
        {
            get
            {
                return head;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                if (head != null)
                {
                    return head.prev;
                }

                return null;
            }
        }

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        void ICollection<T>.Add(T value)
        {
            AddLast(value);
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(node.list, value);
            InternalInsertNodeBefore(node.next, newNode);
            return newNode;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ValidateNode(node);
            ValidateNewNode(newNode);
            InternalInsertNodeBefore(node.next, newNode);
            newNode.list = this;
        }

        public 链表.LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(node.list, value);
            InternalInsertNodeBefore(node, newNode);
            if (node == head)
            {
                head = newNode;
            }

            return newNode;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ValidateNode(node);
            ValidateNewNode(newNode);
            InternalInsertNodeBefore(node, newNode);
            newNode.list = this;
            if (node != head)
            {
                return;
            }

            head = newNode;
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(newNode);
            }
            else
            {
                InternalInsertNodeBefore(head, newNode);
                head = newNode;
            }
            return newNode;
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            ValidateNewNode(node);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
                head = node;
            }
            node.list = this;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(newNode);
            }
            else
            {
                InternalInsertNodeBefore(head, newNode);
            }

            return newNode;
        }

        public void AddLast(LinkedListNode<T> node)
        {
            ValidateNewNode(node);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
            }

            node.list = this;
        }

        public void Clear()
        {
            LinkedListNode<T> linkedListNode1 = head;
            while (linkedListNode1 != null)
            {
                LinkedListNode<T> linkedListNode2 = linkedListNode1;
                linkedListNode1 = linkedListNode1.Next;
                linkedListNode2.Invalidate();
            }
            head = null;
            count = 0;
            ++version;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }




            LinkedListNode<T> linkedListNode = head;
            if (linkedListNode == null)
            {
                return;
            }

            do
            {
                array[index++] = linkedListNode.item;
                linkedListNode = linkedListNode.next;
            }
            while (linkedListNode != head);
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> linkedListNode = head;
            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
            if (linkedListNode != null)
            {
                if (value != null)
                {
                    while (!equalityComparer.Equals(linkedListNode.item, value))
                    {
                        linkedListNode = linkedListNode.next;
                        if (linkedListNode == head)
                        {
                            goto label_8;
                        }
                    }
                    return linkedListNode;
                }
                while (linkedListNode.item != null)
                {
                    linkedListNode = linkedListNode.next;
                    if (linkedListNode == head)
                    {
                        goto label_8;
                    }
                }
                return linkedListNode;
            }
            label_8:
            return null;
        }

        public 链表.LinkedListNode<T> FindLast(T value)
        {
            if (head == null)
            {
                return null;
            }

            链表.LinkedListNode<T> prev = head.prev;
            链表.LinkedListNode<T> linkedListNode = prev;
            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
            if (linkedListNode != null)
            {
                if (value != null)
                {
                    while (!equalityComparer.Equals(linkedListNode.item, value))
                    {
                        linkedListNode = linkedListNode.prev;
                        if (linkedListNode == prev)
                        {
                            goto label_10;
                        }
                    }
                    return linkedListNode;
                }
                while (linkedListNode.item != null)
                {
                    linkedListNode = linkedListNode.prev;
                    if (linkedListNode == prev)
                    {
                        goto label_10;
                    }
                }
                return linkedListNode;
            }
            label_10:
            return null;
        }

        public 链表.LinkedList<T>.Enumerator GetEnumerator()
        {
            return new 链表.LinkedList<T>.Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T value)
        {
            链表.LinkedListNode<T> node = Find(value);
            if (node == null)
            {
                return false;
            }

            InternalRemoveNode(node);
            return true;
        }

        public void Remove(链表.LinkedListNode<T> node)
        {
            ValidateNode(node);
            InternalRemoveNode(node);
        }

        public void RemoveFirst()
        {


            InternalRemoveNode(head);
        }

        public void RemoveLast()
        {


            InternalRemoveNode(head.prev);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("Version", version);
            info.AddValue("Count", count);
            if (count == 0)
            {
                return;
            }

            T[] array = new T[count];
            CopyTo(array, 0);
            info.AddValue("Data", array, typeof(T[]));
        }

        public virtual void OnDeserialization(object sender)
        {
            if (_siInfo == null)
            {
                return;
            }

            int int32 = _siInfo.GetInt32("Version");
            if (_siInfo.GetInt32("Count") != 0)
            {
                T[] objArray = (T[])_siInfo.GetValue("Data", typeof(T[]));

                for (int index = 0; index < objArray.Length; ++index)
                {
                    AddLast(objArray[index]);
                }
            }
            else
            {
                head = null;
            }

            version = int32;
            _siInfo = null;
        }

        private void InternalInsertNodeBefore(链表.LinkedListNode<T> node, 链表.LinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            ++version;
            ++count;
        }

        private void InternalInsertNodeToEmptyList(链表.LinkedListNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            head = newNode;
            ++version;
            ++count;
        }

        internal void InternalRemoveNode(链表.LinkedListNode<T> node)
        {
            if (node.next == node)
            {
                head = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (head == node)
                {
                    head = node.next;
                }
            }
            node.Invalidate();
            --count;
            ++version;
        }

        internal void ValidateNewNode(链表.LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
        }

        internal void ValidateNode(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);
                }

                return _syncRoot;
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }



            if (array.Length - index < Count)
            {

            }

            T[] array1 = array as T[];
            if (array1 != null)
            {
                CopyTo(array1, index);
            }
            else
            {
                object[] objArray = array as object[];


                链表.LinkedListNode<T> linkedListNode = head;
                try
                {
                    if (linkedListNode == null)
                    {
                        return;
                    }

                    do
                    {
                        objArray[index++] = linkedListNode.item;
                        linkedListNode = linkedListNode.next;
                    }
                    while (linkedListNode != head);
                }
                catch (ArrayTypeMismatchException)
                {
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator, ISerializable, IDeserializationCallback
        {
            private readonly 链表.LinkedList<T> _list;
            private 链表.LinkedListNode<T> _node;
            private readonly int _version;
            private T _current;
            private int _index;

            internal Enumerator(链表.LinkedList<T> list)
            {
                _list = list;
                _version = list.version;
                _node = list.head;
                _current = default(T);
                _index = 0;
            }

            public T Current
            {
                get
                {
                    return _current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || _index == _list.Count + 1)
                    {
                    }

                    return _current;
                }
            }

            public bool MoveNext()
            {
                if (_version != _list.version)
                {
                }

                if (_node == null)
                {
                    _index = _list.Count + 1;
                    return false;
                }
                ++_index;
                _current = _node.item;
                _node = _node.next;
                if (_node == _list.head)
                {
                    _node = null;
                }

                return true;
            }

            void IEnumerator.Reset()
            {
                if (_version != _list.version)
                {
                }

                _current = default(T);
                _node = _list.head;
                _index = 0;
            }

            public void Dispose()
            {
            }

            void ISerializable.GetObjectData(
              SerializationInfo info,
              StreamingContext context)
            {
                throw new PlatformNotSupportedException();
            }

            void IDeserializationCallback.OnDeserialization(object sender)
            {
                throw new PlatformNotSupportedException();
            }
        }
    }
}
