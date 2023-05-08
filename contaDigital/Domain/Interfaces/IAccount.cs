using Domain.Interfaces.Generics;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAccount : IGenerics<Account>
    {
        Task<List<Account>> ListAccount(Expression<Func<Account, bool>> exAccount);

        Task<Boolean> CheckIfAccountExists(Expression<Func<Account, bool>> exAccount);
    }
}
