using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;

namespace Kreta.Models.Relationship
{
    public class ClassesRepo
    {
        private List<Class> classes;

        public List<Class> Classes { get => classes; }

        public ClassesRepo()
        {
            classes = new List<Class>();
            MakeTestData();
        }

        public void MakeTestData()
        {
            classes.Add(new Class(1, 9, 'a', 4));
            classes.Add(new Class(2, 9, 'b', 1));
            classes.Add(new Class(3, 10, 'a', 6));
            classes.Add(new Class(4, 10, 'b', 3));
            classes.Add(new Class(5, 10, 'c', 0));
        }
    }
}
