using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Hashing.Service
{
    public class InstallService
    {
        /// <summary>
        /// Path to the exe-file
        /// </summary>
        private readonly string exePath;
        /// <summary>
        /// Path to HashingWindowsInstaller.exe
        /// </summary>
        private readonly string installerPath;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallService"/> class.
        /// </summary>
        public InstallService()
        {
            installerPath = AppDomain.CurrentDomain.BaseDirectory + @"HashingWindowsInstaller.exe";

            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var exeTempPath = location.Substring(0, location.Length - 3) + "exe";
            exePath = "\"" + exeTempPath + "\"";
        }
        #endregion

        /// <summary>
        /// Defines the method by which HashingWindowsInstaller.exe is started to install registry keys.
        /// </summary>
        public void Install()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = installerPath,
                Arguments = exePath,
                Verb = "runas",
                UseShellExecute = true
            };
            process.StartInfo = startInfo;

            try
            {
                process.Start();
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        /// <summary>
        /// Defines the method that checks whether the HashingWindowsInstaller.exe is present.
        /// </summary>
        /// <returns></returns>
        public bool CanInstall()
        {
            return File.Exists(installerPath);
        }
    }
}
