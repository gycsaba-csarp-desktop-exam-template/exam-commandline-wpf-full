using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public abstract class SimplePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        protected SimplePerson(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        protected SimplePerson()
        {
            LastName = string.Empty;
            LastName = string.Empty;
        }

    }
}
