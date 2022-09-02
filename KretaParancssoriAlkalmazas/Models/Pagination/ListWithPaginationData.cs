using KretaParancssoriAlkalmazas.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Pagination
{
    public class ListWithPaginationData<T> : PaginationParameter
    {
        public List<T> Items { get; set; }

        private PaginationParameter paginationData;

        public PaginationParameter PaginationData
        {
            get
            {
                paginationData.CurrentPage = CurrentPage;
                paginationData.PageSize = PageSize;
                paginationData.NumberOfPage = NumberOfPage;

                return paginationData;
            }
        }        
    }
}
