namespace CollegeRegistrationApp.StudentControls
{
    partial class UserControl3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.classScheduleTerm = new System.Windows.Forms.DataGridView();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.classScheduleTerm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(506, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Search";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1215, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // classScheduleTerm
            // 
            this.classScheduleTerm.AllowUserToAddRows = false;
            this.classScheduleTerm.BackgroundColor = System.Drawing.SystemColors.Control;
            this.classScheduleTerm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classScheduleTerm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptName,
            this.CourseName,
            this.sectionID,
            this.days,
            this.StartT,
            this.EndT});
            this.classScheduleTerm.Location = new System.Drawing.Point(92, 166);
            this.classScheduleTerm.Margin = new System.Windows.Forms.Padding(4);
            this.classScheduleTerm.Name = "classScheduleTerm";
            this.classScheduleTerm.RowHeadersWidth = 51;
            this.classScheduleTerm.RowTemplate.Height = 29;
            this.classScheduleTerm.Size = new System.Drawing.Size(1009, 464);
            this.classScheduleTerm.TabIndex = 2;
            // 
            // DeptName
            // 
            this.DeptName.HeaderText = "Department";
            this.DeptName.MinimumWidth = 10;
            this.DeptName.Name = "DeptName";
            this.DeptName.Width = 150;
            // 
            // CourseName
            // 
            this.CourseName.HeaderText = "Course Name";
            this.CourseName.MinimumWidth = 10;
            this.CourseName.Name = "CourseName";
            this.CourseName.Width = 208;
            // 
            // sectionID
            // 
            this.sectionID.HeaderText = "Section Number";
            this.sectionID.MinimumWidth = 10;
            this.sectionID.Name = "sectionID";
            this.sectionID.Width = 150;
            // 
            // days
            // 
            this.days.HeaderText = "Days";
            this.days.MinimumWidth = 10;
            this.days.Name = "days";
            this.days.Width = 150;
            // 
            // StartT
            // 
            this.StartT.HeaderText = "Start Time";
            this.StartT.MinimumWidth = 10;
            this.StartT.Name = "StartT";
            this.StartT.Width = 150;
            // 
            // EndT
            // 
            this.EndT.HeaderText = "End Time";
            this.EndT.MinimumWidth = 10;
            this.EndT.Name = "EndT";
            this.EndT.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(433, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Department:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(263, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 33);
            this.comboBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(142, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Term:";
            // 
            // Department
            // 
            this.Department.HeaderText = "deptName";
            this.Department.MinimumWidth = 8;
            this.Department.Name = "Department";
            this.Department.Width = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(918, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(618, 104);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(255, 33);
            this.comboBox2.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Location = new System.Drawing.Point(926, 657);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "Add Class";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // UserControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.classScheduleTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(1215, 921);
            this.Load += new System.EventHandler(this.UserControl3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classScheduleTerm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private MenuStrip menuStrip1;
        private DataGridView classScheduleTerm;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private DataGridViewTextBoxColumn DeptName;
        private DataGridViewTextBoxColumn CourseName;
        private DataGridViewTextBoxColumn sectionID;
        private DataGridViewTextBoxColumn days;
        private DataGridViewTextBoxColumn StartT;
        private DataGridViewTextBoxColumn EndT;
        private DataGridViewTextBoxColumn Department;
        private Button button1;
        private ComboBox comboBox2;
        private Button button2;
    }
}
