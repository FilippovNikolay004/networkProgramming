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
using logger;
using Microsoft.VisualBasic.Logging;

namespace homework {
    public partial class Form2 :Form {
        Dictionary<int, string> departmentsDict = new Dictionary<int, string> { };
        ITPersonalContext db;
        int idForEdit = -1;
        string Login { get; set; }
        Logger logger = new Logger("logger.txt");

        public Form2(string login) {
            InitializeComponent();

            Login = login;

            try {
                db = new ITPersonalContext();

                if (!db.Departments.Any()) {
                    Departments d1 = new Departments { DepartmentName = "Development" };
                    Departments d2 = new Departments { DepartmentName = "Management" };
                    Departments d3 = new Departments { DepartmentName = "Data Science" };

                    db.Departments.AddRange(d1, d2, d3);
                    db.SaveChanges();

                    Employees e1 = new Employees { FirstName = "John", LastName = "Smith", Age = 28, DateOfBirth = new DateTime(1996, 05, 14), Email = "john.smith@example.com", Phone = "+1-555-1234", Position = "Software Engineer", DepartmentId = d1 };
                    Employees e2 = new Employees { FirstName = "Robert", LastName = "Wilson", Age = 35, DateOfBirth = new DateTime(1989, 11, 21), Email = "robert.wilson@example.com", Phone = "+1-555-7890", Position = "Backend Developer", DepartmentId = d1 };
                    Employees e3 = new Employees { FirstName = "Alice", LastName = "Johnson", Age = 32, DateOfBirth = new DateTime(1992, 09, 23), Email = "alice.johnson@example.com", Phone = "+1-555-5678", Position = "Project Manager", DepartmentId = d2 };
                    Employees e4 = new Employees { FirstName = "Olivia", LastName = "Martinez", Age = 29, DateOfBirth = new DateTime(1995, 03, 10), Email = "olivia.martinez@example.com", Phone = "+1-555-2345", Position = "Data Scientist", DepartmentId = d3 };

                    db.Employees.AddRange(e1, e2, e3, e4);
                    db.SaveChanges();
                }

                // Получить значения и id Departments
                departmentsDict = db.Departments.ToDictionary(d => d.Id, d => d.DepartmentName);

                foreach (var item in departmentsDict) {
                    comboBoxDepartment.Items.Add(item.Value);
                    textBoxDepartmentToEdit.Items.Add(item.Value);
                }
                comboBoxDepartment.SelectedIndex = 0;
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка при работе с базой: {ex.Message}\n{ex.InnerException?.Message}");
            }

            UpdateDataGridView();

            buttonEditEmploye.Enabled = false;
        }



        private void button1_Click(object sender, EventArgs e) {
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            int age = int.Parse(textBoxAge.Text.Trim().Length == 0 ? "0" : textBoxAge.Text.Trim());
            DateTime dateOfBirth = new DateTime();
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            string position = textBoxPosition.Text.Trim();

            if (firstName.Length == 0 || lastName.Length == 0 || age == 0 || email.Length == 0 || phone.Length == 0 || position.Length == 0) {
                MessageBox.Show("Вы заполнили не все поля!", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                dateOfBirth = DateTime.ParseExact(textBoxDateOfBirth.Text.Trim(), "yyyy.mm.dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch {
                MessageBox.Show("Неверный формат даты. Используйте формат ГГГГ.ММ.ДД.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try {
                string departmentName = comboBoxDepartment.Text.Trim();
                var department = db.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);

                if (department == null) {
                    MessageBox.Show($"Отдел '{departmentName}' не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Employees newEmployees = new Employees {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    Phone = phone,
                    Position = position,
                    DepartmentId = department
                };

                db.Employees.Add(newEmployees);
                db.SaveChanges();

                logger.Log($"Был добавлен новый сотрудник в: {DateTime.Now}. Пользователем: {Login}\n");
                MessageBox.Show("Данные успешно добавлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateDataGridView();
        }

        private void buttonDeleteEmploye_Click(object sender, EventArgs e) {
            string emailToDelete = textBoxEmailToDelete.Text.Trim();

            if (emailToDelete.Length == 0) {
                MessageBox.Show("Вы не заполнили поле!", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                var employeeToDelete = db.Employees.FirstOrDefault(e => e.Email == emailToDelete);

                if (employeeToDelete != null) {
                    DialogResult result = MessageBox.Show($"Сотрудник с почтой '{emailToDelete}' найден. Вы точно хотите его удалить?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes) {
                        db.Employees.Remove(employeeToDelete);
                        db.SaveChanges();
                        logger.Log($"Был удалён сотрудник в: {DateTime.Now}, удалённый сотрудник с почтой: {emailToDelete}. Пользователем: {Login}\n");
                        MessageBox.Show("Сотрудник успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else {
                    MessageBox.Show($"Сотрудник с почтой '{emailToDelete}' не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateDataGridView();
        }

        private void buttonEditEmploye_Click(object sender, EventArgs e) {
            if (idForEdit != -1) {
                try {
                    var employee = db.Employees.Find(idForEdit);

                    if (employee != null) {
                        // Обновляем данные сотрудника
                        employee.FirstName = textBoxFirstNameToEdit.Text.Trim();
                        employee.LastName = textBoxLastNameToEdit.Text.Trim();
                        employee.Age = int.Parse(textBoxAgeToEdit.Text.Trim());
                        employee.DateOfBirth = DateTime.ParseExact(textBoxDateOfBirthToEdit.Text.Trim(), "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture);
                        employee.Email = textBoxEmailToEdit.Text.Trim();
                        employee.Phone = textBoxPhoneToEdit.Text.Trim();
                        employee.Position = textBoxPositionToEdit.Text.Trim();

                        // Получаем DepartmentId по DepartmentName
                        string departmentName = textBoxDepartmentToEdit.SelectedItem.ToString();
                        var department = db.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
                        if (department != null) {
                            employee.DepartmentId = department;
                        }

                        db.SaveChanges();
                        logger.Log($"Данные сотрудника были изменены в: {DateTime.Now}. Пользователем: {Login}\n");
                        MessageBox.Show("Данные сотрудника успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("Сотрудник не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Выберите сотрудника для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateDataGridView();
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e) {
            buttonEditEmploye.Enabled = true;

            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            idForEdit = int.Parse(selectedRow.Cells["Id"].Value.ToString());

            textBoxFirstNameToEdit.Text = selectedRow.Cells["FirstName"].Value.ToString();
            textBoxLastNameToEdit.Text = selectedRow.Cells["LastName"].Value.ToString();
            textBoxAgeToEdit.Text = selectedRow.Cells["Age"].Value.ToString();

            // Преобразуем формат даты
            DateTime dateOfBirth = DateTime.Parse(selectedRow.Cells["DateOfBirth"].Value.ToString());
            textBoxDateOfBirthToEdit.Text = dateOfBirth.ToString("yyyy.MM.dd");

            textBoxEmailToDelete.Text = textBoxEmailToEdit.Text = selectedRow.Cells["Email"].Value.ToString();
            textBoxPhoneToEdit.Text = selectedRow.Cells["Phone"].Value.ToString();
            textBoxPositionToEdit.Text = selectedRow.Cells["Position"].Value.ToString();

            // Находим индекс DepartmentName в ComboBox
            string departmentName = selectedRow.Cells["DepartmentName"].Value.ToString();
            int index = textBoxDepartmentToEdit.Items.IndexOf(departmentName);
            textBoxDepartmentToEdit.SelectedIndex = index;
        }

        // Метод для обновления DataGridView
        private void UpdateDataGridView() {
            try {
                var employees = db.Employees
                .Select(e => new {
                    e.Id,
                    e.FirstName,
                    e.LastName,
                    e.Age,
                    e.DateOfBirth,
                    e.Email,
                    e.Phone,
                    e.Position,
                    DepartmentName = e.DepartmentId.DepartmentName // Получаем DepartmentName
                })
                .ToList();

                // Устанавливаем DataSource для DataGridView
                dataGridView1.DataSource = employees;
            }
            catch (Exception ex) {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
