using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kreta.Repositories.Interfaces;
using Kreta.Repositories.BaseClass;
using Kreta.Models.Context;
using Kreta.Models.EFClass;
using Kreta.Models.Parameters;
using Kreta.Models.Helpers;
using Kreta.Models.HTEOS;
using System.Dynamic;
using Kreta.Models.DataModel;

namespace Kreta.Repositories
{
    public class SubjectRepo : RepositoryBase<EFSubject>, ISubjectRepo
    {
        private ISortHelper<EFSubject> sortHelper;
        private IDataShaper<EFSubject> dataShaper;

        public SubjectRepo(KretaContext kretaContext)
            :base(kretaContext)
        {
            this.sortHelper = new SortHelper<EFSubject>();
            this.dataShaper = new DataShaper<EFSubject>();
        }


        /* public SubjectRepo(KretaContext kretaContext, ISortHelper<EFSubject> sortHelper, IDataShaper<EFSubject> dataShaper)
             : base(kretaContext)
         {
             this.sortHelper = sortHelper;
             this.dataShaper = dataShaper;
         }*/

        public PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters)
        {
            var subjects = SearchSubjectNameStartWith(subjectParameters.Filter);

            var sortedSubject = sortHelper.ApplySort((IQueryable<EFSubject>) subjects, subjectParameters.OrderBy);
            var sortedAndShapedSubject = dataShaper.ShapeData(sortedSubject, subjectParameters.Fields);

            

            return PagedList<ExpandoObject>.ToPagedList(sortedAndShapedSubject, subjectParameters.CurrentPage, subjectParameters.PageSize);      
        }

        public IQueryable<EFSubject> SearchSubjectNameStartWith(string patterNameStartWith)
        {
            if (patterNameStartWith != string.Empty)
                return GetAll()
                    .Where(subject => subject.SubjectName.ToLower().StartsWith(patterNameStartWith.Trim().ToLower()));
            else
                return GetAll();
        }

        public EFSubject? GetSubjectById(long subjectId)
        {
            return Get(subjectId);   
        }

        public ExpandoObject? GetSubjectById(long subjectId,string fields)
        {
            var subjects=FindByCondition(subject => subject.Id.Equals(subjectId))
                .FirstOrDefault();
            return dataShaper.ShapeData(subjects, fields);
        }

        public void CreateSubject(EFSubject subject)
        {
            Insert(subject);
        }


        public void UpdateSubject(EFSubject subject)
        {
            Update(subject);
        }

        public void DeleteSubject(EFSubject subject)
        {
            Delete(subject);
        }

        public void DeleteAll()
        {
            DeleteAll();
        }

        public  long GetNumberOfSubject()
        {
            return Count();
        }
    }
}
