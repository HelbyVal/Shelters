namespace ClientShelters.Forms
{
    partial class AddShelterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AcceptButton = new Button();
            CancelButton = new Button();
            NameBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            INNBox = new TextBox();
            KPP = new Label();
            KPPBox = new TextBox();
            OrgTypeBox = new TextBox();
            label3 = new Label();
            CityComboBox = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // AcceptButton
            // 
            AcceptButton.DialogResult = DialogResult.OK;
            AcceptButton.Location = new Point(43, 330);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(178, 29);
            AcceptButton.TabIndex = 0;
            AcceptButton.Text = "Принять";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(284, 330);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(178, 29);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(284, 61);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(178, 27);
            NameBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 68);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 3;
            label1.Text = "Название приюта:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 118);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 4;
            label2.Text = "ИНН:";
            // 
            // INNBox
            // 
            INNBox.Location = new Point(284, 111);
            INNBox.Name = "INNBox";
            INNBox.Size = new Size(178, 27);
            INNBox.TabIndex = 5;
            // 
            // KPP
            // 
            KPP.AutoSize = true;
            KPP.Location = new Point(43, 168);
            KPP.Name = "KPP";
            KPP.Size = new Size(43, 20);
            KPP.TabIndex = 6;
            KPP.Text = "КПП:";
            // 
            // KPPBox
            // 
            KPPBox.Location = new Point(284, 161);
            KPPBox.Name = "KPPBox";
            KPPBox.Size = new Size(178, 27);
            KPPBox.TabIndex = 7;
            // 
            // OrgTypeBox
            // 
            OrgTypeBox.Location = new Point(284, 210);
            OrgTypeBox.Name = "OrgTypeBox";
            OrgTypeBox.Size = new Size(178, 27);
            OrgTypeBox.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 217);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 9;
            label3.Text = "Тип организации:";
            // 
            // CityComboBox
            // 
            CityComboBox.FormattingEnabled = true;
            CityComboBox.Location = new Point(284, 265);
            CityComboBox.Name = "CityComboBox";
            CityComboBox.Size = new Size(178, 28);
            CityComboBox.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 273);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 11;
            label4.Text = "Город:";
            // 
            // AddShelterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 400);
            Controls.Add(label4);
            Controls.Add(CityComboBox);
            Controls.Add(label3);
            Controls.Add(OrgTypeBox);
            Controls.Add(KPPBox);
            Controls.Add(KPP);
            Controls.Add(INNBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NameBox);
            Controls.Add(CancelButton);
            Controls.Add(AcceptButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddShelterForm";
            Text = "Добавить приют";
            Load += AddShelterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AcceptButton;
        private Button CancelButton;
        private TextBox NameBox;
        private Label label1;
        private Label label2;
        private TextBox INNBox;
        private Label KPP;
        private TextBox KPPBox;
        private TextBox OrgTypeBox;
        private Label label3;
        private ComboBox CityComboBox;
        private Label label4;
    }
}