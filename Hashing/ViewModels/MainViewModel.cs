using Hashing.Commands;
using Hashing.Core;
using Hashing.Service;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Hashing.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        /// <summary>
        /// The Install Service to install the tool inside the registry
        /// </summary>
        private readonly InstallService installService;

        /// <summary>
        /// Visible value for the target file to hash
        /// </summary>
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (value != filePath)
                {
                    filePath = value;
                    Calculate();
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        ///  Visible value for the MD5 Hash
        /// </summary>
        private String md5Hash;
        public String MD5Hash
        {
            get { return md5Hash; }
            set
            {
                md5Hash = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Visible value for the SHA256 Hash 
        /// </summary>
        private string sha256;
        public string SHA256Hash
        {
            get { return sha256; }
            set
            {
                sha256 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Visible value for the SHA512 Hash
        /// </summary>
        private string sha512;
        public string SHA512Hash
        {
            get { return sha512; }
            set
            {
                sha512 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand InstallAppCommand { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            FilePath = null;
            InstallAppCommand = new RelayCommand(InstallAppExecute, InstallAppCanExecute);
            installService = new InstallService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="filePath">Path to the target File for hashing</param>
        public MainViewModel(string filePath)
        {
            FilePath = filePath;
            InstallAppCommand = new RelayCommand(InstallAppExecute, InstallAppCanExecute);
            installService = new InstallService();
        }
        #endregion

        /// <summary>
        /// Defines the method that calculates and displays all hashes.
        /// </summary>
        private void Calculate()
        {
            CleanUpHashValues();

            if (File.Exists(filePath))
            {
                try
                {
                    MD5Calculator mD5 = new MD5Calculator(filePath);
                    MD5Hash = mD5.Calculate();

                    SHA256Calculator sHA256 = new SHA256Calculator(filePath);
                    SHA256Hash = sHA256.Calculate();

                    SHA512Calculator sHA512 = new SHA512Calculator(filePath);
                    SHA512Hash = sHA512.Calculate();
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "Hashing", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show(e.Message, "Hashing", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Defines the method that removes all shown hashes
        /// </summary>
        private void CleanUpHashValues()
        {
            MD5Hash = string.Empty;
            SHA256Hash = string.Empty;
            SHA512Hash = string.Empty;
        }

        /// <summary>
        /// Defines the method that starts the installation.
        /// </summary>
        /// <param name="obj"></param>
        private void InstallAppExecute(object obj)
        {
            installService.Install();
        }

        /// <summary>
        /// Defines the method that decides whether the installation can be carried out
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        private bool InstallAppCanExecute(object obj)
        {
            return installService.CanInstall();
        }
    }
}
