using System;
using System.Collections.Generic;
using System.Text;

namespace l10t9
{
    public class Dog : Pet
    {
        public override Pet GetChild()
        {
            return new Dog();
        }
    }
}
