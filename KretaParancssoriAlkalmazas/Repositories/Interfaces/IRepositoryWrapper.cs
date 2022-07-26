using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        //ISchoolClassRepo SchoolClass { get; }
        ISubjectRepo SubjectRepo { get;  }
        void Save();
    }
}
