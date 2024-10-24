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
    public partial class frmSchedualeTest : Form
    {
        private int LoaclDLAppID =-1;
        private clsTestType.enTestType TestType = clsTestType.enTestType.Vision;
        private int AppointmentID = -1;

        public frmSchedualeTest(int loaclDLAppID, clsTestType.enTestType testType, int appointmentID =-1)
        {
            InitializeComponent();

            LoaclDLAppID = loaclDLAppID;
            TestType = testType;
            AppointmentID = appointmentID;
        }

        private void frmSchedualeTest_Load(object sender, EventArgs e)
        {
            ctrSechuleTest1.TestTypeID = TestType;
            ctrSechuleTest1.LoadInfo(LoaclDLAppID, AppointmentID);
        }
    }
}
