using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Interfaces.Base
{
    public interface ICompany : IEntityIdentify
    {
        public string CompanyName { get; set; }
        public IAddress Address { get; set; }
    }
}
