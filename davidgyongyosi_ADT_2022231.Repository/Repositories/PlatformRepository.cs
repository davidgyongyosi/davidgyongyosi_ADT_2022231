using System;
using System.Collections.Generic;
using System.Linq;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Repository
{
    public class PlatformRepository : GenericRepository<Platform>, IGenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(GamesDbContext ctx) : base(ctx) { }

        public override Platform Read(int id)
        {
            return ctx.Platforms.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Platform item)
        {
            var old = Read(item.Id);
            old.PlatformName = item.PlatformName;
            ctx.SaveChanges();
        }

        public IEnumerable<GamePlatform> ListWin() => ctx.GamePlatforms.Where(t => t.PlatformId == 2);
        public IEnumerable<GamePlatform> ListLin() => ctx.GamePlatforms.Where(t => t.PlatformId == 2);
        public IEnumerable<GamePlatform> ListMac() => ctx.GamePlatforms.Where(t => t.PlatformId == 3);
    }
}

