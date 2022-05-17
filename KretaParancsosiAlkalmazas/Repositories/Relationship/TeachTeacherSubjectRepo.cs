using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Relationship;

namespace Kreta.Repositories.Relationship
{
    class TeachTeacherSubjectRepo
    {
        private List<TeachTeacherSubject> teachTeacherSubjects;

        public List<TeachTeacherSubject> TeachTeacherSubjects { get => teachTeacherSubjects; }

        public TeachTeacherSubjectRepo()
        {
            teachTeacherSubjects = new List<TeachTeacherSubject>();
            MakeTestData();
        }

        public List<long> GetTeacherSubjectsIds(long teacherId)
        {
            var teacherSubjectsIds = teachTeacherSubjects.Where(tts => tts.TeacherID == teacherId).Select(tts => tts.SubjectID);
            return teacherSubjectsIds.ToList();
        }

        public void MakeTestData()
        {
            teachTeacherSubjects.Add(new TeachTeacherSubject(1, 1));
            teachTeacherSubjects.Add(new TeachTeacherSubject(1, 2));
            teachTeacherSubjects.Add(new TeachTeacherSubject(2, 1));
            teachTeacherSubjects.Add(new TeachTeacherSubject(2, 2));
            teachTeacherSubjects.Add(new TeachTeacherSubject(2, 3));
        }

        public void Add(long teacherId, long subjectId)
        {
            teachTeacherSubjects.Add(new TeachTeacherSubject(teacherId, subjectId));
        }

        public void Delete(long teacherId, long subjectId)
        {
            TeachTeacherSubject subjectToDelete = teachTeacherSubjects.Find(tts => tts.TeacherID == teacherId && tts.SubjectID == subjectId);
            if (subjectToDelete != null)
                teachTeacherSubjects.Remove(subjectToDelete);
        }
    }
}
