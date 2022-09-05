using ApplicationPropertiesSettings;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.Parameters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json.Linq;
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
        // View adatok

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

        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set 
            {
                QueryString.PageSize = value;
                pageSize = value;
                LoadData();
            }
        }

        public int NumberOfPage
        {
            get { return QueryString.NumberOfPage > 0 ? QueryString.NumberOfPage : 0; }
        }

        public int NumberOfItem
        {
            get { return QueryString.NumberOfItem > 0 ? QueryString.NumberOfItem : 0;  }
        }

        public int selectedItemIndex;

        public int SelectedItemIndex
        {
            get { return selectedItemIndex; }
            set
            {
                selectedItemIndex = value;
                OnPropertyChanged(nameof(SelectedItemIndex));
                OnPropertyChanged(nameof(ItemData));
            }
        }

        public string ItemData
        {
            get { return $"Tantárgy adatai: {(SelectedItemIndex + 1)}  /  {NumberOfItem}"; }
        }
            

        public int CurrentPage
        {
            get { return QueryString.CurrentPage; }
        }

        private bool sortingAscending;

        public bool SortingAscending
        {
            get
            {
                return sortingAscending; 
            }
            set 
            {
                sortingAscending = value;           
            }
        }

        public RelayCommand LastPageCommand {get; set;}
        public RelayCommand FirstPageCommand { get; set;}
        public RelayCommand PreviusPageCommand { get; set;}
        public RelayCommand NextPageCommand { get; set;}
        public RelayCommand SortingCommand { get; set; }

        public bool IsSortingVisible
        {
            get
            {
                if (sortByField != string.Empty)
                    return true;
                else
                    return false;
            }
        }           

        // Belső adatok
        private string sortByField;

        public string SortByField
        {
            get { return sortByField; }
            set 
            { 
                sortByField = value;
                MakeSortingPartOfQuary();
            }
        }

        public PagedViewModel()
        {
            LastPageCommand = new RelayCommand(execute => LastPage());
            FirstPageCommand = new RelayCommand(execute => FirstPage());
            PreviusPageCommand = new RelayCommand(execute => PreviusPage(), canExecute => CanExecutePreviusPageCommand());
            NextPageCommand = new RelayCommand(execute => NextPage() , canExecute => CanExecuteNextPageCommand());

            SortingCommand = new RelayCommand(execute => Sorting());
            
            AppConfiguration appConfiguration = new AppConfiguration();
            rowPerPagePossibilities=new ObservableCollection<string>(appConfiguration.GetPossibleNumberOfRowOnTheDataGridTable());

            QueryString = new QueryStringParameters();
            QueryString.CurrentPage = 1;
            QueryString.OrderBy = String.Empty;
            QueryString.Fields = String.Empty;
            if (rowPerPagePossibilities.Count > 0)
                SetPageSize(int.Parse(rowPerPagePossibilities.ElementAt(0)));

            SortingAscending = true;
            sortByField = String.Empty;
        }

        public abstract void LoadData();

        public void SetPageSize(int pageSize)
        {
            QueryString.PageSize = pageSize;
        }

        public void SaveParameter(PagedList<Subject> pagedSubjectList)
        {
            QueryString = pagedSubjectList.GetParameters();
            OnPropertyChanged(nameof(CurrentPage));
            OnPropertyChanged(nameof(PageSize));
            OnPropertyChanged(nameof(NumberOfPage));
            OnPropertyChanged(nameof(NumberOfItem));
            OnPropertyChanged(nameof(ItemData));
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

        public bool CanExecutePreviusPageCommand()
        {
            return QueryString.HasPrevious;
        }

        public bool CanExecuteNextPageCommand()
        {
            return QueryString.HasNext;
        }

        public void Sorting()
        {
            sortingAscending = !sortingAscending;
            MakeSortingPartOfQuary();
            OnPropertyChanged(nameof(SortingAscending));
        }

        private void MakeSortingPartOfQuary()
        {
            if (SortByField != string.Empty)
            {
                QueryString.OrderBy = SortByField;
                if (!SortingAscending)
                    QueryString.OrderBy += " desc";
            }
            else
                QueryString.OrderBy = string.Empty;
            LoadData();
        }
    }
}
