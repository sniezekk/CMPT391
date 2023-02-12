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

        private void Term_Click(object sender, EventArgs e)
        {
            string term = comboBox1.Text;
            string[] splitTerm = term.Split(' ');


            string query1 = $"execute dbo.getCLasses '{splitTerm[0]}', {splitTerm[1]}";

            MessageBox.Show(query1);
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


                    //MessageBox.Show(term);
                }
                if (allClasses != null)
                {
                    allClasses.Close();
                }
            }
        }
    }
}

    




