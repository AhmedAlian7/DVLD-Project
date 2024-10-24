using DVLD_Full_Project.Properties;
using People_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class ctrPersonCard : UserControl
    {

        private clsPerson _Person = new clsPerson();
        public int PersonID { get { return _Person.PersonID; } }
        public clsPerson PersonInfo {  get { return _Person; } }

        public void LoadPersonInfo(int ID)
        {
            _Person = clsPerson.Find(ID);

            if( _Person == null )
            {
                MessageBox.Show("Can't Find Person With ID = " + ID,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();
            string Name = _Person.FirstName + " " + _Person.SecondName + " " + _Person.LastName;
            lblName.Text = Name;
            lblNationalNo.Text = _Person.NationalNo;
            lblGender.Text = _Person.Gender.ToString();
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString().ToString();
            lblCountry.Text = Country.Find(_Person.NationalityCountryID);
            lblPhone.Text = _Person.Phone;
            if (_Person.ImagePath != "")
            {
                if(File.Exists(_Person.ImagePath))
                    picPerson.ImageLocation = _Person.ImagePath;
            }
            else
            {
                if (_Person.Gender == "Male")
                    picPerson.Image = Resources.UnknownMale;
                else
                    picPerson.Image = Resources.UnknownFemale;
            }

        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                MessageBox.Show("Can't Find Person With NationalNo = " + NationalNo, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();
            string Name = _Person.FirstName + " " + _Person.SecondName + " " + _Person.LastName;
            lblName.Text = Name;
            lblNationalNo.Text = _Person.NationalNo;
            lblGender.Text = _Person.Gender.ToString();
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString().ToString();
            lblCountry.Text = Country.Find(_Person.NationalityCountryID);
            lblPhone.Text = _Person.Phone;
            if (_Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                    picPerson.ImageLocation = _Person.ImagePath;
            }
            else
            {
                if (_Person.Gender == "Male")
                    picPerson.Image = Resources.UnknownMale;
                else
                    picPerson.Image = Resources.UnknownFemale;
            }

        }

        public ctrPersonCard()
        {
            InitializeComponent();
        }

        private void linkEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdatePerson frm = new AddUpdatePerson(PersonID);
            frm.Show();
            LoadPersonInfo(PersonID);
        }
    }
}
