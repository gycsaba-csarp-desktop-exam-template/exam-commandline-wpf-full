using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Services
{
    public interface ISubjectService
    {
        public PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters);
    }
}
