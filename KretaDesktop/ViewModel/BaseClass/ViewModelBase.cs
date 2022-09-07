using KretaParancssoriAlkalmazas.Models.Parameters;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KretaDesktop.ViewModel.BaseClass
{

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose() { }
    }

    public class PageParameterViewModelBase : ViewModelBase
    {
        private QueryStringParameters queryString;

        public QueryStringParameters QueryString
        {
            get { return queryString; }
            set { queryString = value; }
        }

        public QueryStringParameters GetParameters()
        {            
            return queryString;
        }
    }
}
