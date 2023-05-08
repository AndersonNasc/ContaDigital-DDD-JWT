using Application.Interface;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
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
        IClient _IClient;
        IServiceClient _IServiceClient;

        public ApplicationClient(IClient IClient, IServiceClient IServiceClient)
        {
            _IClient = IClient;
            _IServiceClient = IServiceClient;
        }

        public async Task del(Client Objeto)
        {
            await _IClient.del(Objeto);
        }

        public async Task<List<Client>> List()
        {
            return await _IClient.List();
        }

        public async Task<List<Client>> ListClientEnable()
        {
            return await _IServiceClient.ListClientEnable();
        }

        public async Task put(Client Objeto)
        {
            await _IClient.put(Objeto);
        }

        public async Task putClient(Client client)
        {
            await _IServiceClient.putClient(client);
        }

        public async Task<Client> searchByID(int Id)
        {
            return await _IClient.searchByID(Id);
        }

        public async Task set(Client Objeto)
        {
            await _IClient.set(Objeto);
        }

        public async Task SetClient(Client client)
        {
            await _IServiceClient.SetClient(client);
        }
    }
}
