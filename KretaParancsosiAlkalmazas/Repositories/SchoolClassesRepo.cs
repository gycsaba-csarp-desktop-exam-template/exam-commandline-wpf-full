using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;

namespace Kreta.Repositories
{
    public class SchoolClassesRepo
    {
        private List<SchoolClass> schoolClasses;

        public List<SchoolClass> SchoolClasses { get => schoolClasses; }

        public int NumberOfClasses
        {
            get
            {
                return schoolClasses.Count;
            }
        }

        public SchoolClassesRepo()
        {
            schoolClasses = new List<SchoolClass>();
            MakeTestData();
        }

        public void MakeTestData()
        {
            schoolClasses.Add(new SchoolClass(1, 9, 'a', 4));
            schoolClasses.Add(new SchoolClass(2, 9, 'b', 1));
            schoolClasses.Add(new SchoolClass(3, 10, 'a', 6));
            schoolClasses.Add(new SchoolClass(4, 10, 'b', 3));
            schoolClasses.Add(new SchoolClass(5, 10, 'c', 0));
        }
    }
}
