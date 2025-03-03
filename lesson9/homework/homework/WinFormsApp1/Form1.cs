using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using AcademicLibrary;
using Microsoft.EntityFrameworkCore;

namespace homework {
    public partial class Form1 :Form {
        AcademicContext db;

        public Form1() {
            InitializeComponent();

            try {
                db = new AcademicContext();
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка при работе с базой: {ex.Message}\n{ex.InnerException?.Message}");
            }

            LoadTables();
        }

        private void LoadTables() {
            comboBox1.Items.AddRange(["Subjects", "Teachers", "Curators", "Faculties", "Departments", "Groups", "GroupsLectures", "Lectures", "GroupsCurators"]);
            comboBox1.SelectedIndex = 0;
            LoadDataGrid(comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show($"Выбрана таблица: {comboBox1.SelectedItem}");
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            LoadDataGrid(comboBox1.Text);
        }

        private void LoadDataGrid(string tableName) {
            dataGridView1.DataSource = null;

            if (tableName == "Subjects") {
                dataGridView1.DataSource = db.Subjects.ToList();
            } else if (tableName == "Teachers") {
                dataGridView1.DataSource = db.Teachers.ToList();
            } else if (tableName == "Curators") {
                dataGridView1.DataSource = db.Curators.ToList();
            } else if (tableName == "Faculties") {
                dataGridView1.DataSource = db.Faculties.ToList();
            } else if (tableName == "Departments") {
                dataGridView1.DataSource = db.Departments.ToList();
            } else if (tableName == "Groups") {
                dataGridView1.DataSource = db.Groups.ToList();
            } else if (tableName == "GroupsLectures") {
                dataGridView1.DataSource = db.GroupsLectures.ToList();
            } else if (tableName == "Lectures") {
                dataGridView1.DataSource = db.Lectures.ToList();
            } else if (tableName == "GroupsCurators") {
                dataGridView1.DataSource = db.GroupsCurators.ToList();
            }
        }
    }
}