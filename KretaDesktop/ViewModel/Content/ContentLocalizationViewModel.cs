using ApplicationPropertiesSettings;
using KretaDesktop.Localization;
using KretaDesktop.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaDesktop.ViewModel.Content
{
    public class ContentLocalizationViewModel : ViewModelBase
    {
        public string CurrentLanguage{ get; set; }
        public ObservableCollection<string> AllLanguage { get; set; }

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
