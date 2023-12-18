using ClientShelters.Controllers;
using ClientShelters.Models;

namespace ClientShelters.Forms
{
    public partial class AddShelterForm : Form
    {
        ShelterController shelterController = new ShelterController();
        Shelter? shelt;
        int idShelt = 0;
        internal AddShelterForm(User user)
        {
            InitializeComponent();
            FillCityComboBox(shelterController.GetCities(user));
        }

        internal AddShelterForm(User user,
                                int id_Shelter,
                                int id_City,
                                string Name,
                                string OrgType,
                                string KPP,
                                string INN)
        {
            InitializeComponent();
            FillCityComboBox(shelterController.GetCities(user));
            CityComboBox.Enabled = false;
            idShelt = id_Shelter;
            NameBox.Text = Name;
            OrgTypeBox.Text = OrgType;
            INNBox.Text = INN;
            KPPBox.Text = KPP;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CityComboBox.Text == "")
                {
                    throw new Exception("Не заполнен город");
                }

                var result = new Shelter()
                {
                    Id_Shelter = idShelt,
                    Name = NameBox.Text,
                    INN = INNBox.Text,
                    KPP = KPPBox.Text,
                    OrgType = OrgTypeBox.Text,
                    Id_City = int.Parse(CityComboBox.SelectedValue.ToString())
                };
                shelt = result;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddShelterForm_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillCityComboBox(List<City> cities)
        {
            CityComboBox.Enabled = true;

            CityComboBox.DataSource = cities.Select(p => new KeyValuePair<int, string>(p.Id_City, p.Name)).ToList();
            CityComboBox.DisplayMember = "Value";
            CityComboBox.ValueMember = "Key";
        }

        public Shelter ReturnShelter()
        {
            return shelt;
        }
    }
}
