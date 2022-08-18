using KretaRazorPages.Static;

namespace KretaRazorPages.Extensions.View
{
    public class FlagExtension
    {
        public string GetFlagSpanClass()
        {
            string flagSpanClass = "<span class=\"fi fi-";
            string currentCulture=AppSettingsControl.GettAppSettings("CurrentCulture");
            if (currentCulture == null)
                currentCulture = ApplicationProperties.GetDefaultCulture();

            flagSpanClass += currentCulture.Substring(0, 2) + "\" id=\"flag\"></span>";
            return flagSpanClass;
        }
    }
}
