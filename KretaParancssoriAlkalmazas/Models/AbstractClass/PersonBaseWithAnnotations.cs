using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.AbstractClass
{ 
    public abstract class PersonBaseWithAnnotations : PersonBase
    {
        public PersonBaseWithAnnotations()
            : base()
        {
        }

        public PersonBaseWithAnnotations(int id, string name, string birthDate, bool gender)
            : base(id, name, birthDate, gender)
        {
        }

        [Column("name")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "The name cannot be longer than 30 characters")]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters long")]
        [RegularExpression(@"^([A-ZÁÉIÍÖÓŐÚÜŰ]+[a-záéiíöóőúüű]* *)+$", ErrorMessage = "First letter must be uppercase, other lowercase")]
        public override string Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        [Column("birth_date")]
        [Display(Name = "Birth date")]
        [Required(ErrorMessage = "Birth date is required")]
        [RegularExpression(@"^[1|2]\d{3}.\d{2}\.\d{2}$", ErrorMessage = "Birth date must be a valid date")]
        public override string BirthDate
        {
            get => base.BirthDate;
            set => base.BirthDate = value;
        }

        [Column("gender")]
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public override bool Gender
        {
            get => base.Gender;
            set => base.Gender = value;
        }
    }
}
