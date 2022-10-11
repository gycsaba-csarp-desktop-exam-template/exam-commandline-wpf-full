using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.AbstractClass
{
    public abstract class ParentBase : PersonBaseWithAnnotations
    {
        public virtual String ChildName { get; set; }

        public ParentBase()
            : base()
        {
            this.ChildName = string.Empty;
        }

        public ParentBase(int id, string name, string birthDate, bool gender, string childName)
            : base(id, name, birthDate, gender)
        {
            this.ChildName = childName;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {this.ChildName}";
        }
    }
}
