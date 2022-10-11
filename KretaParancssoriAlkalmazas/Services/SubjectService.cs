using Kreta.Models.Context;
using Kreta.Repositories;
using Kreta.Models.EFClass;
using Kreta.Models.Helpers;
using Kreta.Models.Parameters;
using ServiceKretaLogger;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Services
{
    public class SubjectService : ISubjectService
    {
        private SubjectRepo subjectRepo;
        private KretaContext context;

        public SubjectService(KretaContext context)
        {
            this.context = context;
            subjectRepo = new SubjectRepo(context);
        }

        public void CreateSubject(EFSubject insertedEFSubject)
        {
            subjectRepo.CreateSubject(insertedEFSubject);
            try
            {
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.InnerException.Message);
            }
        }

        public void DeleteSubject(EFSubject subject)
        {
            subjectRepo.Delete(subject);
            context.SaveChanges();
        }

        public PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters)
        {
            return subjectRepo.GetAllSubjects(subjectParameters);            
        }

        public long GetNextId()
        {
            return subjectRepo.GetNextId();
        }

        public EFSubject GetSubjectById(long id)
        {
            return subjectRepo.GetSubjectById(id);
        }

        public IQueryable<EFSubject> SearchSubjectNameStartWith(string name)
        {
            return subjectRepo.SearchSubjectNameStartWith(name);
        }

        public void Update(EFSubject updatedEFSubject)
        {
            subjectRepo.Update(updatedEFSubject);
            context.SaveChanges();
        }

        public long GetNumberOfSubject()
        {
            return subjectRepo.GetNumberOfSubject();
        }

    }
}
