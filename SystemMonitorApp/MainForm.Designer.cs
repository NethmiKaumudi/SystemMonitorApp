namespace SystemMonitorApp
{
    partial class MainForm
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
            NavBar = new Panel();
            btnUsers = new Button();
            btnServices = new Button();
            btnHome = new Button();
            contentPanel = new Panel();
            homePanel = new Panel();
            panel3 = new Panel();
            lblServices = new Label();
            label2 = new Label();
            panel2 = new Panel();
            lblUserStats = new Label();
            label4 = new Label();
            panel1 = new Panel();
            lblRDP = new Label();
            label3 = new Label();
            lblIP = new Label();
            lblDateTime = new Label();
            NavBar.SuspendLayout();
            contentPanel.SuspendLayout();
            homePanel.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // NavBar
            // 
            NavBar.BackColor = Color.RosyBrown;
            NavBar.Controls.Add(btnUsers);
            NavBar.Controls.Add(btnServices);
            NavBar.Controls.Add(btnHome);
            NavBar.Location = new Point(23, 12);
            NavBar.Name = "NavBar";
            NavBar.Size = new Size(847, 75);
            NavBar.TabIndex = 0;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = SystemColors.Highlight;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnUsers.ForeColor = Color.Black;
            btnUsers.Location = new Point(584, 21);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(114, 38);
            btnUsers.TabIndex = 3;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnServices
            // 
            btnServices.BackColor = SystemColors.Highlight;
            btnServices.FlatStyle = FlatStyle.Flat;
            btnServices.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnServices.ForeColor = Color.Black;
            btnServices.Location = new Point(370, 21);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(114, 38);
            btnServices.TabIndex = 2;
            btnServices.Text = "Services";
            btnServices.UseVisualStyleBackColor = false;
            btnServices.Click += btnServices_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = SystemColors.Highlight;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnHome.ForeColor = SystemColors.ActiveCaptionText;
            btnHome.Location = new Point(151, 21);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(114, 38);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // contentPanel
            // 
            contentPanel.Controls.Add(homePanel);
            contentPanel.Location = new Point(23, 92);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(850, 450);
            contentPanel.TabIndex = 1;
            // 
            // homePanel
            // 
            homePanel.BackColor = Color.RosyBrown;
            homePanel.Controls.Add(panel3);
            homePanel.Controls.Add(panel2);
            homePanel.Controls.Add(panel1);
            homePanel.Controls.Add(lblIP);
            homePanel.Controls.Add(lblDateTime);
            homePanel.Location = new Point(3, 3);
            homePanel.Name = "homePanel";
            homePanel.Size = new Size(844, 444);
            homePanel.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(lblServices);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(291, 280);
            panel3.Name = "panel3";
            panel3.Size = new Size(276, 125);
            panel3.TabIndex = 9;
            // 
            // lblServices
            // 
            lblServices.AutoSize = true;
            lblServices.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblServices.Location = new Point(18, 64);
            lblServices.Name = "lblServices";
            lblServices.Size = new Size(51, 20);
            lblServices.TabIndex = 5;
            lblServices.Text = "label5";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(16, 29);
            label2.Name = "label2";
            label2.Size = new Size(209, 23);
            label2.TabIndex = 4;
            label2.Text = "Windows Services Status";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblUserStats);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(471, 149);
            panel2.Name = "panel2";
            panel2.Size = new Size(276, 125);
            panel2.TabIndex = 9;
            // 
            // lblUserStats
            // 
            lblUserStats.AutoSize = true;
            lblUserStats.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUserStats.Location = new Point(32, 59);
            lblUserStats.Name = "lblUserStats";
            lblUserStats.Size = new Size(51, 20);
            lblUserStats.TabIndex = 6;
            lblUserStats.Text = "label6";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(31, 28);
            label4.Name = "label4";
            label4.Size = new Size(99, 23);
            label4.TabIndex = 5;
            label4.Text = "User States";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblRDP);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(105, 149);
            panel1.Name = "panel1";
            panel1.Size = new Size(276, 125);
            panel1.TabIndex = 8;
            // 
            // lblRDP
            // 
            lblRDP.AutoSize = true;
            lblRDP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblRDP.Location = new Point(19, 64);
            lblRDP.Name = "lblRDP";
            lblRDP.Size = new Size(59, 23);
            lblRDP.TabIndex = 5;
            lblRDP.Text = "label5";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(18, 31);
            label3.Name = "label3";
            label3.Size = new Size(197, 23);
            label3.TabIndex = 4;
            label3.Text = "Remote Desctop Status";
            label3.Click += label3_Click;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblIP.ForeColor = Color.Black;
            lblIP.Location = new Point(482, 73);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(59, 23);
            lblIP.TabIndex = 5;
            lblIP.Text = "label2";
            lblIP.Click += lblIP_Click;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblDateTime.ForeColor = Color.Black;
            lblDateTime.Location = new Point(482, 30);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(59, 23);
            lblDateTime.TabIndex = 4;
            lblDateTime.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(contentPanel);
            Controls.Add(NavBar);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            NavBar.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            homePanel.ResumeLayout(false);
            homePanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel NavBar;
        private Button btnServices;
        private Button btnHome;
        private Panel contentPanel;
        private Button btnUsers;
        private Panel homePanel;
        private Label lblUserStats;
        private Label label4;
        private Label lblRDP;
        private Label label3;
        private Label lblIP;
        private Label lblDateTime;
        private Label lblServices;
        private Label label2;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
    }
}