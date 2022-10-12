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
        private MainWindow mainWindow;
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
            
        public RelayCommand UpdateViewCommand { get; }

        public MainWindowViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            UpdateViewCommand = new RelayCommand((parameter) => UpdateView(parameter));
            selectedView = new HeaderAppNameViewModel();            
        }

        public void UpdateView(object parameter)
        {
            // https://www.youtube.com/watch?v=1_cUgpWqS0Y
            if (parameter is string)
            {
                if (parameter.ToString() == "Lists")
                {
                    SelectedView = new HeaderListViewModel();
                }
                if (parameter.ToString() == "Operation")
                {
                    SelectedView = new HeaderOperationViewModel();
                }
                if (parameter.ToString()== "Configuration")
                {
                    SelectedView = new HeaderAppConfigurationViewModel();
                }
                if (parameter.ToString() == "Exit")
                {
                    //https://stackoverflow.com/questions/16172462/close-window-from-viewmodel
                    //Application.Current.Windows[0].Close();
                    mainWindow.Close();
                }

            }
        }
    }
}
