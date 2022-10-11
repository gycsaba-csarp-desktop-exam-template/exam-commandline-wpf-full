using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.EFClass;
using Kreta.Models.Helpers;
using Kreta.Models.HTEOS;
using Kreta.Models.Parameters;

namespace Kreta.Repositories.Interfaces
{
    public interface ISubjectRepo : IRepositoryBase<EFSubject>
    {
        long GetNextId();
        PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters);
        IQueryable<EFSubject> SearchSubjectNameStartWith(string subjectNameSearchingParameters);

        ExpandoObject? GetSubjectById(long id, string fields);
        EFSubject GetSubjectById(long id);
        void CreateSubject(EFSubject subject);
        void UpdateSubject(EFSubject subject);
        void DeleteSubject(EFSubject subject);
    }
}
