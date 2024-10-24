using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Full_Project.Properties;
using People_BusinessLayer;
using System.IO;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Full_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text.Length == 0 || txbPassword.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Your User Name and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User CurrentUser = User.Find(txbUserName.Text.Trim(), txbPassword.Text.Trim());

            if (CurrentUser == null)
            {
                MessageBox.Show("Invalid User Name or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbUserName.Text = string.Empty;
                txbPassword.Text = string.Empty;
                return;
            }

            if (!User.IsUserActive(txbUserName.Text, txbPassword.Text))
            {
                MessageBox.Show("Your Account is Deactivated, Contact Your Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Correct login:
            RememberUsernameAndPassword(txbUserName.Text, txbPassword.Text);
            ClsGloabl.CurrentUser = CurrentUser;

            this.Hide();
            MainForm frm = new MainForm(this);
            frm.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            bool credentialsFound = GetStoredCredential(ref UserName, ref Password);
            txbUserName.Text = UserName;
            txbPassword.Text = Password;

            // Only check the Remember Me checkbox if credentials were found
            cbRemeberMe.Checked = credentialsFound;
        }

        public void RememberUsernameAndPassword(string Username, string Password)
        {
            string keyvalue = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            if (cbRemeberMe.Checked)
            {
                try
                {
                    Registry.SetValue(keyvalue, "UserName", Username);
                    Registry.SetValue(keyvalue, "Password", Password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    // Open the registry key in read/write mode with explicit registry view
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        using (RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\DVLD", true))
                        {
                            if (key != null)
                            {
                                // Delete the specified values if they exist
                                key.DeleteValue("UserName", false);
                                key.DeleteValue("Password", false);
                            }
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("UnauthorizedAccessException: Run the program with administrative privileges.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        public bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyvalue = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            try
            {
                string UserValue = Registry.GetValue(keyvalue, "UserName", null) as string;
                string PassValue = Registry.GetValue(keyvalue, "Password", null) as string;

                if (!string.IsNullOrEmpty(UserValue) && !string.IsNullOrEmpty(PassValue))
                {
                    Username = UserValue;
                    Password = PassValue;
                    return true; // Credentials found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return false; // No credentials found
        }
    }

}

