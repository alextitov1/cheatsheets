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
        //private List<string> _stack;
        private StackItem _stack;
        // contructs

        public Stack(params string[] args)
        {
            //    _stack = new List<string>();
            _stack = new StackItem();
            foreach (var item in args)
            {
                _stack.Add(item);
            }
        }
        //Properties
        public int Size => _stack.Count;

        public string Top
        {
            get
            {
                if (_stack.Count > 0)
                {
                    return _stack.Last();
                }
                return null;
            }
        }
        // Methods
        public string Pop()
        {
            var deleted = Top;

            if (Top == null)
            {
                throw new Exception("the stack is empty");
            }
            _stack.RemoveAt(_stack.Count - 1);
            return deleted;
        }

        public void Add(string element)
        {
            _stack.Add(element);
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
            private List<string> _stackitem;
            //constructors
            public StackItem()
            {
                _stackitem = new List<string>();
            }
            //Properties
            public int Count => _stackitem.Count;

            //Methods
            public string Last() => _stackitem.Last();
            public void Add(string item)
            {
                _stackitem.Add(item);
            }
            public void RemoveAt(int index)
            {
                _stackitem.RemoveAt(index);
            }
        }
}

    public static class StackExtensions
    {
        public static void Merge(this Stack stack, Stack newStack)
        { 
            for (var item = newStack.Size; item > 0; item--)
            {
            stack.Add(newStack.Pop());
            }
        }

    }

}
