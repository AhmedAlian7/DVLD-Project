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
    public partial class ctrPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int ID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(ID);
            }
        }

        bool _ShowbtnAdd = true;
        public bool ShowbtnAdd { get { return _ShowbtnAdd; } set { _ShowbtnAdd = value; btnAdd.Visible = _ShowbtnAdd; } }

        bool _ShowpnlFilter = true;
        public bool ShowpnlFilter { get { return _ShowpnlFilter; } set { _ShowpnlFilter = value; pnlFilter.Visible = _ShowpnlFilter; } }

        public int PersonID { get { return ctrPersonCard1.PersonID; } }
        public clsPerson SelectedPersonInfo { get { return ctrPersonCard1.PersonInfo; } }

        void Find()
        {
            if (cbFilter.SelectedIndex == 0)
            {
                ctrPersonCard1.LoadPersonInfo(txbFilter.Text);
            }
            else
            {
                ctrPersonCard1.LoadPersonInfo(int.Parse(txbFilter.Text));
            }

            if (OnPersonSelected != null && ShowpnlFilter)
            {
                OnPersonSelected(ctrPersonCard1.PersonID);
            }
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            txbFilter.Text = PersonID.ToString();
            Find();
        }


        public ctrPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void FilterFocus()
        {
            txbFilter.Focus();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbFilter.Text = "";
            txbFilter.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some Field Isn't Valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Find();
        }
        private void txbFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbFilter.Text))
            {
                errorProvider1.SetError(txbFilter, "This Field Is Requiered!");
            }
            else
            {
                errorProvider1.SetError(txbFilter, "");

            }
        }

        private void ctrPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txbFilter.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUpdatePerson frm = new AddUpdatePerson();
            frm.DB += DataBackEvent;
            frm.Show();
        }
        void DataBackEvent(object sender, int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            txbFilter.Text = PersonID.ToString();
            ctrPersonCard1.LoadPersonInfo(PersonID);
        }
        private void txbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // char 13 is Enter code;
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
            if (cbFilter.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        public bool FilterEnabled
        {
            get { return cbFilter.Enabled; }
            set 
            { cbFilter.Enabled = value;
              txbFilter.Enabled = value;
            }
        }
    }
}
