using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVautoGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            else
            {
                string path = System.Reflection.Assembly.GetEntryAssembly()
                    .Location.Replace("TVautoGUI.exe", "ProcessResults.txt");

                StreamWriter file;
                if (!File.Exists(path))
                    file = File.CreateText(path);
                else
                    file = File.AppendText(path);

                file.AutoFlush = true;
                file.WriteLine("Running Process On - " + DateTime.Now.ToString());

                try
                {
                    Util.RunProcessForAllShows(file);
                    file.WriteLine("Process Completed Successfully At - " + DateTime.Now.ToString());
                }
                catch (Exception ex)
                {
                    file.WriteLine("Error in process. Message: " + ex.Message);
                }
                finally
                {
                    file.Flush();
                    file.Close();
                }

                Process.Start(path);
            }
        }
    }
}
