using ClientShelters.Controllers;
using ClientShelters.Forms;
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
        List<int> ides = new List<int>();
        private int currentPage = 1;
        readonly User user;
        readonly AnimalController animalController = new AnimalController();
        readonly ShelterController shelterController = new ShelterController();
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
            UserBox.Text = $"{user.Surname} {user.Name} {user.LastName}";
            ChangeAvailability(shelterController.GetShelters(user, 100).Item1);
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
            AddShelter();
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
            UpdateShelterGrid();
        }

        private void UpdateShelterGrid()
        {
            DataGridAllClear();
            ides.Clear();
            ides.Add(0);
            ides.Add(0);
            NextPage.Enabled = true;
            PerviousPage.Enabled = false;
            currentPage = 1;

            var res = shelterController.GetShelters(user, 2, ides.Last());
            ides.Add(res.Item1.Last().Id_Shelter);
            Page.Text = $"{currentPage}/{res.Item2}";
            UploadDataGrid(res.Item1);
        }

        private void ReportClick(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SheltersComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
                        dataGridView.Rows[j].Cells[i].Value = props[i].Item1.GetValue(item).ToString();
                    }
                }
                j++;
            }
        }

        private void ChangeAvailability(List<Shelter> sheltsForComboBox)
        {
            NextPage.Enabled = false;
            PerviousPage.Enabled = false;
            var roles = user.Roles;

            if (roles.Contains("Админ"))
            {
                FillShelterComboBox(sheltsForComboBox);
                //AddButton.Enabled = true;
                //UpdateButton.Enabled = true;
                //DeleteButton.Enabled = true;
            }

        }

        private void FillShelterComboBox(List<Shelter> shelts)
        {
            SheltersComboBox.Enabled = true;

            SheltersComboBox.DataSource = shelts.Select(p => new KeyValuePair<int, string>(p.Id_Shelter, $"{p.OrgType} \"{p.Name}\"")).ToList();
            SheltersComboBox.DisplayMember = "Value";
            SheltersComboBox.ValueMember = "Key";
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            DataGridAllClear();

            var res = shelterController.GetShelters(user, 2, ides.Last());
            UploadDataGrid(res.Item1);
            ides.Add(res.Item1.Last().Id_Shelter);
            currentPage++;
            Page.Text = $"{currentPage}/{res.Item2}";
            if (currentPage == res.Item2)
            {
                NextPage.Enabled = false;
                PerviousPage.Enabled = true;
            }
            else
            {
                NextPage.Enabled = true;
                PerviousPage.Enabled = true;
            }
        }


        private void PerviousPage_Click(object sender, EventArgs e)
        {
            DataGridAllClear();
            ides.RemoveAt(ides.Count() - 1);
            var res = shelterController.GetShelters(user, 2, ides.IndexOf(ides.Count() - 2));
            UploadDataGrid(res.Item1);
            currentPage--;
            Page.Text = $"{currentPage}/{res.Item2}";
            if (currentPage == 1)
            {
                PerviousPage.Enabled = false;
                NextPage.Enabled = true;
            }
            else
            {
                PerviousPage.Enabled = true;
                NextPage.Enabled = true;
            }
        }

        private void DataGridAllClear()
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteShelter();
        }

        void DeleteShelter()
        {
            shelterController.DeleteShelter(user, int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()));
            UpdateShelterGrid();
        }

        void AddShelter()
        {
            var addForm = new AddShelterForm(user);
            addForm.ShowDialog();
            UpdateShelterGrid();
        }
    }
}
