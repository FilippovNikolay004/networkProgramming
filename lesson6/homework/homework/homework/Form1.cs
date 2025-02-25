using Microsoft.EntityFrameworkCore;

namespace homework
{
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();

            LoadTables();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            listView1.View = View.Details;
        }


        private void LoadTables() {
            using (var context = new LibraryContext()) {
                var entityTypes = context.Model.GetEntityTypes();

                comboBox1.Items.Clear();

                foreach (var entityType in entityTypes) {
                    comboBox1.Items.Add(entityType.GetTableName());
                }

                if (comboBox1.Items.Count > 0) {
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            ShowTableInfo(comboBox1.SelectedItem.ToString());
        }

        private void ShowTableInfo(string tableName) {
            using (var context = new LibraryContext()) {
                listView1.Items.Clear();
                listView1.Columns.Clear();

                var entityType = context.Model.GetEntityTypes()
                    .FirstOrDefault(e => e.GetTableName() == tableName);

                if (entityType == null) {
                    // Очищаем ListView и выводим сообщение в нем
                    listView1.Columns.Add("Сообщение");
                    ListViewItem item = new ListViewItem($"Таблица '{tableName}' не найдена.");
                    listView1.Items.Add(item);
                    return;
                }

                foreach (var property in entityType.GetProperties()) {
                    listView1.Columns.Add(property.Name);
                }

                switch (tableName) {
                case "Authors":
                    foreach (var author in context.Authors) {
                        var item = new ListViewItem(author.Id.ToString());
                        item.SubItems.Add(author.Name);
                        listView1.Items.Add(item);
                    }
                    break;
                case "Books":
                    foreach (var book in context.Books) {
                        var item = new ListViewItem(book.Id.ToString());
                        item.SubItems.Add(book.Name);
                        item.SubItems.Add(book.Id.ToString());
                        listView1.Items.Add(item);
                    }
                    break;
                case "Groups":
                    foreach (var group in context.Groups) {
                        var item = new ListViewItem(group.Id.ToString());
                        item.SubItems.Add(group.Name);
                        item.SubItems.Add(group.Count.ToString());
                        listView1.Items.Add(item);
                    }
                    break;
                case "Students":
                    foreach (var student in context.Students) {
                        var item = new ListViewItem(student.Id.ToString());
                        item.SubItems.Add(student.Name);
                        item.SubItems.Add(student.Age.ToString());
                        item.SubItems.Add(student.IdGroups.ToString());
                        listView1.Items.Add(item);
                    }
                    break;
                case "Temp":
                    foreach (var temp in context.Temps) {
                        var item = new ListViewItem(temp.AuthorsId.ToString());
                        item.SubItems.Add(temp.BooksId.ToString());
                        listView1.Items.Add(item);
                    }
                    break;
                default:
                    // Очищаем ListView и выводим сообщение в нем
                    listView1.Columns.Add("Сообщение");
                    ListViewItem errorItem = new ListViewItem($"Неизвестная таблица: {tableName}");
                    listView1.Items.Add(errorItem);
                    return;
                }
                // Вывод количества записей в ListView
                listView1.Items.Add(new ListViewItem($"Количество записей: {listView1.Items.Count}"));
            }
        }
    }
}
