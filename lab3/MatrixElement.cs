using System;
using System.Collections.Generic;
using System.Text;

namespace Sem3Lab3_Collections
{
    partial class Matrix<T>
    {
        public class MatrixElement<T>
        {
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }
            public T data { get; set; }
            public MatrixElement(T data, int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.data = data;
            }

            public override string ToString()
            {
                return "(" + this.x.ToString() + "," + this.y.ToString() + "," + this.z.ToString() + ":" + this.data.ToString() + ")";
            }
        }
    }
}
