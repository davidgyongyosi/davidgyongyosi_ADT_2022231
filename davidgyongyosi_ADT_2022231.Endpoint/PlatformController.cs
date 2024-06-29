using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using davidgyongyosi_ADT_2022231.Logic.Classes;
using davidgyongyosi_ADT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace davidgyongyosi_ADT_2022231.Endpoint
{
    [Route("[controller]/[action]")]
    public class PlatformController : Controller
    {
        IPlatformLogic logic;

        public PlatformController(IPlatformLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Platform> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Platform Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Platform value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Platform value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet]
        public IEnumerable<GamePlatform> ListWindowsGames()
        {
            return this.logic.ListWin();
        }

        [HttpGet]
        public IEnumerable<GamePlatform> ListLinuxGames()
        {
            return this.logic.ListLin();
        }

        [HttpGet]
        public IEnumerable<GamePlatform> ListMacintoshGames()
        {
            return this.logic.ListMac();
        }
    }
}

