using Domain.Interfaces;
using Entity.Entity;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryClient: RepositoryGenerecs<Client>, IClient
    {
        private readonly DbContextOptions<Context> _OptionsBuilder;

        public RepositoryClient() 
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }

        public async Task<List<Client>> ListClient(Expression<Func<Client, bool>> exClient)
        {
            using (var data = new Context(_OptionsBuilder))
            {
                return await data.Clients.Where(exClient).AsNoTracking().ToListAsync();
            }
        }
    }
}
