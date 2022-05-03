## Loops Cheat Sheet

### While Loops
A while loop executes the body of the loop while the condition remains True.

Syntax:
```python
while condition:
    body
```
Things to watch out for!

* Failure to initialize variables. Make sure all the variables used in the loop’s condition  are initialized before the loop.

* Unintended infinite loops. Make sure that the body of the loop modifies the variables used in the condition, so that the loop will eventually end for all possible values of the variables.

 Typical use:

While loops are mostly used when there’s an unknown number of operations to be performed, and a condition needs to be checked at each iteration.

### For Loops
A for loop iterates over a sequence of elements, executing the body of the loop for each element in the sequence.

Syntax:
```py
for variable in sequence:
    body
```
The range() function:

`range()` generates a sequence of integer numbers. It can take one, two, or three parameters:

* range(n): 0, 1, 2, ... n-1
* range(x,y): x, x+1, x+2, ... y-1
* range(p,q,r): p, p+r, p+2r, p+3r, ... q-1 (if it's a valid increment)

Typical use:

For loops are mostly used when there's a pre-defined sequence or range of numbers to iterate.

### Break & Continue
You can interrupt both while and for loops using the **break** keyword. We normally do this to interrupt a cycle due to a separate condition.

You can use the **continue** keyword to skip the current iteration and continue with the next one. This is typically used to jump ahead when some of the elements of the sequence aren’t relevant.

more about loops: 
* [for](https://wiki.python.org/moin/ForLoop)
* [while](https://wiki.python.org/moin/WhileLoop)


### A recursive function will usually have this structure:
```python
def recursive_function(parameters):
    if base_case_condition(parameters):
        return base_case_value
    recursive_function(modified_parameters)
```

>Fill in the blanks to make the is_power_of function return whether the number is a power of the given base. Note: base is assumed to be a positive number. Tip: for functions that return a boolean value, you can return the result of a comparison.

```py
def is_power_of(number, base):
  # Base case: when number is smaller than base.
  if number < base:
    # If number is equal to 1, it's a power (base**0).
    return number == 1

  # Recursive case: keep dividing number by base.
  return is_power_of(number / base, base)

print(is_power_of(8,2)) # Should be True
print(is_power_of(64,4)) # Should be True
print(is_power_of(70,10)) # Should be False
```