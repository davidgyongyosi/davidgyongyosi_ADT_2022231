using System;
using System.Collections.Generic;
using System.Linq;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Repository
{
    public class GameRepository : GenericRepository<Game>, IGenericRepository<Game>, IGameRepository
    {
        public GameRepository(GamesDbContext ctx) : base(ctx) { }

        public override Game Read(int id)
        {
            return ctx.Games.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Game item)
        {
            var old = Read(item.Id);
            old.GameName = item.GameName;
            old.releaseDate = item.releaseDate;
            old.Price = item.Price;
            old.GenreId = item.GenreId;
            ctx.SaveChanges();
        }
    }
}

