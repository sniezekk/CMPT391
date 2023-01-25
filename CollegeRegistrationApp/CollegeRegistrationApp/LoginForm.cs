namespace CollegeRegistrationApp
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

        private void accountTextInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (accountTextInput.Text.StartsWith("E"))
            {
                new AdminMainForm().ShowDialog();
            }
            else
            {
                new StudentMainForm().ShowDialog();
            }
        }
    }
}