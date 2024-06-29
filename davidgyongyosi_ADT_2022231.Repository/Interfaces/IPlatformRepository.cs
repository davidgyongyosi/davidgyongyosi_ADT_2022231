using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Repository
{
    public interface IPlatformRepository
    {
        Platform Read(int id);
        void Update(Platform item);
        IEnumerable<GamePlatform> ListLin();
        IEnumerable<GamePlatform> ListMac();
        IEnumerable<GamePlatform> ListWin();
    }
}