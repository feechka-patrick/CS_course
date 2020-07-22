using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace test
{

    class Kitchen
    {
        public delegate string[] ExampleMethod(string[] arr, bool b);

        static void Main(string[] args)
        {
            ExampleMethod em = (string[] arr, bool b) =>
            {
                if (b)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i].ToUpper();
                    }
                }
                else
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i].ToLower();
                    }
                }

                return arr;
            };
        }
    }


}
