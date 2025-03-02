namespace homework
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            comboBoxDepartment = new ComboBox();
            button1 = new Button();
            textBoxPosition = new TextBox();
            textBoxPhone = new TextBox();
            textBoxEmail = new TextBox();
            textBoxDateOfBirth = new TextBox();
            textBoxAge = new TextBox();
            textBoxLastName = new TextBox();
            textBoxFirstName = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            buttonDeleteEmploye = new Button();
            textBoxEmailToDelete = new TextBox();
            label12 = new Label();
            groupBox3 = new GroupBox();
            textBoxDepartmentToEdit = new ComboBox();
            buttonEditEmploye = new Button();
            textBoxPositionToEdit = new TextBox();
            textBoxPhoneToEdit = new TextBox();
            textBoxEmailToEdit = new TextBox();
            textBoxDateOfBirthToEdit = new TextBox();
            textBoxAgeToEdit = new TextBox();
            textBoxLastNameToEdit = new TextBox();
            textBoxFirstNameToEdit = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            iTPersonalContextBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iTPersonalContextBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxDepartment);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBoxPosition);
            groupBox1.Controls.Add(textBoxPhone);
            groupBox1.Controls.Add(textBoxEmail);
            groupBox1.Controls.Add(textBoxDateOfBirth);
            groupBox1.Controls.Add(textBoxAge);
            groupBox1.Controls.Add(textBoxLastName);
            groupBox1.Controls.Add(textBoxFirstName);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(295, 290);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавление";
            // 
            // comboBoxDepartment
            // 
            comboBoxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepartment.FormattingEnabled = true;
            comboBoxDepartment.Location = new Point(149, 215);
            comboBoxDepartment.Name = "comboBoxDepartment";
            comboBoxDepartment.Size = new Size(137, 23);
            comboBoxDepartment.TabIndex = 18;
            // 
            // button1
            // 
            button1.Location = new Point(6, 258);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 17;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxPosition
            // 
            textBoxPosition.Location = new Point(149, 161);
            textBoxPosition.Name = "textBoxPosition";
            textBoxPosition.Size = new Size(137, 23);
            textBoxPosition.TabIndex = 15;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(149, 107);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(137, 23);
            textBoxPhone.TabIndex = 14;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(149, 53);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(137, 23);
            textBoxEmail.TabIndex = 13;
            // 
            // textBoxDateOfBirth
            // 
            textBoxDateOfBirth.Location = new Point(6, 215);
            textBoxDateOfBirth.Name = "textBoxDateOfBirth";
            textBoxDateOfBirth.Size = new Size(137, 23);
            textBoxDateOfBirth.TabIndex = 12;
            // 
            // textBoxAge
            // 
            textBoxAge.Location = new Point(6, 161);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(137, 23);
            textBoxAge.TabIndex = 11;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(6, 107);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(137, 23);
            textBoxLastName.TabIndex = 10;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(6, 53);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(137, 23);
            textBoxFirstName.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(149, 197);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 8;
            label8.Text = "Deportment:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(149, 143);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 7;
            label7.Text = "Position:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(149, 89);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 6;
            label6.Text = "Phone:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(149, 35);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 5;
            label5.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 197);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 4;
            label4.Text = "DateOfBirth:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 143);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 3;
            label3.Text = "Age:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 89);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "LastName:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 1;
            label1.Text = "FirstName:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonDeleteEmploye);
            groupBox2.Controls.Add(textBoxEmailToDelete);
            groupBox2.Controls.Add(label12);
            groupBox2.Location = new Point(313, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(153, 119);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Удаление";
            // 
            // buttonDeleteEmploye
            // 
            buttonDeleteEmploye.Location = new Point(6, 89);
            buttonDeleteEmploye.Name = "buttonDeleteEmploye";
            buttonDeleteEmploye.Size = new Size(75, 23);
            buttonDeleteEmploye.TabIndex = 17;
            buttonDeleteEmploye.Text = "Удалить";
            buttonDeleteEmploye.UseVisualStyleBackColor = true;
            buttonDeleteEmploye.Click += buttonDeleteEmploye_Click;
            // 
            // textBoxEmailToDelete
            // 
            textBoxEmailToDelete.Location = new Point(6, 53);
            textBoxEmailToDelete.Name = "textBoxEmailToDelete";
            textBoxEmailToDelete.Size = new Size(137, 23);
            textBoxEmailToDelete.TabIndex = 13;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 35);
            label12.Name = "label12";
            label12.Size = new Size(39, 15);
            label12.TabIndex = 5;
            label12.Text = "Email:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxDepartmentToEdit);
            groupBox3.Controls.Add(buttonEditEmploye);
            groupBox3.Controls.Add(textBoxPositionToEdit);
            groupBox3.Controls.Add(textBoxPhoneToEdit);
            groupBox3.Controls.Add(textBoxEmailToEdit);
            groupBox3.Controls.Add(textBoxDateOfBirthToEdit);
            groupBox3.Controls.Add(textBoxAgeToEdit);
            groupBox3.Controls.Add(textBoxLastNameToEdit);
            groupBox3.Controls.Add(textBoxFirstNameToEdit);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label17);
            groupBox3.Location = new Point(472, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(295, 290);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Редактирование";
            // 
            // textBoxDepartmentToEdit
            // 
            textBoxDepartmentToEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxDepartmentToEdit.FormattingEnabled = true;
            textBoxDepartmentToEdit.Location = new Point(149, 215);
            textBoxDepartmentToEdit.Name = "textBoxDepartmentToEdit";
            textBoxDepartmentToEdit.Size = new Size(137, 23);
            textBoxDepartmentToEdit.TabIndex = 18;
            // 
            // buttonEditEmploye
            // 
            buttonEditEmploye.Location = new Point(6, 258);
            buttonEditEmploye.Name = "buttonEditEmploye";
            buttonEditEmploye.Size = new Size(113, 23);
            buttonEditEmploye.TabIndex = 17;
            buttonEditEmploye.Text = "Редактировать";
            buttonEditEmploye.UseVisualStyleBackColor = true;
            buttonEditEmploye.Click += buttonEditEmploye_Click;
            // 
            // textBoxPositionToEdit
            // 
            textBoxPositionToEdit.Location = new Point(149, 161);
            textBoxPositionToEdit.Name = "textBoxPositionToEdit";
            textBoxPositionToEdit.Size = new Size(137, 23);
            textBoxPositionToEdit.TabIndex = 15;
            // 
            // textBoxPhoneToEdit
            // 
            textBoxPhoneToEdit.Location = new Point(149, 107);
            textBoxPhoneToEdit.Name = "textBoxPhoneToEdit";
            textBoxPhoneToEdit.Size = new Size(137, 23);
            textBoxPhoneToEdit.TabIndex = 14;
            // 
            // textBoxEmailToEdit
            // 
            textBoxEmailToEdit.Location = new Point(149, 53);
            textBoxEmailToEdit.Name = "textBoxEmailToEdit";
            textBoxEmailToEdit.Size = new Size(137, 23);
            textBoxEmailToEdit.TabIndex = 13;
            // 
            // textBoxDateOfBirthToEdit
            // 
            textBoxDateOfBirthToEdit.Location = new Point(6, 215);
            textBoxDateOfBirthToEdit.Name = "textBoxDateOfBirthToEdit";
            textBoxDateOfBirthToEdit.Size = new Size(137, 23);
            textBoxDateOfBirthToEdit.TabIndex = 12;
            // 
            // textBoxAgeToEdit
            // 
            textBoxAgeToEdit.Location = new Point(6, 161);
            textBoxAgeToEdit.Name = "textBoxAgeToEdit";
            textBoxAgeToEdit.Size = new Size(137, 23);
            textBoxAgeToEdit.TabIndex = 11;
            // 
            // textBoxLastNameToEdit
            // 
            textBoxLastNameToEdit.Location = new Point(6, 107);
            textBoxLastNameToEdit.Name = "textBoxLastNameToEdit";
            textBoxLastNameToEdit.Size = new Size(137, 23);
            textBoxLastNameToEdit.TabIndex = 10;
            // 
            // textBoxFirstNameToEdit
            // 
            textBoxFirstNameToEdit.Location = new Point(6, 53);
            textBoxFirstNameToEdit.Name = "textBoxFirstNameToEdit";
            textBoxFirstNameToEdit.Size = new Size(137, 23);
            textBoxFirstNameToEdit.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(149, 197);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 8;
            label9.Text = "Department:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(149, 143);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 7;
            label10.Text = "Position:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(149, 89);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 6;
            label11.Text = "Phone:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(149, 35);
            label13.Name = "label13";
            label13.Size = new Size(39, 15);
            label13.TabIndex = 5;
            label13.Text = "Email:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 197);
            label14.Name = "label14";
            label14.Size = new Size(72, 15);
            label14.TabIndex = 4;
            label14.Text = "DateOfBirth:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 143);
            label15.Name = "label15";
            label15.Size = new Size(31, 15);
            label15.TabIndex = 3;
            label15.Text = "Age:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 89);
            label16.Name = "label16";
            label16.Size = new Size(63, 15);
            label16.TabIndex = 2;
            label16.Text = "LastName:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 35);
            label17.Name = "label17";
            label17.Size = new Size(64, 15);
            label17.TabIndex = 1;
            label17.Text = "FirstName:";
            // 
            // iTPersonalContextBindingSource
            // 
            iTPersonalContextBindingSource.DataSource = typeof(ITPersonnelDBLibrary.ITPersonalContext);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 308);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(755, 150);
            dataGridView1.TabIndex = 20;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 582);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ITCompanyDB";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iTPersonalContextBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxFirstName;
        private Label label8;
        private TextBox textBoxLastName;
        private Button button1;
        private TextBox textBoxPosition;
        private TextBox textBoxPhone;
        private TextBox textBoxEmail;
        private TextBox textBoxDateOfBirth;
        private TextBox textBoxAge;
        private ComboBox comboBoxDepartment;
        private GroupBox groupBox2;
        private Button buttonDeleteEmploye;
        private TextBox textBoxEmailToDelete;
        private Label label12;
        private GroupBox groupBox3;
        private ComboBox textBoxDepartmentToEdit;
        private Button buttonEditEmploye;
        private TextBox textBoxPositionToEdit;
        private TextBox textBoxPhoneToEdit;
        private TextBox textBoxEmailToEdit;
        private TextBox textBoxDateOfBirthToEdit;
        private TextBox textBoxAgeToEdit;
        private TextBox textBoxLastNameToEdit;
        private TextBox textBoxFirstNameToEdit;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private BindingSource iTPersonalContextBindingSource;
        private DataGridView dataGridView1;
    }
}
