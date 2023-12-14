using ClientShelters.Controllers;
using ClientShelters.Models;

namespace ClientShelters
{
    public partial class LoginForm : Form
    {
        User? currentUser;
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
            User user = controller.LogIn(LoginBox.Text, PasswordBox.Text);
            currentUser = user;
            var mainForm = new MainForm(currentUser);
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