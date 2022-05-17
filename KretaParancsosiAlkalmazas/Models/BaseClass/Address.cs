using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces.Base;

namespace Kreta.Models.BaseClass
{
    public class Address : IAddress, IEquatable<Address>, IComparable
    {
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
        public int PostCode { get; set; }

        public Address()
        {
            City = string.Empty;
            StreetAndNumber = string.Empty;
            PostCode = -1;
        }

        public Address(string city, string streetAndNumber, int postCode)
        {
            City = city;
            StreetAndNumber = streetAndNumber;
            PostCode = postCode;
        }

        public bool Equals(Address other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
