using Application.Interface.Generecs;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IApplicationAccount : IApplicationGenerecs<Account>
    {
        Task<List<Account>> ListAccount();
        Task SetAccountBalance(Account account);
        Task WithdrawAccountBanlance(Account accocunt, decimal value);
        Task<Boolean> CheckIfAccountExists(string account);
    }
}
