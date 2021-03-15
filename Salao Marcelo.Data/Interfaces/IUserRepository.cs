using Salao_Marcelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.Data.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User GetByNameAndPassword(string name, string password);
    }
}
