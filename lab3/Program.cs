using System;
using System.Collections;
using System.Collections.Generic;

namespace Sem3Lab3_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(4, 5);
            Square sqr = new Square(6);
            Circle crcl = new Circle(1);

            ArrayList figures = new ArrayList();
            figures.Add(rect);
            figures.Add(sqr);
            figures.Add(crcl);

            try
            {
                figures.Sort();
            }
            catch (Exception e)
            {
                throw e;
            }

            foreach (var figure in figures)
            {
                Console.WriteLine(figure.ToString());
            }

            Console.WriteLine("-------------------------------------------");

            List<Figure> figures_list = new List<Figure>();
            figures_list.Add(rect);
            figures_list.Add(sqr);
            figures_list.Add(crcl);

            try
            {
                figures_list.Sort();
            }
            catch (Exception e)
            {

                throw e;
            }

            foreach (var figure in figures_list)
            {
                Console.WriteLine(figure);
            }

            LinkedList<int> list = new LinkedList<int>();
            list.Add(3);
            list.Add(5);
            list.Add(8);
            list.Add(5);

            Console.WriteLine();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            list.Delete(5);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------------------------");
            Stack<int> stack = new Stack<int>();
            stack.Push(3);
            stack.Push(7);
            foreach (var item in stack)
            {
                Console.WriteLine(stack.Pop());
            }

            ////////////////////////////////////////////////////////////
            Console.WriteLine();

            Matrix<int> m = new Matrix<int>(2, 3, 4);
            m.AddElement(99, 1, 2, 3);
            m.Print();
        }
    }
}
