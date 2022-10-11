using Kreta.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Parameters
{
    public interface IQueryStringParameters : IPaginationData
    {
        public string OrderBy { get; set; }

        public string Fields { get; set; }

        public string Filter { get; set; }
    }
}
