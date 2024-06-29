using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Repository
{
    public interface IGenreRepository
    {
        Genre Read(int id);
        void Update(Genre item);
        public List<Game> GamesPerGenres();
    }
}