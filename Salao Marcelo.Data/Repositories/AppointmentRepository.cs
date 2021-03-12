using System;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain;

namespace Salao_Marcelo.Data.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(Context context) : base(context) { }
    }
}
