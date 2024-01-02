# Object-Oriented Programming Defined
In object-oriented programming, concepts are modeled as **classes** and **objects**. An idea is defined using a class, and an instance of this class is called an object. Almost everything in Python is an object, including strings, lists, dictionaries, and numbers. When we create a list in Python, we’re creating an object which is an instance of the list class, which represents the concept of a list. Classes also have attributes and methods associated with them. Attributes are the characteristics of the class, while methods are functions that are part of the class.

## Classes and Instances
* Classes define the behavior of all instances of a specific class.
* Each variable of a specific class is an instance or object.
* Objects can have attributes, which store information about the object.
* You can make objects do work by calling their methods.
* The first parameter of the methods (self) represents the current instance.
* Methods are just like functions, but they can only be used through a class.

### Special methods
* Special methods start and end with __.
* Special methods have specific names, like __init__ for the constructor or __str__ for the conversion to string.

## Dot natation
Lets you access any of the abilities the object might have (callled methods) of information it might store (called attrebutes)

type(0) - check the class

dir("") - print methods and attributes

help("") - shows doco for the corresponding

## Defining Classes
```py
class Apple:
    """This is a docstring"""
    color = ""
    flavor = ""
    pass
```
```
>>> jonagold = Apple()
>>> jonagold.color = "red"
>>> jonagold.flavor = "sweet"
```
> Calling methods on objects executes functions that operate on attributes of a specific instance of the class. 

### contractor method (__init__)

```py
class Apple:
    def __init__(self, color, flavor):
    self.color = color
    self.flavor = flavor

jonagold = Apple("red", "sweet")
print(jonagold.color)
```

### __str__ special method
> ow an instance of an object will be printed when it’s passed to the print() function

```py
class Apple:
    def __init__(self, color, flavor):
        self.color = color
        self.flavor = flavor
    def __str__(self):
        return "This apple is {} and its flavor is {}".format(self.color, self.flavor)

jonagold = Apple("red", "sweet")
print(jonagold)
```

### Object inheritance
```
>>> class Animal:
...     sound = ""
...     def __init__(self, name):
...         self.name = name
...     def speak(self):
...         print("{sound} I'm {name}! {sound}".format(
...             name=self.name, sound=self.sound))
... 
>>> class Piglet(Animal):
...     sound = "Oink!"
... 
>>> class Cow(Animal):
...     sound = "Moooo"
```



```py
class Clothing:
  stock={ 'name': [],'material' :[], 'amount':[]}
  def __init__(self,name):
    material = ""
    self.name = name
  def add_item(self, name, material, amount):
    Clothing.stock['name'].append(self.name)
    Clothing.stock['material'].append(self.material)
    Clothing.stock['amount'].append(amount)
  def Stock_by_Material(self, material):
    count=0
    n=0
    for item in Clothing.stock['material']:
      if item == material:
        count += Clothing.stock['amount'][n]
        n+=1
    return count

class shirt(Clothing):
  material="Cotton"
class pants(Clothing):
  material="Cotton"
  
polo = shirt("Polo")
sweatpants = pants("Sweatpants")
polo.add_item(polo.name, polo.material, 4)
sweatpants.add_item(sweatpants.name, sweatpants.material, 6)
current_stock = polo.Stock_by_Material("Cotton")
print(current_stock)
```