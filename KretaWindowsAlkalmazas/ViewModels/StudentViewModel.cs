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
        private StudentsRepo studentRepo;
        private ObservableCollection<Student> students;

        public StudentViewModel()
        {
            studentRepo = new StudentsRepo();
            students = new ObservableCollection<Student>(studentRepo.Students);
        }
        public ObservableCollection<Student> Students { get => students; set => students = value; }
    }
}
