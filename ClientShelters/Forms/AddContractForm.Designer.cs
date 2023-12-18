namespace ClientShelters.Forms
{
    partial class AddContractForm
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
            label1 = new Label();
            CostBox = new TextBox();
            label2 = new Label();
            DateStartPicker = new DateTimePicker();
            DateEndPicker = new DateTimePicker();
            label3 = new Label();
            label5 = new Label();
            ShelterCombo = new ComboBox();
            AcceptButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 46);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 0;
            label1.Text = "Стоимость:";
            // 
            // CostBox
            // 
            CostBox.Location = new Point(228, 39);
            CostBox.Name = "CostBox";
            CostBox.Size = new Size(250, 27);
            CostBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 92);
            label2.Name = "label2";
            label2.Size = new Size(164, 20);
            label2.TabIndex = 2;
            label2.Text = "Дата начала действия:";
            // 
            // DateStartPicker
            // 
            DateStartPicker.Location = new Point(228, 85);
            DateStartPicker.Name = "DateStartPicker";
            DateStartPicker.Size = new Size(250, 27);
            DateStartPicker.TabIndex = 3;
            // 
            // DateEndPicker
            // 
            DateEndPicker.Location = new Point(228, 138);
            DateEndPicker.Name = "DateEndPicker";
            DateEndPicker.Size = new Size(250, 27);
            DateEndPicker.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(157, 20);
            label3.TabIndex = 5;
            label3.Text = "Дата конца действия:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 202);
            label5.Name = "label5";
            label5.Size = new Size(59, 20);
            label5.TabIndex = 8;
            label5.Text = "Приют:";
            // 
            // ShelterCombo
            // 
            ShelterCombo.FormattingEnabled = true;
            ShelterCombo.Location = new Point(228, 194);
            ShelterCombo.Name = "ShelterCombo";
            ShelterCombo.Size = new Size(250, 28);
            ShelterCombo.TabIndex = 9;
            // 
            // AcceptButton
            // 
            AcceptButton.DialogResult = DialogResult.OK;
            AcceptButton.Location = new Point(12, 255);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(217, 29);
            AcceptButton.TabIndex = 10;
            AcceptButton.Text = "Принять";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(261, 255);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(217, 29);
            CancelButton.TabIndex = 11;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // AddContractForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 312);
            Controls.Add(CancelButton);
            Controls.Add(AcceptButton);
            Controls.Add(ShelterCombo);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(DateEndPicker);
            Controls.Add(DateStartPicker);
            Controls.Add(label2);
            Controls.Add(CostBox);
            Controls.Add(label1);
            Name = "AddContractForm";
            Text = "Добавить контракт";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox CostBox;
        private Label label2;
        private DateTimePicker DateStartPicker;
        private DateTimePicker DateEndPicker;
        private Label label3;
        private Label label5;
        private ComboBox ShelterCombo;
        private Button AcceptButton;
        private Button CancelButton;
    }
}