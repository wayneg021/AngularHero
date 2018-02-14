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
        public IActionResult Get()
        {
            return Ok(_heroService.GetHeroes());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = _heroService.GetHero(id);

            return Ok(result);
        }
    }
}
