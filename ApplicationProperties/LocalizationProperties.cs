using ApplicationPropertiesSettings.Properties;
using CommunityToolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPropertiesSettings
{
    public class LocalizationProperties
    {
        // AppConfigControl -> App.config
        // Resources.ResourceManager -> Resources.resx

        // https://stackoverflow.com/questions/41493636/where-does-visual-studio-put-user-app-config-files-settings

        const string supportedCulture = "SupportedCulture";

        public List<string> GetSupportedCulture()
        {
            List<string> supportedCultures = AppConfigControl.getAppSettingsToList(supportedCulture);
            if (supportedCultures == null)
            {
                supportedCultures = GetSupportedCutureFromResourcesToList();
                AppConfigControl.AddOrUpdateAppSettings(supportedCulture, GetSupportedCutureFromResourcesToString());
            }
            return supportedCultures;
        }

        private string GetSupportedCutureFromResourcesToString()
        {
            string supportedCulture = Resources.ResourceManager.GetString(LocalizationProperties.supportedCulture);
            return supportedCulture;
        }

        private List<string> GetSupportedCutureFromResourcesToList()
        {
            string supportedCulture = GetSupportedCutureFromResourcesToString();
            List<string> result = new List<string>();

            foreach (var token in supportedCulture.Tokenize(','))
            {
                result.Add(token.ToString());
            }
            return result;
        }
    }
}
