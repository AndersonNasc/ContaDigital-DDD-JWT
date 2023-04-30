using Application.Interface;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class ApplicationClient : IApplicationClient
    {
        public Task del(Client Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> List()
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> ListClientEnable()
        {
            throw new NotImplementedException();
        }

        public Task put(Client Objeto)
        {
            throw new NotImplementedException();
        }

        public Task putClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<Client> searchByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Task set(Client Objeto)
        {
            throw new NotImplementedException();
        }

        public Task SetClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
