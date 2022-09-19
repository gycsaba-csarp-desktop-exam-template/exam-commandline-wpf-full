using KretaDesktop.ViewModel.BaseClass;
using KretaDesktop.ViewModel.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaDesktop.ViewModel
{
    public class HeaderAppConfigurationViewModel : HeaderViewModel
    {
        private RelayCommand UpdateContentViewCommand { get; }
       
        public HeaderAppConfigurationViewModel()
        {
            UpdateContentViewCommand = new RelayCommand(parameter => UpdateContentView(parameter));            
            HeaderAppName = new HeaderAppNameViewModel();

            //SelectedView = new ContentListSubjectViewModel();
        }

        public void UpdateContentView(object parameter)
        {
            if (parameter is string)
            {
                if (parameter.ToString() == "Localization")
                {
                    SelectedView = new ContentLocalicationViewModel();
                }
            }
        }
    }
}
