using System;
using System.Linq;
using System.Collections.Generic;

namespace stack
{
    class Program
    {
        static void Main(string[] args)
        {

            // var s = new Stack(new List<string> { "a", "b", "c" });
            var s = new Stack("a", "b", "c");
            // size = 3, Top = 'c'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            var deleted = s.Pop();
            // Извлек верхний элемент 'c' Size = 2
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
            s.Add("d");
            // size = 3, Top = 'd'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            s.Pop();
            s.Pop();
            // size = 0, Top = null
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            //           s.Pop();

            //Optional task 1
            var s1 = new Stack("a", "b", "c");
            s1.Merge(new Stack("1", "2", "3"));

            Console.WriteLine($"size = {s1.Size}, Top = '{s1.Top}'");

            //Optional task 2
            var s2 = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            Console.WriteLine($"size = {s2.Size}, Top = '{s2.Top}'");
        }
    }

    public class Stack
    {
        // fields
        //private List<StackItem> _items;
        //private StackItem _stack;
        // contructs

        public Stack(params string[] args)
        {
            Size = 0;
            foreach (var value in args)
            {
                Add(value);
            }
        }

        private StackItem _top;

        //Properties
        public int Size { get; private set; }

        public string Top
        {
            get
            {
                if (_top != null)
                {
                    return _top.Value;
                }
                return null;
            }
        }

        // Methods
        public string Pop()
        {
            if (Top == null)
            {
                throw new Exception("the stack is empty");
            }

            var deletedValue = _top.Value;

            _top = _top.Previous;
            Size--;

            return deletedValue;
        }

        public void Add(string element)
        {
            StackItem last = _top;
            var newItem = new StackItem(last, element);
            _top = newItem;
            Size++;
        }

        public static Stack Concat(params Stack[] args)
        {
            var cat = new Stack();
            foreach (var arg in args)
            {
                cat.Merge(arg);
            }
            return cat;
        }

        private class StackItem
        {
            public string Value { get; private set; }

            public StackItem Previous { get; private set; }

            public StackItem(StackItem previous, string value)
            {
                Previous = previous;
                Value = value;
            }
        }
    }

    public static class StackExtensions
    {
        public static void Merge(this Stack stack, Stack newStack)
        {
            var num = newStack.Size;
            for (var item = num; item > 0; item--)
            {
                stack.Add(newStack.Pop());
            }
        }

    }

}
