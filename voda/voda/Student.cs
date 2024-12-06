using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace voda
{
    internal class Student
    {
        features features = new features();

        public void viev(string journal, string st_au, string login)
        {
            string new_fio = "0";

            using (BinaryReader reader = new BinaryReader(File.Open(st_au, FileMode.Open)))
            {
                string FIO = reader.ReadString();
                string Age = reader.ReadString();
                string Bornage = reader.ReadString();
                string Group = reader.ReadString();
                string Login = reader.ReadString();
                string Password = reader.ReadString();

                if (Login == login)
                {
                    new_fio = FIO;
                }
            }

            using (BinaryReader reader = new BinaryReader(File.Open(journal, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string prepod = reader.ReadString();
                    string object_ = reader.ReadString();
                    string group = reader.ReadString();
                    string student = reader.ReadString();
                    string grade = reader.ReadString();

                    if (student == new_fio)
                    {
                        Console.Write($"{prepod}\n");
                        Console.Write($"{object_}\n");
                        Console.Write($"{group}\n");
                        Console.Write($"{student}\n");
                        Console.Write($"{grade}\n");
                    }
                }
            }
        }

        public void st_info(string journal_path, ref string act, string login, List<string> journal, string st_au)
        {
            //features.skip();

            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                start = Console.ReadKey();

                if (start.Key == ConsoleKey.RightArrow) { move += 1; }
                else if (start.Key == ConsoleKey.LeftArrow) { move -= 1; }

                if (move > 1) { move = 0; }
                else if (move < 0) { move = 1; }

                switch (move)
                {
                    case 0:
                        features.skip();
                        Console.WriteLine("->Посмотреть   Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            viev(journal_path, st_au, login);
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Посмотреть   ->Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            act = "exit";
                        }
                        break;
                }
            }
        }

        class Info_Student
        {
            public string FIO { get; set; }
            public int Age { get; set; }
            public int Bornage { get; set; }
            public string Group_ { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public Info_Student(string fio, int age, int bornage, string group_, string login, string password)
            {
                FIO = fio;
                Age = age;
                Bornage = bornage;
                Group_ = group_;
                Login = login;
                Password = password;
            }
        }

        class Journal_
        {
            public string Prepod { get; set; }
            public string Object { get; set; }
            public string Student { get; set; }
            public int Grade { get; set; }

            public Journal_(string prepod, string object_, string student, int grade)
            {
                Prepod = prepod;
                Object = object_;
                Student = student;
                Grade = grade;
            }
        }
    }
}
