
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace KretaRazorPages.Static
{
    public class AppSettingsControl
    {
        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {

            }
        }

        public static string? GettAppSettings(string key)
        {
            try
            {
                var configFile=ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var setting = configFile.AppSettings.Settings;
                if (setting.AllKeys.Contains(key))
                    return setting[key].Value;              
            }
            catch (ConfigurationErrorsException)
            {               
            }
            return null;
        }
    }
}
