using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Relationship;

namespace Kreta.Repositories.Relationship
{
    class ParentOfStudentRepo
    {
        List<ParentOfStudent> parentOfStudents;

        public ParentOfStudentRepo()
        {
            parentOfStudents = new List<ParentOfStudent>();
            MakeTestData();
        }

        private void MakeTestData()
        {
            parentOfStudents.Add(new ParentOfStudent(1, 1));
            parentOfStudents.Add(new ParentOfStudent(2, 2));
            parentOfStudents.Add(new ParentOfStudent(3, 3));
            parentOfStudents.Add(new ParentOfStudent(3, 4));
        }
    }
}
