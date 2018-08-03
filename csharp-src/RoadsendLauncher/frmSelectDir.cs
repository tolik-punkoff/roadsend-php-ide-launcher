using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RoadsendLauncher
{
    public partial class frmSelectDir : Form
    {
        public frmSelectDir()
        {
            InitializeComponent();
        }

        private void frmSelectDir_Load(object sender, EventArgs e)
        {
            dlgPath.RootFolder = Environment.SpecialFolder.MyComputer;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult Ans = dlgPath.ShowDialog();
            if (Ans == DialogResult.OK)
            {
                txtPath.Text = dlgPath.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CommonFunctions.SetRoot(txtPath.Text))
            {
                if (CommonFunctions.ErrorMessage != string.Empty)
                {
                    CommonFunctions.ErrMessage(CommonFunctions.ErrorMessage);
                    return;
                }
            }
            
            this.Close();
        }
    }
}
