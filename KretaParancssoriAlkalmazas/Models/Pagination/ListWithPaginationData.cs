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
    }
}
