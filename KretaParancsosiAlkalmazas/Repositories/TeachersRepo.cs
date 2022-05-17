using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Interfaces;

namespace Kreta.Repositories
{
    public partial class TeachersRepo
    {
        private List<ITeacher> teachers;

        public List<ITeacher> Teachers
        {
            get
            {
                return teachers;
            }
        }

        public int NumberOfTeacher
        {
            get
            {
                return teachers.Count;
            }
        }

        public TeachersRepo()
        {
            teachers = new List<ITeacher>();
            MakeTestData();
        }

        public List<ITeacher> GetAllTeachers()
        {
            return new List<ITeacher>(teachers);
        }


        public void MakeTestData()
        {
            teachers.Add(new Teacher(1, "Számoló", "Szonja", true, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(2, "Buktató", "Béla", false, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(3, "Aritmetika", "Antal", false, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(4, "Arany", "András",  false, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(5, "Sportoló", "Jenő", false, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(6, "Visszanéző", "Viola",  true, new DateTime(1974, 10, 24)));
        }
    }
}
