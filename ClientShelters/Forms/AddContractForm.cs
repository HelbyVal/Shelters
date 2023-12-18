using ClientShelters.Controllers;
using ClientShelters.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientShelters.Forms
{
    public partial class AddContractForm : Form
    {
        ShelterController shelterController = new ShelterController();
        ContractController contractController = new ContractController();
        User user;
        Contract contract;

        int conId = 0;

        public AddContractForm(User user,
                               int id_contr,
                               double costPerDay,
                               DateOnly startDate,
                               DateOnly endDate
                                )
        {
            InitializeComponent();
            this.user = user;
            FillShelterComboBox(shelterController.GetShelters(user, 100, 0).Item1);
            ShelterCombo.Enabled = false;

            CostBox.Text = costPerDay.ToString();
            DateStartPicker.Value = startDate.ToDateTime(new TimeOnly());
            DateEndPicker.Value = endDate.ToDateTime(new TimeOnly());
            conId = id_contr; 


        }

        public AddContractForm(User user)
        {
            InitializeComponent();
            this.user = user;
            FillShelterComboBox(shelterController.GetShelters(user, 100, 0).Item1);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (CostBox.Text == "")
            {
                MessageBox.Show("Поле стоимости не должно быть пустым");
            }
            else
            {
                Contract contr = new Contract()
                {
                    Number = conId,
                    CostPerDay = Convert.ToDouble(CostBox.Text),
                    StartDate = DateOnly.FromDateTime(DateStartPicker.Value),
                    EndDate = DateOnly.FromDateTime(DateEndPicker.Value),
                    Id_Shelter = int.Parse(ShelterCombo.SelectedValue.ToString())
                };
                contract = contr;
                Close();
            }

        }
        public Contract GetContract()
        {
            return contract;
        }

        private void FillShelterComboBox(List<Shelter> shelts)
        {
            ShelterCombo.Enabled = true;

            ShelterCombo.DataSource = shelts.Select(p => new KeyValuePair<int, string>(p.Id_Shelter, $"{p.OrgType} \"{p.Name}\"")).ToList();
            ShelterCombo.DisplayMember = "Value";
            ShelterCombo.ValueMember = "Key";
        }

        private void CityCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
