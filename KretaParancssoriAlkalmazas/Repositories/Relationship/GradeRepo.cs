using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Relationship;

namespace Kreta.Repositories.Relationship
{
    class GradeRepo
    {
        List<Grade> grades;

        public GradeRepo()
        {
            grades = new List<Grade>();
            MakeTestData();
        }

        public void MakeTestData()
        {
            grades.Add(new Grade(1, 1, 1, new List<int> { 5, 4, 2 }));
            grades.Add(new Grade(1, 2, 1, new List<int> { 4, 3, 2 }));
        }


    }


}
