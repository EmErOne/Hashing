using Hashing.ViewModels;
using Microsoft.Win32;
using System.Windows;

namespace Hashing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        /// <param name="filepath">target file to hash</param>
        public MainView(string filepath)
        {
            InitializeComponent();
            DataContext = new MainViewModel(filepath);
        }
        #endregion

        /// <summary>
        /// Starts the OpenFileDialog to point to a target file to hash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
