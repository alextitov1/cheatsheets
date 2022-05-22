# [Conditional operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator)

```C#
classify = (input >= 0) ? "nonnegative" : "negative";
```
```C#
string GetWeatherDisplay(double tempInCelsius) => tempInCelsius < 20.0 ? "Cold." : "Perfect!";
```
# [Selection-statements](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements)
```C#
DisplayMeasurement(-4);  // Output: Measured value is -4; too low.
DisplayMeasurement(5);  // Output: Measured value is 5.
DisplayMeasurement(30);  // Output: Measured value is 30; too high.
DisplayMeasurement(double.NaN);  // Output: Failed measurement.

void DisplayMeasurement(double measurement)
{
    switch (measurement)
    {
        case < 0.0:
            Console.WriteLine($"Measured value is {measurement}; too low.");
            break;

        case > 15.0:
            Console.WriteLine($"Measured value is {measurement}; too high.");
            break;

        case double.NaN:
            Console.WriteLine("Failed measurement.");
            break;

        default:
            Console.WriteLine($"Measured value is {measurement}.");
            break;
    }
}
```
```C#
```
```C#
```
```C#
```
```C#
```