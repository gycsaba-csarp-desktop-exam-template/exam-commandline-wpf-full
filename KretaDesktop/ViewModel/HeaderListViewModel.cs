using KretaDesktop.ViewModel.BaseClass;
using KretaDesktop.ViewModel.Content;


namespace KretaDesktop.ViewModel
{
    public class HeaderListViewModel : HeaderViewModel
    {
        private RelayCommand UpdateContentViewCommand { get; }

        public HeaderListViewModel()
        {
            UpdateContentViewCommand = new RelayCommand(parameter => UpdateContentView(parameter));            
            HeaderAppName = new HeaderAppNameViewModel();

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
