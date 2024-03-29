﻿using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceClient
    {
        Task SetClient(Client client);
        Task putClient(Client client);
        Task<List<Client>> ListClientEnable();
    }
}
