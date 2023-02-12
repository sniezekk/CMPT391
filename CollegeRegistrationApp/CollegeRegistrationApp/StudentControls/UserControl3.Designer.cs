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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.classScheduleTerm = new System.Windows.Forms.DataGridView();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1215, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(83, 36);
            this.toolStripMenuItem1.Text = "Term";
            this.toolStripMenuItem1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // classScheduleTerm
            // 
            this.classScheduleTerm.AllowUserToAddRows = false;
            this.classScheduleTerm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classScheduleTerm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptName,
            this.CourseName,
            this.sectionID,
            this.days,
            this.StartT,
            this.EndT});
            this.classScheduleTerm.Location = new System.Drawing.Point(92, 195);
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
            this.label2.Location = new System.Drawing.Point(332, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(422, 98);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 31);
            this.textBox1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 33);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.Term_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 49);
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
            // UserControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.classScheduleTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(1215, 921);
            this.Load += new System.EventHandler(this.UserControl3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classScheduleTerm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private DataGridView classScheduleTerm;
        private Label label2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label3;
        private DataGridViewTextBoxColumn DeptName;
        private DataGridViewTextBoxColumn CourseName;
        private DataGridViewTextBoxColumn sectionID;
        private DataGridViewTextBoxColumn days;
        private DataGridViewTextBoxColumn StartT;
        private DataGridViewTextBoxColumn EndT;
        private DataGridViewTextBoxColumn Department;
    }
}
