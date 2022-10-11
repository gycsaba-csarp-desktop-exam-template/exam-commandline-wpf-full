using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.DataModel;
using Kreta.Models.EFClass;
using Kreta.Models.Helpers;
using Kreta.Models.Parameters;

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
