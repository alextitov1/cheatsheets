### Indexing
```
index [-1] would access the last character 
```
```
>>> fruit = "Mangosteen"
>>> fruit[1:4]
'ang'
>>> fruit[:5]
'Mango'
>>> fruit[5:]
'steen'
>>> fruit[:5] + fruit[5:]
'Mangosteen'
```

### Sting Methods
### index()
```
>>> animals = "lions tigers and bears"
>>> animals.index("g")
8
>>> animals.index("bears")
17
```
if we try to locate a substring that doesn't exist in the string - **ValueError**

### In
This can be done using the **in** keyword.
```
>>>animals = "lions tegers and bears"
>>>horses in animals
False
```
### lower()
### upper()
### strip(), lstrip(), rstrip()
### count() - retrun the number of times a substring appers in the string
### endswith()
### isnumeric()
### isalpha()
### int()
### join()
### split()
### replace(old, new)
[more string methods](https://docs.python.org/3/library/stdtypes.html#string-methods)

## String Fromatting
```py
def student_grade(name, grade):
	return "{} received {}% on the exam".format(name, grade)
    ##return "{name} received {grade}% on the exam".format(name=name, grade=grade)

print(student_grade("Reed", 80))
>>Reed received 80% on the exam"
```


| Expr   | Meaning                                      | Example                          |
|--------|----------------------------------------------|----------------------------------|
| {:d}   | integer value                                | '{:d}'.format(10.5) → '10'       |
| {:.2f} | floating point with that many decimals       | '{:.2f}'.format(0.5) → '0.50'    |
| {:.2s} | string with that many characters             | '{:.2s}'.format('Python') → 'Py' |
| {:<6s} | string aligned to the left that many spaces  | '{:<6s}'.format('Py') → 'Py    ' |
| {:>6s} | string aligned to the right that many spaces | '{:>6s}'.format('Py') → '    Py' |
| {:^6s} | string centered in that many spaces          | '{:^6s}'.format('Py') → '  Py  ' |


## [Formatted string literals](Opthttps://docs.python.org/3/reference/lexical_analysis.html#f-stringsional)
This feature was added in Python 3.6 and isn’t used a lot yet. Again, it's included here in case you run into it in the future, but it's not needed for this or any upcoming courses.

A formatted string literal or f-string is a string that starts with 'f' or 'F' before the quotes. These strings might contain {} placeholders using expressions like the ones used for format method strings.

The important difference with the format method is that it takes the value of the variables from the current context, instead of taking the values from parameters.

 Examples:
```
>>> name = "Micah"

>>> print(f'Hello {name}')

Hello Micah
```
 
```
>>> item = "Purple Cup"

>>> amount = 5

>>> price = amount * 3.25

>>> print(f'Item: {item} - Amount: {amount} - Price: {price:.2f}')
```

Item: Purple Cup - Amount: 5 - Price: 16.25

