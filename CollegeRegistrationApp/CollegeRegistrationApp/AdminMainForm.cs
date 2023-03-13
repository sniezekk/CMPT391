﻿using System;
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
            LoadDeptBox();
            LoadCourTitleBox();
            LoadCourseCreditBox();

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
                    comboBox10.Items.Add(InsTitleData["Title"].ToString());
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
            String instrucDept = comboBox5.Text;
            String gender = comboBox9.Text;
            String instrucTitle = comboBox10.Text;
            String semester = comboBox3.Text;
            String StartYear = comboBox4.Text;
            String EndYear = comboBox7.Text;
            String courseDept = comboBox8.Text;
            String courseTitle = comboBox11.Text;
            String credits = comboBox12.Text;
            


            if ( instrucDept.Length == 0 && gender.Length == 0 && instrucTitle.Length == 0 &&
                courseDept.Length == 0 && courseTitle.Length == 0 && credits.Length == 0 && 
                semester.Length == 0 && StartYear.Length == 0 && EndYear.Length == 0)
            {
                mainQuery = "select sum (no_course) as Total_Courses from dbo.FactTable ";
                SqlDataReader? mainQ = connection.GetDataReader(mainQuery);

                if (mainQ != null && mainQ.HasRows)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = new BindingSource(mainQ, "");
                    mainQ.Close();
                }
                

            }
            else
            {
                mainQuery = $"select sum (no_course) as Total_Courses from dbo.FactTable F";

                Boolean checkI = false;
                Boolean checkC = false;
                Boolean checkD = false;
                Boolean check = false;

                if (instrucDept.Length != 0 || gender.Length != 0 || instrucTitle.Length != 0)
                {

                    mainQuery += $", dbo.WHinstructor I";
                    checkI = true;

                }

                if (courseDept.Length != 0 || courseTitle.Length != 0 || credits.Length != 0)
                {
                    if (check == false)
                    {
                        mainQuery += $", dbo.WHcourses C";
                        checkC = true;
                    }
                    else
                    {
                        mainQuery += $", dbo.WHcourses C";
                    }

                }

                if (semester.Length != 0 || StartYear.Length != 0 || EndYear.Length != 0)
                {
                    if (check == false)
                    {
                        mainQuery += $", dbo.WHdate D";
                        checkD = true;
                    }
                    else
                    {
                        mainQuery += $", dbo.WHdate D";
                    }
                }

                Boolean check2 = false;

                if (checkI == true)
                {
                    mainQuery += $" where I.IID = F.IID";
                    check2 = true;
                }
                if (checkC == true)
                {
                    if (check2 == true)
                    {
                        mainQuery += $" and C.CID = F.CID";
                    } else
                    {
                        mainQuery += $" where C.CID = F.CID";
                        check2 = true;
                    }
                }
                if (checkD == true)
                {
                    if (check2 == true)
                    {
                        mainQuery += $" and D.dateKey = F.dateKey";
                    } else
                    {
                        mainQuery += $" where D.dateKey = F.dateKey";
                        check2 = true;
                    }
                }

                if (instrucDept.Length != 0)
                {
                    mainQuery += $" and I.Dept = '{instrucDept}'";
                }
                if (gender.Length != 0)
                {
                    mainQuery += $" and I.Gender = '{gender}'";
                }
                if (instrucTitle.Length != 0)
                {
                    mainQuery += $" and I.Title = '{instrucTitle}'";
                }
                if (semester.Length != 0)
                {
                    mainQuery += $" and D.term = '{semester}'";
                }
                if (StartYear.Length != 0)
                {
                    mainQuery += $" and D.d_Year >= {StartYear}";
                }
                if (EndYear.Length != 0)
                {
                    mainQuery += $" and D.d_Year <= {EndYear}";
                }
                if (courseDept.Length != 0)
                {
                    mainQuery += $" and C.Dept = '{courseDept}'";
                }
                if (courseTitle.Length != 0)
                {
                    mainQuery += $" and C.Title = '{courseTitle}'";
                }
                if (credits.Length != 0)
                {
                    mainQuery += $" and C.No_credits = {credits}";
                }

                
                MessageBox.Show(mainQuery);

                SqlDataReader? mainQ = connection.GetDataReader(mainQuery);

                if (mainQ != null && mainQ.HasRows)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = new BindingSource(mainQ, "");
                    mainQ.Close();
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainQuery = $"select sum (no_course) as Total_Courses from dbo.FactTable";

            SqlDataReader? mainQ = connection.GetDataReader(mainQuery);

            if (mainQ != null && mainQ.HasRows)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = new BindingSource(mainQ, "");
                mainQ.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
