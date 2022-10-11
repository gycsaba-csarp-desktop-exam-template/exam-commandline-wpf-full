using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.AbstractClass
{
    public abstract class PersonBase : ClassWithId
    {
        public virtual string Name { get; set; }
        public virtual string BirthDate { get; set; }
        public virtual bool Gender { get; set; }
        
        public PersonBase()
            :base(-1)
        {
            this.Id = -1;
            this.Name = string.Empty;
            this.BirthDate = string.Empty;
            this.Gender = true;
        }

        public PersonBase(int id, string name, string birthDate, bool gender)
            :base(id)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}, {BirthDate}, {Gender}";
        }
    }
}
