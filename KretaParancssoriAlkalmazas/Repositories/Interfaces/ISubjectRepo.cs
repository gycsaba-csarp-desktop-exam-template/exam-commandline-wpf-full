using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.HTEOS;
using KretaParancssoriAlkalmazas.Models.Parameters;

namespace Kreta.Repositories.Interfaces
{
    public interface ISubjectRepo : IRepositoryBase<EFSubject>
    {
        PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters);
        IEnumerable<EFSubject> SearchBySubjectName(SubjectNameSearchingParameters subjectNameSearchingParameters);

        EFSubject? GetSubjectById(long id);
        void CreateSubject(EFSubject subject);
        void UpdateSubject(EFSubject subject);
        void DeleteSubject(EFSubject subject);
    }
}
