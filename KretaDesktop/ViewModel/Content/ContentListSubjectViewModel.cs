using ApplicationPropertiesSettings;
using Kreta.Models.DataModel;
using Kreta.Models.Helpers;
using KretaDesktop.Localization;
using KretaDesktop.ViewModel.BaseClass;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Pkcs;

namespace KretaDesktop.ViewModel.Content
{
    // TODO: A datagrid oszlopa olyan széles legyen mint az adatbázisban lévő max hosszúságú adat
    public class ContentListSubjectViewModel : PagedViewModel
    {
        private bool waitingForNewData;

        public bool WaitingForNewData
        {
            get { return waitingForNewData; }
            set 
            { 
                waitingForNewData = value;
                OnPropertyChanged(nameof(WaitingForNewData));
                OnPropertyChanged(nameof(NoWaitingForNewData)); 
            }
        }

        public bool NoWaitingForNewData 
        { 
            get
            {
                return !waitingForNewData;
            }
        }

        APISubjectService subjectService;

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
                    // https://levelup.gitconnected.com/5-ways-to-clone-an-object-in-c-d1374ec28efa
                    displayedSubject = (Subject) selectedSubject.Clone();
                    OnPropertyChanged(nameof(DisplayedSubject));
                }
            }
        }

        private Subject displayedSubject;

        public Subject DisplayedSubject
        {
            get { return displayedSubject; }
            set 
            { 
                displayedSubject = value;
                OnPropertyChanged(nameof(DisplayedSubject));
            }
        }

        public string contentInfo;

        public string ContentInfo
        {
            get
            {
                return contentInfo;
            }
            set
            {
                contentInfo = value;
                OnPropertyChanged(nameof(ContentInfo));
            }
        }

        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand NewCommand { get; }
        public RelayCommand CancelCommand { get; }

        public ContentListSubjectViewModel()
        {
            DeleteCommand = new RelayCommand(parameter => Delete(parameter));
            NewCommand = new RelayCommand(execute => New());
            SaveCommand = new RelayCommand(parameter => Save(parameter));
            CancelCommand = new RelayCommand(execute => Cancel());

            subjects = new ObservableCollection<Subject>();
            subjectService = new APISubjectService();
            selectedSubject = new Subject();
            displayedSubject = new Subject();

            SortBy = "SubjectName";

            waitingForNewData = false;
            OnPropertyChanged(nameof(WaitingForNewData));

            SetInfoText(GetLocalizedString("infoSubjectTable"));
        }

        async public override void LoadData()
        {
            if (subjectService != null)
            {
                try
                {
                    PagedList<Subject> pagedSubjectList = await subjectService.GetSubjectsAsyncWithPageData(GetParameters());
                    //PagedList<Subject> pagedSubjectList = await subjectService.GetSubjectsAsyncWithPageData(GetParameters()).WaitAsync(TimeSpan.FromSeconds(APITimeOut.GetAPITimeout())); 
                    SaveParameter(pagedSubjectList);                  
                    if (pagedSubjectList != null)                    
                        Subjects = new ObservableCollection<Subject>(pagedSubjectList);
                    else
                        Subjects = new ObservableCollection<Subject>();
                }
                catch(APISubjectException exceptin)
                {
                    SetInfoText(exceptin.Message);
                }
            }     
            SelectRow(displayedSubject);
            ConcanetenateInfoTextWithLocalizedString("infoAllSubjectIsLoaded", subjects.Count);
        }

        async public void Delete(object entity)
        {
            if (entity is Subject)
            {
                Subject subjectToDelete = (Subject) entity;
                try
                {
                    if (subjectService != null)
                        await subjectService.DeleteSubjectAsync(subjectToDelete.Id);
                    SetInfoTextWithLocalizedString("infoSubjectIsDeleted", subjectToDelete);
                }

                catch (APISubjectException exceptin)
                {
                    SetInfoText(exceptin.Message);

                }
                LoadData();
            }
        }

        async public void New()
        {
            if (subjectService != null)
            {
                long newId=-1;
                try
                {
                    newId = await subjectService.GetNextSubjectIdAsync();
                }
                catch (APISubjectException exceptin)
                {
                    SetInfoText(exceptin.Message);
                }
                DisplayedSubject = new Subject(newId);
                WaitingForNewData = true;
                SelectedItemIndex = -1;
                SelectedSubject = null;
                // Mégsem gomb
                // Törlés nincs 
                // Datagirdre nem lehet kattintani
            }
        }

        public async void Save(object entity)
        {
            if (entity is Subject)
            {
                HttpStatusCode statusCode=HttpStatusCode.OK;
                Subject subjectToSave = (Subject)entity;
                try
                {
                    statusCode = await subjectService.Save(subjectToSave);
                    //statusCode = await subjectService.Save(subjectToSave).WaitAsync(TimeSpan.FromSeconds(APITimeOut.GetAPITimeout()));
                    SetInfoTextWithLocalizedString("infoSubjectIsSaved", subjectToSave);
                }
                catch (APISubjectException exceptin)
                {
                    SetInfoText(exceptin.Message);
                }
                catch (Exception exception)
                {
                    SetInfoText(exception.Message);
                }
                if (statusCode != HttpStatusCode.OK)
                {
                    SetInfoTextWithLocalizedString("errorStatusCode", statusCode);
                }
                WaitingForNewData = false;
                LoadData();
            }
        }

        public void Cancel()
        {
            WaitingForNewData = false;
            SelectRow();
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
            OnPropertyChanged(nameof(SelectedSubject));
        }

        private void SetInfoText(string info)
        {
            ContentInfo = info;
        }

        private void SetInfoTextWithLocalizedString(string localizationStringName)
        {
            ContentInfo = GetLocalizedString(localizationStringName);
        }

        private void SetInfoTextWithLocalizedString(string localizationStringName,object data)
        {
            ContentInfo = string.Format(GetLocalizedString(localizationStringName), data);
        }

        private void ConcanetenateInfoTextWithLocalizedString(string localizationStringName, object data)
        {
            ContentInfo += " "+string.Format(GetLocalizedString(localizationStringName), data);
        }


        private string GetLocalizedString(string localizationStringName)
        {
            ProjectLocalization projectLocalization = new ProjectLocalization();
            return projectLocalization.GetStringResource(localizationStringName);
        }

        
    }
}
