namespace SystemMonitorApp
{
    partial class ServicesForm
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
            dgvServices = new DataGridView();
            label1 = new Label();
            btnStop = new Button();
            btnStart = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            SuspendLayout();
            // 
            // dgvServices
            // 
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.BackgroundColor = SystemColors.Control;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Location = new Point(77, 93);
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersWidth = 51;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(675, 268);
            dgvServices.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 39);
            label1.Name = "label1";
            label1.Size = new Size(207, 31);
            label1.TabIndex = 1;
            label1.Text = "Windows Services";
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Red;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnStop.Location = new Point(576, 390);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(133, 34);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop Service";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.Highlight;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnStart.Location = new Point(440, 390);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(125, 34);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start Service";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // ServicesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(826, 438);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(label1);
            Controls.Add(dgvServices);
            Name = "ServicesForm";
            Text = "ServicesForm";
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvServices;
        private Label label1;
        private Button btnStop;
        private Button btnStart;
    }
}