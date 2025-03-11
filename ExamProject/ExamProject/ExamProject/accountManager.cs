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