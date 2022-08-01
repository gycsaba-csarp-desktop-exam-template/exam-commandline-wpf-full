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

namespace Kreta.Repositories
{
    public class SubjectRepo : RepositoryBase<EFSubject>, ISubjectRepo
    {
        private ISortHelper<EFSubject> sortHelper;
        private IDataShaper<EFSubject> dataShaper;

        public SubjectRepo(KretaContext kretaContext, ISortHelper<EFSubject> sortHelper, IDataShaper<EFSubject> dataShaper)
            : base(kretaContext)
        {
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        public PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters)
        {

            var subjects = GetAll();

            var sortedSubject = sortHelper.ApplySort(subjects, subjectParameters.OrderBy);
            var sortedAndShapedSubject = dataShaper.ShapeData(sortedSubject, subjectParameters.Fields);

            return PagedList<ExpandoObject>.ToPagedList(sortedAndShapedSubject, subjectParameters.PageNumber, subjectParameters.PageSize);

         
        }

        public IEnumerable<EFSubject> SearchBySubjectName(SubjectNameSearchingParameters searchingParameters)
        {
            return GetAll()
                .Where(subject => subject.SubjectName.ToLower().Contains(searchingParameters.Name.Trim().ToLower()))
                .ToList();
        }


        public EFSubject? GetSubjectById(long subjectId)
        {
            return FindByCondition(subject => subject.Id.Equals(subjectId))
                .FirstOrDefault();
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
