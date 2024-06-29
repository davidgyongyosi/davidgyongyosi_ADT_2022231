using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Logic.Classes
{
    public interface IGenreLogic
    {
        void Create(Genre item);
        void Delete(int id);
        Genre Read(int id);
        IEnumerable<Genre> ReadAll();
        void Update(Genre item);
        public IEnumerable<Game> GAmes();
    }
}