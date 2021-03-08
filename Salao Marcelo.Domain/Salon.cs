using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.Domain
{
	public class Salon
	{
		public List<Professional> Professionals { get; set; }
		public List<Client> Clients { get; set; }
		public List<Appointment> Appointments { get; set; }
		public List<Service> Services { get; set; }
		public CashFlow Cash { get; set; }

		public Salon()
		{
			Professionals = new List<Professional>();
			Clients = new List<Client>();
			Appointments = new List<Appointment>();
			Services = new List<Service>();
			Cash = new CashFlow();
		}

		public void Add<T>(T entity)
		{
			switch (entity)
			{
				case Professional professional:
					if (!Professionals.Contains(professional))
						Professionals.Add(professional);
					else
						Console.WriteLine("Profissional já existe");
					break;
				case Client client:
					if (!Clients.Contains(client))
						Clients.Add(client);
					else
						Console.WriteLine("Cliente já existe");
					break;
				case Appointment appointment:
					if (!Appointments.Contains(appointment))
						Appointments.Add(appointment);
					else
						Console.WriteLine("Agendamento já existe");
					break;
				case Service service:
					if (!Services.Contains(service))
						Services.Add(service);
					else
						Console.WriteLine("Serviço já existe");
					break;
			}
		}

		public void Remove<T>(T entity)
		{
			switch (entity)
			{
				case Professional professional:
					Professionals.Remove(professional);
					break;
				case Client client:
					Clients.Remove(client);
					break;
				case Appointment appointment:
					Appointments.Remove(appointment);
					break;
				case Service service:
					Services.Remove(service);
					break;
			}
		}
	}
}
