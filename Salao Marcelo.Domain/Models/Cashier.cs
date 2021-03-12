using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salao_Marcelo.Domain
{
	public class CashFlow : IEntity
	{
		public int Id { get; set ; }
		public List<Decimal> Income { get; private set; }
		public List<Decimal> Outcome { get; private set; }
		public Decimal IncomeTotal { get => Income.Sum(); }
		public Decimal OutcomeTotal { get => Outcome.Sum(); }
		public Decimal TotalBalance { get => Income.Sum() - Outcome.Sum(); }

		public void Receive(Decimal income) => Income.Add(income);

		public void Pay(Decimal outcome) => Outcome.Add(outcome);

	}
}
