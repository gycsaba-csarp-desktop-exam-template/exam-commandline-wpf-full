using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.Parameters;

namespace Kreta.Repositories.Interfaces
{
    public interface ISchoolClassRepo : IRepositoryBase<EFSchoolClass>
    {
        IEnumerable<EFSchoolClass> GetAllSchoolClasses();

        PagedList<EFSchoolClass> GetAllPagedSchoolClasses(SchollClassPageParameters schollClassPageParameters);
        
        IEnumerable<EFSchoolClass> GetAllFilteringSchoolClass(SchoolClassQueryYearParameter schoolClassQueryYearParameter);
        IEnumerable<EFSchoolClass> GetAllSorted(SchoolClassSortingParameters schoolClassSortingParameters);

        IEnumerable<ExpandoObject> GetAllSelectField(SchoolClassFieldsParameters schoolClassFiledsParameters);

        EFSchoolClass GetSchoolClassById(int id);
        public ExpandoObject GetSchoolClassById(int id, SchoolClassFieldsParameters fields);
    }
}
