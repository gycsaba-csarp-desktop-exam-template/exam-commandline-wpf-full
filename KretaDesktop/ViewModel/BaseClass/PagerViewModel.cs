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
        public PagerViewModel()
        {

        }

        public abstract void LoadData();

    }
}
