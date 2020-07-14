using System;

namespace l10t10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int min(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else return b;
        }
        public static long min(long a, long b)
        {
            if (a < b)
            {
                return a;
            }
            else return b;
        }
        public static double min(double a, double b)
        {
            if (a < b)
            {
                return a;
            }
            else return b;
        }
    }
}
