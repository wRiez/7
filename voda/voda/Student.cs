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

        public void viev(string journal, ref List<string> journal_inf, string st_inf, string login)
        {
            List<string> bufer = new List<string>();
            string new_fio = "0";
            int k = 0;

            //features.journal_see(journal, ref journal_inf);

            using (BinaryReader reader = new BinaryReader(File.Open(st_inf, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    bufer.Add(name);

                    if (bufer.Count > 2)
                    {
                        //Console.WriteLine(bufer[i]);
                        if (bufer[k - 2] == login)
                        {
                            new_fio = bufer[k];
                            break;
                        }
                    }

                    k += 1;
                }  
            }

            //for (int i = 0; i < bufer.Count; i++) { bufer.Remove(bufer[i]); }

            //for (int i = 0; i < journal_inf.Count; i++) { Console.WriteLine(journal_inf[i]); }

            //Console.WriteLine(new_fio);

            using (BinaryReader reader = new BinaryReader(File.Open(journal, FileMode.Open)))
            {
                features.skip();

                while (reader.PeekChar() > -1)
                {
                    string prepod = reader.ReadString();
                    string predmet = reader.ReadString();
                    string grouo = reader.ReadString();
                    string stud = reader.ReadString();
                    string grade = reader.ReadString();


                    if (stud == new_fio)
                    {
                        Console.WriteLine($"{prepod}\t{predmet}\t{grouo}\t{stud}\t{grade}\n\n\n");
                    }
                }
            }

            //features.skip();

            //for (int i = 0; i < journal_inf.Count; i++)
            //{
            //    if (journal_inf[i] == new_fio)
            //    { 
            //        Console.WriteLine($"{journal_inf[i - 3]}\t{journal_inf[i - 2]}\t{journal_inf[i - 1]}\t{journal_inf[i]}\t{journal_inf[i + 1]}\n\n\n");
            //    }
            //}
        }

        public void st_info(string journal_path, ref List<string> journal_inf, ref string act, string login, string st_inf)
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
                            viev(journal_path, ref journal_inf, st_inf, login);
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
