using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salao_Marcelo.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public User GetByNameAndPassword(string name, string password)
        {
            return _context.Set<User>().FirstOrDefault(user => user.Name == name && user.Password == password);
        }
    }
}
