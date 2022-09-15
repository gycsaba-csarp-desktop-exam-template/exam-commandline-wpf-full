using ApplicationPropertiesSettings.Properties;
using CommunityToolkit.HighPerformance;

namespace ApplicationPropertiesSettings
{
    // Application properties - Resources.resx
    public class APIUriProperties
    {        
        public UriBuilder GetAPIUri(UriBuilder uri)
        {
            uri.Scheme = Resources.ResourceManager.GetString("APIScheme");
            uri.Host = Resources.ResourceManager.GetString("APIHost");
            string port = Resources.ResourceManager.GetString("APIPort");
            if (!string.IsNullOrEmpty(port))
                uri.Port = int.Parse(port);
            return uri;
        }
    }
}
