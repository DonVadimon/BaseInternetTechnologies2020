using System;
using System.Collections.Generic;

namespace Sem3Lab1_Equation
{
    class Program
    {

        static double CoefInput()
        {
            double coef;
            Console.WriteLine("Enter Coefficient: ");
            string line = Console.ReadLine();
            if (!Double.TryParse(line, out coef))
            {
                Console.WriteLine("Invalid Input!");
                coef = CoefInput();
            }
            return coef;
        }

        static double[] GetCoefficients(string[] args)
        {
            var coefs = new double[3];
            if (args.Length != 3)
            {
                Console.WriteLine("Enter a:");
                do
                {
                    coefs[0] = CoefInput();
                } while (coefs[0] == 0);
                
                Console.WriteLine("a = {0}", coefs[0]);

                Console.WriteLine("Enter b:");
                coefs[1] = CoefInput();
                Console.WriteLine("b = {0}", coefs[1]);

                Console.WriteLine("Enter c:");
                coefs[2] = CoefInput();
                Console.WriteLine("c = {0}", coefs[2]);
            }
            else
            {
                if (!double.TryParse(args[0], out coefs[0]))
                {
                    Console.WriteLine("Incorrect data! Input A:");
                    do
                    {
                        coefs[0] = CoefInput();
                    } while (coefs[0] == 0);
                }
                if (!double.TryParse(args[1], out coefs[1]))
                {
                    Console.WriteLine("Incorrect data! Input B:");
                    coefs[1] = CoefInput();
                }
                if (!double.TryParse(args[2], out coefs[2]))
                {
                    Console.WriteLine("Incorrect data! Input C:");
                    coefs[2] = CoefInput();
                }
            }

            return coefs;
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\tИУ5-35 Хижняков Вадим");
            Console.ResetColor();

            double[] coefs = GetCoefficients(args);

            HashSet<double> roots = new HashSet<double>();


            double D = Math.Pow(coefs[1], 2) - 4 * coefs[0] * coefs[2];
            roots.Add(Math.Sqrt((-coefs[1] + Math.Sqrt(D)) / 2 * coefs[0]));
            roots.Add(Math.Sqrt((-coefs[1] - Math.Sqrt(D)) / 2 * coefs[0]));
            roots.Add(-Math.Sqrt((-coefs[1] + Math.Sqrt(D)) / 2 * coefs[0]));
            roots.Add(-Math.Sqrt((-coefs[1] - Math.Sqrt(D)) / 2 * coefs[0]));
            roots.Remove(Double.NaN);

            if (roots.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO ROOTS!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("ROOTS:");
                foreach (var root in roots)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t* {0}\n", root);
                    Console.ResetColor();
                }
            }
        }
    }
}