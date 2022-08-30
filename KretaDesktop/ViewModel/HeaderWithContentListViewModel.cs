using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BaseClass;

namespace KretaDesktop.ViewModel
{
    public class HeaderWithContentListViewModel : ViewModelBase
    {
        private RelayCommand UpdateContentViewCommand;
        private ViewModelBase selectedView;

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
