using Kreta.Models;
using Kreta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreta.Repositories;

namespace Kreta.Services
{
    public class TeachTeacherSubjectService
    {
        TeachersRepo teachersRepo;
        SubjectRepo subjectRepo;

        public TeachTeacherSubjectService()
        {
            teachersRepo = new TeachersRepo();
            subjectRepo = new SubjectRepo();
        }

        public List<Teacher> Teachers
        {
            get
            {
                return teachersRepo.Teachers;
            }
        }
        public List<Subject> GetTeachersSubject(int teacherId)
        {
            return subjectRepo.Subject.FindAll(x => x.Id == teacherId);
        }
    }

}
