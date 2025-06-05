namespace SystemMonitorApp
{
    partial class AddUserForm
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
            btnAdd = new Button();
            label1 = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            chkRemoteAccess = new CheckBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.Highlight;
            btnAdd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnAdd.Location = new Point(209, 301);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 38);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(187, 35);
            label1.Name = "label1";
            label1.Size = new Size(155, 23);
            label1.TabIndex = 1;
            label1.Text = "Add Windows User";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(236, 100);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(205, 27);
            txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(236, 162);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(205, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(113, 102);
            label2.Name = "label2";
            label2.Size = new Size(104, 23);
            label2.TabIndex = 4;
            label2.Text = "User Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(113, 166);
            label3.Name = "label3";
            label3.Size = new Size(91, 23);
            label3.TabIndex = 5;
            label3.Text = "Password :";
            // 
            // chkRemoteAccess
            // 
            chkRemoteAccess.AutoSize = true;
            chkRemoteAccess.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            chkRemoteAccess.Location = new Point(118, 233);
            chkRemoteAccess.Name = "chkRemoteAccess";
            chkRemoteAccess.Size = new Size(203, 27);
            chkRemoteAccess.TabIndex = 6;
            chkRemoteAccess.Text = "Enable Remote Access";
            chkRemoteAccess.UseVisualStyleBackColor = true;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(532, 403);
            Controls.Add(chkRemoteAccess);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AddUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label label1;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Label label2;
        private Label label3;
        private CheckBox chkRemoteAccess;
    }
}