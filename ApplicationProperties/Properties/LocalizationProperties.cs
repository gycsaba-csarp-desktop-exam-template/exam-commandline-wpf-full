using CommunityToolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPropertiesSettings.Properties
{
    public class LocalizationProperties
    {
        // AppConfigControl -> App.config
        // Resources.ResourceManager -> Resources.resx

        public List<string> GetSupportedCulture()
        {
            List<string> supportedCultures = AppConfigControl.getAppSettingsToList("SupportedCulture");
            if (supportedCultures == null)
            {
                supportedCultures = GetSupportedCutureFromResourcesToList();
                AppConfigControl.AddOrUpdateAppSettings("PossibleNumberOfElementsOnDataGridTable", GetSupportedCutureFromResourcesToString());
            }
            return supportedCultures;
        }

        public string GetSupportedCutureFromResourcesToString()
        {
            string rowPerPageData = Resources.ResourceManager.GetString("GetPossibleNumberOfRowOnTheDataGridTable");
            return rowPerPageData;
        }

        public static List<string> GetSupportedCutureFromResourcesToList()
        {
            string rowPerPageData = Resources.ResourceManager.GetString("GetPossibleNumberOfRowOnTheDataGridTable");
            List<string> result = new List<string>();

            foreach (var token in rowPerPageData.Tokenize(','))
            {
                result.Add(token.ToString());
            }
            return result;
        }
    }
}
