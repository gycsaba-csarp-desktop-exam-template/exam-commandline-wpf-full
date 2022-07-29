using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories.Interfaces;
using Kreta.Models.Context;
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.DataModel;

namespace Kreta.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private KretaContext kretaContext;
        private ISchoolClassRepo schoolClass;
        private ISubjectRepo subjectRepo;

        private ISortHelper<SchoolClass> schoolClassSortHelper;

        public RepositoryWrapper(KretaContext kretaContext, ISortHelper<SchoolClass> schoolClassSortHelper)
        {
            this.kretaContext = kretaContext;
            this.schoolClassSortHelper = schoolClassSortHelper;
        }

        public ISchoolClassRepo SchoolClass
        {
            get
            {
                if (schoolClass == null)
                {
                    schoolClass = new SchoolClassesRepo(kretaContext, schoolClassSortHelper);
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
            try
            {
                kretaContext.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
