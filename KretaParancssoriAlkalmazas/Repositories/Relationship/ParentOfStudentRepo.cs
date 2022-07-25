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

        public List<ParentOfStudent> ParentOfStudents { get => parentOfStudents;}

        public List<ParentOfStudent> GetAllParentOfStudents()
        {
            return new List<ParentOfStudent>(parentOfStudents);
        }

        public ParentOfStudentRepo()
        {
            parentOfStudents = new List<ParentOfStudent>();
            MakeTestData();
        }

        private void MakeTestData()
        {
            parentOfStudents.Add(new ParentOfStudent(1, 1));
            parentOfStudents.Add(new ParentOfStudent(1, 2));
            parentOfStudents.Add(new ParentOfStudent(2, 3));
            parentOfStudents.Add(new ParentOfStudent(2, 4));
            parentOfStudents.Add(new ParentOfStudent(3, 5));
            parentOfStudents.Add(new ParentOfStudent(3, 6));
            parentOfStudents.Add(new ParentOfStudent(4, 7));
            parentOfStudents.Add(new ParentOfStudent(4, 8));
            parentOfStudents.Add(new ParentOfStudent(5, 9));
            parentOfStudents.Add(new ParentOfStudent(6, 10));
        }
    }
}

