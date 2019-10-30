using System;
using System.Collections.Generic;
using System.Text;

namespace 链表
{
    public sealed class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> next;
        internal LinkedListNode<T> prev;
        internal T item;

        public LinkedListNode(T value)
        {
            this.item = value;
        }

        internal LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.item = value;
        }

        public LinkedList<T> List
        {
            get
            {
                return this.list;
            }
        }

        public LinkedListNode<T> Next
        {
            get
            {
                if (this.next != null && this.next != this.list.head)
                    return this.next;
                return (LinkedListNode<T>)null;
            }
        }

        public LinkedListNode<T> Previous
        {
            get
            {
                if (this.prev != null && this != this.list.head)
                    return this.prev;
                return (LinkedListNode<T>)null;
            }
        }

        public T Value
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        internal void Invalidate()
        {
            this.list = (LinkedList<T>)null;
            this.next = (LinkedListNode<T>)null;
            this.prev = (LinkedListNode<T>)null;
        }
    }
}
