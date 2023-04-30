using Domain.Interfaces;
using Entity.Entity;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryUser : RepositoryGenerecs<ApplicationUser>, IUser
    {
        private readonly DbContextOptions<Context> _optionsbuilder;

        public RepositoryUser()
        {
            _optionsbuilder = new DbContextOptions<Context>();
        }

        public async Task<bool> CheckIfUserExists(string email, string password)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    return await data.ApplicationUser.Where(x => x.Email.Equals(email) && x.PasswordHash.Equals(password)).AsNoTracking().AnyAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return false;
        }

        public async Task<bool> SetUser(string email, string password, int Age, string phone)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    await data.ApplicationUser.AddAsync(new ApplicationUser
                    {
                        Email = email,
                        PasswordHash = password,
                        Age = Age,
                        Phone = phone
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }
    }
}
