using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class serviceClient : IServiceClient
    {
        private readonly IClient _IClient;

        public serviceClient(IClient IClient)
        {
            _IClient = IClient;
        }

        public async Task<List<Client>> ListClientEnable()
        {
            throw new NotImplementedException();
        }

        public async Task putClient(Client client)
        {
            throw new NotImplementedException();
        }

        public async Task SetClient(Client client)
        {
            var validationCPF = client.ValidationPropertiesCPF(client.CPF);

            if (validationCPF)
            {
                await _IClient.set(client);
            }
            throw new NotImplementedException();
        }
    }
}
