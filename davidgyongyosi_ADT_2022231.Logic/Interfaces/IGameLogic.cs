using System.Collections.Generic;
using System.Linq;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Logic
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        Game Read(int id);
        IEnumerable<Game> ReadAll();
        void Update(Game item);
    }
}