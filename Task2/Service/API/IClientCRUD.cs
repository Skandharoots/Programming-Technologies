﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Implementation;

namespace Service.API
{
    public interface IClientCRUD
    {
        void AddClient(int id, string name, string surname);

        void DeleteClient(int id);
        void UpdateClientName(int id, string name);
        void UpdateClientSurname(int id, string surname);
        IClientDTO GetClient(int id);
        IEnumerable<IClientDTO> GetAllClients();


    }
}