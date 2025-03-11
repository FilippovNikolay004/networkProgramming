using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accountManager {
    public class User {
        public static int CountUsers = 0;

        public int Id { get; set; } = 0;
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User() : this(null, null, null) {}
        public User(string login, string password, string email) {
            Id = CountUsers++;
            Login = login;
            Password = password;
            Email = email;
        }
        public User(int startId, string login, string password, string email) {
            Id = CountUsers = startId;
            CountUsers++;
            Login = login;
            Password = password;
            Email = email;
        }
    }

    internal class AccountManager {
        List<User> Users = new List<User>();
        readonly string _NAMEFILE;
        readonly string _PATH;
        readonly string _FULLFILEPATH;
        private readonly Dictionary<string, int> FieldPositions = new Dictionary<string, int> {
            { "ID", 1 },
            { "LOGIN", 3 },
            { "PASSWORD", 5 },
            { "EMAIL", 7 }
        };
        private readonly DbContext db;

        public AccountManager() : this(null, null) {}
        public AccountManager(string nameFile, string path) {
            _NAMEFILE = nameFile != null ? nameFile : "users.txt";
            _PATH = path != null ? path : Directory.GetCurrentDirectory();

            _FULLFILEPATH = $@"{_PATH}\{_NAMEFILE}";
            LoadUsersFromFile(_FULLFILEPATH); 
        }
        
        public AccountManager(DbContext dbContext) {
            db = dbContext;
        }


        // Ввод данных
        public bool InputRegisterData() {
            string login = CorrectEnter("Создайте логин", "Создайте логин!");
            string email = CorrectEnter("Введите почту", "Введите почту!");
            string password = CorrectEnter("Создайте пароль", "Создайте пароль!", true);

            if (Register(login, password, email)) {
                Console.WriteLine("Регистрация прошла успешно!");
                return true;
            }

            Console.WriteLine("Произошла ошибка регистрации!");
            return false;
        }
        public bool InputLoginData() {
            string login = CorrectEnter("Введите логин", "Введите логин!");
            string password = CorrectEnter("Введите пароль", "Введите пароль!", true);

            if (Login(login, password)) {
                Console.WriteLine("Авторизация прошла успешно!");
                return true;
            }

            Console.WriteLine("Неверный логин или пароль!");
            return false;
        }
        public bool InputChangePasswordData() {
            string login = CorrectEnter("Введите логин", "Введите логин!");
            string password = CorrectEnter("Введите старый пароль", "Введите старый пароль!", true);
            
            if (!Login(login, password)) {
                Console.WriteLine("Неверный логин или пароль!");
                return false;
            }

            string newPassword = CorrectEnter("Введите новый пароль", "Введите новый пароль!", true);

            if (ChangePassword(login, password, newPassword)) {
                Console.WriteLine("Пароль успешно изменён!");
                return true;
            }

            Console.WriteLine("Произошла ошибка!");
            return false;
        }


        // Проверка на корректность ввода данных
        public static string CorrectEnter(string msg, string msgError, bool hideEnter = false) {
            string input = string.Empty;
            bool isNext = false;

            do {
                Console.Write($"{msg}: ");
                if (!hideEnter)
                    input = Console.ReadLine();
                else
                    input = WritePassword();

                isNext = input == null || input.Length == 0;

                if (isNext) { Console.WriteLine($"{msgError}\n"); }
            } while (isNext);

            return input;
        }
        public static int CorrectEnterDate(string msg, string msgError, int maxValue) {
            bool isNext = false;
            int input = 0;

            do {
                Console.Write($"{msg}: ");
                input = int.Parse(Console.ReadLine());

                isNext = input.ToString().Length == 0 || input < 1 || input > maxValue;

                if (isNext) {
                    Console.WriteLine($"{msgError}\n");
                }
            } while (isNext);

            return input;
        }


        // Аутентификация
        public bool Register(string login, string password, string email) {
            for (int i = 0; i < Users.Count; i++) {
                if (Users[i].Login == login || Users[i].Email == email) {
                    Console.WriteLine("A user with this username or email already exists");
                    return false; 
                }
            }

            Users.Add(new User(login, password, email));
            SaveUsersToFile(_FULLFILEPATH);
            return true;
        }
        public bool Login(string login, string password) {
            for (int i = 0; i < Users.Count; i++) 
                if (Users[i].Login == login && Users[i].Password == password) 
                    return true;
            
            return false;
        }


        // Работа с файлами
        private void SaveUsersToFile(string PATH) {
            FileStream fs = new FileStream(PATH, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine($"ID: {Users.Last().Id}, " +
                $"LOGIN: {Users.Last().Login}, " +
                $"PASSWORD: {Users.Last().Password}, " +
                $"EMAIL: {Users.Last().Email}");

            sw.Close();
            fs.Close();
        }
        private void LoadUsersFromFile(string PATH) {
            FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = string.Empty;
            while (!sr.EndOfStream) {
                line = sr.ReadLine();
                string[] tempData = line.Replace(",", "").Split(' ');

                if (line.Length == 0) { continue; }

                Users.Add(new User(
                    int.Parse(tempData[FieldPositions["ID"]]),
                    tempData[FieldPositions["LOGIN"]],
                    tempData[FieldPositions["PASSWORD"]],
                    tempData[FieldPositions["EMAIL"]] 
                ));
            }

            sr.Close();
            fs.Close();
        }
        private void ChangeUsersInFile(string PATH) {
            PATH = $@"{_PATH}\usersTemp.txt";

            FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            foreach (User user in Users) {
                sw.WriteLine($"ID: {user.Id}, " +
                $"LOGIN: {user.Login}, " +
                $"PASSWORD: {user.Password}, " +
                $"EMAIL: {user.Email}");
            }

            sw.Close();
            fs.Close();

            File.Delete(_FULLFILEPATH);
            File.Move(PATH, _FULLFILEPATH);
        }


        // Работа с БД
        private void SaveUsersToDataBase() {

        }
        private void LoadUsersFromDataBase() {

        }


        // Вывод
        /*
         * PrintColumn - должен адаптироваться под список
         */
        private string PrintColumn() {
            return $"{"ID", -5}{"LOGIN", -10}{"PASSWORD", -10}";
        }
        public string PrintData() {
            string result = PrintColumn() + "\n";
            for (int i = 0; i < Users.Count; i++) { result += PrintUserId(i) + "\n"; }
            return result;
        }
        private string PrintUserId(int i) {
            return $"{Users[i].Id, -5}{Users[i].Login, -10}{Users[i].Password, -10}";
        }


        // Поиск
        public void SearchUser(string login) {
            int index = GetIndexByLogin(login);
            if (index != -1) {
                Console.WriteLine($"{PrintColumn()}\n{PrintUserId(index)}"); 
                return; 
            }

            Console.WriteLine("User not found");
        }
        public bool UserExists(string login) {
            int index = GetIndexByLogin(login);
            if (index == -1) return false;
            return true;
        }
        private int GetIndexByLogin(string login) {
            for (int i = 0; i < Users.Count; i++)
                if (Users[i].Login == login) return i;
            return -1;
        }


        // Изменение данных
        public bool ChangePassword(string login, string oldPassword, string newPassword) {
            int index = GetIndexByLogin(login);
            
            if (index == -1) { return false; }
            if (!Login(login, oldPassword)) { Console.WriteLine("Invalid login or password entered!"); return false; }
        
            Users[index].Password = newPassword;

            ChangeUsersInFile(_PATH);

            return true;
        }

        // Скрытый ввод пароля
        private static string WritePassword() {
            string password = string.Empty;
            ConsoleKeyInfo key;

            do {
                // Не отображает вводимые символы
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace && password.Length > 0) {
                    // Удаление символа из пароля
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b"); // Удаляет символ в консоли
                } else if (!char.IsControl(key.KeyChar)) {
                    // Добавление символа в пароль
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter); // Завершение ввода по Enter
            Console.WriteLine();

            return password;
        }
    }
}