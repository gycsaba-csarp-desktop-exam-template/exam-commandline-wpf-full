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

namespace Kreta.Repositories
{
    public class SchoolClassesRepo : RepositoryBase<SchoolClass>, ISchoolClassRepo
    {
        public SchoolClassesRepo(KretaContext kretaContext) 
            : base(kretaContext)
        {
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

        public SchoolClass GetSchoolClassById(int id)
        {
            return Get(id);      
        }
    }
}
