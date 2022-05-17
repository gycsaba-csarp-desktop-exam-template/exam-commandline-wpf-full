using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Interfaces;
using Kreta.Repositories.BaseClass;

namespace Kreta.Repositories
{
    public partial class TeachersTestRepo<TEntity> : GenericTestRepository<ITeacher, List<ITeacher>>
    {

        // https://stackoverflow.com/questions/17902579/repository-pattern-and-unit-testing-from-memory
        public List<ITeacher> Teachers
        {
            get
            {
                return repo; 
            }
        }

        public int NumberOfTeacher
        {
            get
            {
                return repo.Count;
            }
        }

        public TeachersTestRepo()
        {
            repo = new List<ITeacher>();
            MakeTestData();            
        }

        public List<ITeacher> GetAllTeachers()
        {
            return new List<ITeacher>(repo);
        }


        public void MakeTestData()
        {
            repo.Add(new Teacher(1, "Számoló", "Szonja", true, new DateTime(1974, 10, 24)));
            repo.Add(new Teacher(2, "Buktató", "Béla", false, new DateTime(1974, 10, 24)));
            repo.Add(new Teacher(3, "Aritmetika", "Antal", false, new DateTime(1974, 10, 24)));
            repo.Add(new Teacher(4, "Arany", "András",  false, new DateTime(1974, 10, 24)));
            repo.Add(new Teacher(5, "Sportoló", "Jenő", false, new DateTime(1974, 10, 24)));
            repo.Add(new Teacher(6, "Visszanéző", "Viola",  true, new DateTime(1974, 10, 24)));
        }
    }
}
