using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using KretaDesktop.ViewModel.BaseClass;
using KretaDesktop.ViewModel.Interface;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Helpers;
using ServiceKretaAPI.Services;

namespace KretaDesktop.ViewModel
{
    // TODO: A datagrid oszlopa olyan széles legyen mint az adatbázisban lévő max hosszúságú adat
    public class ContentListSubjectViewModel : PagedViewModel, ICrudCommand<Subject>
    {
        SubjectService subjectService;

        private ObservableCollection<Subject> subjects;

        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set 
            { 
                subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        private Subject selectedSubject;

        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }

        public RelayCommand<Subject> DeleteCommand { get; }
        public RelayCommand<Subject> SaveCommand { get; }
        public RelayCommand<Subject> NewCommand { get; }

        public ContentListSubjectViewModel()
        {
            //CreateCommand=new RelayCommand<Subject>((subjects)=>)

            subjects = new ObservableCollection<Subject>();
            subjectService = new SubjectService();
            selectedSubject = new Subject();

            SortBy = "SubjectName";

            LoadData();
        }

        async public override void LoadData()
        {
            if (subjectService != null)
            {
                PagedList<Subject> pagedSubjectList = await subjectService.GetSubjectsAsyncWithPageData(GetParameters());
                SaveParameter(pagedSubjectList);
                if (pagedSubjectList != null)
                {
                    Subjects = new ObservableCollection<Subject>((List<Subject>)pagedSubjectList);
                }
                else
                    Subjects = new ObservableCollection<Subject>();
            }
            SelectedItemIndex = 0;
        }

        async public void Delete(Subject entity)
        {
            if (subjectService!=null)
                await subjectService.DeleteSubjectAsync(entity.Id);
            LoadData();

        }

        public void Save(Subject entity)
        {
        }

        public void New(Subject entity)
        {
        }
    }
}
