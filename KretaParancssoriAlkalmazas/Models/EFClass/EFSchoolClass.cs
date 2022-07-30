using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaParancssoriAlkalmazas.Models.DataModel;

namespace KretaParancssoriAlkalmazas.Models.EFClass
{
    [Table("schoolclass")]
    public class EFSchoolClass
    {

        private long id;
        private int scoolYear;
        private char classType;
        private int teacherId;

        public EFSchoolClass(long id, int schoolYear, char classType, int teacherId)
        {
            this.id = id;
            scoolYear = schoolYear;
            this.classType = classType;
            this.teacherId = teacherId;
        }

        public EFSchoolClass()
        {
            this.id = -1;
            scoolYear = 9;
            this.classType = 'a';
            this.teacherId = -1;
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
