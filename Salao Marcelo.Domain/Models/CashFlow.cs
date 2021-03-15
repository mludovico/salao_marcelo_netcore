using System;
namespace Salao_Marcelo.Domain.Models
{
	public class CashFlow : IEntity
	{
		public CashFlow(Decimal value)
		{
			Timestamp = DateTime.Now;
			Value = value;
		}

		public int Id { get; set; }
		public DateTime Timestamp { get; set; }
		public Decimal Value { get; set; }
	}
}
