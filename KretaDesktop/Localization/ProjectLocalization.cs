using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Windows;
using System.Globalization;
using System.Collections;
using System.Resources;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Diagnostics;

namespace ValidationProject.Static
{
    public class ProjectLocalization
    {
        // https://stackoverflow.com/questions/53441784/showing-different-message-in-multilanguage-dynamically


        public void SwitchToCurrentCutureLanguage()
        {
            var languageDictionary = new ResourceDictionary();
            string url = GetLocXAMLFilePath(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
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

        /*public void SwitchToCurrentCutureLanguage()
        {
            string path = GetLocXAMLFilePath(CultureInfo.CurrentCulture.Name);
            SwitchLanguage(path);
        }*/

        private void SwitchLanguage(string path)
        {
           /* if (CultureInfo.CurrentCulture.Name.Equals(inFiveCharLang))
                return;*/

            /*var ci = new CultureInfo(inFiveCharLang);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;*/

            SetLanguageResourceDictionary(path);
            /*if (null != LanguageChangedEvent)
            {
                LanguageChangedEvent(this, new EventArgs());
            }*/
        }
    

        private string GetLocXAMLFilePath(string cultureName)
        {
            //String Directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            StringBuilder path=new StringBuilder();
            //path.Append("KretaDesktop");

            // /ValidationProject;component/Resources\\HU\\StringResources.xaml
            //Wpath.Append(";component");
            path.Append("..\\Localization\\Resources\\" + cultureName + "\\StringResources.xaml");            
            return path.ToString();
        }

        private void SetLanguageResourceDictionary(String inFile)
        {
            if (!File.Exists(inFile))
            {
                // Read in ResourceDictionary File
                var languageDictionary = new ResourceDictionary();
                languageDictionary.Source = new Uri(inFile, UriKind.Relative);

                // Remove any previous Localization dictionaries loaded
                int langDictId = -1;
                for (int i = 0; i < Application.Current.Resources.MergedDictionaries.Count; i++)
                {
                    var md = Application.Current.Resources.MergedDictionaries[i];
                    // Make sure your Localization ResourceDictionarys have the ResourceDictionaryName
                    // key and that it is set to a value starting with "Loc-".
                    if (md.Contains("ResourceDictionaryName"))
                    {
                        if (md["ResourceDictionaryName"].ToString().StartsWith("Loc-"))
                        {
                            langDictId = i;
                            break;
                        }
                    }
                }
                if (langDictId == -1)
                {
                    // Add in newly loaded Resource Dictionary
                    Application.Current.Resources.MergedDictionaries.Add(languageDictionary);
                }
                else
                {
                    // Replace the current langage dictionary with the new one
                    Application.Current.Resources.MergedDictionaries[langDictId] = languageDictionary;
                }
            }
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
    }
}
