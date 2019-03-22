using System;
using System.Windows.Input;

namespace Savaged.OnScreenRulerLib.ViewModels
{
    public abstract class DialogViewModel
    {
        public DialogViewModel()
        {
            CloseCmd = new RelayCommand(OnClose, true);
        }

        public ICommand CloseCmd { get; }

        public Action Close { get; set; }

        protected virtual void OnClose()
        {
            Close?.Invoke();
        }
    }
}
