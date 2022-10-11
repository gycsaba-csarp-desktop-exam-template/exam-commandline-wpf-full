using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.AbstractClass
{
    public abstract class ParentBaseWithAnnotations : ParentBase
    {
        [Column("name")]
        [Display(Name = "Parent name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "The name cannot be longer than 30 characters")]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long")]
        [RegularExpression(@"^([A-ZÁÉIÍÖÓŐÚÜŰ]+[a-záéiíöóőúüű]* *)+$", ErrorMessage = "First letter must be uppercase, other lowercase")]
        public override string Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        [Column("childname")]
        [Display(Name = "Child's name")]
        [Required(ErrorMessage = "Child's name is required")]
        [StringLength(30, ErrorMessage = "The child's name cannot be longer than 30 characters")]
        [MinLength(3, ErrorMessage = "The child's name must be at least 3 characters long")]
        [RegularExpression(@"^([A-ZÁÉIÍÖÓŐÚÜŰ]+[a-záéiíöóőúüű]* *)+$", ErrorMessage = "First letter must be uppercase, other lowercase")]
        public override string ChildName
        {
            get => base.ChildName;
            set => base.ChildName = value;
        }
    }
}
