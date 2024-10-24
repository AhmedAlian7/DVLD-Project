using People_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class frmApplictionTypes : Form
    {
        public frmApplictionTypes() 
        {
            InitializeComponent();
        }

        private void _RefreshAppsList()
        {
            dgvApplications.DataSource = clsApplicationType.AppTypesTable();
        }

        private void frmApplictionTypes_Load(object sender, EventArgs e)
        {
            _RefreshAppsList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApps frm = new frmUpdateApps((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.Show();
            _RefreshAppsList();
        }
    }
}
