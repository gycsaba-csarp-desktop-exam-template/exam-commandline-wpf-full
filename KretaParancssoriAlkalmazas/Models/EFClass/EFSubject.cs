using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KretaParancssoriAlkalmazas.Models.AbstractClass;

namespace KretaParancssoriAlkalmazas.Models.EFClass
{
    [Table("subject")]
    public class EFSubject : SubjectBaseWithAttributes
    {
        public EFSubject()
        {
            this.Id = -1;
            this.SubjectName = string.Empty;
        }
    }
}
