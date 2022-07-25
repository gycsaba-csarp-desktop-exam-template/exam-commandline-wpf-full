using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Relationship
{
    class TeachTeacherSubject
    {
        private long teacherID;
        private long subjectID;

        public TeachTeacherSubject(long teacherID, long subjectID)
        {
            this.teacherID = teacherID;
            this.subjectID = subjectID;
        }

        public long TeacherID { get => teacherID; set => teacherID = value; }
        public long SubjectID { get => subjectID; set => subjectID = value; }
    }
}
