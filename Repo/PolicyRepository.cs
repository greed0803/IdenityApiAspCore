using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Repo.Base;

namespace Repo
{
    public class PolicyRepository : BaseRepository<Policy, int>
    {
        public PolicyRepository(IdentityProviderContext context) : base(context)
        {
        }

        public override DbSet<Policy> GetAll()
        {
            return _context.Policies;
        }
    }
}
