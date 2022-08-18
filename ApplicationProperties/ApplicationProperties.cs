using ApplicationPropertiesSettings.Properties;

namespace ApplicationPropertiesSettings
{
    public static class ApplicationProperties
    {
        public static UriBuilder GetAPIUri(UriBuilder uri)
        {
            uri.Scheme = Resources.ResourceManager.GetString("APIScheme");
            uri.Host = Resources.ResourceManager.GetString("APIHost");
            return uri;
        }

        public static string GetDefaultCulture()
        {
            return Resources.ResourceManager.GetString("CultureInfo");
        }
    }
}
