using Kreta.Models.Context;
using Kreta.Repositories;
using Kreta.Repositories.Interfaces;
using KretaParancssoriAlkalmazas.Services;
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

        public RepoService()
        {
            subjectService = new SubjectService();
        }
    }
}
