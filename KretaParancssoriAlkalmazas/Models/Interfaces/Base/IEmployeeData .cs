using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Interfaces.Base
{
    public interface IEmployeeData : IEntityIdentify
    {
        public ulong GrossSalary { get; set; }

        public uint NumberOfChildren { get; set; }

        public bool HasChild
        {
            get => this.NumberOfChildren > 0;
        }

        public bool HasNoChild
        {
            get => this.NumberOfChildren == 0;
        }
    }
}
