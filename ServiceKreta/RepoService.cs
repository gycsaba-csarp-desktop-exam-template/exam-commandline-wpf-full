using Kreta.Models.Context;
using Kreta.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceKreta
{
    public class RepoService : IRepoService
    {
        private SubjectService subjectService;
        private KretaContext context;

        public RepoService(KretaContext context)
        {
            this.context = context;
            subjectService = new SubjectService(context);
        }
    }
}
