using System;
using System.Collections.Generic;
using System.Text;

namespace Sem3Lab3_Collections
{
    partial class LinkedList<T> : IEnumerable<T>
    {
        public class Node<T>
        {
            public T data { get; set; } = default(T);
            public Node<T> Next { get; set; } = null;
            public Node(T data)
            {
                if (data != null)
                {
                    this.data = data;
                }
                else
                {
                    throw new ArgumentNullException(nameof(data));
                }
            }
            public override string ToString()
            {
                return this.data.ToString();
            }
        }
    }
}
