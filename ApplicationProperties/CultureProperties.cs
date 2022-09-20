using ApplicationPropertiesSettings.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPropertiesSettings
{
    public class CultureProperties
    {
        public void SetCurrentCultureToDefaultCulture()
        {
            string cultureName = GetDefaultCulture(); 
            CultureInfo culture = new CultureInfo(cultureName);
            SetCurrentCulture(culture);

        }

        public void SetCurrentCulture(CultureInfo culture)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }

        public string GetDefaultCulture()
        {
            return Resources.ResourceManager.GetString("CultureInfo");
        }

        public string GetCurrentCulture()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.DisplayName;
        }
    }
}
