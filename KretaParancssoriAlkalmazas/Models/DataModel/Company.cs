using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public class Company : ICompany, IComparable, IEquatable<Company>
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public IAddress Address { get; set; }

        protected Company(long id, string companyName, IAddress address)
        {
            Id = id;
            CompanyName = companyName;
            Address = address;
        }

        protected Company()
        {
            Id = -1;
            CompanyName = string.Empty;
            Address = new Address();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Company? other)
        {
            throw new NotImplementedException();
        }
    }
}
