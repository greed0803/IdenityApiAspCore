using Data.Context;
using Data.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Repo.Base
{
    public abstract class BaseRepository<Entity, Key> where Entity : BaseModel<Key>
    {
        protected IdentityProviderContext _context;
        public BaseRepository(IdentityProviderContext context)
        {
            _context = context;
        }
        public Entity Create(Entity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Delete(Key Id)
        {
            Entity? searchEntity = GetById(Id);
            if (null != searchEntity)
            {
                _context.Remove(searchEntity);
                _context.SaveChanges();
            }
        }
        public Entity? Update(Entity entity)
        {
            Entity? searchEntity = GetById(entity.Id);
            if (null != searchEntity)
            {
                _context.Update(searchEntity);
                _context.SaveChanges();
            }
            return searchEntity;
        }

        public Entity? GetById(Key Id)
        {
            return GetAll().FirstOrDefault(x => x.Id.Equals(Id));
        }

        public abstract DbSet<Entity> GetAll();
    }
}
