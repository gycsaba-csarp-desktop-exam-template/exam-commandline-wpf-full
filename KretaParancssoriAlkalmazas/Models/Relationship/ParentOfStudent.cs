using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Relationship
{
    class ParentOfStudent
    {
        private int studentId;
        private int parentId;

        public int StudentId { get => studentId; set => studentId = value; }
        public int ParentId { get => parentId; set => parentId = value; }

        public ParentOfStudent(int studentId, int parentId)
        {
            this.studentId = studentId;
            this.parentId = parentId;
        }
    }
}
