using CollegeRegistrationApp.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CollegeRegistrationApp.StudentControls
{
    public partial class UserControl1 : UserControl


    {

        private string student_id = "";
        private DBConnection connection;
        public UserControl1(string input, DBConnection input_connection)
        {
            InitializeComponent();
            connection= input_connection;
            student_id = input;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            label8.Text= student_id;
            string query = "SELECT * FROM Student Where Student_ID= " + student_id;
            SqlDataReader? studentData = connection.GetDataReader(query);
            if (studentData != null && studentData.HasRows)
            {
                studentData.Read();
                string name = studentData["First_Name"].ToString() + " " + studentData["Last_Name"].ToString();
                label1.Text = name;
                if (studentData["Unit_Number"].ToString() == "NULL")
                {
                    textBox1.Text = "";

                }
                else
                {
                    textBox1.Text = studentData["Unit_Number"].ToString();
                }
                textBox2.Text = studentData["Street_Number"].ToString();
                textBox7.Text = studentData["Street_Address"].ToString();
                textBox3.Text = studentData["City"].ToString();
                textBox4.Text = studentData["State"].ToString();
                textBox5.Text = studentData["Zip_Code"].ToString();
                textBox6.Text = studentData["Phone"].ToString();

                
            }
            studentData.Close();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)


        {
            string unitnumber = textBox1.Text;
            string streetnumber = textBox2.Text;
            string streetadd = textBox7.Text;
            string city = textBox3.Text;
            string state = textBox4.Text;
            string zip = textBox5.Text;
            string phone = textBox6.Text;
            

            List<String> infoList = new List<String>();
            infoList.Add(streetnumber);
            infoList.Add(streetadd);
            infoList.Add(city);
            infoList.Add(state);
            infoList.Add(zip);
            infoList.Add(phone);

            

            if (infoList.Contains(""))
                {
                MessageBox.Show("All * fields must be filled");
                return;

            }
            else
            {
                infoList.Add(unitnumber);
                if (infoList.Contains(""))
                {
                    unitnumber = null;
                }
                
            }

           

            string update_student =
                "UPDATE Student SET " +
                $"Unit_Number = {unitnumber}, " +
                $"Street_Number = {streetnumber} " +
                $"Street_Address ={streetadd} " +
                $"City = {city} " +
                $"State = {state} " +
                $"Zip_Code = {zip} " +
                $"Phone = {phone} " +
                $"WHERE Student_ID = {student_id}";

            int row_updated = connection.ExecuteMutation(update_student);
            if (row_updated == 1)
            {
                MessageBox.Show("Successfully updated info");
                
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
