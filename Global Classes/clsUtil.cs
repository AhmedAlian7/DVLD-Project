using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    internal class clsUtil
    {
        static string GetPictureNameAsGUID(string FileName)
        {
            FileInfo file = new FileInfo(FileName);
            Guid giud = Guid.NewGuid();

            return giud + file.Extension;
        }
        static bool CreateFolder(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
        }
        public static bool CopyImageToProjectFolder(ref string filepath)
        {
            string FolderPath = @"C:\DVLD-People-Images\";
            
            if(!CreateFolder(FolderPath))
            {
                return false;
            }

            string ImageNewPath = FolderPath + GetPictureNameAsGUID(filepath);

            try
            {
                File.Copy(filepath, ImageNewPath, true);
            }
            catch
            {
                MessageBox.Show("Can't Save Image!","Fail",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}
