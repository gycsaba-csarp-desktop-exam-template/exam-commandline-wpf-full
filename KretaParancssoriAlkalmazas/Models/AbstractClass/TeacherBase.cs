using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.AbstractClass
{
    public abstract class TeacherBase : PersonBaseWithAnnotations
    {
        public virtual string HeadTeacherOfClass { get; set; }

        public TeacherBase()
            : base()
        {
        }

        public TeacherBase(int id, string name, string birthDate, bool gender, string headTeacherOfClass)
            : base(id, name, birthDate, gender)
        {
            this.HeadTeacherOfClass = headTeacherOfClass;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {this.HeadTeacherOfClass}";
        }
    }
}
