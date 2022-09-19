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
    }
}
