using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Services;
using ViewModels.BaseClass;

namespace Kreta.ViewModels
{
    public class TeachTeacherSubjectViewModel:ViewModelBase
    {
        private ObservableCollection<Teacher> teacherDatas;
        private ObservableCollection<Subject> subjectDatas;
        private TeachTeacherSubjectService teachTeacherSubjectService;
        private Teacher selectedTeacher;

        public TeachTeacherSubjectViewModel()
        {
            teacherDatas = new ObservableCollection<Teacher>();
            subjectDatas = new ObservableCollection<Subject>();
            teachTeacherSubjectService = new TeachTeacherSubjectService();
        }

        public ObservableCollection<Teacher> Teachers
        {
            get
            {
                teacherDatas.Clear();
                teacherDatas = new ObservableCollection<Teacher>(teachTeacherSubjectService.Teachers);
                return teacherDatas;
            }
        }

        public ObservableCollection<Subject> SubjectsOfTeachers
        {
            get
            {
                if (selectedTeacher != null)
                {
                    List<Subject> subjectsOfTeachers = teachTeacherSubjectService.GetTeachersSubject(SelectedTeacher.Id);
                    subjectDatas.Clear();
                    subjectDatas = new ObservableCollection<Subject>(subjectsOfTeachers);
                    return subjectDatas;
                }
                else
                    return null;
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
                OnPropertyChanged(nameof(SubjectsOfTeachers));
            }
        }
    }
}
