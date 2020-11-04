using System;

namespace Sem3Lab2_Figures
{
    class Program
    {
        abstract class Figure
        {
            public abstract double GetArea();
        }

        interface IPrint
        {
            public void Print();
        }

        class Rectangle : Figure, IPrint
        {
            public double a { get; set; }
            public double b { get; set; }
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
                return "Lenght: " + a.ToString() + " Width: " + b.ToString() +  " Area: " + this.GetArea().ToString();
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
            public double r { get; set; }
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

        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(4, 5);
            rec.Print();

            Square sqr = new Square(6);
            sqr.Print();

            Circle crcl = new Circle(9);
            crcl.Print();
        }
    }
}
