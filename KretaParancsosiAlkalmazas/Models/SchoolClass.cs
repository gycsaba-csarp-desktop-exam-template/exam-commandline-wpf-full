using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces;

namespace Kreta.Models
{
    public class SchoolClass 
    {
        private long id;
        private int schoolClass;
        private char gradeType;
        private int teacherId;

        public SchoolClass(long id, int grade, char gradeType, int teacherId)
        {
            this.id = id;
            this.schoolClass = grade;
            this.gradeType = gradeType;
            this.teacherId = teacherId;
        }

        public long Id { get => id; set => id = value; }
        public int Grade { get => schoolClass; set => schoolClass = value; }
        public char GradeType { get => gradeType; set => gradeType = value; }
        public int TeacherId { get => teacherId; set => teacherId = value; }

        public string GradeGradeType
        {
            get { return schoolClass + " " + GradeType; }
        }
    }
}
