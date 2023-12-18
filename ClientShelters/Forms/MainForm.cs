using ClientShelters.Controllers;
using ClientShelters.Forms;
using ClientShelters.Models;
using System.Data;
using System.Drawing.Design;
using System.Reflection;


namespace ClientShelters
{
    public partial class MainForm : Form
    {
        IController currentController;
        List<int> ides = new List<int>();
        private int currentPage = 1;
        private bool allShelters = true;
        readonly User user;
        readonly AnimalController animalController = new AnimalController();
        readonly ShelterController shelterController = new ShelterController();
        readonly ContractController contractController = new ContractController();
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
            if (currentController == shelterController)
            {
                AddShelter();
            }
            if (currentController == contractController)
            {
                AddContract();
            }
        }

        private void AnimalRegClick(object sender, EventArgs e)
        {
            currentController = animalController;
            UpdateGrid();
        }

        private void ContractsRegClick(object sender, EventArgs e)
        {
            currentController = contractController;
            ShelterFilters.Visible = false;
            ContractsFilters.Visible = true;
            EnterFilters.Visible = true;
            CancelFilters.Visible = true;
            UpdateGrid();
        }

        private void SheltersRegClick(object sender, EventArgs e)
        {
            currentController = shelterController;
            ShelterFilters.Visible = true;
            EnterFilters.Visible = true;
            CancelFilters.Visible = true;
            FillCityComboBox(shelterController.GetCities(user));
            UpdateGrid();

        }

        private void FillCityComboBox(List<City> cities)
        {
            CityComboBox.Enabled = true;

            CityComboBox.DataSource = cities.Select(p => new KeyValuePair<int, string>(p.Id_City, p.Name)).ToList();
            CityComboBox.DisplayMember = "Value";
            CityComboBox.ValueMember = "Key";
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
            if (currentController == shelterController)
            {
                t = typeof(Shelter);
            }
            if (currentController == animalController)
            {
                t = typeof(Animal);
            }
            if (currentController == contractController)
            {
                t = typeof(Contract);
            }
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
            var res = InsertNextPage(currentController, 2);
            UploadDataGrid(res.Item1);
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

        private (List<IMyModel>, int) InsertNextPage(IController controller, int pageSize)
        {
            var res = controller.GetEntities(user, pageSize, ides.Last());
            Type t = res.Item1.Last().GetType();
            var attr = t.GetCustomAttribute(typeof(Id));
            var currentAttr = (Id)attr;
            var requiredProperty = t.GetProperty(currentAttr.IdName);
            ides.Add((int)requiredProperty.GetValue(res.Item1.Last()));
            return res;
        }


        private void PerviousPage_Click(object sender, EventArgs e)
        {
            DataGridAllClear();
            ides.RemoveAt(ides.Count() - 1);
            var res = InsertPreviousPage(shelterController, 2);
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

        private (List<IMyModel>, int) InsertPreviousPage(IController controller, int pageSize)
        {
            var res = controller.GetEntities(user, pageSize, ides.IndexOf(ides.Count() - 2));
            return res;
        }

        private void DataGridAllClear()
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            currentController.DeleteEntity(user, int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()));
            UpdateGrid();
        }

        void AddShelter()
        {
            var addForm = new AddShelterForm(user);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                Shelter shelt = addForm.ReturnShelter();
                if (!shelterController.AddShelter(user, shelt))
                {
                    MessageBox.Show("Сервер не может обработать корректно введеные данные! Возможно, есть повторяющиеся данные.");
                }
                UpdateGrid();
            }
        }

        void UpdateContract()
        {
            var addForm = new AddContractForm(user,
                                              int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()),
                                              Convert.ToDouble(dataGridView.CurrentRow.Cells[1].Value.ToString()),
                                              DateOnly.FromDateTime(Convert.ToDateTime(dataGridView.CurrentRow.Cells[2].Value.ToString())),
                                              DateOnly.FromDateTime(Convert.ToDateTime(dataGridView.CurrentRow.Cells[3].Value.ToString())));
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                Contract contr = addForm.GetContract();
                if (contractController.UpadateContract(user, contr))
                {
                    MessageBox.Show("Сервер не может обработать корректно введеные данные!");
                }
                else
                {
                    UpdateGrid();
                }
            }
        }

        void UpdateShelter()
        {
            var addForm = new AddShelterForm(user,
                                             int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString()),
                                             int.Parse(dataGridView.CurrentRow.Cells[5].Value.ToString()),
                                             dataGridView.CurrentRow.Cells[1].Value.ToString(),
                                             dataGridView.CurrentRow.Cells[4].Value.ToString(),
                                             dataGridView.CurrentRow.Cells[3].Value.ToString(),
                                             dataGridView.CurrentRow.Cells[2].Value.ToString());
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                Shelter shelt = addForm.ReturnShelter();
                if (!shelterController.UpdateShelter(user, shelt))
                {
                    MessageBox.Show("Сервер не может обработать корректно введеные данные!");
                }
                else
                {
                    UpdateGrid();
                }
            }

        }

        void AddContract()
        {
            var addForm = new AddContractForm(user);
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
            {
                Contract contract = addForm.GetContract();
                if (!contractController.CreateContract(user, contract))
                {
                    MessageBox.Show("Сервер не может обработать корректно введеные данные! Возможно, есть повторяющиеся данные.");
                }
                else
                {
                    UpdateGrid();
                }
            }
        }

        private void UpdateGrid()
        {
            DataGridAllClear();
            ides.Clear();
            ides.Add(0);
            ides.Add(0);
            try
            {
                var res = InsertNextPage(currentController, 2);
                currentPage = 1;
                if (currentPage != res.Item2)
                {
                    NextPage.Enabled = true;
                    PerviousPage.Enabled = false;
                }
                else
                {
                    NextPage.Enabled = false;
                    PerviousPage.Enabled = false;
                }
                Page.Text = $"{currentPage}/{res.Item2}";
                UploadDataGrid(res.Item1);
            }
            catch (Exception)
            {
                NextPage.Enabled = false;
                PerviousPage.Enabled = false;
                Page.Text = "0/0";
            }
        }

        private void EnterFilters_Click(object sender, EventArgs e)
        {
            if (currentController == shelterController)
            {
                int idcity = -1;
                int idshelt = -1;
                if (IsShelterNeedCheck.Checked)
                {
                    idshelt = int.Parse(SheltersComboBox.SelectedValue.ToString());
                }

                if (IsCityNeedCheck.Checked)
                {
                    idcity = int.Parse(CityComboBox.SelectedValue.ToString());
                }

                shelterController.SetFilters(idcity,
                                             idshelt,
                                             OrgTypeBox.Text.ToString(),
                                             NameShelterBox.Text.ToString(),
                                             INNBox.Text.ToString(),
                                             KPPBox.Text.ToString());
            }

            if (currentController == contractController)
            {
                int idshelt = -1;
                double filtStartCost = 0;
                double filtEndCost = 0;
                int number = -1;
                if (IsSheltNeedConCheck.Checked)
                {
                    idshelt = int.Parse(SheltersComboBox.SelectedValue.ToString());
                }

                if (FiltStartCostBox.Text == "" || Convert.ToDouble(FiltStartCostBox.Text) <= 0)
                {
                    filtStartCost = 0;
                }
                else
                {
                    filtStartCost = Convert.ToDouble(FiltStartCostBox.Text);
                } 

                if (FiltEndCostBox.Text == "" || Convert.ToDouble(FiltEndCostBox.Text) <= 0)
                {
                    filtEndCost = int.MaxValue;
                }
                else
                {
                    filtEndCost = Convert.ToDouble(FiltEndCostBox.Text);
                }

                if (int.Parse(FiltNumberBox.Text) <= 1 || FiltNumberBox.Text == "")
                {
                    number = -1;
                }
                else
                {
                    number = int.Parse(FiltNumberBox.Text);
                }

                contractController.SetFilts(DateOnly.FromDateTime(FiltStartConDate.Value),
                                            DateOnly.FromDateTime(FiltEndConDate.Value),
                                            filtStartCost,
                                            filtEndCost,
                                            idshelt,
                                            number,
                                            allShelters);

            }

            UpdateGrid();
        }

        private void CancelFilters_Click(object sender, EventArgs e)
        {
            currentController.CancelFilters();
            UpdateGrid();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (currentController == shelterController)
            {
                UpdateShelter();
            }
        }
    }
}
