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
            ShelterFilters = new GroupBox();
            IsCityNeedCheck = new CheckBox();
            IsShelterNeedCheck = new CheckBox();
            label8 = new Label();
            KPPBox = new TextBox();
            INNBox = new TextBox();
            label7 = new Label();
            label6 = new Label();
            NameShelterBox = new TextBox();
            label5 = new Label();
            OrgTypeBox = new TextBox();
            label4 = new Label();
            CityComboBox = new ComboBox();
            EnterFilters = new Button();
            CancelFilters = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ShelterFilters.SuspendLayout();
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
            menuStrip1.Size = new Size(1266, 28);
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
            UpdateButton.Click += UpdateButton_Click;
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
            // ShelterFilters
            // 
            ShelterFilters.Controls.Add(IsCityNeedCheck);
            ShelterFilters.Controls.Add(IsShelterNeedCheck);
            ShelterFilters.Controls.Add(label8);
            ShelterFilters.Controls.Add(KPPBox);
            ShelterFilters.Controls.Add(INNBox);
            ShelterFilters.Controls.Add(label7);
            ShelterFilters.Controls.Add(label6);
            ShelterFilters.Controls.Add(NameShelterBox);
            ShelterFilters.Controls.Add(label5);
            ShelterFilters.Controls.Add(OrgTypeBox);
            ShelterFilters.Controls.Add(label4);
            ShelterFilters.Controls.Add(CityComboBox);
            ShelterFilters.Location = new Point(837, 140);
            ShelterFilters.Name = "ShelterFilters";
            ShelterFilters.Size = new Size(419, 466);
            ShelterFilters.TabIndex = 15;
            ShelterFilters.TabStop = false;
            ShelterFilters.Text = "Фильтры для приютов";
            ShelterFilters.Visible = false;
            // 
            // IsCityNeedCheck
            // 
            IsCityNeedCheck.AutoSize = true;
            IsCityNeedCheck.Location = new Point(253, 373);
            IsCityNeedCheck.Name = "IsCityNeedCheck";
            IsCityNeedCheck.Size = new Size(156, 24);
            IsCityNeedCheck.TabIndex = 12;
            IsCityNeedCheck.Text = "Учитывать город?";
            IsCityNeedCheck.UseVisualStyleBackColor = true;
            // 
            // IsShelterNeedCheck
            // 
            IsShelterNeedCheck.AutoSize = true;
            IsShelterNeedCheck.Location = new Point(253, 412);
            IsShelterNeedCheck.Name = "IsShelterNeedCheck";
            IsShelterNeedCheck.Size = new Size(160, 24);
            IsShelterNeedCheck.TabIndex = 11;
            IsShelterNeedCheck.Text = "Учитывать приют?";
            IsShelterNeedCheck.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 289);
            label8.Name = "label8";
            label8.Size = new Size(43, 20);
            label8.TabIndex = 10;
            label8.Text = "КПП:";
            // 
            // KPPBox
            // 
            KPPBox.Location = new Point(229, 286);
            KPPBox.Name = "KPPBox";
            KPPBox.Size = new Size(184, 27);
            KPPBox.TabIndex = 9;
            // 
            // INNBox
            // 
            INNBox.Location = new Point(229, 232);
            INNBox.Name = "INNBox";
            INNBox.Size = new Size(184, 27);
            INNBox.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 235);
            label7.Name = "label7";
            label7.Size = new Size(45, 20);
            label7.TabIndex = 7;
            label7.Text = "ИНН:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 183);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 6;
            label6.Text = "Название приюта:";
            // 
            // NameShelterBox
            // 
            NameShelterBox.Location = new Point(229, 176);
            NameShelterBox.Name = "NameShelterBox";
            NameShelterBox.Size = new Size(184, 27);
            NameShelterBox.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 119);
            label5.Name = "label5";
            label5.Size = new Size(134, 20);
            label5.TabIndex = 4;
            label5.Text = "Тип организации:";
            // 
            // OrgTypeBox
            // 
            OrgTypeBox.Location = new Point(229, 116);
            OrgTypeBox.Name = "OrgTypeBox";
            OrgTypeBox.Size = new Size(184, 27);
            OrgTypeBox.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 61);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 2;
            label4.Text = "Город:";
            // 
            // CityComboBox
            // 
            CityComboBox.FormattingEnabled = true;
            CityComboBox.Location = new Point(229, 58);
            CityComboBox.Name = "CityComboBox";
            CityComboBox.Size = new Size(184, 28);
            CityComboBox.TabIndex = 1;
            // 
            // EnterFilters
            // 
            EnterFilters.Location = new Point(1105, 612);
            EnterFilters.Name = "EnterFilters";
            EnterFilters.Size = new Size(149, 29);
            EnterFilters.TabIndex = 16;
            EnterFilters.Text = "Применить";
            EnterFilters.UseVisualStyleBackColor = true;
            EnterFilters.Visible = false;
            EnterFilters.Click += EnterFilters_Click;
            // 
            // CancelFilters
            // 
            CancelFilters.Location = new Point(948, 612);
            CancelFilters.Name = "CancelFilters";
            CancelFilters.Size = new Size(151, 29);
            CancelFilters.TabIndex = 17;
            CancelFilters.Text = "Отменть фильтры";
            CancelFilters.UseVisualStyleBackColor = true;
            CancelFilters.Visible = false;
            CancelFilters.Click += CancelFilters_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 731);
            Controls.Add(CancelFilters);
            Controls.Add(EnterFilters);
            Controls.Add(ShelterFilters);
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
            ShelterFilters.ResumeLayout(false);
            ShelterFilters.PerformLayout();
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
        private GroupBox ShelterFilters;
        private Button EnterFilters;
        private Label label5;
        private TextBox OrgTypeBox;
        private Label label4;
        private ComboBox CityComboBox;
        private Label label8;
        private TextBox KPPBox;
        private TextBox INNBox;
        private Label label7;
        private Label label6;
        private TextBox NameShelterBox;
        private Button CancelFilters;
        private CheckBox IsCityNeedCheck;
        private CheckBox IsShelterNeedCheck;
    }
}