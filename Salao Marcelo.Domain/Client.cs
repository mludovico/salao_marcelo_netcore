using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.Domain
{
	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }

		public void Update(Client client)
		{
			if (client != null)
			{
				Name = client.Name != null ? client.Name : Name;
				Phone = client.Phone != null ? client.Phone : Phone;
				Address = client.Address != null ? client.Address : Address;
			}
		}
	}
}
