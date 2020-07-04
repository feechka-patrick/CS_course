using System;
using System.Collections.Generic;
using System.Text;

namespace l10t7
{
    class Queen:Chess
    {
        public override void Motion(int a, char b)
        {
            this.position.position_number = a;
            this.position.position_symbol = b;
        }
    }
}
