using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Windows;
using System.Globalization;
using System.Collections;
using System.Threading;
using System.IO;

namespace KretaDesktop.Localization
{
    public class ProjectLocalization
    {
        // https://stackoverflow.com/questions/53441784/showing-different-message-in-multilanguage-dynamically
        // https://stackoverflow.com/questions/45407108/how-to-change-ui-language-using-resource-dictionary-at-run-time
        // https://kontext.tech/article/768/read-embedded-assembly-resource-files-in-net
        // http://www.codedigest.com/CodeDigest/207-Get-All-Language-Country-Code-List-for-all-Culture-in-C---ASP-Net.aspx

        public void SwitchToCurrentCuture()
        {
            var languageDictionary = new ResourceDictionary();

            string currentCultureName = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            string url = GetLocXAMLFilePath(currentCultureName);
            //string url = GetLocXAMLFilePath(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            languageDictionary.Source = new Uri(url, UriKind.Relative);

            int index = GetLanguageDictionaryIndex();
            if (index == -1)
            {
                // Add in newly loaded Resource Dictionary
                Application.Current.Resources.MergedDictionaries.Add(languageDictionary);

            }
            else
            {
                // Replace the current langage dictionary with the new one
                Application.Current.Resources.MergedDictionaries[index] = languageDictionary;
            }
        }

        private int GetLanguageDictionaryIndex()
        {
            int langDictId = -1;
            bool found = false;
            for (int i = 0; i < Application.Current.Resources.MergedDictionaries.Count && !found; i++)
            {
                var md = Application.Current.Resources.MergedDictionaries[i].Source.ToString();
                if (md.Contains("ResourceDictionaryName"))
                {
                    langDictId = i;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                return -1;
            }
            else
            {
                return langDictId;
            }
        }

        private void LoadStringResource(string locale)
        {
            var resources = new ResourceDictionary();

            resources.Source = new Uri("pack://application:,,,/Resources_" + locale + ";component/Strings.xaml", UriKind.Absolute);

            var current = Application.Current.Resources.MergedDictionaries.FirstOrDefault(
                             m => m.Source.OriginalString.EndsWith("Strings.xaml"));


            if (current != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(current);
            }

            Application.Current.Resources.MergedDictionaries.Add(resources);
        }


        private string GetLocXAMLFilePath(string cultureName)
        {
            //String Directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            StringBuilder path = new StringBuilder();
            //path.Append("KretaDesktop");

            // /ValidationProject;component/Resources\\HU\\StringResources.xaml
            //Wpath.Append(";component");
            path.Append("..\\Localization\\Resources\\" + cultureName + "\\StringResources.xaml");
            return path.ToString();
        }

        public string GetStringResource(string stringResourceName)
        {

            string url = GetLocXAMLFilePath(CultureInfo.CurrentCulture.Name);


            string result = string.Empty;
            ResourceDictionary res = Application.LoadComponent(new Uri(url, UriKind.Relative)) as ResourceDictionary;
            if ((res != null) && (res.Contains(stringResourceName)))
                result = res[stringResourceName].ToString();
            return result;

        }

        public List<string> GetSupportedCultures()
        {
            //TODO A lokalizációs nyelvek meghatározása Localization/ mappában lévő fájlok alapján
            List<string> supportedCultures = new List<string>();
           /* foreach (string file in Directory.GetDirectories("..\\Localization\\Resources\\"))
            {
                supportedCultures.Add(file);
            }*/
            return supportedCultures;
            /*if (Application.Current.Resources != null)
            {

            }*/

        }
    }
}

