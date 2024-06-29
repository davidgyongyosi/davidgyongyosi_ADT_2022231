using System;
using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Models;
using davidgyongyosi_ADT_2022231.Repository;

namespace davidgyongyosi_ADT_2022231.Logic.Classes
{
    public class GenreLogic : IGenreLogic
    {
        IGenericRepository<Genre> repogen;
        IGenreRepository repo;

        public GenreLogic(IGenericRepository<Genre> repogen, IGenreRepository repo)
        {
            this.repogen = repogen;
            this.repo = repo;
        }

        public GenreLogic(IGenericRepository<Genre> repogen)
        {
            this.repogen = repogen;
        }

        public void Create(Genre item)
        {
            if (item.GenreName.Length == 0)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.repogen.Create(item);
        }

        public void Delete(int id)
        {
            this.repogen.Delete(id);
        }

        public Genre Read(int id)
        {
            var genre = this.repo.Read(id);
            if (genre == null)
            {
                throw new ArgumentException("Genre does not exist");
            }
            return genre;

        }

        public IEnumerable<Genre> ReadAll()
        {
            return this.repogen.ReadAll();
        }

        public void Update(Genre item)
        {
            this.repo.Update(item);
        }

        //5 non-crud needs to be added
        public IEnumerable<Game> GAmes()
        {
            return this.repo.GamesPerGenres();
        }
    }
}

