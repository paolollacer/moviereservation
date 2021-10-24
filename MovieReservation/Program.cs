using MovieReservation.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieReservation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (!File.Exists(Application.StartupPath + "\\Readme.txt"))
                    File.WriteAllText(Application.StartupPath + "\\Readme.txt", Properties.Resources.Readme);

                if (!File.Exists(Application.StartupPath + "\\settings.txt"))
                    File.WriteAllText(Application.StartupPath + "\\settings.txt", Properties.Resources.settings);

                if (!File.Exists(Application.StartupPath + "\\MySql.Data.dll"))
                    File.WriteAllBytes(Application.StartupPath + "\\MySql.Data.dll", Properties.Resources.MySql_Data);

                Dictionary<string, string> dic = File.ReadAllLines(Application.StartupPath +
                                                @"\\settings.txt").Select(l => l.Split(new[] { '=' },
                                                2)).ToDictionary(s => s[0].ToUpper().Trim(), s => s[1].Trim());

                classGlobalVariables.Server = dic["SERVER"];

                try { classGlobalVariables.Sqlport = dic["SQLPORT"]; }
                catch { classGlobalVariables.Sqlport = "3306"; };

                classGlobalVariables.Username = dic["USERNAME"];
                classGlobalVariables.Password = dic["PASSWORD"];
                classGlobalVariables.Database = dic["DATABASE"];

                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                functionGlobal.printLogMessage(ex.ToString());
                MessageBox.Show("An error was encountered while starting up application. Please check your logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
