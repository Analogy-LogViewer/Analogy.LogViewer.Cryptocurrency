using Analogy.LogViewer.Template.Managers;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Analogy.LogViewer.Cryptocurrency.Managers
{
    public class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        public string AffirmationsFileSetting { get; private set; } = "AnalogyCryptocurrencySettings.json";
        public CryptocurrencySettings Settings { get; set; }


        public UserSettingsManager()
        {
            if (File.Exists(AffirmationsFileSetting))
            {
                try
                {
                    var settings = new JsonSerializerSettings
                    {
                        ObjectCreationHandling = ObjectCreationHandling.Replace
                    };
                    string data = File.ReadAllText(AffirmationsFileSetting);
                    Settings = JsonConvert.DeserializeObject<CryptocurrencySettings>(data, settings);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogException("Error loading user setting file", ex, "Analogy Cryptocurrency Settings");
                    Settings = new CryptocurrencySettings();

                }
            }
            else
            {
                Settings = new CryptocurrencySettings();
            }

        }

        public void Save()
        {
            try
            {
                File.WriteAllText(AffirmationsFileSetting, JsonConvert.SerializeObject(Settings));
            }
            catch (Exception e)
            {
                LogManager.Instance.LogException("Error saving settings: " + e.Message, e, "Analogy Cryptocurrency Settings");
            }


        }
    }
}