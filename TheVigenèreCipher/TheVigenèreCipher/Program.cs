using System;
using System.Xml;

namespace TheVigenèreCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Ключ: ");
            //string key = Console.ReadLine();
            //Console.Write("Текст: ");
            //string text = Console.ReadLine();

            string key = "скорпион";
            string text = "поздравляю";
            string decodeText = "";

            string[] alphabet = new string[33];

            int bykva = 'а';
            for (int i = 0; i < 6; i++)
            {
                alphabet[i] = ((char)(bykva + i)).ToString();
            }

            alphabet[6] = "ё";

            for (int i = 7; i < 33; i++)
            {
                alphabet[i] = ((char)(bykva + i - 1)).ToString();
            }
            string[,] quarte = new string[33, 33];

            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if ((i + j) >= 33)
                    {
                        quarte[i, j] = alphabet[(i + j) % 33];
                    }
                    else
                    {
                        quarte[i, j] = alphabet[i + j];
                    }
                    
                }
            }

            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    Console.Write(quarte[i, j] + " ");
                }
                Console.WriteLine("");
            }

            

            for (int i = 0; i < text.Length; i++)
            {
                int index = i % key.Length;
                Console.WriteLine(key[index]);
                decodeText += quarte[(int)key[index] - bykva, (int)text[i] - bykva];
            }

            Console.WriteLine(decodeText);
        }
    }
}
