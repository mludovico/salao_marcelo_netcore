using System;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain;

namespace Salao_Marcelo.Data.Repositories
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(Context context) : base(context)
        {
        }
    }
}
