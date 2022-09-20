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

        // https://stackoverflow.com/questions/4902039/difference-between-selecteditem-selectedvalue-and-selectedvaluepath
        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
                if (selectedSubject != null)
                {
                    displayedSubject = (Subject)selectedSubject.Clone();
                    OnPropertyChanged(nameof(DisplayedSubject));
                }
            }
        }

        // https://levelup.gitconnected.com/5-ways-to-clone-an-object-in-c-d1374ec28efa
        private Subject displayedSubject;

        public Subject DisplayedSubject
        {
            get { return displayedSubject; }
            set { displayedSubject = value; }
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
            displayedSubject = new Subject();

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
                    subjects = new ObservableCollection<Subject>(pagedSubjectList);
                }
                else
                    subjects = new ObservableCollection<Subject>();
            }
            OnPropertyChanged(nameof(Subjects));          
            SelectRow(displayedSubject);
            
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
                if (DisplayedSubject != null)
                {
                    long newId = await subjectService.GetNextSubjectIdAsync();
                    displayedSubject.Id = newId;
                    displayedSubject.SubjectName = string.Empty;
                    OnPropertyChanged(nameof(DisplayedSubject));
                }
                // Mégsem gomb
                // Törlés nincs 
                // Datagirdre nem lehet kattintani
            }
        }

        public async void Save(object entity)
        {
            if (entity is Subject)
            {
                Subject subjectToSave = (Subject)entity;
                HttpStatusCode statusCode = await subjectService.Save(subjectToSave);
                if (statusCode == HttpStatusCode.OK)
                {
                    LoadData();                    
                }
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
                SelectRowContains(subjectToSelect);
            }
        }

        private void SelectFirstRow()
        {
            if (Subjects.Count > 0)
                selectedItemIndex = 0;
            OnPropertyChanged(nameof(SelectedItemIndex));
            
        }

        private void SelectRowContains(Subject subjectToSelect)
        {
            if (subjectToSelect==null)
            {
                SelectFirstRow();
                return;
            }                
            var list = subjects.Select(subject => subject.Id).ToList();
            int index = list.IndexOf(subjectToSelect.Id);
            if (index >= 0)
            {
                selectedItemIndex = index;                
            }
            else
            {
                selectedItemIndex = 0;
            }
            OnPropertyChanged(nameof(SelectedItemIndex));
            selectedSubject = subjectToSelect;
            OnPropertyChanged(nameof(selectedSubject));
        }
    }
}
