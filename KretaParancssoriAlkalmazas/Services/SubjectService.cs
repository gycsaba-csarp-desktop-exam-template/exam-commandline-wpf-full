using Kreta.Models.Context;
using Kreta.Repositories;
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
    public class SubjectService : ISubjectService
    {
        private SubjectRepo subjectRepo;

        public SubjectService(KretaContext context)
        {
            subjectRepo = new SubjectRepo();
        }

        public PagedList<ExpandoObject> GetAllSubjects(SubjectParameters subjectParameters)
        {

            
        }
    }
}
