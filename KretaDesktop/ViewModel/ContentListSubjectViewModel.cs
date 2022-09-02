using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using KretaDesktop.ViewModel.BaseClass;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Pagination;
using KretaParancssoriAlkalmazas.Models.Parameters;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;

namespace KretaDesktop.ViewModel
{
    // TODO: A datagrid oszlopa olyan széles legyen mint az adatbázisban lévő max hosszúságú adat
    public class ContentListSubjectViewModel : PagerViewModel
    {
        ISubjectService subjectService;

        private ObservableCollection<Subject> subjects;
        private Subject selectedSubject;
        private int pageSize;


        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set 
            { 
                subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }

        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = int.Parse(value.ToString());
                OnPropertyChanged(nameof(PageSize));
            }
        }


        public ContentListSubjectViewModel()
        {
            subjects = new ObservableCollection<Subject>();
            subjectService = new SubjectService();
            selectedSubject = new Subject();

            LoadData();
        }

        async public override void LoadData()
        {
            if (subjectService != null)
            {

                // TODO: PagedList, ListWithPaginationData, PaginationParameters egyeztetés

                ListWithPaginationData<Subject> listWithPaginationData = await subjectService.GetSubjectsAsyncWithPageData(QueryParameter);
                if ((listWithPaginationData != null) && (listWithPaginationData.Items != null))
                {
                    Subjects = new ObservableCollection<Subject>(listWithPaginationData.Items);
                }
                else
                    Subjects = new ObservableCollection<Subject>();
            }            
        }
    }
}
