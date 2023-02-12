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

namespace CollegeRegistrationApp.StudentControls
{
    public partial class UserControl2 : UserControl
    {
        private string student_id = "";
        private DBConnection connection;
        public UserControl2(string input, DBConnection input_connection)
        {
            InitializeComponent();
            connection = input_connection;
            student_id = input;

            loadCurrentlyEnrolled();
        }

        private void loadCurrentlyEnrolled()
        {
            int currentYear = DateTime.Now.Year;
            string query1 = $"execute dbo.getEnrolledClasses {student_id}, 1, {currentYear}";
            MessageBox.Show(query1);
            SqlDataReader? eClasses = connection.GetDataReader(query1);
            if (eClasses != null && eClasses.HasRows)
            {
                dataGridView1.Rows.Clear();
                while (eClasses.Read())
                {
                    dataGridView1.Rows.Add(
                        eClasses["Course_Name"].ToString(),
                        eClasses["Section_ID"].ToString(),
                        eClasses["Semester"].ToString(),
                        eClasses["year"].ToString(),
                        eClasses["Room_ID"].ToString(),
                        eClasses["Day"].ToString(),
                        eClasses["time_start"].ToString(),
                        eClasses["time_end"].ToString()
                        );
                }
                if (eClasses != null)
                {
                    eClasses.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
