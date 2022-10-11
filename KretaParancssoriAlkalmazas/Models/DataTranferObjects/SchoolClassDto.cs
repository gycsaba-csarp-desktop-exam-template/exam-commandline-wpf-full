using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kreta.Models.Interfaces;
using Kreta.Models;

namespace Kreta.Models.DataTranferObjects
{
    public class SchoolClassDto
    {
        private long id;
        private int scoolYear;
        private char classType;
        private int teacherId;

        public SchoolClassDto(long id, int schoolYear, char classType, int teacherId)
        {
            this.id = id;
            scoolYear = schoolYear;
            this.classType = classType;
            this.teacherId = teacherId;
        }

        public long Id { get => id; set => id = value; }
        public int SchoolYear { get => scoolYear; set => scoolYear = value; }
        public char ClassType { get => classType; set => classType = value; }
        public int TeacherId { get => teacherId; set => teacherId = value; }

        public string GradeGradeType
        {
            get { return scoolYear + " " + ClassType; }
        }
    }
}
