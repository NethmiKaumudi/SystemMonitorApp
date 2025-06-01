namespace SystemMonitorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRemoteUsers = new Button();
            btnServices = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnRemoteUsers
            // 
            btnRemoteUsers.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnRemoteUsers.Location = new Point(414, 187);
            btnRemoteUsers.Name = "btnRemoteUsers";
            btnRemoteUsers.Size = new Size(199, 39);
            btnRemoteUsers.TabIndex = 0;
            btnRemoteUsers.Text = "View Remote Users";
            btnRemoteUsers.UseVisualStyleBackColor = true;
            btnRemoteUsers.Click += btnRemoteUsers_Click;
            // 
            // btnServices
            // 
            btnServices.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnServices.Location = new Point(133, 187);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(198, 39);
            btnServices.TabIndex = 1;
            btnServices.Text = "View Services";
            btnServices.UseVisualStyleBackColor = true;
            btnServices.Click += btnServices_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(281, 100);
            label1.Name = "label1";
            label1.Size = new Size(228, 31);
            label1.TabIndex = 2;
            label1.Text = "System Monitor App";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnServices);
            Controls.Add(btnRemoteUsers);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRemoteUsers;
        private Button btnServices;
        private Label label1;
    }
}
