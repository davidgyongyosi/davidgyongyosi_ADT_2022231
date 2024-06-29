using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Repository
{
    public interface IGameRepository
    {
        Game Read(int id);
        void Update(Game item);
    }
}