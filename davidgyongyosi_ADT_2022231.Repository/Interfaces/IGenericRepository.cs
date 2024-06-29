using System.Linq;

namespace davidgyongyosi_ADT_2022231.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T item);
    }
}