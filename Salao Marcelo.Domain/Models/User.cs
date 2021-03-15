using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.Domain.Models
{
	public class User : IEntity
	{
		public int Id { get; set ; }
		public string Name { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
	}
}
