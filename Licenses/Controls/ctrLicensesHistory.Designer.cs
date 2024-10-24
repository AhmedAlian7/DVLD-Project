namespace DVLD_Full_Project
{
    partial class ctrLicensesHistory
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInternationalHistory = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgvLocalHistory = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsInternational = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseDitailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalHistory)).BeginInit();
            this.cmsLocal.SuspendLayout();
            this.cmsInternational.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.Location = new System.Drawing.Point(4, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 344);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(6, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 306);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dgvLocalHistory);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 270);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dgvInternationalHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            // 
            // dgvInternationalHistory
            // 
            this.dgvInternationalHistory.AllowUserToAddRows = false;
            this.dgvInternationalHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInternationalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalHistory.ContextMenuStrip = this.cmsInternational;
            this.dgvInternationalHistory.Location = new System.Drawing.Point(7, 41);
            this.dgvInternationalHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInternationalHistory.Name = "dgvInternationalHistory";
            this.dgvInternationalHistory.ReadOnly = true;
            this.dgvInternationalHistory.RowHeadersWidth = 51;
            this.dgvInternationalHistory.Size = new System.Drawing.Size(871, 222);
            this.dgvInternationalHistory.TabIndex = 16;
            // 
            // dgvLocalHistory
            // 
            this.dgvLocalHistory.AllowUserToAddRows = false;
            this.dgvLocalHistory.AllowUserToDeleteRows = false;
            this.dgvLocalHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalHistory.ContextMenuStrip = this.cmsLocal;
            this.dgvLocalHistory.Location = new System.Drawing.Point(7, 41);
            this.dgvLocalHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLocalHistory.Name = "dgvLocalHistory";
            this.dgvLocalHistory.ReadOnly = true;
            this.dgvLocalHistory.RowHeadersWidth = 51;
            this.dgvLocalHistory.Size = new System.Drawing.Size(871, 222);
            this.dgvLocalHistory.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Local Licenses History:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "International Licenses History:";
            // 
            // cmsLocal
            // 
            this.cmsLocal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLocal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseDitailsToolStripMenuItem});
            this.cmsLocal.Name = "cmsLocal";
            this.cmsLocal.Size = new System.Drawing.Size(265, 64);
            // 
            // cmsInternational
            // 
            this.cmsInternational.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsInternational.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternational.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsInternational.Name = "cmsInternational";
            this.cmsInternational.Size = new System.Drawing.Size(265, 36);
            // 
            // showLicenseDitailsToolStripMenuItem
            // 
            this.showLicenseDitailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.showLicenseDitailsToolStripMenuItem.Image = global::DVLD_Full_Project.Properties.Resources.Application_ShowDetails;
            this.showLicenseDitailsToolStripMenuItem.Name = "showLicenseDitailsToolStripMenuItem";
            this.showLicenseDitailsToolStripMenuItem.Size = new System.Drawing.Size(264, 32);
            this.showLicenseDitailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDitailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDitailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripMenuItem1.Image = global::DVLD_Full_Project.Properties.Resources.Application_ShowDetails;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(264, 32);
            this.toolStripMenuItem1.Text = "Show License Details";
            // 
            // ctrLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrLicensesHistory";
            this.Size = new System.Drawing.Size(912, 350);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalHistory)).EndInit();
            this.cmsLocal.ResumeLayout(false);
            this.cmsInternational.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvLocalHistory;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvInternationalHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsLocal;
        private System.Windows.Forms.ContextMenuStrip cmsInternational;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDitailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
