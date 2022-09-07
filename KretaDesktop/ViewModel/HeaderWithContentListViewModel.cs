using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KretaDesktop.ViewModel.BaseClass;

namespace KretaDesktop.ViewModel
{
    public class HeaderWithContentListViewModel : ViewModelBase
    {
        private RelayCommand UpdateContentViewCommand;
        private ViewModelBase selectedView;
        private ViewModelBase headerAppName;

        public ViewModelBase HeaderAppName
        {
            get { return headerAppName; }
            set { headerAppName = value; }
        }


        public ViewModelBase SelectedView
        {
            get
            {
                return selectedView;
            }
            set
            {
                selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }

        public HeaderWithContentListViewModel()
        {
            UpdateContentViewCommand = new RelayCommand(parameter => UpdateContentView(parameter));
            SelectedView = new ContentListSubjectViewModel();
            HeaderAppName = new HeaderAppNameViewModel();
        }

        public void UpdateContentView(object parameter)
        {
            if (parameter is string)
            {
                if (parameter.ToString()== "Tantargyak")
                {
                    SelectedView = new ContentListSubjectViewModel();
                }
            }
        }
    }
}
