using System.Windows;

using Savaged.OnScreenRulerLib.ViewModels;

namespace Savaged.OnSreenRuler
{
    public partial class App : Application
    {
        private MainWindow _main;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _main = new MainWindow
            {
                DataContext = ViewModelLocator.Current.MainViewModel
            };            
            _main.Show();
        }
    }
}
