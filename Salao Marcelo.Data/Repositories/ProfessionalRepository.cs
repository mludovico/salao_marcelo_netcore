using System;
using Salao_Marcelo.Data.Interfaces;

namespace Salao_Marcelo.Data.Repositories
{
    public class ProfessionalRepository : BaseRepository<Professional>, IProfessionalRepository
    {
        public ProfessionalRepository(Context context) : base(context)
        {
        }
    }
}
