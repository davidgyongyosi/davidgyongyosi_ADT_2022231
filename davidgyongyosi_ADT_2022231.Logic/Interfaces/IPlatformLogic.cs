using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Logic.Classes
{
    public interface IPlatformLogic
    {
        void Create(Platform item);
        void Delete(int id);
        Platform Read(int id);
        IEnumerable<Platform> ReadAll();
        void Update(Platform item);
        IEnumerable<GamePlatform> ListWin();
        IEnumerable<GamePlatform> ListLin();
        IEnumerable<GamePlatform> ListMac();
    }
}