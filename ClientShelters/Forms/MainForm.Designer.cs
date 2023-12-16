namespace ClientShelters
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            contextMenuStrip3 = new ContextMenuStrip(components);
            dataGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            выйтиИзАккаунтаToolStripMenuItem = new ToolStripMenuItem();
            RegsMenu = new ToolStripMenuItem();
            AnimalRegMenu = new ToolStripMenuItem();
            ContractRegMenu = new ToolStripMenuItem();
            SheltersRegMenu = new ToolStripMenuItem();
            ReportMenu = new ToolStripMenuItem();
            AddButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
            NextPage = new Button();
            PerviousPage = new Button();
            label1 = new Label();
            Page = new Label();
            label2 = new Label();
            UserBox = new TextBox();
            panel1 = new Panel();
            SheltersComboBox = new ComboBox();
            label3 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.ImageScalingSize = new Size(20, 20);
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(61, 4);
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 31);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(831, 575);
            dataGridView.TabIndex = 3;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { выйтиИзАккаунтаToolStripMenuItem, RegsMenu, ReportMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1256, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // выйтиИзАккаунтаToolStripMenuItem
            // 
            выйтиИзАккаунтаToolStripMenuItem.Name = "выйтиИзАккаунтаToolStripMenuItem";
            выйтиИзАккаунтаToolStripMenuItem.Size = new Size(151, 24);
            выйтиИзАккаунтаToolStripMenuItem.Text = "Выйти из аккаунта";
            выйтиИзАккаунтаToolStripMenuItem.Click += выйтиИзАккаунтаToolStripMenuItem_Click;
            // 
            // RegsMenu
            // 
            RegsMenu.DropDownItems.AddRange(new ToolStripItem[] { AnimalRegMenu, ContractRegMenu, SheltersRegMenu });
            RegsMenu.Name = "RegsMenu";
            RegsMenu.Size = new Size(80, 24);
            RegsMenu.Text = "Реестры";
            // 
            // AnimalRegMenu
            // 
            AnimalRegMenu.Name = "AnimalRegMenu";
            AnimalRegMenu.Size = new Size(166, 26);
            AnimalRegMenu.Text = "Животные";
            AnimalRegMenu.Click += AnimalRegClick;
            // 
            // ContractRegMenu
            // 
            ContractRegMenu.Name = "ContractRegMenu";
            ContractRegMenu.Size = new Size(166, 26);
            ContractRegMenu.Text = "Контракты";
            ContractRegMenu.Click += ContractsRegClick;
            // 
            // SheltersRegMenu
            // 
            SheltersRegMenu.Name = "SheltersRegMenu";
            SheltersRegMenu.Size = new Size(166, 26);
            SheltersRegMenu.Text = "Приюты";
            SheltersRegMenu.Click += SheltersRegClick;
            // 
            // ReportMenu
            // 
            ReportMenu.Name = "ReportMenu";
            ReportMenu.Size = new Size(73, 24);
            ReportMenu.Text = "Отчёты";
            ReportMenu.Click += ReportClick;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(0, 612);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(94, 29);
            AddButton.TabIndex = 5;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(100, 612);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(94, 29);
            UpdateButton.TabIndex = 6;
            UpdateButton.Text = "Изменить";
            UpdateButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(200, 612);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(94, 29);
            DeleteButton.TabIndex = 7;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // NextPage
            // 
            NextPage.Location = new Point(800, 612);
            NextPage.Name = "NextPage";
            NextPage.Size = new Size(31, 29);
            NextPage.TabIndex = 8;
            NextPage.Text = ">";
            NextPage.UseVisualStyleBackColor = true;
            NextPage.Click += NextPage_Click;
            // 
            // PerviousPage
            // 
            PerviousPage.Location = new Point(763, 612);
            PerviousPage.Name = "PerviousPage";
            PerviousPage.Size = new Size(31, 29);
            PerviousPage.TabIndex = 9;
            PerviousPage.Text = "<";
            PerviousPage.UseVisualStyleBackColor = true;
            PerviousPage.Click += PerviousPage_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(620, 616);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 10;
            label1.Text = "Страница:";
            // 
            // Page
            // 
            Page.AutoSize = true;
            Page.Location = new Point(714, 616);
            Page.Name = "Page";
            Page.Size = new Size(31, 20);
            Page.TabIndex = 11;
            Page.Text = "0/0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 18);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 12;
            label2.Text = "Пользователь:";
            // 
            // UserBox
            // 
            UserBox.Enabled = false;
            UserBox.Location = new Point(122, 15);
            UserBox.Name = "UserBox";
            UserBox.ReadOnly = true;
            UserBox.Size = new Size(284, 27);
            UserBox.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.Controls.Add(SheltersComboBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(UserBox);
            panel1.Location = new Point(837, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(419, 98);
            panel1.TabIndex = 14;
            // 
            // SheltersComboBox
            // 
            SheltersComboBox.FormattingEnabled = true;
            SheltersComboBox.Location = new Point(120, 51);
            SheltersComboBox.Name = "SheltersComboBox";
            SheltersComboBox.Size = new Size(287, 28);
            SheltersComboBox.TabIndex = 15;
            SheltersComboBox.SelectedIndexChanged += SheltersComboBox_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 54);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 14;
            label3.Text = "Приют:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 731);
            Controls.Add(panel1);
            Controls.Add(Page);
            Controls.Add(label1);
            Controls.Add(PerviousPage);
            Controls.Add(NextPage);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(AddButton);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = " Главная";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ContextMenuStrip contextMenuStrip3;
        private DataGridView dataGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem выйтиИзАккаунтаToolStripMenuItem;
        private ToolStripMenuItem RegsMenu;
        private ToolStripMenuItem AnimalRegMenu;
        private ToolStripMenuItem ReportMenu;
        private ToolStripMenuItem ContractRegMenu;
        private ToolStripMenuItem SheltersRegMenu;
        private Button AddButton;
        private Button UpdateButton;
        private Button DeleteButton;
        private Button NextPage;
        private Button PerviousPage;
        private Label label1;
        private Label Page;
        private Label label2;
        private TextBox UserBox;
        private Panel panel1;
        private ComboBox SheltersComboBox;
        private Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}