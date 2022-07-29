using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreta.Repositories.Interfaces;
using Kreta.Repositories.BaseClass;
using Kreta.Models.Context;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Linq.Expressions;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Parameters;
using KretaParancssoriAlkalmazas.Repositories.BaseClass;
using System.Reflection;

using KretaParancssoriAlkalmazas.Models.Helpers;

namespace Kreta.Repositories
{
    public class SchoolClassesRepo : RepositoryBase<SchoolClass>, ISchoolClassRepo
    {
        private ISortHelper<SchoolClass> sortHelper;

        public SchoolClassesRepo(KretaContext kretaContext,ISortHelper<SchoolClass> sortHelper) 
            : base(kretaContext)
        {
            this.sortHelper = sortHelper;
        }

        public IEnumerable<SchoolClass> GetAllSchoolClasses()
        {
            return GetAll()
                .OrderBy(schoolClass => schoolClass.SchoolYear)
                .ThenBy(schoolClass => schoolClass.ClassType)
                .ToList();
        }

        public PagedList<SchoolClass> GetAllPagedSchoolClasses(SchollClassPageParameters schollClassPageParameters)
        {
            return PagedList<SchoolClass>.ToPagedList(GetAll()
                .OrderBy(schoolClass => schoolClass.SchoolYear)
                .ThenBy(schoolClass => schoolClass.ClassType),
                schollClassPageParameters.PageNumber,
                schollClassPageParameters.PageSize);
        }

        public IEnumerable<SchoolClass> GetAllFilteringSchoolClass(SchoolClassQueryYearParameter schoolClassQueryYearParameter)
        {
            return FindByCondition(schoolClass => schoolClass.SchoolYear >= schoolClassQueryYearParameter.MinYear 
                                               && schoolClass.SchoolYear <= schoolClassQueryYearParameter.MaxYear)
                .OrderBy(schoolClass => schoolClass.SchoolYear)
                .ThenBy(schoolClass => schoolClass.ClassType)
                .ToList();
        }

        public IEnumerable<SchoolClass> GetAllSorted(SchoolClassSortingParameters schoolClassSortingParameters)
        {
            var schoolClasses= GetAll()
                .OrderBy(schoolClass => schoolClass.SchoolYear)
                .ThenBy(schoolClass => schoolClass.ClassType);

            var sortedSchoolClasses = sortHelper.ApplySort(schoolClasses, schoolClassSortingParameters.OrderBy);

            return sortedSchoolClasses.ToList();

        }

        public SchoolClass GetSchoolClassById(int id)
        {
            return Get(id);
        }
    }
}
