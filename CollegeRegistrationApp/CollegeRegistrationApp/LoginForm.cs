using System.Data;
using System.Data.SqlClient;

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
        readonly String connectionString = "Server = localhost; Database = CollegeRegistration; Trusted_Connection = yes;";
        private void loginButton_Click(object sender, EventArgs e)

        {
           
            SqlConnection connstring = new SqlConnection(connectionString);
            string query = "Select * from Student Where Student_ID = '" + accountTextInput.Text + "'";
            

            if (accountTextInput.Text.StartsWith("E"))
            {
                new AdminMainForm().ShowDialog();
            }else if (accountTextInput.Text =="")
            {
                MessageBox.Show("Enter valid id");
            }
            else
            {
                SqlDataAdapter adap = new SqlDataAdapter(query, connstring);
                DataTable dtb = new DataTable();
                adap.Fill(dtb);
                if(dtb.Rows.Count == 1) 
                {
                    new StudentMainForm().ShowDialog();
                }
                else 
                {
                    MessageBox.Show("Enter valid id");
                }
            }
            
        }
    }
}