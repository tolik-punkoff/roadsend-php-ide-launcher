using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RoadsendLauncher
{
    public static class CommonFunctions
    {
        public static string RoadsendRoot = "";
        public static string ConfigPath = Application.StartupPath + "\\rootpath";
        public static string ErrorMessage = "";

        public static string[] FileList = new string[] { "bin\\sh.exe",
        "pcc\\bin\\loon.exe"};

        public static bool GetRoot()
        {
            RoadsendRoot = "";
            ErrorMessage = "";
            if (!File.Exists(ConfigPath)) return false;
            
            string[] FileContent = null;
            
            try
            {
                FileContent = File.ReadAllLines(ConfigPath);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            
            foreach (string s in FileContent)
            {
                if (s.Trim() != string.Empty)
                {
                    RoadsendRoot = s.Trim();
                    break;
                }
            }

            if (RoadsendRoot == string.Empty) return false;

            if (Directory.Exists(RoadsendRoot))
            {
                if (!RoadsendRoot.EndsWith("\\")) RoadsendRoot = 
                    RoadsendRoot + "\\";
                
                return true;
            }

            return false;
        }

        public static bool SetRoot(string RootPath)
        {
            ErrorMessage = "";
            RootPath = RootPath.Trim();
            if (RootPath == string.Empty) return false;
            if (!RootPath.EndsWith("\\")) RootPath = RootPath + "\\";
            if (!Directory.Exists(RootPath)) return false;

            try
            {
                File.WriteAllText(ConfigPath, RootPath);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            return true;
        }

        public static bool CheckFile(string FileName)
        {
            return File.Exists(FileName);
        }
        
        public static void ErrMessage(string stMessage)
        {
            MessageBox.Show(stMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowHelp(string AddMessage)
        {
            string help = "Roadsend PHP Studio IDE Launcher for Windows 7\n" +
                "(L) Leha Silent [tolik-punkoff.com] 2018\n" +
                "\n" +
                "Parameters:\n" +
                "--help - This help\n" +
                "--clear - Clear config\n" +
                "--setroot <directory> - Set Roadsend root directory\n" +
                "" +
                "" +
                "" +
                AddMessage;

            MessageBox.Show(help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ClearConfig()
        {
            DialogResult Ans = MessageBox.Show("Are you sure?", "Clear config",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ans != DialogResult.Yes) return;

            if (File.Exists(ConfigPath))
            {
                try
                {
                    File.Delete(ConfigPath);
                }
                catch (Exception ex)
                {
                    ErrMessage(ex.Message);
                }
            }            
        }
    }
}
