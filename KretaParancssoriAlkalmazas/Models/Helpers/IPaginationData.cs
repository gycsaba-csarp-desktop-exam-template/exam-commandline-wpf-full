using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Helpers
{
    public interface IPaginationData
    {
        public int CurrentPage { get; set; }
        public int NumberOfPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfItem { get; set; }
    }
}
