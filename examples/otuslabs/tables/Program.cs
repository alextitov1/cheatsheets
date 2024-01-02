using System;
using System.Linq;

namespace tables
{
    class Program
    {
		static string Table2MidStr(int isEven, int strWight)
        {
			var str = (isEven == 0) ? string.Concat(Enumerable.Repeat("+ ", strWight / 2)) : string.Concat(Enumerable.Repeat(" +", strWight / 2));
			return str[..(strWight - 2)];
		}

		static void Main(string[] args)
        {
			//declare variables
            int n;
            string textString;

			//input a table size
            do
			{
				Console.Write("Enter the table size: ");
				var readSize = Convert.ToString(Console.ReadKey().KeyChar);
				if ((int.TryParse(readSize, out n)) && (n is > 0 and <= 6))
                    break;
				else
					Console.WriteLine("\nTable size must be an integer from 1 to 6");
			} while (true);

			//input a string
			Console.WriteLine("");
			do
			{
				Console.Write("Enter the text string: ");
				textString = Console.ReadLine();
				if (textString.Length > 0)
						break;
				Console.WriteLine("Text string cannot be empty");
			} while (true);

			var tableWidth = (n * 2 + textString.Length >= 40) ? 40 : n * 2 + textString.Length;

			for (var i = 1; i <= n * 4; i++)
            {
				switch (i)
                {

					case 1: //top border
					case var value1 when value1 == n * 2: //intermediate border
					case var value2 when value2 == n * 4: //intermediate border2
						Console.WriteLine(new String('+', tableWidth));
						break;
					case var value when value == n: //text string (String1)
						Console.WriteLine('+' + new string(' ', n - 1) + textString + new string(' ', n - 1) + '+');
						break;
					case var value when value > n * 2 && value < n * 4: //String2
						Console.WriteLine('+' + Table2MidStr(i % 2, tableWidth) + '+');
						break;
					default:
						Console.WriteLine('+' + new string(' ', tableWidth - 2) + '+'); //blank strings (String1)
						break;

				}


            }

			Console.WriteLine("\n Press any key to exit");
			Console.ReadKey();
		}
    }
}
