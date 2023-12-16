using ClientShelters.Controllers;
using ClientShelters.Models;

namespace ClientShelters.Forms
{
    public partial class AddShelterForm : Form
    {
        User user;
        ShelterController shelterController = new ShelterController();
        internal AddShelterForm(User user)
        {
            InitializeComponent();
            this.user = user;
            FillCityComboBox(shelterController.GetCities(user));
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
                    Name = NameBox.Text,
                    INN = INNBox.Text,
                    KPP = KPPBox.Text,
                    OrgType = OrgTypeBox.Text,
                    Id_City = int.Parse(CityComboBox.SelectedValue.ToString())
                };
                if (!shelterController.AddShelter(user, result))
                    throw new Exception("Сервер не может обработать корректно введеные данные! Возможно, есть повторяющиеся данные.");
                
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
    }
}
