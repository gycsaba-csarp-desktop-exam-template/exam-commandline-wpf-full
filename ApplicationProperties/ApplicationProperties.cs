using ApplicationPropertiesSettings.Properties;
using CommunityToolkit.HighPerformance;

namespace ApplicationPropertiesSettings
{
    // Application properties - Resources.resx
    public static class ApplicationProperties
    {        
        public static UriBuilder GetAPIUri(UriBuilder uri)
        {
            uri.Scheme = Resources.ResourceManager.GetString("APIScheme");
            uri.Host = Resources.ResourceManager.GetString("APIHost");
            string port = Resources.ResourceManager.GetString("APIPort");
            if (!string.IsNullOrEmpty(port))
                uri.Port = int.Parse(port);
            return uri;
        }

        public static string GetDefaultCulture()
        {
            return Resources.ResourceManager.GetString("CultureInfo");
        }

        public static string GetPossibleNumberOfRowOnTheDataGridTableToString()
        {
            string rowPerPageData = Resources.ResourceManager.GetString("GetPossibleNumberOfRowOnTheDataGridTable");
            return rowPerPageData;
        }

        public static List<string> GetPossibleNumberOfRowOnTheDataGridTableToList()
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
