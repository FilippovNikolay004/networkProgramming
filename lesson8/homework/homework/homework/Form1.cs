using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ITPersonnelDBLibrary;
using logger;

namespace homework {
    public partial class Form1 :Form {
        Dictionary<string, string> users = new Dictionary<string, string> { };
        private ITPersonalContext db;
        Logger logger = new Logger("logger.txt");

        public Form1() {
            InitializeComponent();

            try {
                db = new ITPersonalContext();
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка при работе с базой: {ex.Message}\n{ex.InnerException?.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                // Получить значения таблицы Users
                users = db.Users.ToDictionary(d => d.Login, d => d.Password);

                string login = textBoxLogin.Text.Trim();
                string password = textBoxPassword.Text.Trim();

                if (!users.ContainsKey(login) || !(users[login] == password) || !db.Users.Any()) {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Log($"Был выполнен неверный логин и пароль: {DateTime.Now}. Введённый логин: {login}\n");
                    return;
                }

                MessageBox.Show("Доступ разрешен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                logger.Log($"Был выполнен вход в: {DateTime.Now}. Пользователем: {login}\n");

                Form2 form2 = new Form2(login);
                form2.ShowDialog();
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка при работе с базой: {ex.Message}\n{ex.InnerException?.Message}");
            }
        }
    }
}