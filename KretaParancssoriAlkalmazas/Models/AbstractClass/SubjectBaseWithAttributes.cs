using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KretaParancssoriAlkalmazas.Models.AbstractClass
{
    public abstract class SubjectBaseWithAttributes : SubjectBase
    {
        [Column("name")]
        [Required(ErrorMessage = "The name is required")]
        [StringLength(30, ErrorMessage = "The name cannot be longer than 30 characters")]
        public override string SubjectName { get; set; }
    }
}
