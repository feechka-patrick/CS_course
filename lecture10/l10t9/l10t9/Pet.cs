using System;
using System.Collections.Generic;
using System.Text;

namespace l10t9
{
    public class Pet
    {
        public virtual Pet GetChild()
        {
            return new Pet();
        }
    }
}
