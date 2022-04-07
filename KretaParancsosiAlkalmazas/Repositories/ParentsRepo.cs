using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;

namespace Kreta.Repositories
{
    class ParentsRepo
    {
        private List<Parent> parents;

        public ParentsRepo()
        {
            parents = new List<Parent>();
            MakeTestData();
        }

        internal List<Parent> Parents { get => parents; set => parents = value; }

        private void MakeTestData()
        {
            parents.Add(new Parent(1, "Kis Szonja", true));
            parents.Add(new Parent(2, "Nagy Imre", false));
            parents.Add(new Parent(3, "Szabó Ida", true));
            parents.Add(new Parent(4, "Szabó Sándor", true));
        }
    }
}
