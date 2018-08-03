using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RoadsendLauncher
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        int Item = 0;
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            lvMessages.Items.Add("Checking root directory...");
            if (!CommonFunctions.GetRoot())
            {
                lvMessages.Items[Item].Text += "ERROR";
                lvMessages.Items[Item].ForeColor = Color.Red;
                if (CommonFunctions.ErrorMessage != string.Empty)
                {
                    CommonFunctions.ErrMessage(CommonFunctions.ErrorMessage);
                }
                
                SelectDir();
                return;
            }
            else
            {
                lvMessages.Items[Item].Text += "OK";
                lvMessages.Items[Item].ForeColor = Color.Lime;
            }
            Item++;
            lvMessages.Items.Add("Checking files...");
            Item++;

            bool checkerror = false;
            foreach (string filename in CommonFunctions.FileList)
            {
                string filepath = CommonFunctions.RoadsendRoot + filename;
                lvMessages.Items.Add(filename+"...");
                if (!CommonFunctions.CheckFile(filepath))
                {
                    checkerror = true;
                    lvMessages.Items[Item].Text += "ERROR";
                    lvMessages.Items[Item].ForeColor = Color.Red;
                }
                else
                {
                    lvMessages.Items[Item].Text += "OK";
                    lvMessages.Items[Item].ForeColor = Color.Lime;
                }
                Item++;
            }

            if (checkerror)
            {
                DialogResult Ans = MessageBox.Show("Select Roadsend root directory?",
                    "Files not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Ans == DialogResult.Yes)
                {
                    SelectDir();
                    return;
                }
                else
                {
                    return;
                }
            }
            
            lvMessages.Items.Add("Launch...");
            //Item++;

            if (!Launch.RunIDE())
            {
                lvMessages.Items[Item].Text += "ERROR";
                lvMessages.Items[Item].ForeColor = Color.Red;

                CommonFunctions.ErrMessage(Launch.ErrorMessage);
                return;
            }
            else
            {
                lvMessages.Items[Item].Text += "OK";
                lvMessages.Items[Item].ForeColor = Color.Lime;
                //System.Threading.Thread.Sleep(15000);
                Application.Exit();
            }
        }
        //-------------
        private void SelectDir()
        {
            frmSelectDir fSD = new frmSelectDir();
            DialogResult Ans = fSD.ShowDialog();
            if (Ans == DialogResult.OK)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
