using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Repo.Base;

namespace Repo
{
    public class ClientRepository : BaseRepository<Client, int>
    {
        public ClientRepository(IdentityProviderContext context) : base(context)
        {
        }

        public override DbSet<Client> GetAll()
        {
            return _context.Clients;
        }
    }
}
