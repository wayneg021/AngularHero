using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroService
{
    public interface IHeroService
    {
        List<Hero> GetHeroes();

        Hero GetHero(int Id);
    }
}
