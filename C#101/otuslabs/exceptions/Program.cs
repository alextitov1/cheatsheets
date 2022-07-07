using System;
using System.Linq;

namespace tables
{
    class Program
    {
		static void Main(string[] args)
        {
            Console.Clear();
            try 
            {
                Calculate();
            }
            catch (Exception)
            {
                Console.WriteLine("something went wrong, Calculator will be closed");
            }
        }
        static void Calculate()
        {
            do 
            {
                try 
                {
                    Console.WriteLine("enter an expression or type stop for exit");
                    var textString = Console.ReadLine();
                    if (textString == "stop") break;
                    List<string> args = textString.Trim().Split().ToList();       
                    if (args.Count % 2 == 0) throw new FormatException();
                    Console.WriteLine($"result {Calc(args)}\n");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("division by zero");
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("expresion doesn't match the format \nusage examples:\n a + b \n a * b / c ");
                }
                catch (GreenException ex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"integer overflow occurred, max result is {int.MaxValue}");
                }
                finally
                {
                    Console.ResetColor();
                }
            }
            while (true);
        }

        static double Calc(List<string> lArgs)
        {
            var allowedSymbols = new List<char> {'+', '-', '*', '/', '%'};
            var res = int.Parse(lArgs[0]);

            for (int i = 1; i < lArgs.Count; i += 2)
            {
                var lSymbol = char.Parse(lArgs[i]);
                if (!allowedSymbols.Contains(lSymbol)) throw new FormatException();

                var lTerm = int.Parse(lArgs[i+1]);
                switch (lSymbol)
                {
                    case '+':
                        res = Sum(res, lTerm);
                        break;
                    case '-':
                        res = Sub(res, lTerm);
                        break;
                    case '*':
                        res = Mult(res, lTerm);
                        break;
                    case '/':
                        res = Div(res, lTerm);
                        break;
                    default:
                        throw new GreenException($"operation {lSymbol} ins't supported");
                }
            }
            if (res == 13) throw new GreenException($"result is thirteen");
            return res;
        }
        static int Sum(int a, int b) => checked(a + b);
        static int Sub(int a, int b) => checked(a - b);
        static int Mult(int a, int b) => checked(a * b);
        static int Div(int a, int b) => checked(a / b);

        class GreenException : Exception
        {
            public GreenException(string message) : base(message) { }
        }
    }
}