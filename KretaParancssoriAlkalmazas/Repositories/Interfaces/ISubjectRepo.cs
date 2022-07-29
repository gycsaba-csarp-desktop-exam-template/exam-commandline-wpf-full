using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KretaParancssoriAlkalmazas.Models.EFClass;

namespace Kreta.Repositories.Interfaces
{
    public interface ISubjectRepo : IRepositoryBase<EFSubject>
    {
        IEnumerable<EFSubject> GetAllSubjects();
        EFSubject? GetSubjectById(long id);
        void CreateSubject(EFSubject subject);
        void UpdateSubject(EFSubject subject);
        void DeleteSubject(EFSubject subject);
    }
}
