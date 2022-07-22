using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Context;
using Kreta.Models.Interfaces;
using Kreta.Repositories.Interfaces;

namespace Kreta.Repositories
{
    public class TeacherDatabaseRepo<TEntity, TContext> : ICRUDRepository<ITeacher, KretaContext>
    {
        public TeacherDatabaseRepo(KretaContext context) : base(context)
        {

        }
    }
}
