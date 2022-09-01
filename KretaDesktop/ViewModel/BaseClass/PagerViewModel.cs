using KretaParancssoriAlkalmazas.Models.Pagination;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaDesktop.ViewModel.BaseClass
{
    public abstract class PagerViewModel : ViewModelBase
    {
        private PaginationModel pagination;

        public PaginationModel Pagination
        {
            get { return pagination; }
        }

        public PagerViewModel()
        {
            this.pagination = new PaginationModel();
        }

        public abstract void LoadData();

        public void LastPage()
        {
            pagination.CurrentPage = pagination.TotalPages - 1;
            LoadData();
        }
    }
}
