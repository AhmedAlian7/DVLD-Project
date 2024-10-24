namespace DVLD_Full_Project
{
    partial class frmManageAppointments
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
            this.components = new System.ComponentModel.Container();
            this.lblCreationMode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.TakeTest = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.takeTheTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picTestType = new System.Windows.Forms.PictureBox();
            this.localDLApplicationInfo1 = new DVLD_Full_Project.LocalDLApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.cmsAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCreationMode
            // 
            this.lblCreationMode.AutoSize = true;
            this.lblCreationMode.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCreationMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(189)))));
            this.lblCreationMode.Location = new System.Drawing.Point(106, 95);
            this.lblCreationMode.Name = "lblCreationMode";
            this.lblCreationMode.Size = new System.Drawing.Size(408, 45);
            this.lblCreationMode.TabIndex = 90;
            this.lblCreationMode.Text = "Street Test Appointments ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 502);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 21);
            this.label3.TabIndex = 100;
            this.label3.Text = "Appointments:";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmsAppointments;
            this.dgvAppointments.Location = new System.Drawing.Point(12, 529);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.Size = new System.Drawing.Size(614, 150);
            this.dgvAppointments.TabIndex = 101;
            // 
            // cmsAppointments
            // 
            this.cmsAppointments.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Edit,
            this.TakeTest,
            this.takeTheTestToolStripMenuItem});
            this.cmsAppointments.Name = "cmsAppointments";
            this.cmsAppointments.Size = new System.Drawing.Size(248, 62);
            // 
            // Edit
            // 
            this.Edit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Edit.Image = global::DVLD_Full_Project.Properties.Resources.icons8_test_passed_100__1_;
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(247, 26);
            this.Edit.Text = "Edit Appoinment Date";
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // TakeTest
            // 
            this.TakeTest.Name = "TakeTest";
            this.TakeTest.Size = new System.Drawing.Size(244, 6);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.btnAddUser.Image = global::DVLD_Full_Project.Properties.Resources.Applications_32;
            this.btnAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddUser.Location = new System.Drawing.Point(517, 478);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(107, 42);
            this.btnAddUser.TabIndex = 103;
            this.btnAddUser.Text = " Add";
            this.btnAddUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // takeTheTestToolStripMenuItem
            // 
            this.takeTheTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.takeTheTestToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.icons8_test_passed_100;
            this.takeTheTestToolStripMenuItem.Name = "takeTheTestToolStripMenuItem";
            this.takeTheTestToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.takeTheTestToolStripMenuItem.Text = "Take The Test";
            this.takeTheTestToolStripMenuItem.Click += new System.EventHandler(this.takeTheTestToolStripMenuItem_Click);
            // 
            // picTestType
            // 
            this.picTestType.Image = global::DVLD_Full_Project.Properties.Resources.StreetTest;
            this.picTestType.Location = new System.Drawing.Point(160, 1);
            this.picTestType.Name = "picTestType";
            this.picTestType.Size = new System.Drawing.Size(315, 91);
            this.picTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTestType.TabIndex = 91;
            this.picTestType.TabStop = false;
            // 
            // localDLApplicationInfo1
            // 
            this.localDLApplicationInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.localDLApplicationInfo1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.localDLApplicationInfo1.Location = new System.Drawing.Point(0, 145);
            this.localDLApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.localDLApplicationInfo1.Name = "localDLApplicationInfo1";
            this.localDLApplicationInfo1.Size = new System.Drawing.Size(626, 326);
            this.localDLApplicationInfo1.TabIndex = 104;
            // 
            // frmManageAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(636, 688);
            this.Controls.Add(this.localDLApplicationInfo1);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCreationMode);
            this.Controls.Add(this.picTestType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmManageAppointments";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Appointments";
            this.Load += new System.EventHandler(this.frmManageAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmsAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreationMode;
        private System.Windows.Forms.PictureBox picTestType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ContextMenuStrip cmsAppointments;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripSeparator TakeTest;
        private System.Windows.Forms.ToolStripMenuItem takeTheTestToolStripMenuItem;
        private LocalDLApplicationInfo localDLApplicationInfo1;
    }
}