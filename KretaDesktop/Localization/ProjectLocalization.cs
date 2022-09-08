using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Windows;
using System.Globalization;
using System.Collections;

namespace ValidationProject.Static
{
    public class ProjectLocalization
    {

        public string GetStringResource(string stringResourceName)
        {

            //string appName = Assembly.GetEntryAssembly().GetName().Name;
            string appName = "KretaDesktop";

            // /ValidationProject;component/Resources\\HU\\StringResources.xaml
            string url = appName + ";component/";
            url += "/Localization\\Resources\\" + CultureInfo.CurrentCulture.Name + "\\StringResources.xaml";


            string result = string.Empty;
            ResourceDictionary res = Application.LoadComponent(new Uri(url, UriKind.Relative)) as ResourceDictionary;
            if ((res != null) && (res.Contains(stringResourceName)))
                result = res[stringResourceName].ToString();
            return result;

        }
    }
}
