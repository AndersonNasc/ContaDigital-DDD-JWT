using Domain.Interfaces.Util;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClient: IGenerics<Client>
    {
        Task<List<Client>> ListClient(Expression<Func<Client, bool>> exClient);
    }
}
