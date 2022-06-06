# Strings
string - **immutable** 
ReferenceEquals(s1, s2)
s3 = string.Intern(s3)

`$" text {variable} "` - [string interpolation]

### Properties
* s.Length;

### Methods - return new string objects
* s.Trim();
* s.TrimStart();
* s.Replace("Hello", "Greetings");
* s.ToUpper();
* s.Contains("goodbye");


## [Interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated)

**{<interpolationExpression>[,<alignment>][:<formatString>]}**

```C#
string firstFriend = "Maria";
string secondFriend = "Sage";
Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");

//Aligment
Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

//verbatim
Console.WriteLine(@"Text C:\Windows\System32")

## Concatenation
```C#
var str = new String('+', tableWidth);
var Hello = string.Concat("Hello", " Otus")
```

### StringBuilder
```C#
var sb = new StringBuilder();

sb.Append("Hello");
sb.Append(" Otus");

var res = sb.ToString();
```

```C#
str[..(strWight - 2)]
```

```C#
```

# char
2 bytes

```C#
char c = 'j';
char c = '\u006A'; //hex unicode
```
```C#
```
```C#
```


