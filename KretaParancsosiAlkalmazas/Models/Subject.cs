using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kreta.Models
{
    [Table("subject")]
    public class Subject
    {

        private long id;
        private string subjectName;

        public Subject(long id, string subName)
        {
            this.Id = id;
            this.SubjectName = subName;
        }

        public long Id { get => id; set => id = value; }
        [Required(ErrorMessage ="The name is required")]
        [StringLength(30,ErrorMessage ="The name cannot be longer than 30 characters")]
        public string SubjectName { get => subjectName; set => subjectName = value; }

        public override string ToString()
        {
            return id + ". " + subjectName;
        }

    }
}
