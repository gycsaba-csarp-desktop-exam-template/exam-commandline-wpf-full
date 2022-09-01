using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Pagination
{
    public class ListWithPaginationData<T> : PaginationModel
    {
        public List<T> Items { get; set; }

        private PaginationModel paginationData;

        public PaginationModel PaginationData
        {
            get
            {
                paginationData.CurrentPage = CurrentPage;
                paginationData.PageSize = PageSize;
                paginationData.TotalCount = TotalCount;
                paginationData.TotalPages = TotalPages;

                return paginationData;
            }
        }        
    }
}
