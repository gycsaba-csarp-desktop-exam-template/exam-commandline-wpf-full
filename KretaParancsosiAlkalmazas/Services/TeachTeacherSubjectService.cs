using Kreta.Models;
using Kreta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Interfaces;
using Kreta.Repositories.Relationship;

namespace Kreta.Services
{
    public class TeachTeacherSubjectService
    {
        private TeachersRepo teachersRepo;
        private SubjectRepo subjectRepo;
        private TeachTeacherSubjectRepo teachTeacherSubjectRepo;

        public TeachTeacherSubjectService()
        {
            teachersRepo = new TeachersRepo();
            subjectRepo = new SubjectRepo();
            teachTeacherSubjectRepo = new TeachTeacherSubjectRepo();
        }

        public List<ITeacher> GetAllTeachers()
        {
            return teachersRepo.GetAllTeachers();
        }

        public List<Subject> GetTeachersSubject(long teacherId)
        {
            List<long> subjedIds = teachTeacherSubjectRepo.GetTeacherSubjectsIds(teacherId);
            List<Subject> teacherSubjects = new List<Subject>();
            foreach(int subjectID in subjedIds)
            {
                teacherSubjects.Add(subjectRepo.GetSubject(subjectID));
            }
            return teacherSubjects;
        }

        public List<Subject> GetTeachersNotTeachedSubjects(long teacherId)
        {
            List<long> teachedSubjedIds = teachTeacherSubjectRepo.GetTeacherSubjectsIds(teacherId);
            List<Subject> allSubjects =  new List<Subject>(subjectRepo.Subjects);
            List<Subject> notTeachedSubjet = allSubjects;
            foreach (int subjectID in teachedSubjedIds)
            {
                Subject teachedSubject = subjectRepo.GetSubject(subjectID);
                allSubjects.Remove(teachedSubject);
            }
            return notTeachedSubjet;
        }

        public void AddTeacherSubject(long teacherId, long subjectId)
        {
            teachTeacherSubjectRepo.Add(teacherId, subjectId);
        }

        public void DeleteTeacherSubject(long teacherId, long subjectId)
        {
            teachTeacherSubjectRepo.Delete(teacherId, subjectId);
        }
    }

}
