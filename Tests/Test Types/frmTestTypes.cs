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
    public partial class frmTestTypes : Form
    {
        public frmTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreshTestsList()
        {
            dgvTests.DataSource = clsTestType.AppTypesTable();
        }
        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestsList();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUpdateTestType frm = new frmUpdateTestType((int)dgvTests.CurrentRow.Cells[0].Value);
            frm.Show();
            _RefreshTestsList();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
