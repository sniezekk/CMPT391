using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CollegeRegistrationApp.SQL;

namespace CollegeRegistrationApp
{
    public partial class AdminMainForm : Form
    {
        private DBConnection connection;
        public AdminMainForm(DBConnection input_connection)
        {
            connection = input_connection;
            InitializeComponent();
            LoadInstructorDeptBox();
        }
        /*
        private void LoadInstructorBox()
        {
            string query1 = $"select First_Name, Last_Name from dbo.WHinstructor";
            SqlDataReader? instructorData = connection.GetDataReader(query1);

            if (instructorData != null && instructorData.HasRows)
            {
                while (instructorData.Read())
                {
                    comboBox1.Items.Add(instructorData["Dept_Name"].ToString());
                }

                instructorData.Close();
            }

        }*/

        private void LoadInstructorDeptBox()
        {
            string query2 = $"select distinct Dept from dbo.WHinstructor";
            SqlDataReader? instructorDeptData = connection.GetDataReader(query2);

            if (instructorDeptData != null && instructorDeptData.HasRows)
            {
                while (instructorDeptData.Read())
                {
                    comboBox5.Items.Add(instructorDeptData["Dept"].ToString());
                }

                instructorDeptData.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
