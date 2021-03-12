using System;
using System.Collections.Generic;
using System.Linq;
using Salao_Marcelo.Domain.Models;

namespace Salao_Marcelo.Domain
{
	public class Cashier : IEntity
	{
		public int Id { get; set ; }
		public List<CashFlow> Income { get; private set; }
		public List<CashFlow> Outcome { get; private set; }
		public Decimal IncomeTotal { get => Income.Sum(x => x.Value); }
		public Decimal OutcomeTotal { get => Outcome.Sum(x => x.Value); }
		public Decimal TotalBalance { get => IncomeTotal - OutcomeTotal; }

		public void Receive(Decimal income)
		{
			var cashFlow = new CashFlow(income);
			Income.Add(cashFlow);
		}

		public void Pay(Decimal outcome)
		{
			var cashFlow = new CashFlow(outcome);
			Outcome.Add(cashFlow);
		}
	}
}
