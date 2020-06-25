using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Notebook
{
    class Program
    {
        public static Note[] NoteArray = new Note[100];
        public static int indexNote = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение Notebook");
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("\nМЕНЮ");
            Console.WriteLine("Если вы хотите добавить запись - введите 1");
            Console.WriteLine("Если вы хотите просмотреть все добавленные записи - введите 2");
            Console.WriteLine("Выход из программы - 0");
            Console.Write("--> ");
            string answer = Console.ReadLine();
            while (true)
            {
                if (answer == "1")
                {
                    NewNote();
                }
                else if (answer == "2")
                {
                    LookNotes();
                }
                else if (answer == "0")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Что-то пошло не так, попробуйте еще раз");
                    Console.Write("--> ");
                    answer = Console.ReadLine();
                }
            }
        }
        static void NewNote()
        {
            NoteArray[indexNote] = new Note();
            indexNote++;
            Console.WriteLine("Запись успешно добавлена, чтобы вернуться в меню, введите 0");
            Console.Write("--> ");
            string answer = Console.ReadLine();
            while (true)
            {
                if (answer == "0")
                {
                    Menu();
                }
                else
                {
                    Console.WriteLine("Что-то пошло не так, попробуйте еще раз");
                    Console.Write("--> ");
                    answer = Console.ReadLine();
                }
            }
        }
        static void LookNotes()
        {
            Console.WriteLine("\nВСЕ ЗАПИСИ: ");
            if (indexNote == 0)
            {
                Console.WriteLine("Записей нет");
            }
            else
            {
                for (int i = 0; i < indexNote; i++)
                {
                    Console.Write($"({i + 1}) ");
                    NoteArray[i].LookBasic();
                }
            }
            Console.WriteLine("\n(0) Вернуться в меню");
            if (indexNote == 1)
            {
                Console.WriteLine($"(1) Выбрать запись");
            }
            else if (indexNote > 1)
            {
                Console.WriteLine($"(1-{indexNote}) Выбрать запись");
            }
            Console.Write("--> ");
            string answer = Console.ReadLine();
            while (true)
            {
                if (answer == "0")
                {
                    Menu();
                }
                else
                {
                    try
                    {
                        int numberNote = Convert.ToInt32(answer);
                        if (numberNote <= indexNote && numberNote > 0)
                        {
                            MenuNote(numberNote);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Что-то пошло не так, попробуйте еще раз");
                            Console.Write("--> ");
                            answer = Console.ReadLine();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Что-то пошло не так, попробуйте еще раз");
                        Console.Write("--> ");
                        answer = Console.ReadLine();
                    }
                }      
            }
        }

        public static void MenuNote(int index)
        {
            Console.WriteLine($"ЗАПИСЬ {index}");
            Console.WriteLine("\n(0) Вернуться в меню");
            Console.WriteLine("(1) Назад");
            Console.WriteLine("(2) Просмотреть запись");
            Console.WriteLine("(3) Редактировать запись");
            Console.WriteLine("(4) Удалить запись");

            Console.Write("--> ");
            string answer = Console.ReadLine();
            bool answ = true;
            while (answ)
            {
                switch (answer)
                {
                    case "0":
                        answ = false;
                        Menu();
                        break;
                    case "1":
                        answ = false;
                        LookNotes();
                        break;
                    case "2":
                        answ = false;
                        NoteArray[index - 1].LookAll();
                        Console.WriteLine("\n");
                        MenuNote(index);
                        break;
                    case "3":
                        answ = false;
                        NoteArray[index - 1].Edit(index);
                        break;
                    case "4":
                        answ = false;
                        Delete(index - 1);
                        LookNotes();
                        break;
                    default:
                        Console.WriteLine("Что-то пошло не так, попробуйте еще раз");
                        Console.Write("--> ");
                        answer = Console.ReadLine();
                        break;
                }
            }
        }
        static void Delete(int index)
        {
            NoteArray = NoteArray.Take(index).Concat(NoteArray.Skip(index + 1)).ToArray();
            indexNote--;
        }
    }
    class Note
    {
        public string name;
        public string firstName;
        public string lastName; //
        public string numberPhone;
        public string country;
        public string dateOfBirth; //
        public string organization; //
        public string position; //
        public string otherNotes; //
        
        public Note()
        {
            Console.WriteLine("\nДОБАВЛЕНИЕ ЗАПИСИ");

            Console.Write("Имя: ");
            name = Console.ReadLine();
            bool uncorrectEnter = true;

            while (uncorrectEnter)
            {
                if (name == "")
                {
                    Console.WriteLine("Это поле должно быть заполненным.");
                    Console.Write("Имя: ");
                    name = Console.ReadLine();
                }
                else
                {
                    uncorrectEnter = false;
                }
            }

            Console.Write("Фамилия: ");
            firstName = Console.ReadLine();
            uncorrectEnter = true;

            while (uncorrectEnter)
            {
                if (firstName == "")
                {
                    Console.WriteLine("Это поле должно быть заполненным.");
                    Console.Write("Фамилия: ");
                    firstName = Console.ReadLine();
                }
                else
                {
                    uncorrectEnter = false;
                }
            }

            Console.Write("Отчество: ");
            lastName = Console.ReadLine();

            Console.Write("Номер телефона: ");
            numberPhone = Console.ReadLine();
            uncorrectEnter = true;

            while (uncorrectEnter)
            {
                if (numberPhone == "")
                {
                    Console.WriteLine("Это поле должно быть заполненным.");
                    Console.Write("Номер телефона: ");
                    numberPhone = Console.ReadLine();
                }               
                else
                {
                    for (int i = 0; i < numberPhone.Length; i++)
                    {
                        if (numberPhone[i] < 48 || numberPhone[i] > 57)
                        {
                            uncorrectEnter = false;
                        }
                    }
                    if (!uncorrectEnter)
                    {
                        Console.WriteLine("Это поле должно содержать только цифры.");
                        Console.Write("Номер телефона: ");
                        numberPhone = Console.ReadLine();
                        uncorrectEnter = true;
                    }
                    else
                    {
                        uncorrectEnter = false;
                    }
                }
            }

            Console.Write("Cтрана проживания: ");
            country = Console.ReadLine();
            uncorrectEnter = true;

            while (uncorrectEnter)
            {
                if (country == "")
                {
                    Console.WriteLine("Это поле должно быть заполненным.");
                    Console.Write("Cтрана проживания: ");
                    country = Console.ReadLine();
                }
                else
                {
                    uncorrectEnter = false;
                }
            }

            Console.Write("Дата рождения: ");
            dateOfBirth = Console.ReadLine();

            Console.Write("Организация: ");
            organization = Console.ReadLine();

            Console.Write("Должность: ");
            position = Console.ReadLine();

            Console.Write("Заметки: ");
            otherNotes = Console.ReadLine();
        }

        public void LookAll()
        {
            Console.WriteLine($"Имя: {this.name}");
            Console.WriteLine($"Фамилия: {this.firstName}");
            Console.WriteLine($"Отчество: {this.lastName}");
            Console.WriteLine($"Номер телефона: {this.numberPhone}");
            Console.WriteLine($"Cтрана проживания: {this.country}");
            Console.WriteLine($"Дата рождения: {this.dateOfBirth}");
            Console.WriteLine($"Организация: {this.organization}");
            Console.WriteLine($"Должность: {this.position}");
            Console.WriteLine($"Заметки: {this.otherNotes}");
        }
        public void LookBasic()
        {
            Console.WriteLine($"Имя: {this.name}");
            Console.WriteLine($"Фамилия: {this.firstName}");
            Console.WriteLine($"Номер телефона: {this.numberPhone}");
        }
        public void Edit(int index)
        {
            Console.WriteLine("\nРЕДАКТИРОВАНИЕ ЗАПИСИ");
            Console.WriteLine($"{1} Имя: {this.name}");
            Console.WriteLine($"{2} Фамилия: {this.firstName}");
            Console.WriteLine($"{3} Отчество: {this.lastName}");
            Console.WriteLine($"{4} Номер телефона: {this.numberPhone}");
            Console.WriteLine($"{5} Cтрана проживания: {this.country}");
            Console.WriteLine($"{6} Дата рождения: {this.dateOfBirth}");
            Console.WriteLine($"{7} Организация: {this.organization}");
            Console.WriteLine($"{8} Должность: {this.position}");
            Console.WriteLine($"{9} Заметки: {this.otherNotes}");
            Console.WriteLine("\n(0) Назад");
            Console.WriteLine("(1-9) Выбрать параметр для редактирования");
            Console.Write("--> ");
            string answer = Console.ReadLine();
            bool answ = true;
            while (answ)
            {
                switch (answer)
                {
                    case "0":
                        answ = false;
                        Program.MenuNote(index);
                        break;
                    case "1":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Имя --> ");
                        name = Console.ReadLine();
                        bool uncorrectEnter = true;

                        while (uncorrectEnter)
                        {
                            if (name == "")
                            {
                                Console.WriteLine("Это поле должно быть заполненным.");
                                Console.Write("Имя: ");
                                name = Console.ReadLine();
                            }
                            else
                            {
                                uncorrectEnter = false;
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Фамилия --> ");
                        firstName = Console.ReadLine();
                        uncorrectEnter = true;

                        while (uncorrectEnter)
                        {
                            if (firstName == "")
                            {
                                Console.WriteLine("Это поле должно быть заполненным.");
                                Console.Write("Фамилия: ");
                                firstName = Console.ReadLine();
                            }
                            else
                            {
                                uncorrectEnter = false;
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Отчество --> ");
                        lastName = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Номер телефона --> ");
                        numberPhone = Console.ReadLine();
                        uncorrectEnter = true;

                        while (uncorrectEnter)
                        {
                            if (numberPhone == "")
                            {
                                Console.WriteLine("Это поле должно быть заполненным.");
                                Console.Write("Номер телефона: ");
                                numberPhone = Console.ReadLine();
                            }
                            else
                            {
                                for (int i = 0; i < numberPhone.Length; i++)
                                {
                                    if (numberPhone[i] < 48 || numberPhone[i] > 57)
                                    {
                                        uncorrectEnter = false;
                                    }
                                }
                                if (!uncorrectEnter)
                                {
                                    Console.WriteLine("Это поле должно содержать только цифры.");
                                    Console.Write("Номер телефона: ");
                                    numberPhone = Console.ReadLine();
                                    uncorrectEnter = true;
                                }
                                else
                                {
                                    uncorrectEnter = false;
                                }
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Страна проживания --> ");
                        name = Console.ReadLine();
                        uncorrectEnter = true;

                        while (uncorrectEnter)
                        {
                            if (country == "")
                            {
                                Console.WriteLine("Это поле должно быть заполненным.");
                                Console.Write("Cтрана проживания: ");
                                country = Console.ReadLine();
                            }
                            else
                            {
                                uncorrectEnter = false;
                            }
                        }
                        break;
                    case "6":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Дата рождения --> ");
                        dateOfBirth = Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Организация --> ");
                        organization = Console.ReadLine();
                        break;
                    case "8":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Должность --> ");
                        position = Console.ReadLine();
                        break;
                    case "9":
                        Console.WriteLine("Введите новое значение поля: ");
                        Console.Write("Заметки --> ");
                        otherNotes = Console.ReadLine();
                        break;                    
                    default:
                        Console.WriteLine("Что-то пошло не так, попробуйте еще раз");
                        Console.Write("--> ");
                        answer = Console.ReadLine();
                        answ = false;
                        break;
                }
                if (answ == false)
                {
                    answ = true;
                }
                else
                {
                    Console.WriteLine("\n(0) Прекратить редактирование");
                    Console.WriteLine("(1-9) Выбрать параметр для редактирования");
                    Console.Write("--> ");
                    answer = Console.ReadLine();
                }
            }

        }

    }
}
