using Domain.Interfaces;
using Entity.Entity;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repository
{
    public class RepositoryAccount : RepositoryGenerecs<Account>, Domain.Interfaces.IAccount
    {
        private readonly DbContextOptions<Context> _OptionsBuilder;

        public RepositoryAccount()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
    }
}
