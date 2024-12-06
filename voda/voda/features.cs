using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public void journal_upd(string path, string prepod, string object_, string group, string student, string grade)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(prepod);
                writer.Write(object_);
                writer.Write(group);
                writer.Write(student);
                writer.Write(grade);
                //writer.Write(time);
            }
        }

        public void journal_see(string path, ref List<string> journal)
        {
            if (File.Exists(path))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    int i = 1;
                    while (reader.PeekChar() > -1)
                    {
                        string copu = reader.ReadString();

                        i+=1;
                        if (i == 2)
                        {
                            journal.RemoveAll(x => x.Equals(copu));
                        }

                        journal.Add(copu);
                    }
                }
            }
        }

        public void delete_smth(List<string> bufer, string path, string path_au)
        {
            Console.WriteLine("Введите логин пользователя\n");

            List<string> buf_dop = new List<string>();
            string login = Console.ReadLine();

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    string check = reader.ReadString();

                    if (check != login)
                    {
                        bufer.Add(check);
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            check = reader.ReadString();
                        }
                    }
                }   
            }
            File.Delete(path);

            using (BinaryWriter writer = new BinaryWriter(File.Open(path_au, FileMode.OpenOrCreate)))
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

    }
}
