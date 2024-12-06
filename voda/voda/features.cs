using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

                        i++;
                        if (i == 2)
                        {
                            journal.RemoveAll(x => x.Equals(copu));
                        }

                        journal.Add(copu);
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
