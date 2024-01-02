```C#
namespace Acme.Collections;

public class Stack<T>
{
    Entry _top;

    public void Push(T data)
    {
        _top = new Entry(_top, data);
    }

    public T Pop()
    {
        if (_top == null)
        {
            throw new InvalidOperationException();
        }
        T result = _top.Data;
        _top = _top.Next;

        return result;
    }

    class Entry
    {
        public Entry Next { get; set; }
        public T Data { get; set; }

        public Entry(Entry next, T data)
        {
            Next = next;
            Data = data;
        }
    }
}
```
```C#
public class Stack: BaseStack
{
    // fields
    private int _value;
    private string _message;
    private List<string> _stack;

    //constructs

    private Stack(int value)
    {
        _value = value;
    }

    public Stack(string[] values)
    {
        _stack = new List<string>();
        foreach (value in values)
            {
                
            }
        _value = values[1];
    }

    public Stack(string inputString, int value1) : this(value1)
    {

    }

    public Stack(decimal decInput): base()
    {

    }


    //Properties - wrapped methods
    public int GetValue
    {
        get
        {
            var temp = _value;
            return temp;
        }
        
    }

    public int SetValue
    {
        set { _value = value; }

    }

    public string Message1
    {
        get
        {
            return _message;
        }
        set
        {
            _message = value;
        }
    }

    public string Value { get; set; }

    //Methods
    public string Message()
    {
        return _value.ToString();
    }
}
```