# Enum in C#

In C#, there's an important distinction between `enum` and `Enum`:

## `enum` (lowercase)
- **Keyword**: `enum` is a C# keyword used to declare enumeration types
- **Used for declaration**: You use it to create your own enumeration types
- **Compile-time construct**: It's part of the language syntax

```csharp
// Using 'enum' keyword to declare an enumeration
public enum DayOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

public enum Status
{
    Active = 1,
    Inactive = 2,
    Pending = 3
}
```

## `Enum` (uppercase)
- **Base class**: `Enum` is the base class that all enumeration types inherit from
- **System.Enum**: It's a class in the `System` namespace
- **Provides methods**: Contains static and instance methods for working with enumerations

```csharp
using System;

public class Program
{
    public static void Main()
    {
        // Using Enum class methods
        string[] dayNames = Enum.GetNames(typeof(DayOfWeek));
        Console.WriteLine("Days: " + string.Join(", ", dayNames));
        
        // Parse string to enum
        DayOfWeek today = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), "Monday");
        Console.WriteLine($"Today is: {today}");
        
        // Check if value is defined
        bool isValid = Enum.IsDefined(typeof(DayOfWeek), "Friday");
        Console.WriteLine($"Is Friday valid? {isValid}");
        
        // Get underlying type
        Type underlyingType = Enum.GetUnderlyingType(typeof(Status));
        Console.WriteLine($"Status underlying type: {underlyingType}");
    }
}
```

## Key Differences Summary:

| Aspect | `enum` | `Enum` |
|--------|--------|--------|
| **Type** | Keyword | Class |
| **Purpose** | Declare enumerations | Work with enumeration instances |
| **Usage** | `enum MyEnum { ... }` | `Enum.Parse()`, `Enum.GetNames()` |
| **When to use** | Creating enum types | Runtime enum operations |

## Common Enum Class Methods:

```csharp
// Useful Enum class methods
Enum.GetNames(typeof(DayOfWeek))           // Get all names
Enum.GetValues(typeof(DayOfWeek))          // Get all values
Enum.Parse(typeof(DayOfWeek), "Monday")    // Parse string to enum
Enum.TryParse<DayOfWeek>("Monday", out var day)  // Safe parsing
Enum.IsDefined(typeof(DayOfWeek), "Monday") // Check if value exists
Enum.GetUnderlyingType(typeof(Status))     // Get underlying type (int, byte, etc.)
```

So in summary: use `enum` to **create** enumerations, use `Enum` to **work with** them at runtime.
