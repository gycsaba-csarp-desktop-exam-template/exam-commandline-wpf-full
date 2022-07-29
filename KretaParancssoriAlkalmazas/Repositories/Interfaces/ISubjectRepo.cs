using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Parameters;

namespace Kreta.Repositories.Interfaces
{
    public interface ISubjectRepo : IRepositoryBase<EFSubject>
    {
        IEnumerable<EFSubject> GetAllSubjects();
        IEnumerable<EFSubject> SearchBySubjectName(SubjectNameSearchingParameters subjectNameSearchingParameters);

        EFSubject? GetSubjectById(long id);
        void CreateSubject(EFSubject subject);
        void UpdateSubject(EFSubject subject);
        void DeleteSubject(EFSubject subject);
    }
}
