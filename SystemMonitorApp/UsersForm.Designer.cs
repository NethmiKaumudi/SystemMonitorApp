namespace SystemMonitorApp
{
    partial class UsersForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label2 = new Label();
            dgvWindowsUsers = new DataGridView();
            btnAddUser = new Button();
            tabPage2 = new TabPage();
            label1 = new Label();
            dgvUsers = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWindowsUsers).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, -4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(827, 442);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.RosyBrown;
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dgvWindowsUsers);
            tabPage1.Controls.Add(btnAddUser);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(819, 409);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Windows Users";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(288, 40);
            label2.Name = "label2";
            label2.Size = new Size(178, 31);
            label2.TabIndex = 12;
            label2.Text = "Windows Users";
            label2.Click += label2_Click;
            // 
            // dgvWindowsUsers
            // 
            dgvWindowsUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWindowsUsers.BackgroundColor = SystemColors.Control;
            dgvWindowsUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWindowsUsers.Location = new Point(62, 115);
            dgvWindowsUsers.Name = "dgvWindowsUsers";
            dgvWindowsUsers.ReadOnly = true;
            dgvWindowsUsers.RowHeadersWidth = 51;
            dgvWindowsUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWindowsUsers.Size = new Size(700, 268);
            dgvWindowsUsers.TabIndex = 11;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = SystemColors.HotTrack;
            btnAddUser.Location = new Point(611, 69);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(151, 40);
            btnAddUser.TabIndex = 10;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click_1;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.RosyBrown;
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(dgvUsers);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(819, 409);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Remote Users";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(256, 17);
            label1.Name = "label1";
            label1.Size = new Size(255, 31);
            label1.TabIndex = 8;
            label1.Text = "Remote Desktop Users";
            // 
            // dgvUsers
            // 
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = SystemColors.ControlLightLight;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(49, 64);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(718, 297);
            dgvUsers.TabIndex = 7;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 436);
            Controls.Add(tabControl1);
            Name = "UsersForm";
            Text = "UsersForm";
            Load += UsersForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWindowsUsers).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnAddUser;
        private TabPage tabPage2;
        private Label label1;
        private DataGridView dgvUsers;
        private Label label2;
        private DataGridView dgvWindowsUsers;
    }
}