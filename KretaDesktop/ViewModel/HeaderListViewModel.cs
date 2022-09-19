using KretaDesktop.ViewModel.BaseClass;
using KretaDesktop.ViewModel.Content;


namespace KretaDesktop.ViewModel
{
    public class HeaderListViewModel : ViewModelBase 
    {
        private RelayCommand UpdateContentViewCommand { get; }
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

        public HeaderListViewModel()
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
