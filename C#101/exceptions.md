```C#
try {
// statements causing exception
} catch( ExceptionName e1 ) {
// error handling code
} catch( ExceptionName e2 ) {
// error handling code
} catch( ExceptionName eN ) {
// error handling code
} finally {
// statements to be executed
}
```


```C#
class GreenException : Exception
{
    public GreenException(string message) : base(message) { }
}
```
