using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voda
{
    internal class Admin
    {
        features features = new features();


        public void start_info(ref string active, ref string act)
        {
            int move = 0;
            act = "0";

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();
                
                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 4) { move = 0; }
                else if (move < 0) { move = 4; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Просмотреть журналы   Изменить данные   Удалить данные   Добавить данные   Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "viev"; }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Просмотреть журналы   ->Изменить данные   Удалить данные   Добавить данные   Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "change"; }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Просмотреть журналы   Изменить данные   ->Удалить данные   Добавить данные   Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "del"; }
                        break;
                    case 3:
                        features.skip();
                        Console.WriteLine("Просмотреть журналы   Изменить данные   Удалить данные   ->Добавить данные   Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "add"; }
                        break;
                    case 4:
                        features.skip();
                        Console.WriteLine("Просмотреть журналы   Изменить данные   Удалить данные   Добавить данные   ->Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "ex";  active = "exit"; }
                        break;
                }
            }
           
        }

        public void Viev(string journal_path, string stud_path, string teach_path, ref List<string> journal)
        {
            features.skip();

            for (int i = 0; i < journal.Count; i++)
            {
                if (i % 5 == 0) { Console.WriteLine("\n"); };
                Console.Write($"{journal[i]}\t");
            }

            Console.ReadKey();

        }

        public void Change(string journal_path, string stud_path, string teach_path)
        {
            features.skip();

            Console.WriteLine("Где изменить?\n");

            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 2) { move = 0; }
                else if (move < 0) { move = 2; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Журнал    Студенты    Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите имя преподавателя\n");


                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Журнал    ->Студенты    Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите логин студента\n");



                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Журнал    Студенты    ->Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите логин прподавателя\n");


                        }
                        break;

                }
            }
        }

        public void Del(string journal_path, string stud_path, string stud_au, string teach_path, string teach_au)
        {
            List<string> Del_bufer = new List<string>();

            features.skip();

            Console.WriteLine("Где удалить?\n");

            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 2) { move = 0; }
                else if (move < 0) { move = 2; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Журнал    Студенты    Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите имя преподавателя\n");


                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Журнал    ->Студенты    Учителя\n");

                        if(start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Удалить всё?\n");
                            int move_ = 0;

                            ConsoleKeyInfo start_ = Console.ReadKey();
                            while (start_.Key != ConsoleKey.Enter)
                            {
                                start_ = Console.ReadKey();

                                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                                if (move > 1) { move = 0; }
                                else if (move < 0) { move = 1; }

                                switch (move)
                                {
                                    case 0:
                                        features.skip();
                                        Console.WriteLine("->Да   Нет\n");
                                        if (start_.Key == ConsoleKey.Enter) { File.Delete(stud_path); File.Delete(stud_au); }
                                        break;
                                    case 1:
                                        features.skip();
                                        Console.WriteLine("Да   ->Нет\n");
                                        if (start_.Key == ConsoleKey.Enter)
                                        {

                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Журнал    Студенты    ->Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Удалить всё?\n");
                            int move_ = 0;

                            ConsoleKeyInfo start_ = Console.ReadKey();
                            while (start_.Key != ConsoleKey.Enter)
                            {
                                start_ = Console.ReadKey();

                                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                                if (move > 1) { move = 0; }
                                else if (move < 0) { move = 1; }

                                switch (move)
                                {
                                    case 0:
                                        features.skip();
                                        Console.WriteLine("->Да   Нет\n");
                                        if (start_.Key == ConsoleKey.Enter) { File.Delete(teach_path); File.Delete(teach_au); }
                                        break;
                                    case 1:
                                        features.skip();
                                        Console.WriteLine("Да   ->Нет\n");
                                        if (start_.Key == ConsoleKey.Enter)
                                        {
                                            Console.WriteLine("Введите логин кого удалить?\n");
                                            string choose = Console.ReadLine();

                                            using (BinaryReader reader = new BinaryReader(File.Open(teach_path, FileMode.Open)))
                                            {
                                                while (reader.PeekChar() > -1)
                                                {
                                                    string login = reader.ReadString();

                                                    if (login == choose)
                                                    {

                                                    }
                                                }
                                            }
                                            using (BinaryReader reader = new BinaryReader(File.Open(teach_au, FileMode.Open)))
                                            {
                                                while (reader.PeekChar() > -1)
                                                {
                                                    string login = reader.ReadString();

                                                    if (login == choose)
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                        }           
                        break;
                    
                }
            }

        
        }

        public void Add(string journal_path, string stud_path, string teach_path, ref List<string> journal_inf)
        {
            features.skip();

            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 2) { move = 0; }
                else if (move < 0) { move = 2; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Журнал    Студенты    Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите данные для новой строки: препод предмет группа студент оценка");

                            string Prepod = Console.ReadLine();
                            string Object_ = Console.ReadLine();
                            string Group = Console.ReadLine();
                            string Student = Console.ReadLine();
                            string grade = Console.ReadLine();

                            features.journal_upd(journal_path, Prepod, Object_, Group, Student, grade);

                            //features.journal_see(journal_path, ref journal_inf);

                            Console.WriteLine("\nDone");
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Журнал    ->Студенты    Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите данные для нового студента: ФИО возраст год_рождения группа логин пароль");

                            string FIO = Console.ReadLine();
                            string Age = Console.ReadLine();
                            string Bornage = Console.ReadLine();
                            string Group = Console.ReadLine();
                            string Login = Console.ReadLine();
                            string Password = Console.ReadLine();

                            using (BinaryWriter writer = new BinaryWriter(File.Open(stud_path, FileMode.OpenOrCreate)))
                            {
                                writer.Write(FIO);
                                writer.Write(Age);
                                writer.Write(Bornage);
                                writer.Write(Group);
                                writer.Write(Login);
                                writer.Write(Password);
                            }

                            using (BinaryWriter writer = new BinaryWriter(File.Open("auth/auth_info_stud.dat", FileMode.OpenOrCreate)))
                            {
                                writer.Write(Login);
                                writer.Write(Password);
                                Console.WriteLine("\nDone");
                            }
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Журнал    Студенты    ->Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите данные для нового препода: ФИО год_рождения дисциплины(сколько) группы(сколько) логин пароль");

                            string FIO = Console.ReadLine();
                            int Bornage = int.Parse(Console.ReadLine());
                            int Objects_count = int.Parse(Console.ReadLine());               
                            int Groups_count = int.Parse(Console.ReadLine());
                            string Login = Console.ReadLine();
                            string Password = Console.ReadLine();

                            using (BinaryWriter writer = new BinaryWriter(File.Open(teach_path, FileMode.OpenOrCreate)))
                            {
                                writer.Write(FIO);
                                writer.Write(Bornage);
                                Console.WriteLine("Введите дисциплины: ");
                                for (int i = 0; i < Objects_count; i++)
                                {
                                    string Ojects = Console.ReadLine();
                                    writer.Write(Ojects);
                                }
                                Console.WriteLine("Введите группы: ");
                                for (int i = 0; i < Groups_count; i++)
                                {
                                    string Groups = Console.ReadLine();
                                    writer.Write(Groups);
                                }
                                writer.Write(Login);
                                writer.Write(Password);
                                writer.Write("zanzuzak");
                            }

                            using (BinaryWriter writer = new BinaryWriter(File.Open("auth/auth_info_teacher.dat", FileMode.OpenOrCreate)))
                            {
                                writer.Write(Login);
                                writer.Write(Password);
                                Console.WriteLine("\nDone");
                            }
                        }
                        break;
                }
            }
            
        }



        class Info_Admin
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public Info_Admin(string login, string password)
            {
                Login = login;
                Password = password;
            }
        }

        class journal
        {
            public string Object { get; set; }
            public string Student { get; set; }
            public int Grade { get; set; }
            public string Time { get; set; }

            public journal(string object_, string student, int grade, string time_)
            {
                Object = object_;
                Student = student;
                Grade = grade;
                Time = time_;
            }
        }

    }
}
