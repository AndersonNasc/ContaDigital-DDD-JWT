using Application.Interface.Generecs;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IApplicationClient: IApplicationGenerecs<Client>
    {
        Task SetClient(Client client);
        Task putClient(Client client);
        Task<List<Client>> ListClientEnable();
    }
}
