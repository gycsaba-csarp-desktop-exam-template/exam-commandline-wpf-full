using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces.Base;

namespace Kreta.Models.DataModel
{
    public class Address : IAddress, IEquatable<Address>, IComparable
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
        public int PostCode { get; set; }


        public Address()
        {
            Id = -1;
            City = string.Empty;
            StreetAndNumber = string.Empty;
            PostCode = -1;
        }

        public Address(long id, string city, string streetAndNumber, int postCode)
        {
            Id = id;
            City = city;
            StreetAndNumber = streetAndNumber;
            PostCode = postCode;
        }

        public bool Equals(Address? other)
        {
            if (other is null)
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            if (other is Address)
            {
                Address address = (Address)other;
                return this.City == address.City
                    && this.StreetAndNumber == address.StreetAndNumber
                    && this.PostCode == address.PostCode
                    && this.Id == address.Id;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

    }
}
