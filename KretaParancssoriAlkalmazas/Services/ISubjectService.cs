using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Services
{
    public interface ISubjectService
    {
        public PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters);
        long GetNextId();
        IQueryable<EFSubject> SearchSubjectNameStartWith(string name);
        EFSubject GetSubjectById(long id);
        void CreateSubject(EFSubject insertedEFSubject);
        void Update(EFSubject updatedEFSubject);
        void DeleteSubject(EFSubject subject);
    }
}
