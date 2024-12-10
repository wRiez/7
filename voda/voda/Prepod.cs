using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voda
{
    internal class Prepod
    {
        features features = new features();
        public void te_info(string journal_path, ref string act, string login, List<string> journal, string te_inf, string st_inf)
        {
            //features.skip();

            int move = 0;
            string fio_te = "0";
            List<string> bufer = new List<string>();


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
                        Console.WriteLine("->Посмотреть   Выставить оценку   Изменить   Удалить  Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            viev(journal_path, journal, te_inf, login, ref fio_te);
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Посмотреть   ->Выставить оценку   Изменить   Удалить  Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            add_grade(journal_path, journal, te_inf, login, bufer, ref fio_te, st_inf);
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Посмотреть   Выставить оценку   ->Изменить   Удалить  Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            change_grade(journal_path, journal, te_inf, login, bufer, ref fio_te);
                        }
                        break;
                    case 3:
                        features.skip();
                        Console.WriteLine("Посмотреть   Выставить оценку   Изменить   ->Удалить  Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            del_grade(journal_path, journal, te_inf, login, bufer, ref fio_te);
                        }
                        break;
                    case 4:
                        features.skip();
                        Console.WriteLine("Посмотреть   Выставить оценку   Изменить   Удалить  ->Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            act = "exit";
                        }
                        break;
                }
            }
        }


        public void viev(string journal_path, List<string> journal_inf, string te_inf, string login, ref string fio_te)
        {

            auth_teacher_fio(te_inf, login, ref fio_te);

            //Console.WriteLine($"{fio_te}\n");

            using (BinaryReader reader = new BinaryReader(File.Open(journal_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    //Console.WriteLine(name);

                    if (name == fio_te)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            
                            Console.Write($"{name}\t");
                            if (i != 4) { name = reader.ReadString(); }

                        }
                        Console.WriteLine("\n");
                    }
                }
            }

            Console.ReadKey();
        }

        public void add_grade(string journal_path, List<string> journal_ing, string te_inf, string login, List<string> bufer, ref string fio_te, string st_inf)
        {

            auth_teacher_fio(te_inf, login, ref fio_te);

            Console.WriteLine("\nВведите имя студента и предмет\n");

            string fio_st = Console.ReadLine();
            string object_choose = Console.ReadLine();

            //features.st_for_te(st_inf, ref fio_st);

            using (BinaryReader reader = new BinaryReader(File.Open(journal_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    if (name == fio_te)
                    {
                        string object_ = reader.ReadString();
                        string group = reader.ReadString();
                        string student = reader.ReadString();
                        string grade = reader.ReadString();

                        if ((student == fio_st) && (object_ == object_choose))
                        {
                            bufer.Add(name);
                            bufer.Add(object_);
                            bufer.Add(group);
                            bufer.Add(student);
                            if (grade != "none") { Console.WriteLine("\nОценка уже стоит\n"); bufer.Add(grade); }
                            else { Console.WriteLine("\nВведите оценку\n"); string grade_add = Console.ReadLine(); bufer.Add(grade_add); }
                        }
                        else
                        {
                            bufer.Add(name);
                            bufer.Add(object_);
                            bufer.Add(group);
                            bufer.Add(student);
                            bufer.Add(grade);
                        }
                    }
                    else { bufer.Add(name); }
                }
            }

            File.Delete(journal_path);

            using (BinaryWriter writer = new BinaryWriter(File.Open(journal_path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < bufer.Count; i++)
                {
                    writer.Write(bufer[i]);
                }
            }

            Console.WriteLine("\nDone\n");

        }


        public void change_grade(string journal_path, List<string> journal_ing, string te_inf, string login, List<string> bufer, ref string fio_te)
        {

            auth_teacher_fio(te_inf, login, ref fio_te);

            Console.WriteLine("\nВведите имя студента и предмет\n");

            string fio_st = Console.ReadLine();
            string object_choose = Console.ReadLine();

            using (BinaryReader reader = new BinaryReader(File.Open(journal_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    if (name == fio_te)
                    {
                        string object_ = reader.ReadString();
                        string group = reader.ReadString();
                        string student = reader.ReadString();
                        string grade = reader.ReadString();

                        if ((student == fio_st) && (object_ == object_choose))
                        {
                            bufer.Add(name);
                            bufer.Add(object_);
                            bufer.Add(group);
                            bufer.Add(student);
                            
                            Console.WriteLine("\nВведите оценку\n"); 
                            string grade_add = Console.ReadLine(); 
                            bufer.Add(grade_add);
                        }
                        else
                        {
                            bufer.Add(name);
                            bufer.Add(object_);
                            bufer.Add(group);
                            bufer.Add(student);
                            bufer.Add(grade);
                        }
                    }
                    else { bufer.Add(name); }
                }
            }

            File.Delete(journal_path);

            using (BinaryWriter writer = new BinaryWriter(File.Open(journal_path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < bufer.Count; i++)
                {
                    writer.Write(bufer[i]);
                }
            }

            Console.WriteLine("\nDone\n");
        }



        public void del_grade(string journal_path, List<string> journal_ing, string te_inf, string login, List<string> bufer, ref string fio_te)
        {

            auth_teacher_fio(te_inf, login, ref fio_te);

            Console.WriteLine("\nВведите имя студента и предмет\n");

            string fio_st = Console.ReadLine();
            string object_choose = Console.ReadLine();

            using (BinaryReader reader = new BinaryReader(File.Open(journal_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();

                    if (name == fio_te)
                    {
                        string object_ = reader.ReadString();
                        string group = reader.ReadString();
                        string student = reader.ReadString();
                        string grade = reader.ReadString();

                        if ((student == fio_st) && (object_ == object_choose))
                        {
                            bufer.Add(name);
                            bufer.Add(object_);
                            bufer.Add(group);
                            bufer.Add(student);

                            string grade_add = "none";
                            bufer.Add(grade_add);
                        }
                        else
                        {
                            bufer.Add(name);
                            bufer.Add(object_);
                            bufer.Add(group);
                            bufer.Add(student);
                            bufer.Add(grade);
                        }
                    }
                    else { bufer.Add(name); }
                }

            }

            File.Delete(journal_path);

            using (BinaryWriter writer = new BinaryWriter(File.Open(journal_path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < bufer.Count; i++)
                {
                    writer.Write(bufer[i]);
                }
            }

            Console.WriteLine("\nDone\n");
        }



        void auth_teacher_fio(string te_inf, string login, ref string fio_te)
        {
            fio_te = "0";
            //Console.WriteLine(login);

            using (BinaryReader reader = new BinaryReader(File.Open(te_inf, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string log_in = reader.ReadString();

                    if (log_in == login)
                    {
                        string skip1 = reader.ReadString();
                        string skip2 = reader.ReadString();

                        fio_te = skip2;
                        break;
                    }
                }
            }
        }
        class Info_Teacher
        {
            public string FIO { get; set; }
            public int Bornage { get; set; }
            public string Disciplines { get; set; }
            public string Groups_ { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public Info_Teacher(string fio, int bornage, string disciplines, string groups_, string login, string password)
            {
                FIO = fio;
                Bornage = bornage;
                Disciplines = disciplines;
                Groups_ = groups_;
                Login = login;
                Password = password;
            }
        }

        class journal
        {
            public string Object { get; set; }
            public int Grade { get; set; }
            public string Time { get; set; }

            public journal(string object_, int grade, string time_)
            {
                Object = object_;
                Grade = grade;
                Time = time_;
            }
        }
    }
}
