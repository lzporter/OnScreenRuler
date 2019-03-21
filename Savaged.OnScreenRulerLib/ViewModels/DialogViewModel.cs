using System;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Savaged.OnScreenRulerLib.ViewModels
{
    public abstract class DialogViewModel : ViewModelBase
    {
        public DialogViewModel()
        {
            CloseCmd = new RelayCommand(OnClose);
        }

        public ICommand CloseCmd { get; }

        public Action Close { get; set; }

        protected virtual void OnClose()
        {
            Close?.Invoke();
        }
    }
}
