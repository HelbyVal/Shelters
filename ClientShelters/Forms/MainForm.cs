using ClientShelters.Controllers;
using ClientShelters.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClientShelters
{
    public partial class MainForm : Form
    {
        readonly User user;
        readonly AnimalController animalController = new AnimalController();
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
            UserBox.Text = $"{user.Surname} {user.Name} {user.LastName}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void животныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void AnimalRegClick(object sender, EventArgs e)
        {
            UploadDataGrid(animalController.GetAnimals(user,
                                           "",
                                           "",
                                           -1,
                                           "",
                                           -1,
                                           0,
                                           1));
        }

        private void ContractsRegClick(object sender, EventArgs e)
        {

        }

        private void SheltersRegClick(object sender, EventArgs e)
        {

        }

        private void ReportClick(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UploadDataGrid<T>(List<T> data) where T : IMyModel
        {
            Type t = typeof(T);
            var props = t.GetProperties()
                .Select(proper => (proper, proper.GetCustomAttributes(false)))
                .ToList();
            foreach (var prop in props)
            {
                if (prop.Item2.Count() != 0)
                {
                    var attr = prop.Item2.FirstOrDefault();
                    if (attr is NameAttribute nameAttribute)
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.Name = prop.proper.Name.ToString() + "Column";
                        column.HeaderText = nameAttribute.Name;
                        dataGridView.Columns.Add(column);
                    }
                }
            }
            if (data.Count > 0)
            {
                EnterDataToGrid(data, props);
            }

        }

        private void EnterDataToGrid<T>(List<T> data, List<(PropertyInfo, object[])> props) where T : IMyModel
        {
            int j = 0;
            foreach (var item in data)
            {
                dataGridView.Rows.Add();
                for (int i = 0; i < props.Count(); i++)
                {
                    var attr = props[i].Item2.FirstOrDefault();
                    if (attr is NameAttribute nameAttribute)
                    {
                        if (dataGridView.Columns[i].Name == nameAttribute.Name)
                        {
                            dataGridView.Rows[j].Cells[i].Value = props[i].Item1.GetValue(item).ToString();
                        }
                    }
                }
                j++;
            }
        }

        //private void ChangeVisible()
        //{
        //    var roles = user.Roles;

        //    if (roles.Contains("Админ"))
        //    {
        //        AddButton.Enabled = true;
        //        UpdateButton.Enabled = true;
        //        DeleteButton.Enabled = true;
        //        Reg
        //    }

        //        return;
        //    if (roles.Contains("Опера"))
        //}
    }
}
