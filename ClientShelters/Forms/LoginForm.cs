using ClientShelters.Controllers;
using ClientShelters.Models;

namespace ClientShelters
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void EnterClick(object sender, EventArgs e)
        {
                var controller = new AuthController();
                User user = User.ToUser(controller.LogIn(LoginBox.Text, PasswordBox.Text).Result);
                AuthController.CurrentUser = user;
                var mainForm = new MainForm();
                if (mainForm.ShowDialog() == DialogResult.Cancel)
                {
                    Close();
                }
        }

        private void ShowPaaswordClick(object sender, EventArgs e)
        {

        }

        private void LoginBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}