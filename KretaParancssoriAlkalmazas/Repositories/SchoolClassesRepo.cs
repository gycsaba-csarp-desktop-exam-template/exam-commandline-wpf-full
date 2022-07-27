using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreta.Repositories.Interfaces;
using Kreta.Repositories.BaseClass;
using Kreta.Models.Context;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using KretaParancssoriAlkalmazas.Models;
using System.Linq.Expressions;

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

        public SchoolClass GetSchoolClassById(int id)
        {
            return Get(id);      
        }
    }
}
