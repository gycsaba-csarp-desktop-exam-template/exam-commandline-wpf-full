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
        private ClassesRepo classesRepo;
        private ObservableCollection<Class> classes;

        public ClassViewModel()
        {
            classesRepo = new ClassesRepo();
            classes = new ObservableCollection<Class>(classesRepo.Classes);
        }

        public ObservableCollection<Class> Classes { get => classes; set => classes = value; }
    }
}
