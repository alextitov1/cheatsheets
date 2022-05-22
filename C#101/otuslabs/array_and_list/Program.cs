using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace array_and_list
{
    class Program
    {
        static void PrintResults(List<int> PList, string CollType, long IniTtime, long SearchNTime, long SearchMult, int n = 10)
        {
            Console.WriteLine($"Resulet for {CollType}");
            Console.WriteLine($"Init time = {IniTtime} ms, Search of n element time = {SearchNTime} ms, Search for multipliers of 777 = {SearchMult} ms");
            Console.WriteLine($"Fist {n} multipliers of 777");
            int counter = 0;
            while ((PList.Count >= counter) && (n >= counter))
                {
                Console.Write(PList[counter] + " ");
                counter++;
                }
            Console.WriteLine("...\n");

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // declare variables
            var MyList = new List<int>();
            var MyArrayList = new ArrayList();
            var MyLinkedList = new LinkedList<int>();
            var elements = 1000000;
            var n = 496753;


////////////List////////////////////////////////////////////////////////////////////////////////
            // fill the list
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < elements; i++)
            {
                MyList.Add(i);
            }
            stopWatch.Stop();
            var InitTime = stopWatch.ElapsedMilliseconds;
            
            // search for n element
            stopWatch.Restart();
            var temp = MyList.ElementAt(n);
            stopWatch.Stop();
            var SearchNTime = stopWatch.ElapsedMilliseconds;
            
            //search for all multiples of 777
            stopWatch.Restart();
            var MyList777 = MyList.FindAll(x => x % 777 == 0);
            stopWatch.Stop();
            var MultTime = stopWatch.ElapsedMilliseconds;

            PrintResults(MyList777,"List", InitTime, SearchNTime, MultTime);

////////////ArrayList////////////////////////////////////////////////////////////////////////////////
            // fill the ArrayList
            Console.WriteLine("ArrayList:");
            stopWatch.Restart();
            for (int i = 0; i < elements; i++)
            {
                MyArrayList.Add(i);
            }
            stopWatch.Stop();
            InitTime = stopWatch.ElapsedMilliseconds;

            // search for n element
            stopWatch.Restart();
            temp = (int)MyArrayList[n];
            stopWatch.Stop();
            SearchNTime = stopWatch.ElapsedMilliseconds;

            //search for all multiples of 777
            stopWatch.Restart();
            var MyArrayList777 = new List<int>();
            foreach(int element in MyArrayList)
                {
                if (element % 777 == 0)
                    MyArrayList777.Add(element);
                }
            stopWatch.Stop();
            MultTime = stopWatch.ElapsedMilliseconds;

            PrintResults(MyList777, "ArrayList", InitTime, SearchNTime, MultTime);

            ////////////LinkedList///////////////////////////////////////////////////
            // fill the LinkedList
            stopWatch.Restart();
            for (int i = 0; i < elements; i++)
            {
                MyLinkedList.AddLast(i);
            }
            stopWatch.Stop();
            InitTime = stopWatch.ElapsedMilliseconds;

            // search for n element
            stopWatch.Restart();
            temp = (int)MyLinkedList.ElementAt(n);
            stopWatch.Stop();
            SearchNTime = stopWatch.ElapsedMilliseconds;

            //search for all multiples of 777
            stopWatch.Restart();
            var MyLinkedList777 = new List<int>();
            foreach (int element in MyLinkedList)
            {
                if (element % 777 == 0)
                    MyLinkedList777.Add(element);
            }
            stopWatch.Stop();
            MultTime = stopWatch.ElapsedMilliseconds;

            PrintResults(MyList777, "LinkedList", InitTime, SearchNTime, MultTime);


            Console.WriteLine("\n Press any key to exit");
            Console.ReadKey();
        }
    }
}
