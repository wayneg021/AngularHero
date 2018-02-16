using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroService
{
    public class HeroService : IHeroService
    {
        private static List<Hero> _heroes = new List<Hero>()
            {
                new Hero { Id = 11, Name = "Mr. Nice"},
                new Hero { Id = 12, Name = "Narco"},
                new Hero { Id = 13, Name = "Bombasto"},
                new Hero { Id = 14, Name = "Celeritas"},
                new Hero { Id = 15, Name = "Magneta"},
                new Hero { Id = 16, Name = "RubberMan"},
                new Hero { Id = 17, Name = "Dynama"},
                new Hero { Id = 18, Name = "Dr IQ"},
                new Hero { Id = 19, Name = "Magma"},
                new Hero { Id = 20, Name = "Tornado"}
            };


        public HeroService()
        {
            
        }

        public Hero CreateHero(Hero hero)
        {
            var heroId = _heroes.Max(h => h.Id);
            var addedHero = new Hero
            {
                Id = heroId + 1,
                Name = hero.Name
            };
            
            _heroes.Add(addedHero);

            return addedHero;
        }

        public Hero DeleteHero(int Id)
        {
            var heroToBeDeleted = _heroes.Where(h => h.Id == Id).FirstOrDefault();
             _heroes.Remove(heroToBeDeleted);

             return heroToBeDeleted;
        }

        public Hero GetHero(int Id)
        {
            return _heroes.Where(h => h.Id == Id).FirstOrDefault();
        }

        public List<Hero> GetHeroes()
        {
            return _heroes;
        }

        public List<Hero> GetHeroes(string name)
        {
            var results = _heroes.Where(h => h.Name.Contains(name)).ToList();

            return results;
        }

        public void UpdateHero(Hero hero)
        {
            var heroNeedToBeUpdated = 
                _heroes.Where(h => h.Id == hero.Id)
                .FirstOrDefault();
            var updatedHero = heroNeedToBeUpdated.Name = hero.Name;

        }
    }
}
