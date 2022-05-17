using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreta.Models.Interfaces.Base;

namespace Kreta.Models.Interfaces
{
    interface IStudent :  IPerson, IAddress, IAccount
    {
        
    }
}
