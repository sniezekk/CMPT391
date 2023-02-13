namespace CollegeRegistrationApp.StudentControls
{
    partial class UserControl2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Coursename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.CourseN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectionN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(361, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Where enrolled classes are viewed";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Coursename,
            this.sectionID,
            this.Semester,
            this.year,
            this.roomNumber,
            this.day,
            this.timeS,
            this.endT});
            this.dataGridView1.Location = new System.Drawing.Point(100, 521);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(966, 304);
            this.dataGridView1.TabIndex = 2;
            // 
            // Coursename
            // 
            this.Coursename.HeaderText = "Course Name";
            this.Coursename.MinimumWidth = 8;
            this.Coursename.Name = "Coursename";
            this.Coursename.Width = 185;
            // 
            // sectionID
            // 
            this.sectionID.HeaderText = "Section Number";
            this.sectionID.MinimumWidth = 8;
            this.sectionID.Name = "sectionID";
            this.sectionID.Width = 150;
            // 
            // Semester
            // 
            this.Semester.HeaderText = "Semester";
            this.Semester.MinimumWidth = 8;
            this.Semester.Name = "Semester";
            this.Semester.Width = 150;
            // 
            // year
            // 
            this.year.HeaderText = "Year";
            this.year.MinimumWidth = 8;
            this.year.Name = "year";
            this.year.Width = 150;
            // 
            // roomNumber
            // 
            this.roomNumber.HeaderText = "Room Number";
            this.roomNumber.MinimumWidth = 8;
            this.roomNumber.Name = "roomNumber";
            this.roomNumber.Width = 150;
            // 
            // day
            // 
            this.day.HeaderText = "Day";
            this.day.MinimumWidth = 8;
            this.day.Name = "day";
            this.day.Width = 75;
            // 
            // timeS
            // 
            this.timeS.HeaderText = "Start Time";
            this.timeS.MinimumWidth = 8;
            this.timeS.Name = "timeS";
            this.timeS.Width = 150;
            // 
            // endT
            // 
            this.endT.HeaderText = "End Time";
            this.endT.MinimumWidth = 8;
            this.endT.Name = "endT";
            this.endT.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(100, 449);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Currently Enrolled";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(99, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cart";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseN,
            this.SectionN,
            this.sem,
            this.year2,
            this.roomN,
            this.day1,
            this.TimeEn});
            this.dataGridView2.Location = new System.Drawing.Point(100, 114);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(966, 292);
            this.dataGridView2.TabIndex = 5;
            // 
            // CourseN
            // 
            this.CourseN.HeaderText = "CourseName";
            this.CourseN.MinimumWidth = 8;
            this.CourseN.Name = "CourseN";
            this.CourseN.Width = 150;
            // 
            // SectionN
            // 
            this.SectionN.HeaderText = "Section Number";
            this.SectionN.MinimumWidth = 8;
            this.SectionN.Name = "SectionN";
            this.SectionN.Width = 150;
            // 
            // sem
            // 
            this.sem.HeaderText = "Semester";
            this.sem.MinimumWidth = 8;
            this.sem.Name = "sem";
            this.sem.Width = 150;
            // 
            // year2
            // 
            this.year2.HeaderText = "Year";
            this.year2.MinimumWidth = 8;
            this.year2.Name = "year2";
            this.year2.Width = 150;
            // 
            // roomN
            // 
            this.roomN.HeaderText = "Room Number";
            this.roomN.MinimumWidth = 8;
            this.roomN.Name = "roomN";
            this.roomN.Width = 150;
            // 
            // day1
            // 
            this.day1.HeaderText = "Day";
            this.day1.MinimumWidth = 8;
            this.day1.Name = "day1";
            this.day1.Width = 150;
            // 
            // TimeEn
            // 
            this.TimeEn.HeaderText = "End Time";
            this.TimeEn.MinimumWidth = 8;
            this.TimeEn.Name = "TimeEn";
            this.TimeEn.Width = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(822, 414);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Enroll";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Location = new System.Drawing.Point(948, 414);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "Empty";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Location = new System.Drawing.Point(697, 414);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 36);
            this.button3.TabIndex = 8;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1215, 921);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView2;
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn Coursename;
        private DataGridViewTextBoxColumn sectionID;
        private DataGridViewTextBoxColumn Semester;
        private DataGridViewTextBoxColumn year;
        private DataGridViewTextBoxColumn roomNumber;
        private DataGridViewTextBoxColumn day;
        private DataGridViewTextBoxColumn timeS;
        private DataGridViewTextBoxColumn endT;
        private DataGridViewTextBoxColumn CourseN;
        private DataGridViewTextBoxColumn SectionN;
        private DataGridViewTextBoxColumn sem;
        private DataGridViewTextBoxColumn year2;
        private DataGridViewTextBoxColumn roomN;
        private DataGridViewTextBoxColumn day1;
        private DataGridViewTextBoxColumn TimeEn;
        private Button button3;
    }
}
