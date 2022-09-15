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
            System.Threading.Thread.CurrentThread.CurrentCulture=new CultureInfo(cultureName);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
        }

        public string GetDefaultCulture()
        {
            return Resources.ResourceManager.GetString("CultureInfo");
        }
    }
}
