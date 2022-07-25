using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories.Interfaces;
using Kreta.Models.Context;

namespace Kreta.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private KretaContext kretaContext;
        private ISchoolClassRepo schoolClass;
        private ISubjectRepo subjectRepo;

        public RepositoryWrapper(KretaContext kretaContext)
        {
            this.kretaContext = kretaContext;
        }

        public ISchoolClassRepo SchoolClass
        {
            get
            {
                if (schoolClass == null)
                {
                    schoolClass = new SchoolClassesRepo(kretaContext);
                }
                return schoolClass;
            }
        }

        public ISubjectRepo SubjectRepo
        {
            get
            {
                if (subjectRepo==null)
                {
                    subjectRepo = new SubjectRepo(kretaContext);
                }
                return subjectRepo;
            }
        }

        public void Save()
        {
            kretaContext.SaveChanges();
        }
    }
}
