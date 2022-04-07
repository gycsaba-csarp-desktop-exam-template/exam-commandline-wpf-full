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

        public ParentOfStudent(int studentId, int parentId)
        {
            this.studentId = studentId;
            this.parentId = parentId;
        }
    }
}
