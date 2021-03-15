using System;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain;
using Salao_Marcelo.Domain.Models;

namespace Salao_Marcelo.Data.Repositories
{
    public class CashFlowRepository : BaseRepository<CashFlow>, ICashFlowRepository
    {
        public CashFlowRepository(Context context): base(context)
        {
        }
    }
}
