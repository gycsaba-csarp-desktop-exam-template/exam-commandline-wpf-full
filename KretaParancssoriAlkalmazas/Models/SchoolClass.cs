using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kreta.Models.Interfaces;

namespace Kreta.Models
{
    [Table("schoolclass")]
    public class SchoolClass 
    {
       
        private long id;     
        private int scoolYear;      
        private char classType;
        private int teacherId;

        public SchoolClass(long id, int grade, char gradeType, int teacherId)
        {
            this.id = id;
            this.scoolYear = grade;
            this.classType = gradeType;
            this.teacherId = teacherId;
        }

        public long Id { get => id; set => id = value; }
        [Required(ErrorMessage = "School class is required")]
        public int SchoolYear { get => scoolYear; set => scoolYear = value; }
        [Required(ErrorMessage = "Class type is required")]
        public char ClassType { get => classType; set => classType = value; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get => teacherId; set => teacherId = value; }

        public string GradeGradeType
        {
            get { return scoolYear + " " + ClassType; }
        }
    }
}
