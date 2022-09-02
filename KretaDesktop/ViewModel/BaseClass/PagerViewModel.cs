using ApplicationPropertiesSettings;
using KretaParancssoriAlkalmazas.Models.Pagination;
using KretaParancssoriAlkalmazas.Models.Parameters;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaDesktop.ViewModel.BaseClass
{
    public abstract class PagerViewModel : ViewModelBase
    {
        private QueryStringParameters queryParameter;

        public QueryStringParameters QueryParameter
        {
            get { return queryParameter; }
        }

        private ObservableCollection<string> rowPerPage;

        public ObservableCollection<string> RowPerPagePossibilities
        {
            get { return rowPerPage; }
            set 
            { 
                rowPerPage = value;
                OnPropertyChanged(nameof(RowPerPagePossibilities));
            }
        }

        public RelayCommand LastPageCommand {get; set;}


        public PagerViewModel()
        {
            queryParameter = new QueryStringParameters();
            LastPageCommand = new RelayCommand(execute => LastPage());
            AppConfiguration appConfiguration = new AppConfiguration();
            RowPerPagePossibilities = new ObservableCollection<string>(appConfiguration.GetPossibleNumberOfRowOnTheDataGridTable());
        }

        public abstract void LoadData();

        public void SetPageSize(int pageSize)
        {
            this.queryParameter.PageSize = pageSize;
        }

        public void LastPage()
        {
            queryParameter.CurrentPage = queryParameter.NumberOfPage;
            LoadData();
        }
    }
}
