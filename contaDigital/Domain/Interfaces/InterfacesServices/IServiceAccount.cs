using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceAccount
    {
        Task SetAccountBalance(Account account);        
        Task WithdrawAccountBanlance(Account accocunt, decimal value);
        Task getBalance(Account accocunt);
        Task<List<Account>> ListAccount(string numberAccount, string agency);
    }
}
