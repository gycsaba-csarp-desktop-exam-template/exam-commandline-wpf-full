using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public class Outsider : SimplePerson, IEntityIdentify
    {
        public long Id { get; set; }
        public IAddress? Address { get; set; }


        public Outsider(long id, string firstName, string lastName, IAddress address)
            : base(firstName, lastName)
        {
            Id = id;
            Address = address;
        }

        public Outsider()
        {
            Id = -1;
            Address = null;
        }
    }
}
