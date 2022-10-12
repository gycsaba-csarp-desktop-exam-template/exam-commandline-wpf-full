using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Repositories;
using System.Collections.ObjectModel;

namespace Kreta.ViewModels
{
    public class ClassViewModel
    {
        private SchoolClassesRepo classesRepo;
        private ObservableCollection<SchoolClass> classes;

        public ClassViewModel()
        {
            classesRepo = new SchoolClassesRepo();
            classes = new ObservableCollection<SchoolClass>(classesRepo.SchoolClasses);
        }

        public ObservableCollection<SchoolClass> Classes { get => classes; set => classes = value; }
    }
}
