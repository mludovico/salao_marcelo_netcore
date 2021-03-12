using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.Domain
{
	public class Appointment : IEntity
	{
		public int Id { get; set; }
		public DateTime Scheduledtime { get; set; }
		public bool Finished { get; set; }
		public Service Service { get; set; }
		public Professional Professional { get; set; }
		public Client Client { get; set; }

		private void Update(Appointment agendamento)
		{
			if (agendamento != null)
			{
				Scheduledtime = agendamento.Scheduledtime != null ? agendamento.Scheduledtime : Scheduledtime;
				Service = agendamento.Service != null ? agendamento.Service : Service;
				Professional = agendamento.Professional != null ? agendamento.Professional : Professional;
				Client = agendamento.Client != null ? agendamento.Client : Client;
			}
		}

		private void Finish(Cashier cash)
		{
			cash.Receive(Service.Price);
			cash.Pay(Professional.Commission * Service.Price);
		}
	}
}
