using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KretaParancssoriAlkalmazas.Models.DataTranferObjects
{
    public class SubjectForCreationDto
    {
        private long id;
        private string subjectName;

        public long Id { get => id; set => id = value; }

        [Column("name")]
        [Required(ErrorMessage = "The name is required")]
        [StringLength(30, ErrorMessage = "The name cannot be longer than 30 characters")]
        public string SubjectName { get => subjectName; set => subjectName = value; }
    }
}
