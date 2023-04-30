using Application.Interface;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ApplicationAccount : IApplicationAccount
    {
        public Task del(Account Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> List()
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
    }
}
