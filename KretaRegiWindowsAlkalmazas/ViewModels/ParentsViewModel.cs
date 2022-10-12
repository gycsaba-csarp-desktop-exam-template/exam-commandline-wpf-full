using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Repositories;
using Kreta.Services;
using ViewModels.BaseClass;

using System.Collections.ObjectModel;

namespace Kreta.ViewModel
{
    public class ParentsViewModel : ViewModelBase
    {
        private ParentService parentService;

        private ObservableCollection<Student> students;
        private ObservableCollection<Parent> selectedStudentParents;
        private ObservableCollection<Parent> parentsWithNoStudent;

        private Student selectedStudent;
        private Parent selectedParent;
        private Parent selectedParantWithNoStudent;

        public Parent SelectedParent { get => selectedParent; set => selectedParent = value; }

        public ObservableCollection<Student> Students { get => students; set => students = value; }

        public RelayCommand DeleteParentCommand { get; private set; }
        public RelayCommand DeleteParantWithNoStudentCommand { get; private set; }


        public ParentsViewModel()
        {
            parentService = new ParentService();
            students = new ObservableCollection<Student>(parentService.GetAllStudents());
            selectedStudentParents = new ObservableCollection<Parent>(parentService.GetAllParents());
            selectedParent = new Parent();
            DeleteParentCommand = new RelayCommand(execute => DeleteParent());
            DeleteParantWithNoStudentCommand = new RelayCommand(execute => DeleteParentFinaly());
        }


        public string NumberOfParents
        {
            get
            {
                return " "+ parentService.NumberOfParents+" fő.";
            }
        }

        public string NumberOfWomen
        {
            get
            {
                return " " + parentService.NumberOfWomen + " fő.";
            }
        }

        public string NumberOfMan
        {
            get
            {
                return " " + parentService.NumberOfMan + " fő.";
            }
        }

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudentParents));
            }
        }

        public Parent SelectedParantWithNoStudent
        {
            get => selectedParantWithNoStudent;
            set
            {
                selectedParantWithNoStudent = value;
                OnPropertyChanged(nameof(SelectedParantWithNoStudent));
            }
        }

        public ObservableCollection<Parent> SelectedStudentParents
        {
            get
            {
                if (selectedStudent == null)
                    return null;
                else
                {
                    List<Parent> selectedStudentParnetsList = parentService.GetParents(selectedStudent.Id);
                    selectedStudentParents = new ObservableCollection<Parent>(selectedStudentParnetsList);
                    return selectedStudentParents;
                }
            }
        }

        public ObservableCollection<Parent> ParentsWithNoStudent
        {
            get
            {
                List<Parent> parentsWithNoStudent = parentService.GetAllParentsWithNoStudent();
                this.parentsWithNoStudent = new ObservableCollection<Parent>(parentsWithNoStudent);
                return this.parentsWithNoStudent;
            }
        }

        public void DeleteParent()
        {
            if (selectedStudent != null && selectedParent != null)
            {
                int studentId = selectedStudent.Id;
                int parentId = selectedParent.Id;
                parentService.DeleteParent(studentId, parentId);
                OnPropertyChanged(nameof(SelectedStudentParents));
                OnPropertyChanged(nameof(ParentsWithNoStudent));
                OnPropertyChanged(nameof(NumberOfParents));
                OnPropertyChanged(nameof(NumberOfMan));
                OnPropertyChanged(nameof(NumberOfWomen));
            }
        }

        public void DeleteParentFinaly()
        {
            if (SelectedParantWithNoStudent != null)
                parentService.DeleteParent(SelectedParantWithNoStudent.Id);
            OnPropertyChanged(nameof(ParentsWithNoStudent));
            OnPropertyChanged(nameof(NumberOfParents));
            OnPropertyChanged(nameof(NumberOfMan));
            OnPropertyChanged(nameof(NumberOfWomen));
        }
    }
}
