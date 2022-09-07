using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationPropertiesSettings;
using CommunityToolkit.Mvvm.ComponentModel;
using KretaDesktop.ViewModel.BaseClass;

namespace KretaDesktop.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase selectedView;

        public ViewModelBase SelectedView
        {
            get { return selectedView; }
            set 
            { 
                selectedView = value; 
                OnPropertyChanged(nameof(SelectedView));
            }
        }
            
        public RelayCommandClass UpdateViewCommand { get; set; }

        public MainWindowViewModel()
        {
            UpdateViewCommand = new RelayCommandClass((parameter) => UpdateView(parameter));
            selectedView = new HeaderWithContentListViewModel();            
        }

        public void UpdateView(object parameter)
        {
            // https://www.youtube.com/watch?v=1_cUgpWqS0Y
            if (parameter is string)
            {
                if (parameter.ToString() == "Listak")
                {
                    SelectedView = new HeaderWithContentListViewModel();
                }
                if (parameter.ToString() == "Athelyezesek")
                {
                    SelectedView = new HeaderWithContentMoveViewModel();
                }
            }
        }
    }
}
