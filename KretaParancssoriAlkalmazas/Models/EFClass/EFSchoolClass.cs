using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KretaParancssoriAlkalmazas.Models.AbstractClass;
using KretaParancssoriAlkalmazas.Models.DataModel;

namespace KretaParancssoriAlkalmazas.Models.EFClass
{
    [Table("schoolclass")]
    public class EFSchoolClass : SchoolClassBaseWithAttributes
    {
    }
}
