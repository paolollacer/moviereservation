using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieReservation
{
    class functionGlobal
    {
        public static void printLogMessage(string logMessage)
        {
            string logEntry;
            string logsFolderPath;

            try
            {
                if (logMessage == "")
                    return;

                logEntry = "";
                logsFolderPath = Application.StartupPath + "\\Logs\\";

                if (!(System.IO.Directory.Exists(logsFolderPath)))
                    System.IO.Directory.CreateDirectory(logsFolderPath);

                if (File.Exists(logsFolderPath + $"{Application.ProductName}.txt"))
                    logEntry = File.ReadAllText(logsFolderPath + $"{Application.ProductName}.txt");

                using (StreamWriter w = File.CreateText(logsFolderPath + $"{Application.ProductName}.txt"))
                {
                    logEntry += $"[{DateTime.Now}] {logMessage}\n";
                    w.Write(logEntry);
                    w.Close();
                }
            }
            catch (Exception)
            { }
        }
    }
}
