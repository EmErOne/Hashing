using System.Windows;

namespace Hashing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Method that is used to start the app. It reads out whether a file is pointed to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainView wnd;
            if (e.Args.Length == 1)
            {
                string filepath = e.Args[0];
                wnd = new MainView(filepath);
            }
            else
            {
                wnd = new MainView();
            }

            wnd.Show();
        }
    }
}
