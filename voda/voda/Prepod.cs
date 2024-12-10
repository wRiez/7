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
        public void te_info(string journal_path, ref string act, string login, List<string> journal, string te_au, string te_inf)
        {
            features.skip();

            int move = 0;

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
                            features.skip();
                            string fio_te = "0";
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

                            using (BinaryReader reader = new BinaryReader(File.Open(journal_path, FileMode.Open)))
                            {
                                while (reader.PeekChar() > -1)
                                {
                                    string name = reader.ReadString();

                                    if (name == fio_te)
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            string name_see = reader.ReadString();
                                            Console.Write($"{name_see}\t");
                                        }
                                    }
                                }
                            }

                            Console.ReadKey();
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Посмотреть   ->Выставить оценку   Изменить   Удалить  Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {

                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Посмотреть   Выставить оценку   ->Изменить   Удалить  Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {

                        }
                        break;
                    case 3:
                        features.skip();
                        Console.WriteLine("Посмотреть   Выставить оценку   Изменить   ->Удалить  Выйти\n");

                        if (start.Key == ConsoleKey.Enter)
                        {

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
