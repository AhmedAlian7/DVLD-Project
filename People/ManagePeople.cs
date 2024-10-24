using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using People_BusinessLayer;

namespace DVLD_Full_Project
{
    public partial class ManagePeople : Form
    {

        //private static DataTable _dtAllPeople = clsPerson.GetPeopleTable();

        ////only select the columns that you want to show in the grid
        //private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
        //                                                 "FirstName", "SecondName", "LastName",
        //                                                 "Gendor", "DateOfBirth", "CountryName",
        //                                                 "Phone", "Email");
        private DataTable _dtPeople = clsPerson.GetPeopleTable();
        public ManagePeople()
        {
            InitializeComponent();

        }
        private void _RefreshPeopleList()
        {
            dgvPeople.DataSource = clsPerson.GetPeopleTable();
            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = _dtPeople;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
            if (dgvPeople.Rows.Count > 0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;

                dgvPeople.Columns[4].HeaderText = "Last Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                dgvPeople.Columns[6].Width = 80;

                dgvPeople.Columns[5].HeaderText = "Date Of Birth";
                dgvPeople.Columns[5].Width = 140;

                dgvPeople.Columns[7].HeaderText = "Address";
                dgvPeople.Columns[7].Width = 120;


                dgvPeople.Columns[8].HeaderText = "Phone";
                dgvPeople.Columns[8].Width = 100;

                dgvPeople.Columns[9].HeaderText = "Email";
                dgvPeople.Columns[9].Width = 170;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePerson frm = new AddUpdatePerson();

            //frm.DB += DataBacktoform;
            frm.Show();

            _RefreshPeopleList();
        }
        private void tsmAddPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePerson frm = new AddUpdatePerson();

            frm.ShowDialog();

            _RefreshPeopleList();
        }
        private void tsmUpdatePerson_Click(object sender, EventArgs e)
        {
            AddUpdatePerson frm = new AddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            //frm.DB += DataBacktoform;
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void tmsDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want Do Delete This Person!", "Delete Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (User.DeleteUser((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successffuly", "Complated Opertion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Can't Delete This Person", "Fialed Opertion",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }
    }
}
