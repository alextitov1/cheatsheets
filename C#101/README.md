C# in Depth 4th edition - Jon Skeet

data types:
## Array - 
```
string[] ar = new string[10];
ar.Length - размерность

int[,] ar2 = new int[10,20] // двухмерный массив 10 на 20

```
## List
```C#
var l = new List<int> (new [] {1,2,3,4,5});

l.Add(1000); // Append the list

l.Insert(2,100); // insert to 2nd position

l.Remove(3); // remove first 3
l.RemoveAt(3); // remove element index 3
l.RemoveAll(x => x == 3); // remove all 3
l.RemoveRange(2,3)
l.AddRange(new[] {88, 333, 1123123});
l.Clear();
```
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

````

## Collections