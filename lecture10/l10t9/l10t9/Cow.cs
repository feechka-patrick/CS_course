using System;
using System.Collections.Generic;
using System.Text;

namespace l10t9
{
    class Cow
    {
        public static void Main(string[] args)
        {
            Pet pet1 = new Cat();
            Pet cat = pet1.GetChild();

            Pet pet2 = new Dog();
            Pet dog = pet2.GetChild();
        }
    }
}
