﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUser
    {
        Task<bool> SetUser(string email, string password, int Age, string phone);

        Task<bool> CheckIfUserExists(string email, string password);

        Task<string> ReturnIdUser(string email);

    }
}
