using Savaged.OnScreenRulerLib.Models;
using Savaged.OnScreenRulerLib.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
                mainViewModel.ColourChanged += OnColourChanged;
                mainViewModel.Close = new Action(Close);
                mainViewModel.Load();
            }
        }

        private void OnColourChanged(object sender, ColourChangedEventArgs e)
        {
            var converter = new BrushConverter();
            var brush = (SolidColorBrush)converter.ConvertFromString(e.Colour);
            ContentGrid.Background = brush;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (DataContext is MainViewModel mainViewModel
                && e.WidthChanged)
            {
                double delta;
                if (e.PreviousSize.Width < e.NewSize.Width)
                {
                    delta = e.NewSize.Width - e.PreviousSize.Width;
                }
                else
                {
                    delta = e.PreviousSize.Width - e.NewSize.Width;
                }
                if (delta > 100)
                {
                    var size = e.NewSize;
                    var length = size.Width;
                    mainViewModel.ChangeLength(length);
                }
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (DataContext is MainViewModel mainViewModel)
            {
                mainViewModel.ColourChanged -= OnColourChanged;
                mainViewModel.Close = null;
            }
        }

        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // TODO allow drag window
        }
    }
}
