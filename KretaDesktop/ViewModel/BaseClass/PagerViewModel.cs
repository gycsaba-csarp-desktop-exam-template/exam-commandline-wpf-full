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
        private ObservableCollection<string> rowPerPagePossibilities;

        public ObservableCollection<string> RowPerPagePossibilities
        {
            get { return rowPerPagePossibilities; }
            set 
            { 
                rowPerPagePossibilities = value;
                OnPropertyChanged(nameof(RowPerPagePossibilities));
            }
        }

        public int CurrentPage
        {
            get { return QueryString.CurrentPage; }
        }

        public RelayCommand LastPageCommand {get; set;}
        public RelayCommand FirstPageCommand { get; set;}
        public RelayCommand PreviusPageCommand { get; set;}
        public RelayCommand NextPageCommand { get; set;}

        public PagedViewModel()
        {
            LastPageCommand = new RelayCommand(execute => LastPage());
            FirstPageCommand = new RelayCommand(execute => FirstPage());
            PreviusPageCommand = new RelayCommand(execute => PreviusPage());
            NextPageCommand = new RelayCommand(execute => NextPage());
            
            AppConfiguration appConfiguration = new AppConfiguration();
            rowPerPagePossibilities=new ObservableCollection<string>(appConfiguration.GetPossibleNumberOfRowOnTheDataGridTable());

            QueryString = new QueryStringParameters();
            QueryString.CurrentPage = 1;
            QueryString.OrderBy = String.Empty;
            QueryString.Fields = String.Empty;
            if (rowPerPagePossibilities.Count > 0)
                SetPageSize(int.Parse(rowPerPagePossibilities.ElementAt(0)));
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
            OnPropertyChanged(nameof(CurrentPage));
            LoadData();
        }

        public void FirstPage()
        {
            QueryString.CurrentPage = 1;
            OnPropertyChanged(nameof(CurrentPage));
            LoadData();
        }

        public void PreviusPage()
        {
            QueryString.CurrentPage -= 1;
            OnPropertyChanged(nameof(CurrentPage));
            LoadData();
        }

        public void NextPage()
        {
            QueryString.CurrentPage += 1;
            OnPropertyChanged(nameof(CurrentPage));
            LoadData();
        }  
    }
}
