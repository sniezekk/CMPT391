using System.Data;
using System.Data.SqlClient;
using CollegeRegistrationApp.SQL;

namespace CollegeRegistrationApp
{
    public partial class LoginForm : Form
    {


        DBConnection connection;
        public LoginForm(DBConnection input_connection)
        {
            InitializeComponent();
            connection = input_connection;
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
                new AdminMainForm(connection).ShowDialog();
            }else if (accountTextInput.Text =="")
            {
                MessageBox.Show("Enter valid id");
            }
            else
            {
                
                string student_ID = accountTextInput.Text;
               
                string query = $"select Student_ID from Student where Student_ID = {student_ID}";
                SqlDataReader? custdata = connection.GetDataReader(query);
                if(custdata != null && custdata.HasRows) 
                {
                    
                    custdata.Read();
                    string ID = custdata["Student_ID"].ToString();
                    custdata.Close();
                    accountTextInput.Text = "";
                    passwordTextInput.Text = "";
                    new StudentMainForm(ID,connection).ShowDialog();
                }
                else 
                {
                    MessageBox.Show("Enter valid id");
                }
            }
            
        }
    }
}