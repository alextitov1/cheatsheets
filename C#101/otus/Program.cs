using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace COLLECTIONS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            // declare variables
            List<int> MyList = new();
            ArrayList MyArrayList = new();
            var MyLinkedList = new LinkedList<int>();
            var elements = 1000000;
            var n = 496753;


            //List////////////////////////////////////////////////////////////////////////////////
            // fill the list
            Stopwatch stopWatch = new();
            stopWatch.Start();
            for (int i = 0; i < elements; i++)
            {
                MyList.Add(i);        
            }
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            Console.WriteLine(String.Format("Init of List with {0} elements has taken {1} ms", elements, ts.Milliseconds));
            // search for n element
            stopWatch.Reset();
            stopWatch.Start();
            //var temp = MyList[n];
            MyList.Find(x => x == n); //what happens here?
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(String.Format("Search of {1} element in the List has taken {0} ms", ts.Milliseconds, n));

            stopWatch.Reset();
            stopWatch.Start();
            var MyList777 = MyList.FindAll(x => x % 777 == 0);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(String.Format("Search for multiples of 777 has taken {0} ms", ts.Milliseconds));

            foreach (var item in MyList777)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("");

            //ArrayList////////////////////////////////////////////////////////////////////////////////
            // fill the ArrayList
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < elements; i++)
            {
                MyArrayList.Add(i);
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(String.Format("Init of ArrayList with {0} elements has taken {1} ms", elements, ts.Milliseconds));
            // search for n element
            stopWatch.Reset();
            stopWatch.Start();
            var temp = (int)MyArrayList[n]; // does it count?
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(String.Format("Search of {1} element in the ArrayList has taken {0} ms", ts.Milliseconds, n));

            //LinkedList//
            // fill the LinkedList
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < elements; i++)
            {
                MyLinkedList.AddLast(i);
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(String.Format("Init of LinkedList with {0} elements has taken {1} ms", elements, ts.Milliseconds));
            // search for n element
            stopWatch.Reset();
            stopWatch.Start();
            MyLinkedList.Find(n); //why it's different for List ?
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(String.Format("Search of {1} element in the ArrayList has taken {0} ms", ts.Milliseconds, n));

        }
    }
}
