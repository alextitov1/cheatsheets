namespace recursion;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter a number ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 0) break;
            Console.WriteLine($"The Fibonacci(Recoursion) of {n} is {FibRecursion(n)}");
            Console.WriteLine($"The Fibonacci(Loop) of {n} is {FibLoop(n)}");
            Console.Read();
        }
    }


    public static int FibRecursion(int n)
    {
        if (n <= 2)
            return 1;
        return FibRecursion(n - 1) + FibRecursion(n - 2);
    }

    public static int FibLoop(int n)
    {
        int t1 = 0, t2 = 1, result = 0;
        if (n == 0) return 0; //It will return the first number of the series
        if (n == 1) return 1; // it will return  the second number of the series
        for (int i = 2; i <= n; i++)  // main processing starts from here
        {
            result = t1 + t2;
            t1 = t2;
            t2 = result;
        }
        return result;
    }

}