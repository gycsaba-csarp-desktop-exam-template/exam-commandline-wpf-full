using KretaDesktop.ViewModel.BaseClass;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Helpers;
using ServiceKretaAPI.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace KretaDesktop.ViewModel.Content
{
    // TODO: A datagrid oszlopa olyan széles legyen mint az adatbázisban lévő max hosszúságú adat
    public class ContentListSubjectViewModel : PagedViewModel
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

        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand NewCommand { get; }

        public ContentListSubjectViewModel()
        {
            DeleteCommand = new RelayCommand(parameter => Delete(parameter));
            NewCommand = new RelayCommand(execute => New());
            SaveCommand = new RelayCommand(parameter => Save(parameter));

            subjects = new ObservableCollection<Subject>();
            subjectService = new SubjectService();
            selectedSubject = new Subject();

            SortBy = "SubjectName";

        }

        async public override void LoadData()
        {
            if (subjectService != null)
            {
                PagedList<Subject> pagedSubjectList = await subjectService.GetSubjectsAsyncWithPageData(GetParameters());
                SaveParameter(pagedSubjectList);
                if (pagedSubjectList != null)
                {
                    Subjects = new ObservableCollection<Subject>(pagedSubjectList);
                }
                else
                    Subjects = new ObservableCollection<Subject>();
            }
            SelectRow();
        }

        async public void Delete(object entity)
        {
            if (entity is Subject)
            {
                Subject subjectToDelete = (Subject)entity;
                if (subjectService != null)
                    await subjectService.DeleteSubjectAsync(subjectToDelete.Id);
                LoadData();
            }
        }

        async public void New()
        {
            if (subjectService != null)
            {
                if (SelectedSubject != null)
                {
                    long newId = await subjectService.GetNextSubjectIdAsync();
                    SelectedSubject.Id = newId;
                    SelectedSubject.SubjectName = string.Empty;
                    OnPropertyChanged(nameof(SelectedSubject));
                }
            }
        }

        public async void Save(object entity)
        {
            if (entity is Subject)
            {
                Subject subjectToSave = (Subject)entity;
                HttpStatusCode statusCode = await subjectService.Save(subjectToSave);
                if (statusCode == HttpStatusCode.OK)
                    LoadData();
                SelectedSubject = subjectToSave;
                SelectRow(SelectedSubject);
            }
        }

        private void SelectRow(Subject? subjectToSelect = null)
        {

            if (subjectToSelect == null)
            {
                SelectFirstRow();
            }
            else
            {
                LoadDataAndSelectRowContains(subjectToSelect);
            }
        }

        private void SelectFirstRow()
        {
            if (Subjects.Count > 0)
                SelectedItemIndex = 0;
        }

        private void LoadDataAndSelectRowContains(Subject subjectToSelect)
        {
            var list = subjects.Select(subject => subject.Id).ToList();
            int index = list.IndexOf(subjectToSelect.Id);
            if (index >= 0)
                SelectedItemIndex = index;
        }

    }
}
