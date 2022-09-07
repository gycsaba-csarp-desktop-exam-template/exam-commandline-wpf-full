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

        // TODO Can not execute nem látszik a gombokon

        public RelayCommand LastPageCommand { get; private set; }
        public RelayCommand FirstPageCommand { get; private set; }
        public RelayCommand PreviusPageCommand { get; private set; }
        public RelayCommand NextPageCommand { get; private set; }
        public RelayCommand SortingCommand { get; private set; }
        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand SearchAllCommand { get; private set; }

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
            get 
            {
                int index = ((QueryString.CurrentPage-1) * QueryString.PageSize) + (SelectedItemIndex + 1);
                return $"Tantárgy adatai: {index}  /  {NumberOfItem}"; 
            }
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
        
        public bool IsSortingVisible
        {
            get
            {
                if (sortBy != string.Empty)
                    return true;
                else
                    return false;
            }
        }           

        // Belső adatok
        private string sortBy;

        public string SortBy
        {
            get { return sortBy; }
            set 
            { 
                sortBy = value;
                MakeSortingPartOfQuary();
            }
        }

        private string userFiltringParameter;

        public string UserFiltringParameter
        {
            get { return userFiltringParameter; }
            set 
            { 
                userFiltringParameter = value;
                OnPropertyChanged(nameof(UserFiltringParameter));
            }
        }


        public PagedViewModel()
        {
            LastPageCommand = new RelayCommand(execute => LastPage());
            FirstPageCommand = new RelayCommand(execute => FirstPage());
            PreviusPageCommand = new RelayCommand(execute => PreviusPage(), canExecute => CanExecutePreviusPageCommand());
            NextPageCommand = new RelayCommand(execute => NextPage() , canExecute => CanExecuteNextPageCommand());            

            SortingCommand = new RelayCommand(execute => Sorting());
            SearchCommand = new RelayCommand(execute => Filtring(), canExecute => CanExecuteFiltringCommand());
            SearchAllCommand = new RelayCommand(execute => SearrchAll(), canExecute => CanExecuteSeachAllCommand());


            AppConfiguration appConfiguration = new AppConfiguration();
            rowPerPagePossibilities=new ObservableCollection<string>(appConfiguration.GetPossibleNumberOfRowOnTheDataGridTable());

            SortingAscending = true;
            sortBy = String.Empty;
            UserFiltringParameter = String.Empty;

            QueryString = new QueryStringParameters();
            QueryString.CurrentPage = 1;
            QueryString.Fields = String.Empty;
            QueryString.OrderBy = SortBy;
            QueryString.Filter = UserFiltringParameter;

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

        public void Filtring()
        {
            QueryString.Filter = UserFiltringParameter;
            LoadData();
        }

        // TODO CanExecuteFiltringCommand nem működik
        public bool CanExecuteFiltringCommand()
        {
            /*if (UserFiltringParameter != String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }*/
            return true;
        }

        public void SearrchAll()
        {
            UserFiltringParameter= String.Empty;
            LoadData();
        }

        // TODO CanExecuteSeachAllCommand nem működik
        public bool CanExecuteSeachAllCommand()
        {
            //return !CanExecuteFiltringCommand();
            return true;
        }

        private void MakeSortingPartOfQuary()
        {
            if (SortBy != string.Empty)
            {
                QueryString.OrderBy = SortBy;
                if (!SortingAscending)
                    QueryString.OrderBy += " desc";
            }
            else
                QueryString.OrderBy = string.Empty;
            if (UserFiltringParameter != string.Empty)
                QueryString.Filter = UserFiltringParameter;
            LoadData();
        }
    }
}
