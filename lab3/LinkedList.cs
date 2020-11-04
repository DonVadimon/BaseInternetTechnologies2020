using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sem3Lab3_Collections
{
    partial class LinkedList<T> : IEnumerable<T>
    {
        protected Node<T> _head;
        protected Node<T> _tail;
        public int _size { get; protected set; }

        public LinkedList()
        {
            this._head = null;
            this._tail = null;
            this._size = 0;
        }
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var node = new Node<T>(data);

            if (_head == null)
            {
                this._head = node;
            }
            else
            {
                this._tail.Next = node;
            }
            _tail = node;
            _size++;
        }

        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var current = this._head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            this._tail = previous;
                        }
                    }
                    else
                    {
                        this._head = this._head.Next;
                        if (this._head == null)
                        {
                            this._tail = null;
                        }
                    }
                    this._size--;
                    break;
                }
                previous = current;
                current = current.Next;
            }
        }

        public void Clear()
        {
            this._head = null;
            this._tail = null;
            this._size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
            while (current != null)
            {
                yield return current.data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
