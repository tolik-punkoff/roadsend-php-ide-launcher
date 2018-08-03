using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RoadsendLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] cli = Environment.GetCommandLineArgs();
            if (cli.Length > 1)
            {
                switch (cli[1])
                {
                    case "--help":
                        {
                            CommonFunctions.ShowHelp("");
                        }; break;
                    case "--clear":
                        {
                            CommonFunctions.ClearConfig();
                        }; break;
                    case "--setroot":
                        {
                            if (cli.Length > 2)
                            {
                                if (!CommonFunctions.SetRoot(cli[2]))
                                {
                                    CommonFunctions.ErrMessage("Can't set " +
                                        cli[2] + " as Roadsend root " +
                                        CommonFunctions.ErrorMessage);
                                }
                            }
                            else
                            {
                                CommonFunctions.ShowHelp("\n No directory parameter!");
                            }
                        }; break;
                    default:
                        {
                            CommonFunctions.ShowHelp("\n Wrong parameter: "+cli[1]);
                        }; break;
                }
            }
            else
            {
                Application.Run(new frmMain());
            }
        }
    }
}
