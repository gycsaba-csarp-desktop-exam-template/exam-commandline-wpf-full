using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaDesktop.ViewModel.BaseClass
{
    public abstract class HeaderViewModel : ViewModelBase
    {

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
    }
}
