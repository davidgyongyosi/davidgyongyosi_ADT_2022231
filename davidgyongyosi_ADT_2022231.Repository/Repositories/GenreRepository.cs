using System;
using System.Collections.Generic;
using System.Linq;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GamesDbContext ctx) : base(ctx) { }

        public override Genre Read(int id)
        {
            return ctx.Genres.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Genre item)
        {
            var old = Read(item.Id);
            old.GenreName = item.GenreName;
            ctx.SaveChanges();
        }

        public List<Game> GamesPerGenres()
        {
            return ctx.Genres.Join(ctx.Games, ge => ge.Id, ga => ga.GenreId, (ge, ga) => new
            {
                id = ga.Id,
                name = ga.GameName,
                genre = ge.Id,
                price = ga.Price
            }).Where(x => x.price > 0)
            .Select(x => new Game()
            {
                Id = x.id,
                GameName = x.name,
                GenreId = x.genre,
                Price = x.price
            }).ToList();
        }

    }
}

