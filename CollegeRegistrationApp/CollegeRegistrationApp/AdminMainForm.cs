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
using System.Collections;

namespace CollegeRegistrationApp
{
    public partial class AdminMainForm : Form
    {
        private DBConnection connection;
        String mainQuery = "";
        public AdminMainForm(DBConnection input_connection)
        {
            connection = input_connection;
            InitializeComponent();
            LoadInstructorDeptBox();
            LoadGenderBox();
            LoadInstructorTitleBox();
            LoadStartEndYearBox();
            LoadStartEndSemesterBox();
            LoadInstructorBox();
            LoadDeptBox();
            LoadCourseNameBox();
            LoadCourTitleBox();
            LoadCourseCreditBox();

        }
        
        private void LoadInstructorBox()
        {
            string query1 = $"select trim(First_Name) + ' ' + trim(Last_Name) as FullName from dbo.WHinstructor order by FullName asc";
            SqlDataReader? instructorData = connection.GetDataReader(query1);

            if (instructorData != null && instructorData.HasRows)
            {
                while (instructorData.Read())
                {
                    comboBox1.Items.Add(instructorData["FullName"].ToString());
                }

                instructorData.Close();
            }

        }

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
        private void LoadGenderBox()
        {
            string query3 = $"select distinct Gender from dbo.WHinstructor";
            SqlDataReader? genderData = connection.GetDataReader(query3);

            if (genderData != null && genderData.HasRows)
            {
                while (genderData.Read())
                {
                    comboBox9.Items.Add(genderData["Gender"].ToString());
                }

            genderData.Close();
            }

        }

        private void LoadInstructorTitleBox()
        {
            string query4 = $"select Distinct Title from dbo.WHinstructor";
            SqlDataReader? InsTitleData = connection.GetDataReader(query4);

            if (InsTitleData != null && InsTitleData.HasRows)
            {
                while (InsTitleData.Read())
                {
                   
                }

                InsTitleData.Close();
            }

        }

        private void LoadStartEndYearBox()
        {
            string query5 = $"select distinct d_Year from dbo.WHdate";
            SqlDataReader? stEnData = connection.GetDataReader(query5);

            if (stEnData != null && stEnData.HasRows)
            {
                while (stEnData.Read())
                {
                    comboBox4.Items.Add(stEnData["d_Year"].ToString());
                    comboBox7.Items.Add(stEnData["d_Year"].ToString());
                }

                stEnData.Close();
            }

        }

        private void LoadStartEndSemesterBox()
        {
            string query6 = $"select distinct term from dbo.WHdate";
            SqlDataReader? stEnSemData = connection.GetDataReader(query6);

            if (stEnSemData != null && stEnSemData.HasRows)
            {
                while (stEnSemData.Read())
                {
                    comboBox3.Items.Add(stEnSemData["term"].ToString());
                }

                stEnSemData.Close();
            }

        }

        private void LoadCourseNameBox()
        {
            string queryCouNam = $"select trim(Dept) + ' ' + trim(Title) as FullCourseName from dbo.WHcourses order by FullCourseName asc";
            SqlDataReader? CourseDeptData = connection.GetDataReader(queryCouNam);

            if (CourseDeptData != null && CourseDeptData.HasRows)
            {
                while (CourseDeptData.Read())
                {
                    comboBox2.Items.Add(CourseDeptData["FullCourseName"].ToString());
                }

                CourseDeptData.Close();
            }

        }
 
        private void LoadDeptBox()
        {
            string querydeptname = $"select distinct Dept as Department from dbo.WHcourses";
            SqlDataReader? CourseDeptNameData = connection.GetDataReader(querydeptname);

            if (CourseDeptNameData != null && CourseDeptNameData.HasRows)
            {
                while (CourseDeptNameData.Read())
                {
                    comboBox8.Items.Add(CourseDeptNameData["Department"].ToString());
                }

                CourseDeptNameData.Close();
            }

        }

        private void LoadCourTitleBox()
        {
            string queryCourtitle = $"select distinct Title from dbo.WHcourses";
            SqlDataReader? CourseCourTitle = connection.GetDataReader(queryCourtitle);

            if (CourseCourTitle != null && CourseCourTitle.HasRows)
            {
                while (CourseCourTitle.Read())
                {
                    comboBox11.Items.Add(CourseCourTitle["Title"].ToString());
                }

                CourseCourTitle.Close();
            }

        }

        private void LoadCourseCreditBox()
        {
            string queryCredits = $"select distinct No_credits as Credits from dbo.WHcourses order by Credits asc";
            SqlDataReader? CourseCredit = connection.GetDataReader(queryCredits);

            if (CourseCredit != null && CourseCredit.HasRows)
            {
                while (CourseCredit.Read())
                {
                    comboBox12.Items.Add(CourseCredit["Credits"].ToString());
                }

                CourseCredit.Close();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            mainQuery = $"select * from dbo.FactTable F, ";

            String Instructor = comboBox1.Text;
            String instrucDept = comboBox5.Text;
            String gender = comboBox9.Text;
            String instrucTitle = comboBox10.Text;
            String semester = comboBox3.Text;
            String StartYear = comboBox4.Text;
            String EndYear = comboBox7.Text;
            String course = comboBox2.Text;
            String courseDept = comboBox8.Text;
            String courseTitle = comboBox11.Text;
            String credits = comboBox12.Text;

            Boolean check = false;

            if (Instructor != null || instrucDept != null || gender != null || instrucTitle != null)
            {

                mainQuery += $"dbo.WHinstructor I";
                check = true;

            }

            if (course != null || courseDept != null || courseTitle != null || credits != null)
            {
                if (check == false)
                {
                    mainQuery += $"dbo.WHcourses C";
                    check = true;
                }
                else
                {
                    mainQuery += $", dbo.WHcourses C";
                }

            }

            if (semester != null || StartYear != null || StartYear != null)
            {
                if (check == false)
                {
                    mainQuery += $"dbo.WHdate D";
                }
                else
                {
                    mainQuery += $", dbo.WHdate D";
                }
            }

            mainQuery += " where ";

            /*if (Instructor != null)
            {
                //query += $"where t.genres like '%{selectedGenre}%'";
                mainQuery += "F."
            }
            */
            Boolean checkI = false;
            //Boolean secCheck = false;
            if (instrucDept != null)
            {

                mainQuery += $"F.IID = I.IID and I.Dept = '%{instrucDept}%'";
                checkI = true;
            }

            if (gender != null)
            {
                if (checkI == false)
                {
                    mainQuery += $"F.IID = I.IID and I.Gender = '%{gender}%'";
                    checkI = true;
                }
                else
                {
                    mainQuery += $" and I.Gender = '%{gender}%'";
                }

            }

            if (StartYear == null)
            {
                if (checkI == false)
                {
                    mainQuery += $"F.dateKey = C.dateKey and C.d_Year >= '%{StartYear}%'";
                    checkI = true;
                }
                else
                {
                    mainQuery += $" and C.d_Year >= '%{StartYear}%'";
                }
            }
            Boolean checkC = false;
            if (courseTitle != null)
            {
                if (checkC == false)
                {
                    mainQuery += $"F.CID = C.CID and and C.Title = '%{courseTitle}%'";
                }
                else
                {
                    mainQuery += $" C.Title = '%{courseTitle}%'";
                    checkC = true;
                }
            }

            if (courseDept != null)
            {
                if (checkC == false)
                {
                    mainQuery += $" and C.Dept = '%{courseDept}%'";
                }
                else
                {
                    mainQuery += $"F.CID = C.CID and C.Dept = '%{courseDept}%'";
                    checkC = true;
                }

            }

            if (credits != null)
            {
                if (checkC == false)
                {
                    mainQuery += $" and C.No_creadits= '%{credits}%'";
                }
                else
                {
                    mainQuery += $"F.CID = C.CID and C.No_creadits = '%{credits}%'";
                    checkC = true;
                }

            }
            //MessageBox.Show(mainQuery);

            //String mQuery = $"select * from dbo.WHinstructor"; //test query

            SqlDataReader? mainQ = connection.GetDataReader(mainQuery);

            if (mainQ != null && mainQ.HasRows)
            {
                dataGridView1.DataSource = new BindingSource(mainQ, "");
                mainQ.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}
