using System;
using System.Collections.Generic;
using System.Linq;
using Salao_Marcelo.Domain;

public class Professional : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
	public string Phone { get; set; }
	public string Address { get; set; }
	public Decimal Commission { get; set; }

	public void Update(Professional professional)
	{
		if (professional != null)
		{
			Name = professional.Name != null ? professional.Name : Name;
			Phone = professional.Phone != null ? professional.Phone : Phone;
			Address = professional.Address != null ? professional.Address : Address;
			Commission = professional.Commission != 0 ? professional.Commission : Commission;
		}
	}
}
