using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaDesktop.ViewModel.BaseClass;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Pagination;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;

namespace KretaDesktop.ViewModel
{
    public class ContentListSubjectViewModel : PagerViewModel
    {
        private ObservableCollection<Subject> subjects;
        private Subject selectedSubject;

        ISubjectService subjectService;
         

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set 
            {                
                selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }


        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set 
            { 
                subjects = value;
                OnPropertyChanged(nameof(Subjects));
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
                ListWithPaginationData<Subject> listWithPaginationData = await subjectService.GetSubjectsAsyncWithPageData();                
                if ((listWithPaginationData != null) && (listWithPaginationData.Items != null))
                    Subjects = new ObservableCollection<Subject>(listWithPaginationData.Items);
                else
                    Subjects = new ObservableCollection<Subject>();
            }            
        }
    }
}
