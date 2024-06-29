using System;
using System.Linq;

namespace davidgyongyosi_ADT_2022231.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected GamesDbContext ctx;
        public GenericRepository(GamesDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);

    }
}

