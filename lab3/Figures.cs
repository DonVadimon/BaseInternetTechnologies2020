using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Sem3Lab3_Collections
{
    abstract class Figure : IComparable
    {
        public int CompareTo(object o)
        {
            if (o == null)
                return 1;

            Figure f = o as Figure;
            if (f != null)
            {
                return this.GetArea().CompareTo(f.GetArea());
            }
            else
            {
                throw new Exception("Невозможно сравнить");
            }
        }

        public abstract double GetArea();
    }

    interface IPrint
    {
        public void Print();
    }

    class Rectangle : Figure, IPrint
    {
        public double a { get; set; } = 0;
        public double b { get; set; } = 0;
        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override double GetArea()
        {
            return a * b;
        }
        public override string ToString()
        {
            return "Lenght: " + a.ToString() + " Width: " + b.ToString() + " Area: " + this.GetArea().ToString();
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Square : Rectangle, IPrint
    {
        public Square(double a) : base(a, a) { }
        public override string ToString()
        {
            return "Side: " + a.ToString() + " Area: " + this.GetArea().ToString();
        }
    }

    class Circle : Figure, IPrint
    {
        public double r { get; set; } = 0;
        public Circle(double r)
        {
            this.r = r;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(r, 2);
        }
        public override string ToString()
        {
            return "Radius: " + r.ToString() + " Area: " + this.GetArea().ToString();
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
