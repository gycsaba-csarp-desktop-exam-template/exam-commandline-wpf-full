using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories.Interfaces;
using Kreta.Models.Context;
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.EFClass;

namespace Kreta.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private KretaContext kretaContext;
        private ISchoolClassRepo schoolClass;
        private ISubjectRepo subjectRepo;

        private ISortHelper<EFSchoolClass> schoolSortHelper;
        private IDataShaper<EFSchoolClass> schoolDataShaper;

        private ISortHelper<EFSubject> subjectSortHelper;
        private IDataShaper<EFSubject> subjectDataShaper;
        

        public RepositoryWrapper(KretaContext kretaContext, ISortHelper<EFSchoolClass> schoolSortHelper, IDataShaper<EFSchoolClass> schoolDataShaper, ISortHelper<EFSubject> subjectSortHelper,IDataShaper<EFSubject> subjectDataShaper)
        {
            this.kretaContext = kretaContext;
            this.schoolSortHelper = schoolSortHelper;
            this.schoolDataShaper = schoolDataShaper;
            this.subjectSortHelper = subjectSortHelper;
            this.subjectDataShaper = subjectDataShaper;
        }

        public ISchoolClassRepo SchoolClass
        {
            get
            {
                if (schoolClass == null)
                {
                    schoolClass = new SchoolClassesRepo(kretaContext, schoolSortHelper,schoolDataShaper);
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
                    subjectRepo = new SubjectRepo(kretaContext,subjectSortHelper,subjectDataShaper);
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
