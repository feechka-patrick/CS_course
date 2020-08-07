using System;

namespace TheVigenereAlgorithm
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
            string decrypt = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!";
            string encrypt = "аааааааа";


            Console.WriteLine(Encrypt(encrypt, key));
            Console.WriteLine(Decrypt(decrypt, key));

        }
        public static string Encrypt(string message, string key) //зашифровать
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string encrypt = "";

            for (int i = 0; i < message.Length; i++)
            {
                int index = i % key.Length;
                encrypt += alphabet[(alphabet.IndexOf(message[i]) + alphabet.IndexOf(key[index])) % 33];
            }
            return encrypt;
        }
        public static string Decrypt(string message, string key) //расшифровать
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string decrypt = "";

            int count = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (alphabet.IndexOf(message[i]) > -1)
                {
                    int index = count % key.Length;
                    if (alphabet.IndexOf(message[i]) - alphabet.IndexOf(key[index]) < 0)
                    {
                        decrypt += alphabet[33 + alphabet.IndexOf(message[i]) - alphabet.IndexOf(key[index])];
                    }
                    else
                    {
                        decrypt += alphabet[alphabet.IndexOf(message[i]) - alphabet.IndexOf(key[index])];
                    }
                    count++;
                }
                else
                {
                    decrypt += message[i];
                }
            }
            return decrypt;
        }
    }
}
