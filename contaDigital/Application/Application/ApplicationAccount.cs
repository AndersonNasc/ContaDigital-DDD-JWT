using Application.Interface;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Application
{
    public class ApplicationAccount : IApplicationAccount
    {
        IAccount _IAccount;

        public ApplicationAccount(IAccount IAccount)
        {
            _IAccount = IAccount;
        }

        public async Task<Boolean> CheckIfAccountExists(string account)
        {
            return await _IAccount.CheckIfAccountExists(x => x.NumberAccount.Equals(account));
        }

        public Task del(Account Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> List()
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> ListAccount()
        {
            throw new NotImplementedException();
        }

        public Task put(Account Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Account> searchByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Task set(Account Objeto)
        {
            throw new NotImplementedException();
        }

        public Task SetAccountBalance(Account account)
        {
            throw new NotImplementedException();
        }

        public Task WithdrawAccountBanlance(Account accocunt, decimal value)
        {
            throw new NotImplementedException();
        }
    }
}
