using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using CollegeRegistrationApp.SQL;
using System.CodeDom.Compiler;
using System.Collections;
using System.DirectoryServices;

namespace CollegeRegistrationApp.StudentControls
{
    public partial class UserControl3 : UserControl
    {
        private string student_id = "";
        private DBConnection connection;

        public UserControl3(string input, DBConnection input_connection)
        {
            InitializeComponent();
            connection = input_connection;
            student_id = input;

        }
        private void UserControl3_Load(object sender, EventArgs e)
        {
            Load_TermsMenuItems();
            Load_DepartmentMenuItems();
        }

        private void Load_TermsMenuItems()
        {
            foreach (String items in Get_Terms_For_Menu())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                comboBox1.Items.Add(items);
            }
        }

        private List<String> Get_Terms_For_Menu()
        {
            int currentYear = DateTime.Now.Year;
            int nextYear = currentYear + 1;

            List<String> terms = new List<String>();

            if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 4)
            {
                terms.Add("Winter " + currentYear);
                terms.Add("Spring " + currentYear);
                terms.Add("Summer " + currentYear);
                terms.Add("Fall " + currentYear);
            }
            else if (DateTime.Now.Month >= 5 && DateTime.Now.Month <= 6)
            {
                terms.Add("Spring " + currentYear);
                terms.Add("Summer " + currentYear);
                terms.Add("Fall " + currentYear);
                terms.Add("Winter " + nextYear);
            }
            else if (DateTime.Now.Month >= 7 && DateTime.Now.Month <= 8)
            {
                terms.Add("Summer " + currentYear);
                terms.Add("Fall " + currentYear);
                terms.Add("Winter " + nextYear);
                terms.Add("Spring " + nextYear);
            }
            else if (DateTime.Now.Month >= 9 && DateTime.Now.Month <= 12)
            {
                terms.Add("Fall " + currentYear);
                terms.Add("Winter " + nextYear);
                terms.Add("Spring " + nextYear);
                terms.Add("Summer" + nextYear);
            }
            return terms;
        }

        private void Load_DepartmentMenuItems()
        {
            string query3 = $"select Dept_Name from dbo.Department";
            SqlDataReader? deptData = connection.GetDataReader(query3);

            if (deptData != null && deptData.HasRows)
            {
                while (deptData.Read())
                {
                    comboBox2.Items.Add(deptData["Dept_Name"].ToString());
                }

                deptData.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string term = comboBox1.Text;
            string department = comboBox2.Text;
            string[] splitTerm = term.Split(' ');

            if (department != "")
            {
                string query1 = $"execute dbo.getCLasses2 '{splitTerm[0]}', {splitTerm[1]}, '{department}'";
                //MessageBox.Show(query1);
                SqlDataReader? allClasses = connection.GetDataReader(query1);
                if (allClasses != null && allClasses.HasRows)
                {
                    classScheduleTerm.Rows.Clear();
                    while (allClasses.Read())
                    {
                        classScheduleTerm.Rows.Add(
                            allClasses["Dept_Name"].ToString(),
                            allClasses["Course_Name"].ToString(),
                            allClasses["Section_ID"].ToString(),
                            allClasses["Day"].ToString(),
                            allClasses["time_start"].ToString(),
                            allClasses["time_end"].ToString()
                            );
                    }
                    if (allClasses != null)
                    {
                        allClasses.Close();
                    }
                }
            }
            else
            {
                string query2 = $"execute dbo.getCLasses '{splitTerm[0]}', {splitTerm[1]}";
                //MessageBox.Show(query2);

                SqlDataReader? allClasses = connection.GetDataReader(query2);
                if (allClasses != null && allClasses.HasRows)
                {
                    classScheduleTerm.Rows.Clear();
                    while (allClasses.Read())
                    {
                        classScheduleTerm.Rows.Add(
                            allClasses["Dept_Name"].ToString(),
                            allClasses["Course_Name"].ToString(),
                            allClasses["Section_ID"].ToString(),
                            allClasses["Day"].ToString(),
                            allClasses["time_start"].ToString(),
                            allClasses["time_end"].ToString()
                            );
                    }
                    if (allClasses != null)
                    {
                        allClasses.Close();
                    }
                }
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow r = classScheduleTerm.Rows[classScheduleTerm.SelectedCells[0].RowIndex];
            courseName = r.Cells[1].Value.ToString();
            courseSem = r.Cells[2].Value.ToString();

            MessageBox.Show("success");

               
        }
    }
}

    




