
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Savaged.OnScreenRulerLib.Services
{
    public class SettingsService
    {
        private static SettingsService _current;

        public static SettingsService Current =>
            _current ?? (_current = new SettingsService());

        private readonly string _settingsLocation;

        private IDictionary<string, object> _settings;

        private SettingsService()
        {
            var localAppData = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            _settingsLocation = $"{localAppData}\\{GetType().FullName}.json";
            Load();
        }

        public object GetValue(string key)
        {
            object value;
            if (_settings.Keys.Contains(key))
            {
                value = _settings[key];
            }
            else
            {
                value = null;
            }
            return value;
        }

        public void SetValue(KeyValuePair<string, object> setting)
        {
            if (_settings.Keys.Contains(setting.Key))
            {
                _settings[setting.Key] = setting.Value;
            }
            else
            {
                _settings.Add(setting);
            }
            Persist();
        }

        private void Load()
        {
            var fileInfo = new FileInfo(_settingsLocation);
            if (fileInfo.Exists)
            {
                _settings = JsonConvert
                    .DeserializeObject<Dictionary<string, object>>(
                    File.ReadAllText(_settingsLocation));
            }
            else
            {
                _settings = new Dictionary<string, object>();
            }
        }

        private void Persist()
        {
            var json = JsonConvert.SerializeObject(_settings);

            var fileInfo = new FileInfo(_settingsLocation);
            if (fileInfo.Exists)
            {
                File.Delete(_settingsLocation);
            }
            File.WriteAllText(_settingsLocation, json);
        }
    }
}
