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
    public class SubjectViewModel
    {
        private SubjectRepo subjectRepo;
        private ObservableCollection<Subject> subjects;

        public SubjectViewModel()
        {
            subjectRepo = new SubjectRepo();
            subjects = new ObservableCollection<Subject>(subjectRepo.Subject);
        }

        public ObservableCollection<Subject> Subjects { get => subjects; set => subjects = value; }
    }
}
