using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Interfaces;
using Kreta.Repositories.BaseClass;

namespace Kreta.Repositories
{
    public class TeachersDatabaseRepo<TEntity, TContext> : GenericDatabaseRepository<ITeacher, JKContext>
    {
        public TeachersDatabaseRepo(JKContext context) : base(context)
        {

        }
    }
}
