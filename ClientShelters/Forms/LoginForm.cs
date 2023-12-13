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
            var mainForm = new MainForm();
            if (mainForm.ShowDialog() == DialogResult.Cancel) 
            {
                Close();
            }
        }

        private void ShowPaaswordClick(object sender, EventArgs e)
        {

        }
    }
}