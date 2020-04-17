using Microsoft.Win32;
using System;
using System.Windows;

namespace HashingWindowsInstaller
{
    class Program
    {
        /// <summary>
        /// Installs a new key in the windows-registry.
        /// </summary>
        /// <param name="args">Path in which Hashing.exe is located</param>
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string filePath = args[0];

                RegistryKey key = null;
                try
                {
                    key = Registry.ClassesRoot.CreateSubKey(@"*\shell\Hashing-Tool");
                    key.SetValue("Icon", filePath);
                    key = Registry.ClassesRoot.CreateSubKey(@"*\shell\Hashing-Tool\command");
                    key.SetValue("", filePath + " \"%1\"", RegistryValueKind.String);
                    MessageBox.Show("Installation was successful.", "Hashing-Windows-Installer", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hashing-Windows-Installer", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (key != null)
                    {
                        key.Close();
                    }
                }
            }
        }
    }
}
