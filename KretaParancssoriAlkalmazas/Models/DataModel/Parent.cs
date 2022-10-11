using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public class Parent : SimplePerson, IEntityIdentify
    {
        public long Id { get ; set ; }
        public bool Wooman { get; set; }
        public IAddress? Address { get; set; }


        public Parent(long id, string firstName, string lastName, bool woman, IAddress address)
            : base(firstName, lastName)
        {
            Id = id;
            Wooman = woman;
            Address = address;
        }

        public Parent() : base()
        {
            Id = -1;
            Wooman = false;
            Address = null;
        }
    }
}
