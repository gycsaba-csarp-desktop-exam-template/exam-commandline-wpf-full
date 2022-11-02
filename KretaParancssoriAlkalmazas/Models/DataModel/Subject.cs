using Kreta.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public class Subject : SubjectBase, IEquatable<object>, IComparable, ICloneable
    {
        public Subject() :base()
        { }

        public Subject(long id)
        : base(id,String.Empty)
        {
        }

        public Subject(long id, string subjectName)
            : base(id, subjectName)
        {
        }

        public object Clone()
        {
            Subject subject = new Subject();
            subject.Id = Id;
            subject.SubjectName = SubjectName;
            return subject;
        }

        public int CompareTo(object obj)
        {
            return 0;
        }

        // Két tantárgy megegyezhet: pl: 1. Történelem == 1. Történelem
        // Két tantárgy nem egyezik meg:
        // 2. a pl. 1. Történelem != 2. Matek
        // 2. b pl. 1. Történelem != 1. Matek
        // 2. c 1. Történelem != 2. történelem
        // this.Equals(other)
        public bool Equals(object other)
        {
            if (other is null)
                return false;

            // A két objektum a memóriában ugyan ott van
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            // OOP: is -> a változó adott típusú-e
            if (other is Subject)
            {
                // Típus kényszerítés
                Subject subjectToCheck = (Subject)other;
                if (Id == subjectToCheck.Id && SubjectName == subjectToCheck.SubjectName)
                    return true;
            }
            return false;
        }
    }
}
