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
        private const string LengthKey = "Length";
        private const string ColourKey = "Colour";

        private double _length;

        public MainViewModel()
        {
            ChangeColourCmd = new RelayCommand<string>(OnChangeColour);
        }

        public void Load()
        {
            LoadColour();
            LoadLength();
        }

        public void ChangeLength(double length)
        {
            var setting = new KeyValuePair<string, object>(LengthKey, (int)length);
            SettingsService.Current.SetValue(setting);
            Length = length;
        }

        public double Length
        {
            get => _length;
            set => Set(ref _length, value);
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

        private void LoadLength()
        {
            var value = SettingsService.Current.GetValue(LengthKey);
            if (value != null && value is double length)
            {
                ChangeLength(length);
            }
        }

        protected override void OnClose()
        {
            SettingsService.Current.Persist();
            base.OnClose();
        }
    }
}
