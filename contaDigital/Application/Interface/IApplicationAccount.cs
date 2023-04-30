using Application.Interface.Generecs;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IApplicationAccount : IApplicationGenerecs<Account>
    {
    }
}
