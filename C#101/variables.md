```C#
string aFriend = "Bill";
```
```C#
int a = 18;
int e = (a + b) % c; //% - remainder
int max = int.MaxValue;
int min = int.MinValue;
Console.WriteLine($"The range of integers is {min} to {max}");
```


## Predefined data types
| **C#**  | **Mono**       | **Signed** | **Memory** | **Range**                                   |
|---------|----------------|------------|------------|---------------------------------------------|
| sbyte   | System.Sbyte   | Yes        | 1 byte     | –128 to 127                                 |
| short   | System.Int16   | Yes        | 2 bytes    | –32768 to 32767                             |
| int     | System.Int32   | Yes        | 4 bytes    | –2147483648 to 2147483647                   |
| long    | System.Int64   | Yes        | 8 bytes    | –9223372036854775808 to 9223372036854775807 |
| byte    | System.Byte    | No         | 1 byte     | 0 to 255                                    |
| ushort  | System.Uint16  | No         | 2 bytes    | 0 to 65535                                  |
| uint    | System.Uint32  | No         | 4 bytes    | 0 to 4294967295                             |
| ulong   | System.Uint64  | No         | 8 bytes    | 0 to 18446744073709551615                   |
| float   | System.Single  | Yes        | 4 bytes    | –1.5x10-45 to 3.4 x x1038                   |
| double  | System.Double  | Yes        | 8 bytes    | –5.0x10-324 to 1.7x10308                    |
| decimal | System.Decimal | Yes        | 12 bytes   | 1.0x10-28 to 7.9x1028                       |
| char    | System.Char    |            | 2 bytes    | Unicode characters                          |
| boolean | System.Boolean |            | 1 byte     | True or false                               |
