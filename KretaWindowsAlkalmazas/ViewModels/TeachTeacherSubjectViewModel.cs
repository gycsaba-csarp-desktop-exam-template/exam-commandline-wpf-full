using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Services;
using Kreta.Repositories;
using ViewModels.BaseClass;
using Kreta.Models.Interfaces;

namespace Kreta.ViewModels
{
    public class TeachTeacherSubjectViewModel : ViewModelBase
    {
        private TeachTeacherSubjectService teachTeacherSubjectService;

        private Teacher selectedTeacher;
        private Subject selectedSubjectOfTeacher;
        private Subject selectedNotTeachedSubject;
        private ObservableCollection<ITeacher> teachers;
        private ObservableCollection<Subject> subjectsOfTeacher;
        private ObservableCollection<Subject> teachersNotTeachedSubjects;

        public RelayCommand SubjectToTeacherCommand { get; private set;}
        public RelayCommand DeleteTeachedSubjectCommand { get; private set; }


        public TeachTeacherSubjectViewModel()
        {
            SubjectToTeacherCommand = new RelayCommand(execute => AddSubjectToTeacherSubjects());
            DeleteTeachedSubjectCommand = new RelayCommand(execute => DeleteSubjectFromTecherSubjects());

            teachTeacherSubjectService = new TeachTeacherSubjectService();

            teachers = new ObservableCollection<ITeacher>();
            subjectsOfTeacher = new ObservableCollection<Subject>();
            teachersNotTeachedSubjects = new ObservableCollection<Subject>();


        }

        public ObservableCollection<ITeacher> Teachers
        {
            get
            {
                teachers.Clear();
                teachers = new ObservableCollection<ITeacher>(teachTeacherSubjectService.GetAllTeachers());
                return teachers;
            }
        }

        public ObservableCollection<Subject> SubjectsOfTeacher
        {
            get
            {
                if (selectedTeacher == null)
                    return null;
                else
                {
                    List<Subject> subjectsOfTeacher = teachTeacherSubjectService.GetTeachersSubject(SelectedTeacher.Id);
                    this.subjectsOfTeacher.Clear();
                    this.subjectsOfTeacher = new ObservableCollection<Subject>(subjectsOfTeacher);
                    OnPropertyChanged(nameof(TeachersNotTeachedSubjects));
                    return this.subjectsOfTeacher;
                }

            }
        }

        public ObservableCollection<Subject> TeachersNotTeachedSubjects
        {
            get
            {
                if (selectedTeacher == null)
                    return null;
                {
                    List<Subject> notTeachedSubjects = teachTeacherSubjectService.GetTeachersNotTeachedSubjects(SelectedTeacher.Id);
                    teachersNotTeachedSubjects.Clear();
                    teachersNotTeachedSubjects = new ObservableCollection<Subject>(notTeachedSubjects);
                    return teachersNotTeachedSubjects;
                }
            }
        }

        public Teacher SelectedTeacher
        {
            get
            {
                return selectedTeacher;
            }
            set
            {
                selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));                
                OnPropertyChanged(nameof(SubjectsOfTeacher));
            }
        }

        public Subject SelectedSubjectOfTeacher
        {
            get
            {
                return selectedSubjectOfTeacher;
            }
            set
            {
                selectedSubjectOfTeacher = value;
                OnPropertyChanged(nameof(SelectedSubjectOfTeacher));
            }
        }

        public Subject SelectedNotTeachedSubject
        {
            get
            {
                return selectedNotTeachedSubject;
            }
            set
            {
                selectedNotTeachedSubject = value;
                OnPropertyChanged(nameof(SelectedNotTeachedSubject));
            }
        }

        public void AddSubjectToTeacherSubjects()
        {
            if (selectedNotTeachedSubject == null)
                return;
            else
            {
                int teacherId = SelectedTeacher.Id;
                int subjectId = selectedNotTeachedSubject.Id;
                teachTeacherSubjectService.AddTeacherSubject(teacherId, subjectId);
                OnPropertyChanged(nameof(SubjectsOfTeacher));
            }
        }

        public void DeleteSubjectFromTecherSubjects()
        {
            if ((selectedTeacher == null) || (selectedSubjectOfTeacher == null))
                return;
            else
            {
                int teacherId = SelectedTeacher.Id;
                int subjectId = SelectedSubjectOfTeacher.Id;
                teachTeacherSubjectService.DeleteTeacherSubject(teacherId, subjectId);
                OnPropertyChanged(nameof(SubjectsOfTeacher));
            }
        }
    }
}
