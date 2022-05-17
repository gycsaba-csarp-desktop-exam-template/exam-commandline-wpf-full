using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Interfaces;
using Kreta.Repositories;

namespace Kreta.ViewModel
{
    public class TeacherViewModel
    {
        private TeachersRepo teachersRepo;
        private ObservableCollection<ITeacher> teachers;

        public TeacherViewModel()
        {
            teachersRepo = new TeachersRepo();
            teachers = new ObservableCollection<ITeacher>(teachersRepo.Teachers);
        }

        public ObservableCollection<ITeacher> Teachers { get => teachers; set => teachers = value; }
    }
}
