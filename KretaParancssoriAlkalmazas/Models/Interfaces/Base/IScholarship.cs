using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Interfaces.Base
{
    public interface IScholarship : IEntityIdentify
    {
        public ulong TaxNumber { get; set; }
        public ulong Amount { get; set; }
    }
}
