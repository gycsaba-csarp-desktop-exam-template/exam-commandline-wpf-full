using ApplicationPropertiesSettings;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Helpers;
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
    public abstract class PagedViewModel : PageParameterViewModelBase
    {
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

        public PagedViewModel()
        {
            LastPageCommand = new RelayCommand(execute => LastPage());
            AppConfiguration appConfiguration = new AppConfiguration();
            rowPerPage=new ObservableCollection<string>(appConfiguration.GetPossibleNumberOfRowOnTheDataGridTable());

            QueryString = new QueryStringParameters();
            QueryString.CurrentPage = 1;
            QueryString.OrderBy = String.Empty;
            QueryString.Fields = String.Empty;
            if (rowPerPage.Count > 0)
                SetPageSize(int.Parse(rowPerPage.ElementAt(0)));
        }

        public abstract void LoadData();

        public void SetPageSize(int pageSize)
        {
            QueryString.PageSize = pageSize;
        }

        public void SaveParameter(PagedList<Subject> pagedSubjectList)
        {
            QueryString = pagedSubjectList.GetParameters();
        }

        public void LastPage()
        {
            QueryString.CurrentPage = QueryString.NumberOfPage;
            LoadData();
        }

    
    }
}
