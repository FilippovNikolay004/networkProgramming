using ITPersonnelDBLibrary;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace homework {
    public partial class Form1 :Form {
        Dictionary<int, string> departmentsDict = new Dictionary<int, string> { };
        ITPersonalContext db;
        int idForEdit = -1;

        public Form1() {
            InitializeComponent();

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

                // �������� �������� � id Departments
                departmentsDict = db.Departments.ToDictionary(d => d.Id, d => d.DepartmentName);

                foreach (var item in departmentsDict) {
                    comboBoxDepartment.Items.Add(item.Value);
                    textBoxDepartmentToEdit.Items.Add(item.Value);
                }
                comboBoxDepartment.SelectedIndex = 0;
            }
            catch (Exception ex) {
                MessageBox.Show($"������ ��� ������ � �����: {ex.Message}\n{ex.InnerException?.Message}");
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
                MessageBox.Show("�� ��������� �� ��� ����!", "������ ����������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                dateOfBirth = DateTime.ParseExact(textBoxDateOfBirth.Text.Trim(), "yyyy.mm.dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch {
                MessageBox.Show("�������� ������ ����. ����������� ������ ����.��.��.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try {
                string departmentName = comboBoxDepartment.Text.Trim();
                var department = db.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);

                if (department == null) {
                    MessageBox.Show($"����� '{departmentName}' �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show("������ ������� ���������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                if (ex.InnerException != null) {
                    MessageBox.Show($"��������� ������: {ex.InnerException.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UpdateDataGridView();
        }

        private void buttonDeleteEmploye_Click(object sender, EventArgs e) {
            string emailToDelete = textBoxEmailToDelete.Text.Trim();

            if (emailToDelete.Length == 0) {
                MessageBox.Show("�� �� ��������� ����!", "������ ����������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                var employeeToDelete = db.Employees.FirstOrDefault(e => e.Email == emailToDelete);

                if (employeeToDelete != null) {
                    DialogResult result = MessageBox.Show($"��������� � ������ '{emailToDelete}' ������. �� ����� ������ ��� �������?", "������������� ��������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes) {
                        db.Employees.Remove(employeeToDelete);
                        db.SaveChanges();
                        MessageBox.Show("��������� ������� ������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else {
                    MessageBox.Show($"��������� � ������ '{emailToDelete}' �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateDataGridView();
        }

        private void buttonEditEmploye_Click(object sender, EventArgs e) {
            if (idForEdit != -1) {
                try {
                    var employee = db.Employees.Find(idForEdit);

                    if (employee != null) {
                        // ��������� ������ ����������
                        employee.FirstName = textBoxFirstNameToEdit.Text.Trim();
                        employee.LastName = textBoxLastNameToEdit.Text.Trim();
                        employee.Age = int.Parse(textBoxAgeToEdit.Text.Trim());
                        employee.DateOfBirth = DateTime.ParseExact(textBoxDateOfBirthToEdit.Text.Trim(), "yyyy.MM.dd", System.Globalization.CultureInfo.InvariantCulture);
                        employee.Email = textBoxEmailToEdit.Text.Trim();
                        employee.Phone = textBoxPhoneToEdit.Text.Trim();
                        employee.Position = textBoxPositionToEdit.Text.Trim();

                        // �������� DepartmentId �� DepartmentName
                        string departmentName = textBoxDepartmentToEdit.SelectedItem.ToString();
                        var department = db.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
                        if (department != null) {
                            employee.DepartmentId = department;
                        }

                        db.SaveChanges();
                        MessageBox.Show("������ ���������� ������� ���������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("��������� �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("�������� ���������� ��� ��������������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateDataGridView();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            buttonEditEmploye.Enabled = true;

            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            idForEdit = int.Parse(selectedRow.Cells["Id"].Value.ToString());

            textBoxFirstNameToEdit.Text = selectedRow.Cells["FirstName"].Value.ToString();
            textBoxLastNameToEdit.Text = selectedRow.Cells["LastName"].Value.ToString();
            textBoxAgeToEdit.Text = selectedRow.Cells["Age"].Value.ToString();
            
            // ����������� ������ ����
            DateTime dateOfBirth = DateTime.Parse(selectedRow.Cells["DateOfBirth"].Value.ToString());
            textBoxDateOfBirthToEdit.Text = dateOfBirth.ToString("yyyy.mm.dd");

            textBoxEmailToDelete.Text = textBoxEmailToEdit.Text = selectedRow.Cells["Email"].Value.ToString();
            textBoxPhoneToEdit.Text = selectedRow.Cells["Phone"].Value.ToString();
            textBoxPositionToEdit.Text = selectedRow.Cells["Position"].Value.ToString();

            // ������� ������ DepartmentName � ComboBox
            string departmentName = selectedRow.Cells["DepartmentName"].Value.ToString();
            int index = textBoxDepartmentToEdit.Items.IndexOf(departmentName);
            textBoxDepartmentToEdit.SelectedIndex = index;
        }

        // ����� ��� ���������� DataGridView
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
                    DepartmentName = e.DepartmentId.DepartmentName // �������� DepartmentName
                })
                .ToList();

                // ������������� DataSource ��� DataGridView
                dataGridView1.DataSource = employees;
            }
            catch (Exception ex) {
                MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}