```C#
Console.Write(2);
Console.WriteLine($HEX {243:X}");

int Console.Read()
ConsoleKeyInfo Console.ReadKey()
string Console.ReadLine()

int.Parse("12345");
bool.TryParse("true");

Console.Clear()
Console.SetCursorPosition(left, top)
Console.BackgroundColor, Console.ForegroundColor
```

```C#
do
{
    Console.Write("Enter the table size: ");
	var readSize = Convert.ToString(Console.ReadKey().KeyChar);
	if ((int.TryParse(readSize, out n)) && ((n > 0) && (n <= 6)))
        break;
	else
		Console.WriteLine("\nTable size must be an integer from 1 to 6");
	} while (true);
```