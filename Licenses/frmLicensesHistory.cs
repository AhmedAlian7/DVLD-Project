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
    public partial class frmLicensesHistory : Form
    {
        private int _PersonID = -1; 
        public frmLicensesHistory()
        {
            InitializeComponent();
        }
        public frmLicensesHistory(int personId)
        {
            InitializeComponent();
            _PersonID = personId;
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                ctrPersonCardWithFilter1.FilterFocus();
                ctrPersonCardWithFilter1.Enabled = true;

            }
            else
            {
                ctrPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrPersonCardWithFilter1.FilterEnabled = false;
                ctrLicensesHistory1.LoadInfoByPersonID(_PersonID);
            }
        }

        private void ctrPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
                ctrLicensesHistory1.Clear();
            //else
            //    ctrPersonCardWithFilter1.LoadPersonInfo(_PersonID);
        }
    }
}
