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

namespace CollegeRegistrationApp.StudentControls
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
            
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            Load_TermsMenuItems();
        }



        private void Load_TermsMenuItems()
        {
           
            foreach(String items in Get_Terms_For_Menu())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                
                toolStripMenuItem1.DropDownItems.Add(item);

                item.Click += new EventHandler(Term_Click);
            }
            
        }

        private void Term_Click(object sender, EventArgs e)
        {
            // where u can show the different classes for the specific term

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            // if item.Text = "Fall" or "Winter"
        }

        private List<String> Get_Terms_For_Menu()
        {
            int currentYear = DateTime.Now.Year;
            int nextYear = currentYear + 1;

            List<String> terms = new List<String>();

            if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 4)
            {
                terms.Add("Fall " + currentYear);
                terms.Add("Winter " + nextYear);
            }
            else if (DateTime.Now.Month >= 9 && DateTime.Now.Month <= 12)
            {
                terms.Add("Winter " + nextYear);
                terms.Add("Fall " + nextYear);
            }

            return terms;

        }

       
    }
}

    




