using System;
using davidgyongyosi_ADT_2022231.Repository;
using davidgyongyosi_ADT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace davidgyongyosi_ADT_2022231.Logic
{
    public class GameLogic : IGameLogic
    {
        IGenericRepository<Game> repo;

        public GameLogic(IGenericRepository<Game> repo)
        {
            this.repo = repo;
        }

        public void Create(Game item)
        {
            if (item.GameName.Length == 0)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Game Read(int id)
        {
            var game = this.repo.Read(id);
            if (game == null)
            {
                throw new ArgumentException("Game does not exist");
            }
            return game;

        }

        public IEnumerable<Game> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game item)
        {
            this.repo.Update(item);
        }


        //5 non-crud needs to be added

        public double? GetAveragePricePerYear(string date)
        {
            return this.repo.ReadAll().Where(t => t.releaseDate == date).Average(t => t.Price);
        }

        public IEnumerable<YearInfo> StatsPerYear()
        {
            return from x in this.repo.ReadAll()
                   group x by x.releaseDate into g
                   select new YearInfo()
                   {
                       Year = g.Key,
                       AvgPrice = g.Average(t => t.Price),
                       GameNumber = g.Count()
                   };
        }
    }

    public class YearInfo
    {
        public string Year { get; set; }
        public double? AvgPrice { get; set; }
        public int GameNumber { get; set; }

        public override bool Equals(object obj)
        {
            YearInfo b = obj as YearInfo;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Year == b.Year
                    && this.AvgPrice == b.AvgPrice
                    && this.GameNumber == b.GameNumber;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Year, this.AvgPrice, this.GameNumber);
        }
    }
}

