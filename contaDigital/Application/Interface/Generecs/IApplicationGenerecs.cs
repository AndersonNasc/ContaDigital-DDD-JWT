using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Generecs
{
    public interface IApplicationGenerecs<T> where T : class
    {
        Task set(T Objeto);
        Task put(T Objeto);
        Task del(T Objeto);
        Task<T> searchByID(int Id);
        Task<List<T>> List();
    }
}
