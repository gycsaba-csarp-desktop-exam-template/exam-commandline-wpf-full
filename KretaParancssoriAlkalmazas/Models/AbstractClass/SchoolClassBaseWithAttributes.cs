using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaParancssoriAlkalmazas.Models.DataModel;

namespace KretaParancssoriAlkalmazas.Models.AbstractClass
{
    public abstract class SchoolClassBaseWithAttributes : SchoolClassBase
    {
        [Required(ErrorMessage = "School class is required")]
        public int SchoolYear { get; set ; }
        [Required(ErrorMessage = "Class type is required")]
        public char ClassType { get; set ; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
    }
}
