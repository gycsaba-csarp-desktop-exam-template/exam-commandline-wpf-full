using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KretaParancssoriAlkalmazas.Models.Helpers;

namespace KretaParancssoriAlkalmazas.Models.Parameters
{
    public class PaginationParameter : IPaginationData
    {
        const int maxPageSize = 50;
        private int pageSize = 10;

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > maxPageSize ? maxPageSize : value;
            }
        }

        public int CurrentPage { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfItem { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < NumberOfPage;

        public PaginationParameter()
        {
            CurrentPage = 1;
        }
    }
}
