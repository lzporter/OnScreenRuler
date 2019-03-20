using GalaSoft.MvvmLight.Command;
using Savaged.OnScreenRulerLib.Models;
using Savaged.OnScreenRulerLib.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Savaged.OnScreenRulerLib.ViewModels
{
    public class MainViewModel : DialogViewModel
    {
        private const string ColourKey = "Colour";

        public MainViewModel()
        {
            ChangeColourCmd = new RelayCommand<string>(OnChangeColour);
        }

        public void Load()
        {
            LoadColour();
        }

        public ICommand ChangeColourCmd { get; }

        public event EventHandler<ColourChangedEventArgs> ColourChanged = delegate { };

        private void OnChangeColour(string colour)
        {
            ColourChanged?.Invoke(this, new ColourChangedEventArgs(colour));
            var setting = new KeyValuePair<string, object>(ColourKey, colour);
            SettingsService.Current.SetValue(setting);
        }

        private void LoadColour()
        {
            var value = SettingsService.Current.GetValue(ColourKey);
            if (value != null && value is string colour)
            {
                OnChangeColour(colour);
            }
        }

        protected override void OnClose()
        {
            SettingsService.Current.Persist();
            base.OnClose();
        }
    }
}
