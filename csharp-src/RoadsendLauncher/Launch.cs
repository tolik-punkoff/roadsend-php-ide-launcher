using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace RoadsendLauncher
{
    public static class Launch
    {
        public static string Shell = "bin\\sh.exe";
        public static string Params = "--login -c \"cd /pcc/bin && start loon\"";
        public static string ErrorMessage = "";

        public static bool RunIDE()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = CommonFunctions.RoadsendRoot + Shell;
            psi.Arguments = Params;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.CreateNoWindow = true;
            //psi.RedirectStandardOutput = true;

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            return true;
        }
    }
}
