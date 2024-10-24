namespace DVLD_Full_Project
{
    partial class frmLicensesHistory
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
            this.ctrPersonCardWithFilter1 = new DVLD_Full_Project.ctrPersonCardWithFilter();
            this.ctrLicensesHistory1 = new DVLD_Full_Project.ctrLicensesHistory();
            this.labal1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrPersonCardWithFilter1
            // 
            this.ctrPersonCardWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.ctrPersonCardWithFilter1.Location = new System.Drawing.Point(7, 63);
            this.ctrPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrPersonCardWithFilter1.Name = "ctrPersonCardWithFilter1";
            this.ctrPersonCardWithFilter1.ShowbtnAdd = true;
            this.ctrPersonCardWithFilter1.ShowpnlFilter = true;
            this.ctrPersonCardWithFilter1.Size = new System.Drawing.Size(912, 392);
            this.ctrPersonCardWithFilter1.TabIndex = 0;
            this.ctrPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrPersonCardWithFilter1_OnPersonSelected);
            // 
            // ctrLicensesHistory1
            // 
            this.ctrLicensesHistory1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.ctrLicensesHistory1.Location = new System.Drawing.Point(7, 462);
            this.ctrLicensesHistory1.Name = "ctrLicensesHistory1";
            this.ctrLicensesHistory1.Size = new System.Drawing.Size(912, 350);
            this.ctrLicensesHistory1.TabIndex = 1;
            // 
            // labal1
            // 
            this.labal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labal1.AutoSize = true;
            this.labal1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labal1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labal1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labal1.Location = new System.Drawing.Point(322, 9);
            this.labal1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labal1.Name = "labal1";
            this.labal1.Size = new System.Drawing.Size(244, 41);
            this.labal1.TabIndex = 74;
            this.labal1.Text = "Licenses History";
            // 
            // frmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(928, 759);
            this.Controls.Add(this.labal1);
            this.Controls.Add(this.ctrLicensesHistory1);
            this.Controls.Add(this.ctrPersonCardWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmLicensesHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licenses History";
            this.Load += new System.EventHandler(this.frmLicensesHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrPersonCardWithFilter ctrPersonCardWithFilter1;
        private ctrLicensesHistory ctrLicensesHistory1;
        private System.Windows.Forms.Label labal1;
    }
}