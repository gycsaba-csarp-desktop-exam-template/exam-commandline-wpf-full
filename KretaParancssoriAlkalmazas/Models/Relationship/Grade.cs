using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Relationship
{
    class Grade
    {
        private int teacherId;
        private int subjectId;
        private int studentId;

        private List<int> grades;

        public Grade(int teacherId, int subjectId, int studentId, List<int> grades)
        {
            this.teacherId = teacherId;
            this.subjectId = subjectId;
            this.studentId = studentId;
            this.grades = grades;
        }
    }
}
