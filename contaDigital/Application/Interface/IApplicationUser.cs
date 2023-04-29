using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IApplicationUser
    {
        Task<bool> SetUser(string email, string password, int Age, string phone);
    }
}
