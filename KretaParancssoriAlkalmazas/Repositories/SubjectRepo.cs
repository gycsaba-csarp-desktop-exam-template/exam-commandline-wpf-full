using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Kreta.Repositories.Interfaces;
using Kreta.Repositories.BaseClass;
using Kreta.Models.Context;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Parameters;
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.HTEOS;
using System.Dynamic;
using KretaParancssoriAlkalmazas.Models.DataModel;

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
            KretaContext dBContext = base.KretaContext;
            List<EFSubject> proba = dBContext.Set<EFSubject>().ToList();
            EFSubject fSubject = dBContext.Set<EFSubject>().Where(x => x.Id == 1).FirstOrDefault();
            EFSubject subject = FindByCondition(subject => subject.Id.Equals(subjectId)).FirstOrDefault();
            return subject;
   
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
    }
}
