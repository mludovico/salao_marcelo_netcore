using System;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain;

namespace Salao_Marcelo.Data.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(Context context) : base(context)
        {
        }
    }
}
