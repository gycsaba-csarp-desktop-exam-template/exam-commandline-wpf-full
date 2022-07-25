using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Repositories.Interfaces;
using Kreta.Repositories.BaseClass;
using Kreta.Models.Context;

namespace Kreta.Repositories
{
    public class SchoolClassesRepo : RepositoryBase<SchoolClass>, ISchoolClassRepo
    {
        public SchoolClassesRepo(KretaContext kretaContext) 
            : base(kretaContext)
        {
        }
    }
}
