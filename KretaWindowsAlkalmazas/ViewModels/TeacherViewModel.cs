using Kreta.Models;
using Kreta.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.ViewModel
{
    public class TeacherViewModel
    {
        private TeachersRepo teachersRepo;
        private ObservableCollection<Teacher> teachers;

        public TeacherViewModel()
        {
            teachersRepo = new TeachersRepo();
            teachers = new ObservableCollection<Teacher>(teachersRepo.Teachers);
        }

        public ObservableCollection<Teacher> Teachers { get => teachers; set => teachers = value; }
    }
}
