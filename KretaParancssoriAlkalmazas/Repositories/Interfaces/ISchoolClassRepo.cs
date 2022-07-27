using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KretaParancssoriAlkalmazas.Models;

namespace Kreta.Repositories.Interfaces
{
    public interface ISchoolClassRepo : IRepositoryBase<SchoolClass>
    {
        IEnumerable<SchoolClass> GetAllSchoolClasses();
        SchoolClass GetSchoolClassById(int id);
    }
}
