using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.AbstractClass
{
    public abstract class ClassWithId
    {
        public ClassWithId(long id)
        {
            this.Id = id;     
        }

        public long Id { get; set; }
    }
    
}
