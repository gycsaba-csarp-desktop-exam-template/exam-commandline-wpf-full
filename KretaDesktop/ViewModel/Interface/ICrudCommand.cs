using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KretaDesktop.ViewModel.BaseClass;
using CommunityToolkit.Mvvm.Input;

namespace KretaDesktop.ViewModel.Interface
{
    public interface ICrudCommand<T>
    {
        void Delete(T entity);
        void Save(T entity);
        void New(T entity);

    }
}
