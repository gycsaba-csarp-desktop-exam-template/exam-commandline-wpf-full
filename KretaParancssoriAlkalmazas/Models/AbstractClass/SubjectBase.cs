using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.AbstractClass
{
    public abstract class SubjectBase : ClassWithId
    {

        public SubjectBase(long id, string subName)
            :base(id)
        {
            this.SubjectName = subName;
        }
        
        public SubjectBase()
            :base(-1)
        {            
            this.SubjectName = String.Empty;
        }

        public virtual string SubjectName { get; set; }

        public override string ToString()
        {
            return Id + ". " + SubjectName;
        }
    }
}
