using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;

using Savaged.OnScreenRulerLib.ViewModels;

namespace Savaged.OnSreenRuler
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSourceInitialized(object sender, EventArgs e)
        {
            if (DataContext is MainViewModel mainViewModel)
            {
                mainViewModel.Close = new Action(Close);
                mainViewModel.Load();
            }
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
