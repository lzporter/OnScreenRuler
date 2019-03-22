using System;
using System.Windows.Input;

namespace Savaged.OnScreenRulerLib.ViewModels
{
    /// <Summary>
    /// Copied from the docs below and slightly altered
    /// https://docs.microsoft.com/en-us/dotnet/standard/cross-platform/using-portable-class-library-with-model-view-view-model
    /// </Summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _handler;
        private bool _isEnabled;

        public RelayCommand(Action handler, bool isEnabled = false)
        {
            _handler = handler;
            _isEnabled = isEnabled;
        }

        public bool IsEnabled
        {
            get => _isEnabled; 
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _handler();
        }
    }
}