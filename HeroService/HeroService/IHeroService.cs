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

        List<Hero> GetHeroes(string name);

        void UpdateHero(Hero hero);

        Hero CreateHero(Hero hero);

        Hero DeleteHero(int Id);
    }
}
