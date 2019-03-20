using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace Savaged.OnScreenRulerLib.ViewModels
{
    public abstract class DialogViewModel
    {
        public DialogViewModel()
        {
            CloseCmd = new RelayCommand(OnClose);
        }

        public ICommand CloseCmd { get; }

        public Action Close { get; set; }

        protected void OnClose()
        {
            Close?.Invoke();
        }
    }
}
