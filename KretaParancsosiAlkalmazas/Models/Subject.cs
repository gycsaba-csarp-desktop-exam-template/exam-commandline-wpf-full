using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models
{
    public class Subject
    {

        private int id;
        private string subjectName;

        public int NumberOfSubjects
        {
            get
            {
                return 0;
            }
        }

        public Subject(int id, string subName)
        {
            this.Id = id;
            this.SubjectName = subName;
        }

        public int Id { get => id; set => id = value; }
        public string SubjectName { get => subjectName; set => subjectName = value; }

        public override string ToString()
        {
            return id + ". " + subjectName;
        }

    }
}
