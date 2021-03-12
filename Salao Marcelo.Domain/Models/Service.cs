using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.Domain
{
	public class Service : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int TimeInMinutes { get; set; }
		public Decimal Price { get; set; }

		public void Update(Service service)
		{
			if (service != null)
			{
				Name = service.Name != null ? service.Name : Name;
				TimeInMinutes = service.TimeInMinutes != 0 ? service.TimeInMinutes : TimeInMinutes;
				Price = service.Price != 0 ? service.Price : Price;
			}
		}
	}
}
