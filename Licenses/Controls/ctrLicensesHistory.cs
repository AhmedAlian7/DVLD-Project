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
    public partial class ctrLicensesHistory : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;

        private DataTable _LocalTable;
        private DataTable _InternationalTable;
     
        public ctrLicensesHistory()
        {
            InitializeComponent();
        }

        private void _LoadLocal()
        {
            _LocalTable = _Driver.GetLicenses();
            dgvLocalHistory.DataSource = _LocalTable;
        }
        private void _LoadInternational()
        {
            // not implemintation
        }
        public void LoadInfoByDriverID(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(DriverID);
            if(_Driver == null)
            {
                MessageBox.Show("Cannot find Driver with ID = " +  DriverID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadLocal();
            _LoadInternational();


        }
        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);
            if (_Driver == null)
            {
                MessageBox.Show("Cannot find Driver with Person ID = " + PersonID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID = _Driver.DriverID;
            _LoadLocal();
            _LoadInternational();
        }
        public void Clear()
        {
            _LocalTable.Clear();
            _InternationalTable.Clear();
        }
        private void showLicenseDitailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseid = (int)dgvLocalHistory.CurrentRow.Cells[0].Value;
            frmShowLicense frm = new frmShowLicense(licenseid);
        }
    }
}
