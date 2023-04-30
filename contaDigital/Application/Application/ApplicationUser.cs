using Application.Interface;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ApplicationUser: IApplicationUser
    {
        IUser _IUser;
        public ApplicationUser(IUser IUser) 
        {
            _IUser = IUser;
        }

        public async Task<bool> CheckIfUserExists(string email, string password)
        {
            return await _IUser.CheckIfUserExists(email, password);
        }

        public async Task<bool> SetUser(string email, string password, int Age, string phone)
        {
            return await _IUser.SetUser(email, password, Age, phone);
        }
    }
}
