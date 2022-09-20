using ApplicationPropertiesSettings;
using KretaDesktop.Localization;
using KretaDesktop.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaDesktop.ViewModel.Content
{
    public class ContentLocalizationViewModel : ViewModelBase
    {
        public string CurrentLanguage
        { 
            get
            {
                CultureProperties cultureProperties = new CultureProperties();
                return cultureProperties.GetCurrentCulture();
            }
        }
        public ObservableCollection<string> AllLanguage { get; set; }

        private string selectedLanguage;

        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set 
            {
                selectedLanguage = value; 
                CultureProperties cultureProperties = new CultureProperties();
                CultureInfo culture = new CultureInfo(SelectedLanguage);
                cultureProperties.SetCurrentCulture(culture);
                OnPropertyChanged(nameof(CurrentLanguage));  

            }
        }


        public ContentLocalizationViewModel()
        {
            ProjectLocalization localization=new ProjectLocalization();
            //AllLanguage = new ObservableCollection<string>(localization.GetSupportedCultures());
            LocalizationProperties localizationProperties = new LocalizationProperties();
            List<string> supportedCulture = localizationProperties.GetSupportedCulture();
            
            AllLanguage = new ObservableCollection<string>(supportedCulture);                      
        }
    }
}
