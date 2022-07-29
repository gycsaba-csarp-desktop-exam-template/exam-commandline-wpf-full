using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Parameters;
using KretaParancssoriAlkalmazas.Repositories.BaseClass;

namespace Kreta.Repositories.Interfaces
{
    public interface ISchoolClassRepo : IRepositoryBase<SchoolClass>
    {
        IEnumerable<SchoolClass> GetAllSchoolClasses();
        PagedList<SchoolClass> GetAllPagedSchoolClasses(SchollClassPageParameters schollClassPageParameters);
        IEnumerable<SchoolClass> GetAllFilteringSchoolClass(SchoolClassQueryYearParameter schoolClassQueryYearParameter);
        SchoolClass GetSchoolClassById(int id);
    }
}
