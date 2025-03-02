using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITPersonnelDBLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using logger;

namespace homework
{
    public partial class Form3 :Form {
        private ITPersonalContext db;
        Logger logger = new Logger("logger.txt");

        public Form3() {
            InitializeComponent();

            try {
                db = new ITPersonalContext();
            } catch (Exception ex) {
                MessageBox.Show($"Ошибка при работе с базой: {ex.Message}\n{ex.InnerException?.Message}");
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (login.Length == 0 || password.Length == 0) {
                MessageBox.Show("Вы заполнили не все поля!", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                if (db.Users.Any(u => u.Login == login)) {
                    MessageBox.Show("Логин уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Users newUser = new Users {
                    Login = login,
                    Password = password
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                logger.Log($"Была выполнена регистрация в: {DateTime.Now}. Новый пользователь: {login}\n");
            } catch (Exception ex) {
                MessageBox.Show($"Ошибка при работе с базой: {ex.Message}\n{ex.InnerException?.Message}");
            }
        }
    }
}
