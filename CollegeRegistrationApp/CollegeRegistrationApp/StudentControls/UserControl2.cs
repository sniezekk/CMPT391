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
using System.Xml.Serialization;

namespace CollegeRegistrationApp.StudentControls
{
    public partial class UserControl2 : UserControl
    {
        private string student_id = "";
        private DBConnection connection;

        List<string> cart = new List<string>();
        public UserControl2(string input, DBConnection input_connection, List<string> C1)
        {
            InitializeComponent();
            connection = input_connection;
            student_id = input;
            loadCurrentlyEnrolled();
            cart = C1;
            loadCart();
            //MessageBox.Show(cart.Count.ToString());
        }

        private void loadCurrentlyEnrolled()
        {
            int currentYear = DateTime.Now.Year;
            string query1 = $"execute dbo.getEnrolledClasses {student_id}, 1, {currentYear}";
            //MessageBox.Show(query1);
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

        private void loadCart()
        {
            if (cart.Count != 0)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    string query2 = $"select * from secCourTimeTable where Section_ID = {cart[i]}";
                    SqlDataReader? eCart = connection.GetDataReader(query2);
                    if (eCart != null && eCart.HasRows)
                    {
                        while (eCart.Read())
                        {
                            dataGridView2.Rows.Add(
                                eCart["Course_Id"].ToString(),
                                eCart["Course_Name"].ToString(),
                                eCart["Section_ID"].ToString(),
                                eCart["Semester"].ToString(),
                                eCart["year"].ToString(),
                                eCart["Room_ID"].ToString(),
                                eCart["Day"].ToString(),
                                eCart["time_start"].ToString(),
                                eCart["time_end"].ToString()
                                );
                        }
                        if (eCart != null)
                        {
                            eCart.Close();
                        }
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //refresh button
            dataGridView2.Rows.Clear();
            loadCart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //empty button
            cart.Clear(); 
            dataGridView2.Rows.Clear();
            loadCart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //enroll button

            //get selected row
            int selected = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selected];
            if (row != null)
            {
                String sectionNumber = row.Cells[2].Value.ToString();
                String semester = row.Cells[3].Value.ToString();
                String year = row.Cells[4].Value.ToString();
                String courseId = row.Cells[0].Value.ToString();

                String returnVal = connection.ExecuteRegisterProcedureWithReturn(
                    student_id,
                    courseId,
                    sectionNumber,
                    year,
                    semester
                    );
                MessageBox.Show(returnVal);

            }


            loadCurrentlyEnrolled();
        }
    }
}

