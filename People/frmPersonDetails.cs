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
using System.IO;

namespace DVLD_Full_Project
{
    public partial class frmPersonDetails : Form
    {
        int _PersonID;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }

        private void _LoadData()
        {
            clsPerson Person = clsPerson.Find(_PersonID);
            if (Person == null)
            {
                MessageBox.Show("There isn't Person With ID " + _PersonID + " In The System", "Error Message",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = Person.PersonID.ToString();
            string Name = Person.FirstName + " " + Person.SecondName + " " + Person.LastName;
            lblName.Text = Name;
            lblNationalNo.Text = Person.NationalNo;
            lblGender.Text = Person.Gender.ToString();
            lblEmail.Text = Person.Email;
            lblAddress.Text = Person.Address;
            lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString().ToString();
            lblCountry.Text = Country.Find(Person.NationalityCountryID);
            lblPhone.Text = Person.Phone;
            if (Person.ImagePath != "")
            {
                if (File.Exists(Person.ImagePath))
                    picPerson.ImageLocation = Person.ImagePath;
                else
                    MessageBox.Show("Can't Find Image With This Path" + Person.ImagePath, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdatePerson frm = new AddUpdatePerson(_PersonID);
            frm.Show();
            _LoadData();
        }
    }
}
