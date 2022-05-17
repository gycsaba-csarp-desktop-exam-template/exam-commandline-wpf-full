using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces.Base;

namespace Kreta.Models.BaseClass
{
    public class Person : IPerson, IEquatable<Person>, IComparable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Wooman { get; set; }
        public DateTime DataOfBirth { get; set; }

        public Person()
        {
            Id = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            Wooman = false;
            DataOfBirth = DateTime.MinValue;
        }

        public Person(int id, string firstName, string lastName, bool wooman, DateTime dataOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Wooman = wooman;
            DataOfBirth = dataOfBirth;
        }

        public bool Equals(Person other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
