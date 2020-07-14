using System;
using System.Collections.Generic;
using System.Text;

namespace l10t9
{
    public class Cat : Pet
    {
        public override Pet GetChild()
        {
            return new Cat();
        }
    }
}
