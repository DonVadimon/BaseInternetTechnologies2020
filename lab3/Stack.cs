using System;
using System.Collections.Generic;
using System.Text;

namespace Sem3Lab3_Collections
{
    class Stack<T> : LinkedList<T>
    {
        private new void Add(T data) { }
        private new void Delete(T data) { }
        public Stack() : base() { }
        public void Push(T data)
        {
            var node = new Node<T>(data);
            node.Next = this._head;
            this._head = node;
            this._size++;
        }
        public T Pop()
        {
            var tmp = this._head;
            this._head = this._head.Next;
            this._size--;
            return tmp.data;
        }
    }
}
