using System;
using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Models;
using davidgyongyosi_ADT_2022231.Repository;

namespace davidgyongyosi_ADT_2022231.Logic.Classes
{
    public class PlatformLogic : IPlatformLogic
    {
        IPlatformRepository repo;
        IGenericRepository<Platform> repogen;

        public PlatformLogic(IPlatformRepository repo, IGenericRepository<Platform> repogen)
        {
            this.repo = repo;
            this.repogen = repogen;
        }

        public PlatformLogic(IGenericRepository<Platform> repogen)
        {
            this.repogen = repogen;
        }

        public void Create(Platform item)
        {
            if (item.PlatformName.Length == 0)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.repogen.Create(item);
        }

        public void Delete(int id)
        {
            this.repogen.Delete(id);
        }

        public Platform Read(int id)
        {
            var platform = this.repogen.Read(id);
            if (platform == null)
            {
                throw new ArgumentException("Platform does not exist");
            }
            return platform;

        }

        public IEnumerable<Platform> ReadAll()
        {
            return this.repogen.ReadAll();
        }

        public void Update(Platform item)
        {
            this.repogen.Update(item);
        }

        //5 non-crud needs to be added

        public IEnumerable<GamePlatform> ListWin()
        {
            return this.repo.ListWin();
        }

        public IEnumerable<GamePlatform> ListLin()
        {
            return this.repo.ListLin();
        }

        public IEnumerable<GamePlatform> ListMac()
        {
            return this.repo.ListMac();
        }
    }
}

