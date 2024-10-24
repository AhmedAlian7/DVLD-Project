namespace DVLD_Full_Project
{
    partial class frmSchedualeTest
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
            this.ctrSechuleTest1 = new DVLD_Full_Project.ctrSechuleTest();
            this.SuspendLayout();
            // 
            // ctrSechuleTest1
            // 
            this.ctrSechuleTest1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.ctrSechuleTest1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctrSechuleTest1.Location = new System.Drawing.Point(6, 0);
            this.ctrSechuleTest1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrSechuleTest1.Name = "ctrSechuleTest1";
            this.ctrSechuleTest1.Size = new System.Drawing.Size(438, 645);
            this.ctrSechuleTest1.TabIndex = 0;
            this.ctrSechuleTest1.TestTypeID = People_BusinessLayer.clsTestType.enTestType.Vision;
            // 
            // frmSchedualeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(447, 642);
            this.Controls.Add(this.ctrSechuleTest1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmSchedualeTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduale Test";
            this.Load += new System.EventHandler(this.frmSchedualeTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrSechuleTest ctrSechuleTest1;
    }
}