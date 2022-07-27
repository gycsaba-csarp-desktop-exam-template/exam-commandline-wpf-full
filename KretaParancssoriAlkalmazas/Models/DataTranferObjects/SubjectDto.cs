using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.DataTranferObjects
{
    public  class SubjectDto
    {
        private long id;
        private string subjectName;

        public SubjectDto(long id, string subName)
        {
            this.Id = id;
            this.SubjectName = subName;
        }

        public long Id { get => id; set => id = value; }

        public string SubjectName { get => subjectName; set => subjectName = value; }

        public override string ToString()
        {
            return id + ". " + subjectName;
        }
    }
}
