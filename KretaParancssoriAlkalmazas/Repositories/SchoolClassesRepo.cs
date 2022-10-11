using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreta.Repositories.Interfaces;
using Kreta.Repositories.BaseClass;
using Kreta.Models.Context;
using Kreta.Models.DataTranferObjects;
using System.Linq.Expressions;
using Kreta.Models.DataModel;
using Kreta.Models.Parameters;
using System.Reflection;

using Kreta.Models.Helpers;
using System.Dynamic;
using Kreta.Models.EFClass;
using System.Linq.Dynamic.Core;

namespace Kreta.Repositories
{
    public class SchoolClassesRepo : RepositoryBase<EFSchoolClass>, ISchoolClassRepo
    {
        private ISortHelper<EFSchoolClass> sortHelper;
        private IDataShaper<EFSchoolClass> dataShaper;

        public SchoolClassesRepo(KretaContext kretaContext,ISortHelper<EFSchoolClass> sortHelper, IDataShaper<EFSchoolClass> dataShaper)
            : base(kretaContext)
        {
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        public IEnumerable<EFSchoolClass> GetAllSchoolClasses()
        {
            return GetAll()
                .OrderBy(schoolClass => schoolClass.SchoolYear)
                .ThenBy(schoolClass => schoolClass.ClassType)
                .ToList();
        }

        public PagedList<EFSchoolClass> GetAllPagedSchoolClasses(SchollClassPageParameters schollClassPageParameters)
        {
            return PagedList<EFSchoolClass>.ToPagedList(GetAll()
                                                        .OrderBy(schoolClass => schoolClass.SchoolYear)
                                                        .ThenBy(schoolClass => schoolClass.ClassType),
                                                       schollClassPageParameters.PageNumber,
                                                       schollClassPageParameters.PageSize);
        }

        public IEnumerable<EFSchoolClass> GetAllFilteringSchoolClass(SchoolClassQueryYearParameter schoolClassQueryYearParameter)
        {
            return FindByCondition(schoolClass => schoolClass.SchoolYear >= schoolClassQueryYearParameter.MinYear 
                                               && schoolClass.SchoolYear <= schoolClassQueryYearParameter.MaxYear)
                .OrderBy(schoolClass => schoolClass.SchoolYear)
                .ThenBy(schoolClass => schoolClass.ClassType)
                .ToList();
        }

        public IEnumerable<EFSchoolClass> GetAllSorted(SchoolClassSortingParameters schoolClassSortingParameters)
        {
            var schoolClasses= GetAll()
                .OrderBy(schoolClass => schoolClass.SchoolYear)
                .ThenBy(schoolClass => schoolClass.ClassType);

            var sortedSchoolClasses = sortHelper.ApplySort(schoolClasses, schoolClassSortingParameters.OrderBy);

            return sortedSchoolClasses.ToList();

        }

        public IEnumerable<ExpandoObject> GetAllSelectField(SchoolClassFieldsParameters schoolClassFiledsParameters)
        {
            var schoolClasses = GetAll()
                .OrderBy(schoolClass => schoolClass.SchoolYear)
                .ThenBy(schoolClass => schoolClass.ClassType);

            var shapedSchoolClasses = dataShaper.ShapeData(schoolClasses, schoolClassFiledsParameters.Fields);

            return shapedSchoolClasses;
        }

        public EFSchoolClass GetSchoolClassById(int id)
        {
            return Get(id);
        }

        public ExpandoObject GetSchoolClassById(int id, SchoolClassFieldsParameters fields)
        {
            var schoolClass = FindByCondition(schoolClass => schoolClass.Id.Equals(id))
                .FirstOrDefault();

            if (schoolClass == null)
                schoolClass = new EFSchoolClass();

            return dataShaper.ShapeData(schoolClass, fields.Fields);
        }

    }
}
