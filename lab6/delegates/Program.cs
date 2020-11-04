using System;
using System.Runtime.InteropServices.ComTypes;

namespace Sem3Lab6_Delegates
{
    delegate T doSomething<T>(int a, double b);
    class Program
    {
        static double Sum(int a, double b) { return a + b; }

        static double Exponent(int a, double b, doSomething<double> del){ return Math.Pow(Math.E, del(a, b)); }

        static void Main(string[] args)
        {
            doSomething<double> del = Sum;
            Console.WriteLine(del?.Invoke(3, 2.5));
            Console.WriteLine(Exponent(1, 4.2, Sum));
            Console.WriteLine(Exponent(1, 4.2, del));
            Console.WriteLine(Exponent(1, 4.2, (a, b) => a + b));//если параметры передаются через ref/out обязательно указывать тип
            Console.WriteLine(Exponent(1, 4.2, (a, b) => Sum(a, b)));
            Func<int, double, double> func = Sum;
            Console.WriteLine(Exponent(1, 4.2, func.Invoke));
        }
    }
}