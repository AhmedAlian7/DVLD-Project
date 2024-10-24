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
    public partial class frmManageDrivers : Form
    {
        private DataTable dt;
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _RefreshTable()
        {
            this.dt = clsDriver.DriversTable();
            dgvDrivers.DataSource = dt;
        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshTable();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            int PersonId = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmPersonDetails frm = new frmPersonDetails(PersonId);
            frm.ShowDialog();
        }

        private void tsmUpdateApplication_Click(object sender, EventArgs e)
        {
            int PersonId = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmLicensesHistory frm = new frmLicensesHistory(PersonId);
            frm.Show();
        }
    }
}
