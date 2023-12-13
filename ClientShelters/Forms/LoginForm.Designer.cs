namespace ClientShelters
{
    partial class LoginForm
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
        private void InitializeComponent()
        {
            LoginBox = new TextBox();
            PasswordBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ViewPassword = new Button();
            Enter = new Button();
            SuspendLayout();
            // 
            // LoginBox
            // 
            LoginBox.Location = new Point(33, 70);
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(171, 27);
            LoginBox.TabIndex = 0;
            LoginBox.TextChanged += LoginBox_TextChanged;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(34, 167);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.PasswordChar = '*';
            PasswordBox.Size = new Size(170, 27);
            PasswordBox.TabIndex = 1;
            PasswordBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(34, 30);
            label1.Name = "label1";
            label1.Size = new Size(81, 32);
            label1.TabIndex = 2;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(34, 132);
            label2.Name = "label2";
            label2.Size = new Size(96, 32);
            label2.TabIndex = 3;
            label2.Text = "Пароль";
            // 
            // ViewPassword
            // 
            ViewPassword.Location = new Point(210, 166);
            ViewPassword.Name = "ViewPassword";
            ViewPassword.Size = new Size(38, 28);
            ViewPassword.TabIndex = 4;
            ViewPassword.Text = "👁";
            ViewPassword.UseVisualStyleBackColor = true;
            ViewPassword.Click += ShowPaaswordClick;
            // 
            // Enter
            // 
            Enter.Location = new Point(33, 229);
            Enter.Name = "Enter";
            Enter.Size = new Size(215, 29);
            Enter.TabIndex = 5;
            Enter.Text = "Войти";
            Enter.UseVisualStyleBackColor = true;
            Enter.Click += EnterClick;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 281);
            Controls.Add(Enter);
            Controls.Add(ViewPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordBox);
            Controls.Add(LoginBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginBox;
        private TextBox PasswordBox;
        private Label label1;
        private Label label2;
        private Button ViewPassword;
        private Button Enter;
    }
}