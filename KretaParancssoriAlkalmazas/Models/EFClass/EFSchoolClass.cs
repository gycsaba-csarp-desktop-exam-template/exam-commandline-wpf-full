using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreta.Models.AbstractClass;
using Kreta.Models.DataModel;

namespace Kreta.Models.EFClass
{
    [Table("schoolclass")]
    public class EFSchoolClass : SchoolClassBaseWithAttributes
    {
    }
}
