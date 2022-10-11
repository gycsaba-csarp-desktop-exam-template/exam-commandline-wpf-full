using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.AbstractClass
{
    public abstract class TeacherBaseWithAnnotations : TeacherBase
    {
        [Column("name")]
        [Display(Name = "Teacher name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "The name cannot be longer than 30 characters")]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long")]
        [RegularExpression(@"^([A-ZÁÉIÍÖÓŐÚÜŰ]+[a-záéiíöóőúüű]* *)+$", ErrorMessage = "First letter must be uppercase, other lowercase")]
        public override string Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        public override string HeadTeacherOfClass
        {
            get => base.HeadTeacherOfClass;
            set => base.HeadTeacherOfClass = value;
        }
    }
}
