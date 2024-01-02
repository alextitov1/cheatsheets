## Branching blocks
```python
if condition1:
	if-block
elif condition2:
	elif-block
else:
	else-block
```
Remember: The if-block will be executed if condition1 is True. The elif-block will be executed if condition1 is False and condition2 is True. The else block will be executed when all the specified conditions are false.

## Comparison operators
* a == b: a is equal to b
* a != b: a is different than b
* a < b: a is smaller than b
* a <= b: a is smaller or equal to b
* a > b: a is bigger than b
* a >= b: a is bigger or equal to b

## Logical operators
* a and b: True if both a and b are True. False otherwise.
* a or b: True if either a or b or both are True. False if both are False.
* not a: True if a is False, False if a is True.

## Comparison Operators
In Python, we can use comparison operators to compare values. When a comparison is made, Python returns a boolean result, or simply a True or False. 

* To check if two values are the same, we can use the equality operator: == 

* To check if two values are not the same, we can use the not equals operator: != 

We can also check if values are greater than or lesser than each other using `>` and `<`. If you try to compare data types that aren’t compatible, like checking if a string is greater than an integer, Python will throw a `TypeError`. 

We can make very complex comparisons by joining statements together using logical operators with our comparison operators. These logical operators are `and`, `or`, and `not`. When using the `and` operator, both sides of the statement being evaluated must be true for the whole statement to be true. When using the `or` operator, if either side of the comparison is true, then the whole statement is true. Lastly, the `not` operator simply inverts the value of the statement immediately following it. So if a statement evaluates to True, and we put the `not` operator in front of it, it would become False.


## if Statements Recap
We can use the concept of `branching` to have our code alter its execution sequence depending on the values of variables. We can use an _if_ statement to evaluate a comparison. We start with the _if_ keyword, followed by our comparison. We end the line with a colon. The body of the if statement is then indented to the right. If the comparison is `True`, the code inside the if body is executed. If the comparison evaluates to `False`, then the code block is skipped and will not be run.


## else Statements and the Modulo Operator
We just covered the _if_ statement, which executes code if an evaluation is true and skips the code if it’s false. But what if we wanted the code to do something different if the evaluation is false? We can do this using the _else_ statement. The _else_ statement follows an _if_ block, and is composed of the keyword else followed by a colon. The body of the else statement is indented to the right, and will be executed if the above if statement doesn’t execute.


## More Complex Branching with elif Statements
Building off of the _if_ and _else_ blocks, which allow us to branch our code depending on the evaluation of one statement, the _elif_ statement allows us even more comparisons to perform more complex branching. Very similar to the _if_ statements, an _elif_ statement starts with the _elif_ keyword, followed by a comparison to be evaluated. This is followed by a colon, and then the code block on the next line, indented to the right. An _elif_ statement must follow an if statement, and will only be evaluated if the if statement was evaluated as false. You can include multiple elif statements to build complex branching in your code to do all kinds of powerful things!