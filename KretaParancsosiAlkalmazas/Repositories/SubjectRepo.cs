using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Repositories.Interfaces;
using Kreta.Repositories.BaseClass;
using Kreta.Models.Context;

namespace Kreta.Repositories
{
    public class SubjectRepo : RepositoryBase<Subject>, ISubjectRepo
    {
        public SubjectRepo(KretaContext kretaContext)
            : base(kretaContext)
        {
        }
    }
}
