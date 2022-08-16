using KretaRazorPages.Properties;

namespace KretaRazorPages.Static
{
    public static class ApplicationProperties
    {
        public static UriBuilder GetAPIUri(UriBuilder uri)
        {
            uri.Scheme = Resources.ResourceManager.GetString("APIScheme");
            uri.Host = Resources.ResourceManager.GetString("APIHost");
            return uri;
        }

    }
}
