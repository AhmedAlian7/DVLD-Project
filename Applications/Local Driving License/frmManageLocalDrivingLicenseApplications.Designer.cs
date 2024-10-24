namespace DVLD_Full_Project
{
    partial class frmManageLocalDrivingLicenseApplications
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
            this.dgvUsers = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.cmsApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddUser = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUpdateApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsDeleteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangePass = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wrtittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.cmsApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ContextMenuStrip = this.cmsApplication;
            this.dgvUsers.Location = new System.Drawing.Point(16, 350);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.Size = new System.Drawing.Size(1193, 271);
            this.dgvUsers.TabIndex = 10;
            // 
            // cmsApplication
            // 
            this.cmsApplication.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsApplication.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDetails,
            this.tsmAddUser,
            this.tsmUpdateApplication,
            this.tmsDeleteApp,
            this.tsmChangePass,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.scheduleTestToolStripMenuItem,
            this.isToolStripMenuItem,
            this.showDrivingLicenseToolStripMenuItem,
            this.personLicenseHistoryToolStripMenuItem});
            this.cmsApplication.Name = "cmsPeople";
            this.cmsApplication.Size = new System.Drawing.Size(291, 306);
            this.cmsApplication.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplication_Opening);
            // 
            // tsmShowDetails
            // 
            this.tsmShowDetails.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tsmShowDetails.Image = global::DVLD_Full_Project.Properties.Resources.Application_ShowDetails;
            this.tsmShowDetails.Name = "tsmShowDetails";
            this.tsmShowDetails.Size = new System.Drawing.Size(290, 32);
            this.tsmShowDetails.Text = "Show Details";
            this.tsmShowDetails.Click += new System.EventHandler(this.tsmShowDetails_Click);
            // 
            // tsmAddUser
            // 
            this.tsmAddUser.Name = "tsmAddUser";
            this.tsmAddUser.Size = new System.Drawing.Size(287, 6);
            // 
            // tsmUpdateApplication
            // 
            this.tsmUpdateApplication.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tsmUpdateApplication.Image = global::DVLD_Full_Project.Properties.Resources.Application_Edit;
            this.tsmUpdateApplication.Name = "tsmUpdateApplication";
            this.tsmUpdateApplication.Size = new System.Drawing.Size(290, 32);
            this.tsmUpdateApplication.Text = "Edit Application";
            this.tsmUpdateApplication.Click += new System.EventHandler(this.tsmUpdateUser_Click);
            // 
            // tmsDeleteApp
            // 
            this.tmsDeleteApp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tmsDeleteApp.Image = global::DVLD_Full_Project.Properties.Resources.Application_Delete;
            this.tmsDeleteApp.Name = "tmsDeleteApp";
            this.tmsDeleteApp.Size = new System.Drawing.Size(290, 32);
            this.tmsDeleteApp.Text = "Delete Application";
            this.tmsDeleteApp.Click += new System.EventHandler(this.tmsDeleteUser_Click);
            // 
            // tsmChangePass
            // 
            this.tsmChangePass.Name = "tsmChangePass";
            this.tsmChangePass.Size = new System.Drawing.Size(287, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.Application_Cancel;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(287, 6);
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.wrtittenTestToolStripMenuItem,
            this.streetTestToolStripMenuItem});
            this.scheduleTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.scheduleTestToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.test1;
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.scheduleTestToolStripMenuItem.Text = "Sechdule Test";
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.visionTestToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.icons8_vision_48;
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(209, 32);
            this.visionTestToolStripMenuItem.Text = "Vision Test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // wrtittenTestToolStripMenuItem
            // 
            this.wrtittenTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.wrtittenTestToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.icons8_test_passed_100;
            this.wrtittenTestToolStripMenuItem.Name = "wrtittenTestToolStripMenuItem";
            this.wrtittenTestToolStripMenuItem.Size = new System.Drawing.Size(209, 32);
            this.wrtittenTestToolStripMenuItem.Text = "Wrtitten Test";
            this.wrtittenTestToolStripMenuItem.Click += new System.EventHandler(this.wrtittenTestToolStripMenuItem_Click);
            // 
            // streetTestToolStripMenuItem
            // 
            this.streetTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.streetTestToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.StreetTest;
            this.streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            this.streetTestToolStripMenuItem.Size = new System.Drawing.Size(209, 32);
            this.streetTestToolStripMenuItem.Text = "Street Test";
            this.streetTestToolStripMenuItem.Click += new System.EventHandler(this.streetTestToolStripMenuItem_Click);
            // 
            // isToolStripMenuItem
            // 
            this.isToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.isToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.icons8_driving_license_641;
            this.isToolStripMenuItem.Name = "isToolStripMenuItem";
            this.isToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.isToolStripMenuItem.Text = "Issue Drivring License ";
            this.isToolStripMenuItem.Click += new System.EventHandler(this.isToolStripMenuItem_Click);
            // 
            // showDrivingLicenseToolStripMenuItem
            // 
            this.showDrivingLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.showDrivingLicenseToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.icons8_driving_license_64__1_1;
            this.showDrivingLicenseToolStripMenuItem.Name = "showDrivingLicenseToolStripMenuItem";
            this.showDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.showDrivingLicenseToolStripMenuItem.Text = "Show License ";
            this.showDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.showDrivingLicenseToolStripMenuItem_Click);
            // 
            // personLicenseHistoryToolStripMenuItem
            // 
            this.personLicenseHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.personLicenseHistoryToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.icons8_driving_license_64__2_;
            this.personLicenseHistoryToolStripMenuItem.Name = "personLicenseHistoryToolStripMenuItem";
            this.personLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.personLicenseHistoryToolStripMenuItem.Text = "Person Licenses History";
            this.personLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.personLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(163, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(836, 54);
            this.label1.TabIndex = 8;
            this.label1.Text = " Manage Local Driving License Applications";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::DVLD_Full_Project.Properties.Resources.ManageApplications1;
            this.pictureBox1.Location = new System.Drawing.Point(477, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.btnCancel.Image = global::DVLD_Full_Project.Properties.Resources.cancel_16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1075, 646);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 38);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnAddUser.Location = new System.Drawing.Point(1067, 278);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(143, 54);
            this.btnAddUser.TabIndex = 11;
            this.btnAddUser.Text = " Add";
            this.btnAddUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // frmManageLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1225, 699);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmManageLocalDrivingLicenseApplications";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.cmsApplication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvUsers;
        private System.Windows.Forms.ContextMenuStrip cmsApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdateApplication;
        private System.Windows.Forms.ToolStripMenuItem tmsDeleteApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ToolStripSeparator tsmAddUser;
        private System.Windows.Forms.ToolStripSeparator tsmChangePass;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wrtittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personLicenseHistoryToolStripMenuItem;
    }
}