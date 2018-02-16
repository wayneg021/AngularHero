using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeroService.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        private IHeroService _heroService;

        public HeroesController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery]string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return Ok(_heroService.GetHeroes());
            }

            var result = _heroService.GetHeroes(name);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = _heroService.GetHero(id);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody]Hero hero)
        {
            if(hero == null)
            {
                return BadRequest("Invalid Hero");
            }

            _heroService.UpdateHero(hero);

            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Hero hero)
        {
            if(hero == null)
            {
                return BadRequest();
            }

            var createdHero = _heroService.CreateHero(hero);

            return Created($"api/heroes/{createdHero.Id}", createdHero);
        }

        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult Delete([FromRoute]int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var deletedHero = _heroService.DeleteHero(id);

            return Ok(deletedHero);
        }
    }
}
