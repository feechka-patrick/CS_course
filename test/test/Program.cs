using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\Dekstop\\Anna";
            int index = path.LastIndexOf('\\');
            path = path.Remove(index);
            Console.WriteLine(path);
        }
    }
}
