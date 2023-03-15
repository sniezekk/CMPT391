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
using System.Xml;
using System.Security.Cryptography;
using System.Diagnostics;

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



            if (instrucDept.Length == 0 && gender.Length == 0 && instrucTitle.Length == 0 &&
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
                    }
                    else
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
                    }
                    else
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

        private void MakeXML(object sender, EventArgs e)
        {

        }

        private void ReadXML(object sender, EventArgs e)
        {

            using (XmlReader reader = XmlReader.Create(@"D:\XMLcreator\XMLcreator\bin\Debug\net6.0\UNINFO.xml"))
            {
                string firstName = "", lastName = "", InsTitle = "", InsDept = "", gender = "", year = "", term = "", cTitle = "", cDept = "", credits = "";
                while (reader.Read()) //new row from the xml
                {
                    
                    //MessageBox.Show("while loop");
                    Boolean firstStop = false;

                    if (reader.IsStartElement())
                    {

                        switch (reader.Name.ToString())
                        {
                            case "First_Name":
                                //MessageBox.Show("first name is : " + reader.ReadString());
                                firstName = reader.ReadString();
                                break;
                            case "Last_Name":
                                //MessageBox.Show("last name : " + reader.ReadString());
                                lastName = reader.ReadString();
                                break;
                            case "ITitle":
                                //MessageBox.Show("title : " + reader.ReadString());
                                InsTitle = reader.ReadString();
                                break;
                            case "IDept":
                                //MessageBox.Show("instructor dept : " + reader.ReadString());
                                InsDept = reader.ReadString();
                                break;
                            case "Gender":
                                //MessageBox.Show("gender is : " + reader.ReadString());
                                gender = reader.ReadString();
                                break;
                            case "Year":
                                //MessageBox.Show("year is : " + reader.ReadString());
                                year = reader.ReadString();
                                break;
                            case "Term":
                                //MessageBox.Show("term is : " + reader.ReadString());
                                term = reader.ReadString();
                                break;
                            case "CTitle":
                                //MessageBox.Show("course title : " + reader.ReadString());
                                cTitle = reader.ReadString();
                                break;
                            case "CDept":
                                //MessageBox.Show("course dept is: " + reader.ReadString());
                                cDept = reader.ReadString();
                                break;
                            case "Credits":
                                //MessageBox.Show("credits are : " + reader.ReadString());
                                credits = reader.ReadString();
                                firstStop = true;
                                break;
                        }

                    }
                    if (firstStop)
                    {
                        String instQuery = $"select * from WHinstructor I where I.First_Name = '{firstName}' AND I.Last_Name = '{lastName}' " +
                                $"AND I.Title = '{InsTitle}' AND I.Dept = '{InsDept}' AND I.Gender = '{gender}'";
                        Boolean instrutorExists = false;

                        SqlDataReader? instQ = connection.GetDataReader(instQuery);
                        if (instQ != null && instQ.HasRows)
                        {
                            instrutorExists = true;
                            instQ.Close();
                        }
                        else
                        {
                          
                            string addInstructor = $"insert into dbo.WHinstructor (First_Name, Last_Name, Title, Dept, Gender) values('{firstName}','{lastName}', '{InsTitle}', '{InsDept}', '{gender}')";
                            int result = connection.ExecuteMutation(addInstructor);
                            if (result == 0) { MessageBox.Show("failed"); } else { instrutorExists = true; }

                        }

                        String dateQuery = $"select * from dbo.WHdate D where D.d_Year = {year} AND D.term = {term}";
                        Boolean dateExists = false;

                        SqlDataReader? dateQ = connection.GetDataReader(dateQuery);
                        if (dateQ != null && dateQ.HasRows)
                        {
                            dateExists = true;
                            dateQ.Close();
                        }
                        else
                        {
                            String addDate = $"insert into dbo.WHdate (d_Year, term) values ({year}, {term})";
                            int result = connection.ExecuteMutation(addDate);
                            if (result == 0) { MessageBox.Show("failed"); } else { dateExists = true; }
                           
                        }

                        String courseQuery = $"select * from dbo.WHcourses C where C.Title = {cTitle} AND C.Dept = '{cDept}' AND C.No_credits ={credits}";
                        Boolean courseExists = false;

                        SqlDataReader? courseQ = connection.GetDataReader(courseQuery);
                        if (courseQ != null && courseQ.HasRows)
                        {
                            courseExists = true;
                            courseQ.Close();
                        }
                        else
                        {
                            String addCourse = $"insert into WHcourses (Title, Dept, No_credits) values ("{cTitle}, '{cDept}', {credits})";
                            int result = connection.ExecuteMutation(addCourse);
                            if (result == 0) { MessageBox.Show("failed"); } else { courseExists = true; }
                        }

                        if (instrutorExists == true && dateExists == true && courseExists == true)
                        {
                            
                            String instQuery2 = $"select I.IID from WHinstructor I where I.First_Name = '{firstName}' AND I.Last_Name = '{lastName}' " +
                                        $"AND I.Title = '{InsTitle}' AND I.Dept = '{InsDept}' AND I.Gender = '{gender}'";

                            String dateQuery2 = $"select D.dateKey from WHdate D where D.d_Year = {year} AND D.term = {term}";

                            String courseQuery2 = $"select C.CID from WHcourses C where C.Title = {cTitle} AND C.Dept = '{cDept}' AND C.No_credits = {credits}";

                            String IID = "";
                            String CID = "";
                            String dateKey = "";
                            SqlDataReader? getIID = connection.GetDataReader(instQuery2);
                            if (getIID != null && getIID.HasRows)
                            {
                                IID = getIID["IID"].ToString();
                                getIID.Close();
                                MessageBox.Show("IID runs");
                            }

                            SqlDataReader? getCID = connection.GetDataReader(courseQuery2);
                            if (getCID != null && getCID.HasRows)
                            {
                                CID = getCID["CID"].ToString();
                                getCID.Close();
                                MessageBox.Show("CID runs");
                            }

                            SqlDataReader? getDateKey = connection.GetDataReader(dateQuery2);
                            if (getDateKey != null && getDateKey.HasRows)
                            {
                                dateKey = getDateKey["dateKey"].ToString();
                                getDateKey.Close();
                                MessageBox.Show("dataKey runs");
                            }

                            String insertFact = $"insert into FactTable(IID, CID, dateKey, no_course) values({IID}, {CID}, {dateKey}, 1)";
                            int result = connection.ExecuteMutation(insertFact);
                            if (result != 0) { MessageBox.Show("insert in to fact table failed"); }
                        }
                        else
                        {
                            MessageBox.Show("The Instructor/Course/Date not added");
                        }

                    }
                }

            }
        }
    }
}

