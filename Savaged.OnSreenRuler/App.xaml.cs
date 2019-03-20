using Savaged.OnScreenRulerLib.ViewModels;
using System.Windows;

namespace Savaged.OnSreenRuler
{
    public partial class App : Application
    {
        private MainWindow _main;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainViewModel = new MainViewModel();
            _main = new MainWindow
            {
                DataContext = mainViewModel
            };            
            _main.Show();
        }
    }
}
