using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models
{
    public class Student
    {
        private int id;
        private string fullName;
        private int schoolClassId;

        public Student(int id, string fullname, int osztalyId)
        {
            this.Id = id;
            this.FullName = fullname;
            this.SchoolClassId = osztalyId;
        }

        public int Id { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int SchoolClassId { get => schoolClassId; set => schoolClassId = value; }
    }
}
