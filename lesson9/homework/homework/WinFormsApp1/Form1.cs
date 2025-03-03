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
                MessageBox.Show($"������ ��� ������ � �����: {ex.Message}\n{ex.InnerException?.Message}");
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

        // ����� ��� ���������� DataGridView
        private void UpdateDataGridView() {
            try {
                var employees = db.Groups.ToList();

                // ������������� DataSource ��� DataGridView
                dataGridView1.DataSource = employees;
            }
            catch (Exception ex) {
                MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}