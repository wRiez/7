using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
                        Console.WriteLine("->Просмотреть   Изменить данные   Удалить данные   Добавить данные   Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "viev"; }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Просмотреть   ->Изменить данные   Удалить данные   Добавить данные   Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "change"; }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Просмотреть   Изменить данные   ->Удалить данные   Добавить данные   Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "del"; }
                        break;
                    case 3:
                        features.skip();
                        Console.WriteLine("Просмотреть   Изменить данные   Удалить данные   ->Добавить данные   Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "add"; }
                        break;
                    case 4:
                        features.skip();
                        Console.WriteLine("Просмотреть   Изменить данные   Удалить данные   Добавить данные   ->Выход");

                        if (start.Key == ConsoleKey.Enter) { act = "ex";  active = "exit"; }
                        break;
                }
            }
           
        }

        public void Viev(string journal_path, string stud_path, string teach_path, ref List<string> journal)
        {
            features.skip();

            Console.WriteLine("Что именно просмотреть?\n");

            int move = 0;
            int cnt = 0;

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
                        int s = 0;

                        Console.WriteLine("->Журнал   Преподы   Студенты");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            features.skip();

                            using (BinaryReader reader = new BinaryReader(File.Open(journal_path, FileMode.OpenOrCreate)))
                            {
                                while (reader.PeekChar() > -1)
                                {
                                    string name_j = reader.ReadString();

                                    Console.Write($"{name_j}\t");
                                    s += 1;

                                    if (s % 5 == 0) { Console.WriteLine("\n"); };
                                }
                            }
                                
                        }
                        break;
                    case 1:
                        features.skip();

                        Console.WriteLine("Журнал   ->Преподы   Студенты\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            using (BinaryReader reader = new BinaryReader(File.Open(teach_path, FileMode.OpenOrCreate)))
                            {
                                while (reader.PeekChar() > -1)
                                {
                                    string name_te = reader.ReadString();

                                    Console.Write($"{name_te}\t");

                                    if (name_te == "|") { Console.WriteLine(" \n"); }
                                }
                            }
                        }
                        break;
                    case 2:
                        features.skip();

                        Console.WriteLine("Журнал   Преподы   ->Студенты\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            using (BinaryReader reader = new BinaryReader(File.Open(stud_path, FileMode.OpenOrCreate)))
                            {
                                while (reader.PeekChar() > -1)
                                {
                                    string name_st = reader.ReadString();

                                    Console.Write($"{name_st}\t");

                                    cnt += 1;

                                    if (cnt == 6) { Console.WriteLine(" \n"); }
                                }
                            }

                            cnt = 0;
                        }
                        break;
                }
            }

            Console.ReadKey();

        }

        public void Change(string journal_path, string stud_path, string teach_path)
        {
            features.skip();

            Console.WriteLine("Где изменить?\n");

            string activ = "0";
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

                            string login = Console.ReadLine();
                            activ = "journal";

                            features.change_smth(login, journal_path, activ);
                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Журнал    ->Студенты    Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите логин студента\n");

                            string login = Console.ReadLine();
                            activ = "student";

                            features.change_smth(login, stud_path, activ);
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Журнал    Студенты    ->Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите логин прподавателя\n");

                            string login = Console.ReadLine();
                            activ = "teacher";

                            features.change_smth(login, teach_path, activ);
                        }
                        break;

                }
            }
        }

        public void Del(string journal_path, string stud_path, string stud_au, string teach_path, string teach_au, ref List<string> journal_inf)
        {
            List<string> Del_bufer = new List<string>();

            features.skip();

            Console.WriteLine("Где удалить?\n");

            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {

                string activ = "0";
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

                        activ = "journal";

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Удалить всё?\n");
                            int move_j = 0;

                            ConsoleKeyInfo start_j = Console.ReadKey();
                            while (start_j.Key != ConsoleKey.Enter)
                            {
                                start_j = Console.ReadKey();

                                if (start_j.Key == ConsoleKey.RightArrow) { move_j += 1; }
                                else if (start_j.Key == ConsoleKey.LeftArrow) { move_j -= 1; }

                                if (move_j > 1) { move_j = 0; }
                                else if (move_j < 0) { move_j = 1; }

                                string test1 = "0";
                                switch (move_j)
                                {
                                   
                                    case 0:
                                        features.skip();
                                        Console.WriteLine("->Да   Нет\n");
                                        if (start_j.Key == ConsoleKey.Enter) { File.Delete(journal_path); Console.WriteLine("Done\n"); }
                                        break;
                                    case 1:
                                        features.skip();
                                        Console.WriteLine("Да   ->Нет\n");
                                        if (start_j.Key == ConsoleKey.Enter)
                                        {
                                            features.delete_smth(Del_bufer, journal_path, test1, activ);
                                        }
                                        break;
                                }
                            }

                        }
                        break;
                    case 1:
                        features.skip();
                        Console.WriteLine("Журнал    ->Студенты    Учителя\n");

                        activ = "stud";

                        if(start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Удалить всё?\n");
                            int move_st = 0;

                            ConsoleKeyInfo start_st = Console.ReadKey();
                            while (start_st.Key != ConsoleKey.Enter)
                            {
                                start_st = Console.ReadKey();

                                if (start_st.Key == ConsoleKey.RightArrow) { move_st += 1; }
                                else if (start_st.Key == ConsoleKey.LeftArrow) { move_st -= 1; }

                                if (move_st > 1) { move_st = 0; }
                                else if (move_st < 0) { move_st = 1; }

                                switch (move_st)
                                {
                                    case 0:
                                        features.skip();
                                        Console.WriteLine("->Да   Нет\n");
                                        if (start_st.Key == ConsoleKey.Enter) { File.Delete(stud_path); File.Delete(stud_au); Console.WriteLine("Done\n"); }
                                        break;
                                    case 1:
                                        features.skip();
                                        Console.WriteLine("Да   ->Нет\n");
                                        if (start_st.Key == ConsoleKey.Enter)
                                        {
                                            features.delete_smth(Del_bufer, stud_path, stud_au, activ);
                                            features.journal_see(journal_path, ref journal_inf);
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Журнал    Студенты    ->Учителя\n");

                        activ = "teacher";

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Удалить всё?\n");
                            int move_te = 0;

                            ConsoleKeyInfo start_te = Console.ReadKey();
                            while (start_te.Key != ConsoleKey.Enter)
                            {
                                start_te = Console.ReadKey();

                                if (start_te.Key == ConsoleKey.RightArrow) { move_te += 1; }
                                else if (start_te.Key == ConsoleKey.LeftArrow) { move_te -= 1; }

                                if (move_te > 1) { move_te = 0; }
                                else if (move_te < 0) { move_te = 1; }

                                switch (move_te)
                                {
                                    case 0:
                                        features.skip();
                                        Console.WriteLine("->Да   Нет\n");
                                        if (start_te.Key == ConsoleKey.Enter) { File.Delete(teach_path); File.Delete(teach_au); }
                                        break;
                                    case 1:
                                        features.skip();
                                        Console.WriteLine("Да   ->Нет\n");
                                        if (start_te.Key == ConsoleKey.Enter)
                                        {
                                            features.delete_smth(Del_bufer, teach_path, teach_au, activ);
                                        }
                                        break;
                                }
                            }
                        }           
                        break;
                    
                }
            }

        
        }

        public void Add(string journal_path, string stud_path, string teach_path, ref List<string> journal_inf, string login)
        {
            features.skip();

            int move = 0;

            ConsoleKeyInfo start = Console.ReadKey();
            while (start.Key != ConsoleKey.Enter)
            {
                List<string> bufer = new List<string>();

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



                            for (int i = 0; i < 5; i++)
                            {
                                string name = Console.ReadLine();

                                bufer.Add(name);
                            }

                            features.journal_upd(journal_path, bufer);
                            features.journal_see(journal_path, ref journal_inf);

                            Console.WriteLine("\nDone");
                        }
                        break;
                    case 1:
                        features.skip();
                        string stud_au = "auth/auth_info_stud.dat";
                        Console.WriteLine("Журнал    ->Студенты    Учителя\n");

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите данные для нового студента: Логин Пароль ФИО возраст год_рождения группа");

                            if (File.Exists(stud_path))
                            {
                                using (BinaryReader reader = new BinaryReader(File.Open(stud_path, FileMode.Open)))
                                {
                                    while (reader.PeekChar() > -1)
                                    {
                                        string name = reader.ReadString();
                                        bufer.Add(name);
                                    }
                                }

                                File.Delete(stud_path);
                                File.Delete(stud_au);

                            }

                            for (int i = 0; i < 6; i++)
                            {
                                string name = Console.ReadLine();

                                bufer.Add(name);
                            }


                            using (BinaryWriter writer = new BinaryWriter(File.Open(stud_path, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer.Count; i++)
                                {
                                    writer.Write(bufer[i]);
                                }

                            }

                            using (BinaryWriter writer = new BinaryWriter(File.Open(stud_au, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer.Count; i++)
                                { 
                                    if ((i == 0) || (i % 6 == 0))
                                    {
                                        writer.Write(bufer[i]);
                                        writer.Write(bufer[i + 1]);
                                    }
                                }
                                Console.WriteLine("\nDone");
                            }
                        }
                        break;
                    case 2:
                        features.skip();
                        Console.WriteLine("Журнал    Студенты    ->Учителя\n");
                        string teach_au = "auth/auth_info_teacher.dat";

                        if (start.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("Введите данные для нового препода: логин пароль ФИО год_рождения дисциплины группы");

                            if (File.Exists(teach_path))
                            {
                                using (BinaryReader reader = new BinaryReader(File.Open(teach_path, FileMode.Open)))
                                {
                                    while (reader.PeekChar() > -1)
                                    {
                                        string name = reader.ReadString();
                                        bufer.Add(name);
                                    }
                                }

                                File.Delete(teach_path);
                                File.Delete(teach_au);

                            }

                            for (int i = 0; i < 99; i++)
                            {
                                string name = Console.ReadLine();

                                if (name == "exit")
                                {
                                    break;
                                }

                                bufer.Add(name);
                            }


                            using (BinaryWriter writer = new BinaryWriter(File.Open(teach_path, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer.Count; i++)
                                {
                                    writer.Write(bufer[i]);
                                }

                                writer.Write("|");
                            }

                            using (BinaryWriter writer = new BinaryWriter(File.Open(teach_au, FileMode.OpenOrCreate)))
                            {
                                for (int i = 0; i < bufer.Count; i++)
                                {
                                    if ((i == 0) || (bufer[i - 1] == "|"))
                                    {
                                        writer.Write(bufer[i]);
                                        writer.Write(bufer[i + 1]);
                                    }
                                }
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
