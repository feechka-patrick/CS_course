using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l4t38
{
    /*
     * В классе Program создайте публичный статический метод GetIntAsString(), который принимает 1 целое число и возвращает строку:
     * 1) Если число от 1 до 9999 включительно – словесную форму полученного числа (Например: один (1), пятнадцать(15), одна тысяча девятьсот девяносто девять (1999))
     * 2) Если меньше 1 - "Слишком маленькое число".
     * 3) Если больше 9999 - "Слишком большое число".
     */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(GetIntAsString(Convert.ToInt32(Console.ReadLine())));
        }
        /* Добавьте свой код ниже */
        public static string GetIntAsString(int n)
        {
            //9876 / 1000 = 9
            //9876 / 100 % 10 = 8
            //9876 / 10 % 10 = 7
            //9876 % 10 = 6
            string s = "";
            int l = s.Length - 1;
            if (n < 1)
                s = "Слишком маленькое число";
            else if (n > 9999)
                s = "Слишком большое число";
            else
            {
                if (n / 1000 > 0)
                {
                    switch (n / 1000)
                    {
                        case 1:
                            s += "одна тысяча ";
                            break;
                        case 2:
                            s += "две тысячи ";
                            break;
                        case 3:
                            s += "три тысячи тысяча ";
                            break;
                        case 4:
                            s += "четыре тысячи тысяча ";
                            break;
                        case 5:
                            s += "пять тысяч ";
                            break;
                        case 6:
                            s += "шесть тысяч ";
                            break;
                        case 7:
                            s += "семь тысяч ";
                            break;
                        case 8:
                            s += "восемь тысяч ";
                            break;
                        case 9:
                            s += "девять тысяч ";
                            break;
                        default:
                            s += "";
                            break;
                            s.Remove(l);

                    }
                }

                if (n / 100 % 10 > 0)
                {
                    switch (n / 100 % 10)
                    {
                        case 1:
                            s += "сто ";
                            break;
                        case 2:
                            s += "двести ";
                            break;
                        case 3:
                            s += "триста ";
                            break;
                        case 4:
                            s += "четыреста ";
                            break;
                        case 5:
                            s += "пятьсот ";
                            break;
                        case 6:
                            s += "шестьсот ";
                            break;
                        case 7:
                            s += "семьсот ";
                            break;
                        case 8:
                            s += "восемьсот ";
                            break;
                        case 9:
                            s += "девятьсот ";
                            break;
                        default:
                            s += "";
                            break;
                            s.Remove(l);

                    }
                }

                if (n / 10 % 10 > 0)
                {
                    switch (n / 10 % 10)
                    {
                        case 1:
                            {
                                if (n % 10 == 0)
                                    s += "десять";
                                if (n % 10 == 1)
                                    s += "одиннадцать";
                                if (n % 10 == 2)
                                    s += "двеннадцать";
                                if (n % 10 == 3)
                                    s += "тринадцать";
                                if (n % 10 == 4)
                                    s += "четырнадцать";
                                if (n % 10 == 5)
                                    s += "пятнадцать";
                                if (n % 10 == 6)
                                    s += "шестнадцать";
                                if (n % 10 == 7)
                                    s += "семнадцать";
                                if (n % 10 == 8)
                                    s += "восемнадцать";
                                if (n % 10 == 9)
                                    s += "девятнадцать";
                            }

                            break;

                        case 2:
                            s += "двадцать ";
                            break;
                        case 3:
                            s += "тридцать ";
                            break;
                        case 4:
                            s += "сорок ";
                            break;
                        case 5:
                            s += "пятьдесят ";
                            break;
                        case 6:
                            s += "шестьдесят ";
                            break;
                        case 7:
                            s += "семьдесят ";
                            break;
                        case 8:
                            s += "восемьдесят ";
                            break;
                        case 9:
                            s += "девяносто ";
                            break;
                        default:
                            s += "";
                            break;
                            s.Remove(l);
                    }
                }
                if (n / 10 % 10 != 1)
                {
                    switch (n % 10)
                    {
                        case 1:
                            s += "один";
                            break;

                        case 2:
                            s += "два";
                            break;

                        case 3:
                            s += "три";
                            break;

                        case 4:
                            s += "четыре";
                            break;

                        case 5:
                            s += "пять";
                            break;

                        case 6:
                            s += "шесть";
                            break;

                        case 7:
                            s += "семь";
                            break;

                        case 8:
                            s += "восемь";
                            break;

                        case 9:
                            s += "девять";
                            break;

                        default:
                            s += "";
                            break;
                    }
                }
            }

            return s;
        }
    }
}