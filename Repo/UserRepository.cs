using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class UserRepository : BaseRepository<User, int>
    {
        public UserRepository(IdentityProviderContext context) : base(context)
        {
        }

        public override DbSet<User> GetAll()
        {
            return _context.Users;
        }
    }
}
