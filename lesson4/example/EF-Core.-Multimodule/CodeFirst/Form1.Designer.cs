
namespace CodeFirst
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
            groupBox2 = new System.Windows.Forms.GroupBox();
            textBoxGr = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            button6 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            comboBoxStudent = new System.Windows.Forms.ComboBox();
            textBoxAverage = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBoxAge = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBoxLastName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBoxFirstName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            comboBoxGroup = new System.Windows.Forms.ComboBox();
            textBoxGroup = new System.Windows.Forms.TextBox();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxGr);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(comboBoxStudent);
            groupBox2.Controls.Add(textBoxAverage);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBoxAge);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBoxLastName);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxFirstName);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new System.Drawing.Point(226, 14);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(405, 175);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Студенты";
            // 
            // textBoxGr
            // 
            textBoxGr.Location = new System.Drawing.Point(103, 152);
            textBoxGr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxGr.Name = "textBoxGr";
            textBoxGr.ReadOnly = true;
            textBoxGr.Size = new System.Drawing.Size(142, 23);
            textBoxGr.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 157);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(49, 15);
            label5.TabIndex = 12;
            label5.Text = "Группа:";
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(252, 118);
            button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(141, 27);
            button6.TabIndex = 11;
            button6.Text = "Изменить";
            button6.UseVisualStyleBackColor = true;
            button6.Click += EditStudentClick;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(251, 85);
            button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(141, 27);
            button5.TabIndex = 10;
            button5.Text = "Удалить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += RemoveStudentClick;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(251, 53);
            button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(141, 27);
            button4.TabIndex = 9;
            button4.Text = "Добавить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += AddStudentClick;
            // 
            // comboBoxStudent
            // 
            comboBoxStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxStudent.FormattingEnabled = true;
            comboBoxStudent.Location = new System.Drawing.Point(251, 21);
            comboBoxStudent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBoxStudent.Name = "comboBoxStudent";
            comboBoxStudent.Size = new System.Drawing.Size(140, 23);
            comboBoxStudent.TabIndex = 8;
            comboBoxStudent.SelectedIndexChanged += comboBoxStudent_SelectedIndexChanged;
            // 
            // textBoxAverage
            // 
            textBoxAverage.Location = new System.Drawing.Point(103, 120);
            textBoxAverage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxAverage.Name = "textBoxAverage";
            textBoxAverage.Size = new System.Drawing.Size(142, 23);
            textBoxAverage.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 125);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(88, 15);
            label3.TabIndex = 6;
            label3.Text = "Средний балл:";
            // 
            // textBoxAge
            // 
            textBoxAge.Location = new System.Drawing.Point(103, 87);
            textBoxAge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new System.Drawing.Size(142, 23);
            textBoxAge.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(9, 89);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(53, 15);
            label4.TabIndex = 4;
            label4.Text = "Возраст:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new System.Drawing.Point(102, 54);
            textBoxLastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new System.Drawing.Size(142, 23);
            textBoxLastName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 57);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 15);
            label2.TabIndex = 2;
            label2.Text = "Фамилия:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new System.Drawing.Point(102, 22);
            textBoxFirstName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new System.Drawing.Size(142, 23);
            textBoxFirstName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 23);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Имя:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(comboBoxGroup);
            groupBox1.Controls.Add(textBoxGroup);
            groupBox1.Location = new System.Drawing.Point(14, 14);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(186, 175);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Группы";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(8, 143);
            button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(141, 27);
            button3.TabIndex = 4;
            button3.Text = "Изменить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += EditGroupClick;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(8, 112);
            button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(141, 27);
            button2.TabIndex = 3;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += RemoveGroupClick;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(7, 81);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(141, 27);
            button1.TabIndex = 1;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddGroupClick;
            // 
            // comboBoxGroup
            // 
            comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxGroup.FormattingEnabled = true;
            comboBoxGroup.Location = new System.Drawing.Point(8, 51);
            comboBoxGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBoxGroup.Name = "comboBoxGroup";
            comboBoxGroup.Size = new System.Drawing.Size(140, 23);
            comboBoxGroup.TabIndex = 2;
            comboBoxGroup.SelectedIndexChanged += comboBoxGroup_SelectedIndexChanged;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new System.Drawing.Point(7, 22);
            textBoxGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new System.Drawing.Size(142, 23);
            textBoxGroup.TabIndex = 0;
            textBoxGroup.TextChanged += textBoxGroup_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(651, 203);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Академическая группа";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxGr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.TextBox textBoxAverage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.TextBox textBoxGroup;
    }
}

