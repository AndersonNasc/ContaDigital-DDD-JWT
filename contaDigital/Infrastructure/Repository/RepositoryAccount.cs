using Domain.Interfaces;
using Entity.Entity;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repository
{
    public class RepositoryAccount : RepositoryGenerecs<Account>, Domain.Interfaces.IAccount
    {
        private readonly DbContextOptions<Context> _optionsBuilder;

        public RepositoryAccount()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }

        public async Task<Boolean> CheckIfAccountExists(Expression<Func<Account, bool>> exAccount)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Accounts.Where(exAccount).AnyAsync();
            }
        }

        public async Task<List<Account>> ListAccount(Expression<Func<Account, bool>> exAccount)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Accounts.Where(exAccount).AsNoTracking().ToListAsync();
            }
        }
    }
}
