# Branches
* `==` - tests for **quality**
* `&&` - represents **and**
* `||` - represents **or**

[Conditional operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator)

## if
```C#
classify = (input >= 0) ? "nonnegative" : "negative";
```

```C#
int a = 5;
int b = 6;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10.");
```

```C#
int a = 5;
int b = 3;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10");
else
    Console.WriteLine("The answer is not greater than 10");
```

```C#
int a = 5;
int b = 3;
int c = 4;
if ((a + b + c > 10) && (a == b))
{
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("And the first number is equal to the second");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("Or the first number is not equal to the second");
}
```
## case
```C#
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
		Console.WriteLine('+' + String2(i % 2, tableWidth) + '+');
		break;
	default:
		Console.WriteLine('+' + new string(' ', tableWidth - 2) + '+'); //blank strings (String1)
		break;
}
```

# Loops
```C#
int counter = 0;
while (counter < 10)
{
  Console.WriteLine($"Hello World! The counter is {counter}");
  counter++;
}
```
```C#
int counter = 0;
do
{
  Console.WriteLine($"Hello World! The counter is {counter}");
  counter++;
} while (counter < 10);
```
```C#
var names = new List<string> { "<name>", "Ana", "Felipe" };
foreach (var name in names)
{
  Console.WriteLine($"Hello {name.ToUpper()}!");
}
```
```C#
```