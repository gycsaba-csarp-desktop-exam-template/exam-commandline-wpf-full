using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Kreta.Services;
using Kreta.Models;
using ViewModels.BaseClass;



namespace Kreta.ViewModels
{
    public class StudentOfClassViewModel : ViewModelBase
    {
        private ObservableCollection<SchoolClass> schoolClasses;
        private ObservableCollection<Student> studentsOfClass;
        private ObservableCollection<Student> studentHaveNoClass;

        private StudentOfClassService studentOfClassService;
        private SchoolClass selectedSchoolClass;
        private Student selectedStudentHaveNoClass;
        private Student selectedStudentOfClass;

        public RelayCommand StudentHaveNoClassCommand { get; private set; }
        public RelayCommand AddStudentToClassCommand { get; private set; }
        public RelayCommand DeleteStudentFromClassCommand { get; private set; }

        public StudentOfClassViewModel()
        {
            StudentHaveNoClassCommand = new RelayCommand(execute => ShowStudentHaveNoClass());
            AddStudentToClassCommand = new RelayCommand(execute => AddStudentToClass());
            DeleteStudentFromClassCommand = new RelayCommand(execute => DeleteStudentFromClass());

            studentOfClassService = new StudentOfClassService();
            schoolClasses = new ObservableCollection<SchoolClass>();
            studentsOfClass = new ObservableCollection<Student>();
            studentHaveNoClass = new ObservableCollection<Student>();
        }

        public ObservableCollection<SchoolClass> SchoolClasses
        {
            get
            {
                schoolClasses.Clear();
                schoolClasses = new ObservableCollection<SchoolClass>(studentOfClassService.Classes);
                return schoolClasses;
            }
        }

        public ObservableCollection<Student> StudentsOfClass
        {
            get
            {
                if (selectedSchoolClass != null)
                {
                    List<Student> studentOfClassList = studentOfClassService.GetStudentOfClass(SelectedSchoolClass.Id);
                    studentsOfClass.Clear();
                    studentsOfClass = new ObservableCollection<Student>(studentOfClassList);
                    return studentsOfClass;
                }
                else
                    return null;
            }
        }

        public ObservableCollection<Student> StudentHaveNoClass
        {
            get
            {
                return studentHaveNoClass;
            }
        }

        public SchoolClass SelectedSchoolClass
        {
            get => selectedSchoolClass;
            set
            {
                selectedSchoolClass = value;
                OnPropertyChanged("StudentsOfClass");
            }
        }

        public Student SelectedStudentHaveNoClass
        {
            get => selectedStudentHaveNoClass;
            set => selectedStudentHaveNoClass = value;
        }
        public Student SelectedStudentOfClass { get => selectedStudentOfClass; set => selectedStudentOfClass = value; }

        public void ShowStudentHaveNoClass()
        {
            studentHaveNoClass.Clear();
            studentHaveNoClass = new ObservableCollection<Student>(studentOfClassService.GetStudentNoClass());
            OnPropertyChanged("StudentHaveNoClass");
        }



        public void AddStudentToClass()
        {
            if (SelectedStudentHaveNoClass != null && selectedSchoolClass != null)
            {
                int studentId = SelectedStudentHaveNoClass.Id;
                int classId = SelectedSchoolClass.Id;
                studentOfClassService.AddStudentToClass(studentId, classId);
                UpdateListBoxData();
            }
        }

        public void DeleteStudentFromClass()
        {
            if (selectedStudentOfClass != null)
            {
                int studentId = selectedStudentOfClass.Id;
                studentOfClassService.DeleteStudentFromClass(studentId);
                UpdateListBoxData();
            }
        }

        private void UpdateListBoxData()
        {
            OnPropertyChanged(nameof(StudentsOfClass));
            ShowStudentHaveNoClass();
        }
    }
}