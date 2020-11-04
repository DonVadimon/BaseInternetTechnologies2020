using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Sem3Lab3_Collections
{
    partial class Matrix<T> : IPrint
    {
        public List<MatrixElement<T>> NotNullElements { get; private set; }
        public int n { get; private set; }
        public int m { get; private set; }
        public int l { get; private set; }

        public Matrix(int n, int m, int l)
        {
            this.n = n;
            this.m = m;
            this.l = l;
            this.NotNullElements = new List<MatrixElement<T>>();
        }

        public void AddElement(T data, int x, int y, int z)
        {
            if (x > this.n || x <= 0 || y > this.m || y <= 0 || z > this.l || z <= 0)
            {
                throw new InvalidOperationException("Invalid indexes");
            }
            var newElem = new MatrixElement<T>(data, x, y, z);
            this.NotNullElements.Add(newElem);
        }

        public void Print()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    for (int k = 0; k < this.l; k++)
                    {
                        var notNullElem = this.NotNullElements.Where(item => item.x - 1 == i && item.y - 1 == j && item.z - 1 == k).ToList();
                        if (notNullElem.Any())
                        {
                            Console.Write(notNullElem.First().ToString() + "\t");
                        }
                        else
                        {
                            Console.Write("0 \t");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
