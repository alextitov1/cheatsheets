# Lists
declare a list
list = []
```
list = ["This", "is", "a", "list"]
```
something **in** the list
list[0]

### list.append("New data") 
### list.insert(0, "New data")
### list.remove("element")
### list.pop("index")
### list.sort()
### list.reverse()
### list.clear()
### list.copy() - creates a copy of the list
### list.extend(other_list) - append


<br>

# Tuples
declare a tuple
tuple = () #parentheses

var1, var2, var3 = tuple # this unpack the tuple


>`enumerate()` function takes a list as a parameter and returns a tuple for each element in the list
```py
index, element in enumerate(elements)
```

### List Comprehensions
```
>>> list = [x*7 for x in range(1,11)]
>>> print(list)
[7, 14, 21, 28, 35, 42, 49, 56, 63, 70]
```
```py
def odd_numbers(n):
	return [x for x in range(1,n+1) if x % 2 != 0]
```
# Examples

```py
filenames = ["program.c", "stdio.hpp", "sample.hpp", "a.out", "math.hpp", "hpp.out"]
# Generate newfilenames as a list containing the new filenames
# using as many lines of code as your chosen method requires.
newfilenames = [x.replace("hpp","h") if x.endswith("hpp") else x for x in filenames]

print(newfilenames) 
```

```py
def highlight_word(sentence, word):
	return( " ".join([x.upper() if x == word else x for x in sentence.split()]))

print(highlight_word("Have a nice day", "nice"))
print(highlight_word("Shhh, don't be so loud!", "loud"))
print(highlight_word("Automating with Python is fun", "fun"))
```

