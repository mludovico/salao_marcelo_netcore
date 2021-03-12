using System;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain;

namespace Salao_Marcelo.Data.Repositories
{
    public class CashFlowRepository : BaseRepository<Cashier>, ICashFlowRepository
    {
        public CashFlowRepository(Context context): base(context)
        {
        }
    }
}
