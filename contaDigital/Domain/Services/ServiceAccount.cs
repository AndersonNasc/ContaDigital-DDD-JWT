using Domain.Interfaces.InterfacesServices;
using Entity.Entity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceAccount : IServiceAccount
    {
        private readonly Domain.Interfaces.IAccount _IAccount;

        public ServiceAccount(Domain.Interfaces.IAccount IAccount)
        {
            _IAccount = IAccount;
        }

        public async Task<List<Account>> ListAccount(string numberAccount, string agency)
        {
            return await _IAccount.ListAccount(x => x.NumberAccount.Equals(numberAccount) && x.Agency.Equals(agency) && x.StatesAccount.Equals(1));
        }

        public async Task<Boolean> CheckIfAccountExists(string numberAccount)
        {
            return await _IAccount.CheckIfAccountExists(x => x.NumberAccount.Equals(numberAccount));
        }

        public Task SetAccountBalance(Account account)
        {
            throw new NotImplementedException();
        }

        public async Task getBalance(Account account)
        {
            throw new NotImplementedException();
        }

        public Task WithdrawAccountBanlance(Account accocunt, decimal value)
        {
            if (this.ValidationBalance(accocunt.StatesAccount, accocunt.Balance, value))
            {
                accocunt.Balance -= value;
                SetAccountBalance(accocunt);
            }
            throw new NotImplementedException();
        }

        public bool ValidationBalance(Entity.Enums.StatusAccount StatesAccount, decimal value, decimal balanceCurrent)
        {
            if (StatesAccount == Entity.Enums.StatusAccount.Ativa && balanceCurrent >= value && value <= 1000)
                return true;
            else
                return false;
        }
    }
}
