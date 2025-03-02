namespace homework {
    partial class Form3 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            button2 = new Button();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(52, 108);
            button2.Name = "button2";
            button2.Size = new Size(141, 23);
            button2.TabIndex = 12;
            button2.Text = "Зарегистрироваться ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(82, 75);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(138, 23);
            textBoxPassword.TabIndex = 11;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(82, 46);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(138, 23);
            textBoxLogin.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 79);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 9;
            label3.Text = "Пароль:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 50);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 8;
            label2.Text = "Логин:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 7;
            label1.Text = "Регистрация";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 143);
            Controls.Add(button2);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}