using voda;

// --- Класыы ---

features features = new features();
Admin admin = new Admin();
Student student = new Student();
Prepod prepod = new Prepod();

// --- Переменные ---

string path_auth_ad = "auth/auth_info_admin.dat";
string path_auth_st = "auth/auth_info_stud.dat";
string path_auth_te = "auth/auth_info_teacher.dat";
string path_admin = "person/admin_info.dat";
string path_teacher = "person/teacher_info.dat";
string path_student = "person/stud_info.dat";
string path = "0";

string path_journal = "journal.dat";

int test_count = 0;
string Login = "admin";
string Password = "a";
string active = "0";
string act = "0";
string choose = "0";
string logn = "-";
//string work = "start";
int access = 0;

List<string> journal_inf = new List<string>();

// --- Основа --- 


//features.logandchech(Login, Password, path_auth_te);

while (test_count == 0)
{
    Console.WriteLine("\n\n\n\t -> Войти");
    Console.WriteLine("\nНажмите Enter чтобы продолжить");

    ConsoleKeyInfo start = Console.ReadKey();

    if (start.Key == ConsoleKey.Enter)
    {
        test_count += 1;
    }
}

features.skip();

Console.WriteLine("Войти как?    Админ   Студент   Учитель\n");
choose = Console.ReadLine();
Console.WriteLine(" ");


while (true)
{
    switch (choose)
    {
        case "admin":
            while (access == 0)
            {

                features.authorization(ref Login, ref Password);

                features.check(Login, Password, path_auth_ad, ref access);

                features.skip();

                path = path_auth_ad;

                if (access == 0)
                {
                    Console.WriteLine("Ошибка входа\n\n\n\n");
                }

            }
            break;
        case "student":
            while (access == 0)
            {

                features.authorization(ref Login, ref Password);

                features.check(Login, Password, path_auth_st, ref access);

                features.skip();

                path = path_auth_st;

                if (access == 0)
                {
                    Console.WriteLine("Ошибка входа\n\n\n\n");
                }

            }
            break;
        case "teacher":
            while (access == 0)
            {

                features.authorization(ref Login, ref Password);

                features.check(Login, Password, path_auth_te, ref access);

                features.skip();

                path = path_auth_te;

                if (access == 0)
                {
                    Console.WriteLine("Ошибка входа\n\n\n\n");
                }

            }
            break;
        default:
            Console.WriteLine("\nТакого типа нету\n");
            break;
    }

    features.check_log(Login, Password, path, ref active);

    //Console.WriteLine(active);

    while (active != "exit")
    {
        features.journal_see(path_journal, ref journal_inf);

        switch (active)
        {
            case "admin":
                Console.WriteLine("Успешный вход");
                admin.start_info(ref active, ref act);

                switch (act)
                {
                    case "viev":
                        admin.Viev(path_journal, path_student, path_teacher, ref journal_inf);
                        break;
                    case "change":
                        admin.Change(path_journal, path_student, path_teacher);
                        break;
                    case "del":
                        admin.Del(path_journal, path_student, path_auth_st, path_teacher, path_auth_te, ref journal_inf);
                        break;
                    case "add":
                        admin.Add(path_journal, path_student, path_teacher, ref journal_inf, Login);
                        break;
                    case "ex":
                        active = "exit";
                        break;
                }
                goto case "final_ad";
            case "student":
                Console.WriteLine("Успешный вход");
                student.st_info(path_journal, ref journal_inf, ref active, Login, path_student);
                goto case "final_st";
            case "teacher":
                Console.WriteLine("Успешный вход");
                prepod.te_info(path_journal, ref active, Login, journal_inf, path_teacher, path_student);
                goto case "final_te";
            case "final_ad":
                active = "admin";
                goto case "admin";
            case "final_st":
                active = "student";
                goto case "student";
            case "final_te":
                active = "teacher";
                goto case "teacher";
            default:
                Console.WriteLine("Ошибка. Выход из системы");
                active = "exit";
                break;
        }

    }

}
