using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using davidgyongyosi_ADT_2022231.Logic;
using davidgyongyosi_ADT_2022231.Logic.Classes;
using davidgyongyosi_ADT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace davidgyongyosi_ADT_2022231.Endpoint
{
    [Route("[controller]/[action]")]
    public class GenreController : Controller
    {
        IGenreLogic logic;

        public GenreController(IGenreLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Genre> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Genre Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Genre value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Genre value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet]
        public IEnumerable<Game> Games()
        {
            return this.logic.GAmes();
        }
    }
}

