using Kreta.Models;
using Kreta.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.ViewModels
{
    public class StudentViewModel
    {
        private StudentsRepo students;
        private ObservableCollection<Student> students2;

        public StudentViewModel()
        {
            students = new StudentsRepo();
            students2 = new ObservableCollection<Student>(students.Studentss);
        }
        public ObservableCollection<Student> Student { get => students2; set => students2 = value; }
    }
}
