using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaParancssoriAlkalmazas.Models.AbstractClass;

namespace KretaParancssoriAlkalmazas.Models.DataModel
{
    public class Subject : SubjectBase, ICloneable
    {
        public Subject(long id, string subName)
            : base(id,subName)
        {
        }

        public Subject()
            : base()
        {
        }

        public object Clone()
        {
            Subject subject = new Subject();
            subject.Id = Id;
            subject.SubjectName = SubjectName;
            return subject;
        }
    }
}
