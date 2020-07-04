using System;
using System.Collections.Generic;
using System.Text;

namespace l10t7
{
    class Chess
    {
        public Position position;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public virtual void Motion(int a, char b)
        {
            Console.WriteLine("Выберите фигуру и сделайте ход!");
        }
    }

    struct Position
    {
        public int position_number;
        public char position_symbol;
    }
}
