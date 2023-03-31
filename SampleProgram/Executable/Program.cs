// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace MainNS {
    class MainClass {

        static void Main(string[] args)
        {
            Library.Calculator c = new Library.Calculator();
            char op;
            int i = 0;
            int j = 0;
            bool exit = false;

            do
            {
                Console.Out.WriteLine("Please select operation:");
                Console.Out.WriteLine("A - To perform addition");
                Console.Out.WriteLine("S - To perform subtraction");
                Console.Out.WriteLine("M - To perform multiplicaiton");
                Console.Out.WriteLine("D - To perform division");
                Console.Out.WriteLine("Q - To quit\n");
                op = Console.ReadKey().KeyChar;
                
                switch (op)
                {
                    case 'A':
                        Console.Out.WriteLine("\nGive first number: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        Console.Out.WriteLine("Give second number: ");
                        j = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(i + "+" + j + "=" + c.Add(i, j));
                        break;
                    case 'S':
                        Console.Out.WriteLine("\nGive first number: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        Console.Out.WriteLine("Give second number: ");
                        j = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(i + "-" + j + "=" + c.Subtract(i, j));
                        break;
                    case 'M':
                        Console.Out.WriteLine("\nGive first number: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        Console.Out.WriteLine("Give second number: ");
                        j = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(i + "*" + j + "=" + c.Multiply(i, j));
                        break;
                    case 'D':
                        try
                        {
                            Console.Out.WriteLine("\nGive first number: ");
                            i = Convert.ToInt32(Console.ReadLine());
                            Console.Out.WriteLine("Give second number: ");
                            j = Convert.ToInt32(Console.ReadLine());
                            if (j == 0)
                            {
                                throw new ArithmeticException("Cannot divide by zero.\n");
                            }
                            Console.WriteLine(i + "/" + j + "=" + c.Divide(i, j));
                        }
                        catch (ArithmeticException)
                        {
                            Console.Out.WriteLine("Exception happened. Cannot divide by zero\n");
                        }
                        break;
                    case 'Q':
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (exit == false);
        }

    }
}
