using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using AcademicLibrary;

namespace homework {
    public partial class Form1 :Form {
        AcademicContext db;

        public Form1() {
            InitializeComponent();

            try {
                db = new AcademicContext();
            } catch (Exception ex) {
                MessageBox.Show($"Ошибка при работе с базой: {ex.Message}\n{ex.InnerException?.Message}");
            }

            UpdateDataGridView();

            buttonEditEmploye.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) {
           

            UpdateDataGridView();
        }

        private void buttonDeleteEmploye_Click(object sender, EventArgs e) {
            
            UpdateDataGridView();
        }

        private void buttonEditEmploye_Click(object sender, EventArgs e) {
            

            UpdateDataGridView();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            buttonEditEmploye.Enabled = true;
        }

        // Метод для обновления DataGridView
        private void UpdateDataGridView() {
            try {
                var employees = db.Groups.ToList();

                // Устанавливаем DataSource для DataGridView
                dataGridView1.DataSource = employees;
            }
            catch (Exception ex) {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}