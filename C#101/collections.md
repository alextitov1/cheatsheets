# Array

```C#
string[] ar = new string[10];
ar.Length - размерность

int[,] ar2 = new int[10,20] // two-dimensional array 10 x 20
```

# [List\<T> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)
```C#
var names = new List<string> { "<name>", "Ana", "Felipe" };
foreach (var name in names)
{
  Console.WriteLine($"Hello {name.ToUpper()}!");
}

Console.WriteLine($"The list has {names.Count} people in it");
Console.WriteLine($"My name is {names[0]}.");
```
##Properties
* l.Count;

##Methods
* l.Sort();
* l.Add("newname");
* l.Remove(3); // remove first 3
* l.RemoveAt(3); // remove element index 3
* l.RemoveAll(x => x == 3); // remove all 3
* l.RemoveRange(2,3)
* l.AddRange(new[] {88, 333, 1123123});
* l.Clear();

## ArrayList - Список из разнотипных элементов

```C#
var f = new ArrayList();
temp = (int)MyArryList[n];

```

## LinkedList

```C#
val ll = new LinkedList<int>();

ll.AddLast(1);
ll.AddFirst(3);

var last = ll.AddLast(4);
ll.AddBefore(last, 8);

