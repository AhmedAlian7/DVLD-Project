using DVLD_Full_Project.Properties;
using People_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class AddUpdatePerson : Form
    {
        public delegate void DataBack(object sender, int num);
        public event DataBack DB;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PersonID =-1;
        clsPerson _Person = new clsPerson();

        public AddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public AddUpdatePerson(int ID)
        {
            InitializeComponent();
            _PersonID = ID;
            _Mode = enMode.Update;


        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void tbxFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxFirstName.Text))
            {

                errorProvider1.SetError(tbxFirstName, "Enter First Name!");
            }
            else
            {
                errorProvider1.SetError(tbxFirstName, "");

            }
        }
        private void tbxSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSecondName.Text))
            {
                errorProvider1.SetError(tbxSecondName, "Enter Second Name!");
            }
            else
            {
                errorProvider1.SetError(tbxSecondName, "");

            }
        }
        private void tbxLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxLastName.Text))
            {

                errorProvider1.SetError(tbxLastName, "Enter Last Name!");
            }
            else
            {
                errorProvider1.SetError(tbxLastName, "");

            }
        }
        private void tbxNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbxNationalNo, null);
            }

            //Make sure the national number is not used by another person
            if (tbxNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsExist(tbxNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbxNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(tbxNationalNo, null);
            }
        }
        private bool IsValidEmail(string email)
        {
            // Regular expression for email validation
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
        private bool IsValidPhone(string email)
        {
            string pattern = @"^\+?[\d-().\s]{9,}$";
            return Regex.IsMatch(email, pattern);
        }
        private void txbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txbEmail.Text.Trim() == "")
                return;

            //validate email format
            if (IsValidEmail(txbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txbEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txbEmail, null);
            }
        }
        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxPhone.Text))
            {
                e.Cancel = true;
                tbxPhone.Focus();
                errorProvider1.SetError(tbxPhone, "Enter Phone Number!");
            }
            else if (!IsValidPhone(tbxPhone.Text))
            {
                e.Cancel = true;
                tbxPhone.Focus();
                errorProvider1.SetError(tbxPhone, "Invalide Phone Number!");
            }
            else
            {
                errorProvider1.SetError(tbxPhone, "");

            }
        }
        private void txbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbAddress.Text))
            {
                e.Cancel = true;
                txbAddress.Focus();
                errorProvider1.SetError(txbAddress, "Enter Address!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txbAddress, "");
            }
        }
        private void linkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png";
            openFileDialog.Title = "Select an Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image
                string imagePath = openFileDialog.FileName;
                Image image = Image.FromFile(imagePath);

                // Set the image to the PictureBox
                picPerson.Image = image;

                lnlRemoveImage.Visible = true;
            }
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = Country.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);

            }

        }

        private void InitialFormInfo()
        {
            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New Person";
                lblMode.Text = "Add New Person";
            }
            else
            {
                lblMode.Text = "Update Person";
                this.Text = "Update Person";
            }

            rdbMale.Checked = true;

            if (picPerson.ImageLocation == null)
                    lnlRemoveImage.Visible = false;

            // Validate DateOfBirth To Set By Age > 18
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            cbCountries.SelectedIndex = 50;
        }
        private void _LoadPersonData()
        {
            _Person = clsPerson.Find(_PersonID);

            // Make Sure That Person Is Exist
            if (_Person == null)
            {
                MessageBox.Show("There isn't Person With ID " + _PersonID + " In The System", "Error Message",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lbPersonId.Text = _Person.PersonID.ToString();
            tbxFirstName.Text = _Person.FirstName;
            tbxSecondName.Text = _Person.SecondName;
            tbxLastName.Text = _Person.LastName;
            tbxNationalNo.Text = _Person.NationalNo;
            txbEmail.Text = _Person.Email;
            txbAddress.Text = _Person.Address;
            tbxPhone.Text = _Person.Phone;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Gender == "Female")
                 rdbFemale.Checked = true;
            else
                rdbMale.Checked = true;

            if (_Person.ImagePath != "")
            {
                picPerson.ImageLocation = _Person.ImagePath;
                lnlRemoveImage.Visible = true;
            }



        }
        private void AddUpdatePerson_Load(object sender, EventArgs e)
        {
            InitialFormInfo();

            if (_Mode == enMode.Update)
                _LoadPersonData();
        }

        private void rdbMale_CheckedChanged_1(object sender, EventArgs e)
        {
            picPerson.Image = Resources.UnknownMale;

        }
        private void rdbFemale_CheckedChanged_1(object sender, EventArgs e)
        {
            picPerson.Image = Resources.UnknownFemale;

        }

        private bool _HandleImage()
        {
            if (_Person.ImagePath != picPerson.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    File.Delete(_Person.ImagePath);
                }

                if(picPerson.ImageLocation != null)
                {
                    string ImagePath = picPerson.ImageLocation.ToString();  

                    if(clsUtil.CopyImageToProjectFolder(ref ImagePath))
                    {
                        picPerson.ImageLocation = ImagePath;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Can't Save Image!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnSaved_Click(object sender, EventArgs e)
        {
            // Make sure that all input is added
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Add All required Information", "Failed",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleImage())
                return;

            _Person.FirstName = tbxFirstName.Text.Trim();
            _Person.SecondName = tbxSecondName.Text.Trim();
            _Person.LastName = tbxLastName.Text.Trim();
            _Person.NationalNo = tbxNationalNo.Text.Trim();
            if (rdbMale.Checked)
                _Person.Gender = "Male";
            else
                _Person.Gender = "Female";
            _Person.Email = txbEmail.Text.Trim();
            _Person.Address = txbAddress.Text.Trim();
            _Person.Phone = tbxPhone.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = Country.Find(cbCountries.Text);

            if (picPerson.ImageLocation != null)
                    _Person.ImagePath = picPerson.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                if(MessageBox.Show("Person Added Successfully", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                if (MessageBox.Show("Added Failed", "Fail",
                    MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    this.Close();
                }
            }

            DB?.Invoke(this, _Person.PersonID);

        }
        private void btnCansled_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lnlRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to remove person's image?","Confirmation",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            { 
                if (rdbMale.Checked)
                    picPerson.Image = Resources.UnknownMale;
                else
                    picPerson.Image = Resources.UnknownFemale;
                lnlRemoveImage.Visible = false;
            }

        }
    }
}
