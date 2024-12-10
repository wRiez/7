using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace voda
{
    internal class features
    {


        public void skip()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }

        public void authorization(ref string name, ref string password)
        {
            Console.WriteLine("Логин: ");
            name = Console.ReadLine();

            Console.WriteLine("\nПароль: ");
            password = Console.ReadLine();
        }

        public void check(string login, string password, string path, ref int access)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string log_in = reader.ReadString();

                    if (log_in == login)
                    {
                        string pass_word = reader.ReadString();
                        if (pass_word == password)
                        {
                            access = 1;
                        }
                    }
                    else
                    {
                        string skip = reader.ReadString();
                    }
                }
            }
        }

        public void check_log(string login, string password, string path, ref string active)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string log_in = reader.ReadString();

                    if (log_in == login)
                    {
                        string pass_word = reader.ReadString();
                        if (pass_word == password)
                        {
                            switch (path)
                            {
                                case "auth/auth_info_admin.dat":
                                    active = "admin";
                                    break;
                                case "auth/auth_info_stud.dat":
                                    active = "student";
                                    break;
                                case "auth/auth_info_teacher.dat":
                                    active = "teacher";
                                    break;
                            }
                        }
                    }
                    else
                    {
                        string skip = reader.ReadString();
                    }
                }
            }
        }

        public void journal_upd(string path, List<string> bufer)
        {

            List<string> main_bufer = new List<string>();

            if (File.Exists(path))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();

                        main_bufer.Add(name);
                    }
                }
            }

            for (int i = 0; i < bufer.Count; i++) { main_bufer.Add(bufer[i]); }

            //for (int i = 0; i < bufer.Count; i++) { Console.WriteLine(main_bufer[i]); }

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            { 

                for (int i = 0; i < main_bufer.Count; i++)
                {
                    writer.Write(main_bufer[i]);
                }
            }
        }

        public void journal_see(string path, ref List<string> journal)
        {
            if (File.Exists(path))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    for (int j = 0; j < journal.Count; j++) { journal.Remove(journal[j]); }

                    while (reader.PeekChar() > -1)
                    {
                        string copu = reader.ReadString();

                        journal.Add(copu);
                    }
                }
            }
        }

        public void delete_smth(List<string> bufer, string path, string path_au, string activ)
        {
            Console.WriteLine("Введите логин пользователя\n");

            List<string> buf_dop = new List<string>();
            string login = Console.ReadLine();

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                int h = 0;

                while (reader.PeekChar() > -1)
                {
                    string check = reader.ReadString();

                    if (check != login)
                    {
                        bufer.Add(check);
                    }
                    else
                    {
                        if (h > 0) { break; }

                        switch (activ)
                        {
                            case "journal":
                                for (int i = 0; i < 4; i++)
                                {
                                        check = reader.ReadString();
                                        h += 1;
                                }
                                break;
                            case "stud":
                                for (int i = 0; i < 5; i++)
                                {
                                        check = reader.ReadString();
                                        h += 1;
                                }
                                break;
                            case "teacher":
                                for (int i = 0; i < 77; i++)
                                {
                                    check = reader.ReadString();
                                    if (check == "|")
                                    {
                                        break;
                                    }
                                    h += 1;                       
                                }
                                break;
                        }
                    }
                }   
            }
            File.Delete(path);

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < bufer.Count; i++)
                {
                    writer.Write(bufer[i]);
                }
            }

            if (path_au != "0")
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path_au, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string check = reader.ReadString();

                        if (check != login)
                        {
                            buf_dop.Add(check);
                        }
                        else
                        {
                            check = reader.ReadString();
                        }
                    }
                }
                File.Delete(path_au);

                using (BinaryWriter writer = new BinaryWriter(File.Open(path_au, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < buf_dop.Count; i++)
                    {
                        writer.Write(bufer[i]);
                    }
                }
            }

            Console.WriteLine("\nDone\n");
        }


        public void change_smth(string login, string path, string activ)
        {
            List<string> bufer = new List<string>();

            string fio_te = login;
            string fio_st = "0";

            switch (activ)
                {
                    case "journal":

                        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                        {
                            while (reader.PeekChar() > -1)
                            {
                                string name_j = reader.ReadString();

                                if (name_j == fio_te)
                                {
                                    Console.WriteLine("\nВведите новые данные в журнал: препод предмет группа студент оценка\n");

                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (i != 4) { string name_jk = reader.ReadString(); }

                                        string dop = Console.ReadLine();

                                        bufer.Add(dop);
                                    }

                                }
                                else { bufer.Add(name_j); }

                            }
                        }
                        

                        File.Delete(path);

                        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                        {
                            for (int i = 0; i < bufer.Count; i++)
                            {
                                writer.Write(bufer[i]);
                            }
                        }

                        Console.WriteLine("\nDone\n");

                        break;

                    case "student":

                    List<string> bufer_dop = new List<string>();
                    string st_au = "auth/auth_info_stud.dat";

                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            string log_s = reader.ReadString();
                            string pas_s = reader.ReadString();
                            string fio_s = reader.ReadString();
                            string yo_s = reader.ReadString();
                            string yb_s = reader.ReadString();
                            string group_s = reader.ReadString();

                            if ( fio_s == login ) { fio_st = log_s; break; }
                        }
                    }

                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        Console.WriteLine("\nВведите новые данные студента: логин пароль фио возраст год_рождения группа\n");

                        while (reader.PeekChar() > -1)
                        {
                            string name_s = reader.ReadString();

                            if (name_s == fio_st)
                            {

                                for (int i = 0; i < 6; i++)
                                {
                                    if (i != 5) { string name_sk = reader.ReadString(); }

                                    string dop = Console.ReadLine();

                                    bufer.Add(dop);
                                }
                            }
                            else { bufer.Add(name_s); }
                        }
                            
                    }

                    using (BinaryReader reader = new BinaryReader(File.Open(st_au, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            string name_s = reader.ReadString();

                            Console.WriteLine("\nВведите новые данные студента: логин и пароль\n");

                            if (name_s == fio_st)
                            {
                                string name_sk = reader.ReadString();

                                string dop = Console.ReadLine();
                                string dop_2 = Console.ReadLine();

                                bufer_dop.Add(dop);
                                bufer_dop.Add(dop_2);
                            }
                            else { bufer_dop.Add(name_s); }
                        }
                    }

                    File.Delete(path);
                    File.Delete(st_au);

                    using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                    {
                        for (int i = 0; i < bufer.Count; i++)
                        {
                            writer.Write(bufer[i]);
                        }
                    }
                    using (BinaryWriter writer = new BinaryWriter(File.Open(st_au, FileMode.OpenOrCreate)))
                    {
                        for (int i = 0; i < bufer_dop.Count; i++)
                        {
                            writer.Write(bufer_dop[i]);
                        }
                    }

                    Console.WriteLine("\nDone\n");

                    break;



                    case "teacher":

                    List<string> buf_dop = new List<string>();
                    string te_au = "auth/auth_info_teacher.dat";

                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            string name_te = reader.ReadString();

                            buf_dop.Add(name_te);
                        }
                            
                        for (int i = 0; i < buf_dop.Count; i++)
                        {
                            if (buf_dop[i] == login) { fio_te = buf_dop[i-2]; break; }
                        }
                    }

                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        string dop_buf = "-";

                        Console.WriteLine("\nВведите новые данные препода: логин пароль фио год_рождения предметы группы \n");

                        while (reader.PeekChar() > -1)
                        {
                            string name_te = reader.ReadString();

                            if (name_te == fio_te)
                            {
                                while (name_te != "|")
                                {
                                    
                                    string dop = Console.ReadLine();

                                    bufer.Add(dop);

                                    name_te = reader.ReadString();

                                }
                                if (name_te == "|")
                                {
                                    Console.WriteLine("\nИзменения сверхнормы. Продолжить?\n");

                                    string choose = Console.ReadLine();

                                    if (choose == "yes")
                                    {
                                        while (dop_buf != "exit")
                                        {
                                            string dop = Console.ReadLine();

                                            if (dop == "exit") { break; }

                                            bufer.Add(dop);
                                        }
                                    }

                                    bufer.Add("|");
                                }
                            }
                            else { bufer.Add(name_te); }

                        }
                    }

                    for (int i = 0; i < buf_dop.Count; i++) { buf_dop.Remove(buf_dop[i]); }

                    using (BinaryReader reader = new BinaryReader(File.Open(te_au, FileMode.Open)))
                    {

                        Console.WriteLine("\nВведите новые данные препода: логин пароль \n");

                        while (reader.PeekChar() > -1)
                        {
                            string name_te = reader.ReadString();

                            if (name_te == fio_te)
                            {
                                string name_te_s = reader.ReadString();

                                string dop = Console.ReadLine();
                                string dop_2 = Console.ReadLine();

                                buf_dop.Add(dop);
                                buf_dop.Add(dop_2);
                            }
                            else { buf_dop.Add(name_te); }
                        }
                    }

                        File.Delete(path);
                    File.Delete(te_au);

                    using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                    {
                        for (int i = 0; i < bufer.Count; i++)
                        {
                            writer.Write(bufer[i]);
                        }
                    }
                    using (BinaryWriter writer = new BinaryWriter(File.Open(te_au, FileMode.OpenOrCreate)))
                    {
                        for (int i = 0; i < buf_dop.Count; i++)
                        {
                            writer.Write(buf_dop[i]);
                        }
                    }

                    Console.WriteLine("\nDone");
                    break;
                }
        }

        public void log(string Login, string Password, string path) 
        { 
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(Login);
                writer.Write(Password);
                Console.WriteLine("\nDone");
            }
        }

        public void checkуу(string Login, string Password, string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                string name = reader.ReadString();
                string pass = reader.ReadString();
                Console.WriteLine($"Name: {name}  Age: {pass}");
            }
        }


        //public void st_for_te(string st_inf, ref string fio_st)
        //{
        //    List<string> bufer = new List<string>();

        //    Console.WriteLine("\nВведите имя студента\n");
        //    string name_s = Console.ReadLine();

        //    using (BinaryReader reader = new BinaryReader(File.Open(st_inf, FileMode.Open)))
        //    {
        //        while(reader.PeekChar() > -1)
        //        {
        //            string name = reader.ReadString();

        //            bufer.Add(name);
        //        }

        //            for (int i = 0; i < bufer.Count; i++)
        //            {
        //                if (bufer[i] == name_s)
        //                {
        //                    fio_st = bufer[i + 2];
        //                    break;
        //                }
        //            }
        //    }
        //}

    }
}
