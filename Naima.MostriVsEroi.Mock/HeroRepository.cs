using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Mock
{
    public class HeroRepository : IHeroRepository
    {
        private static List<Hero> heroes = new List<Hero>()
        {
            new Hero(1, "The Victorious Bandit", 1,20, new Category(1,"Guerriero", 0), new Weapon(1,"Alabarda", 1, 15),0, null), //livello 1
            new Hero(2, "The Red Caped Spirit", 2,40, new Category(2,"Mago", 0), new Weapon(9,"Onda d'urto", 2, 15),0, null), //2
            new Hero(3, "Kinetic Rattler", 3,60, new Category(2,"Mago", 0), new Weapon(7,"Bacchetta", 2, 5),0, null), //3
            new Hero(4, "Triumphant Orphan", 4,80, new Category(2,"Mago", 0), new Weapon(8,"Bastone Magico", 2, 10),0, null), //4
            new Hero(5, "Nuclear Arctic Fox", 5,100, new Category(1,"Guerriero", 0), new Weapon(2,"Ascia", 1, 8),0, null) //5
        };

        public Hero AddNewHero(string name, Category category, Weapon weapon, int id)
        {
            Hero hero = new Hero();
            hero.Name = name;
            hero.Level = 1;
            hero.LifePoints = 20;
            hero.IdPlayer = id;
            hero.Weapon = weapon;
            hero.Category = category;
            hero.Id = heroes.Count() + 1;
            hero.AccumulatedPoints = 0;

            heroes.Add(hero);
            return hero;
        }

        public Hero DeleteById(int idHero)
        {
            Hero hero = heroes.Find(u => u.Id == idHero);
            heroes.Remove(hero);
            return hero;
        }

        public List<Hero> GetAll()
        {
            return heroes;
        }

        public List<Hero> ShowBest10Heroes()
        {
            var best = heroes.OrderByDescending(h => h.Level);
            
            if(best.Count() == 0)
            {
                return null;
            }
            List<Hero> h = new List<Hero>();
            foreach(var b in best)
            {
                h.Add(b);
            }

            return h;
        }

        private Hero getById(int idPlayer)
        {
            return heroes.Find(h=> h.IdPlayer == idPlayer);
        }

        public void UpdateUserId(int idHero, int id)
        {
            var hero = heroes.Find(u => u.Id == idHero);
            heroes.Remove(hero);
            Hero h = new Hero();
            h = hero;
            h.IdPlayer = id;
            heroes.Add(h);

        }

        public int GetIdByName(string name)
        {
            var hero =  heroes.FirstOrDefault(h => h.Name == name);
            return (int)hero.Id;
        }

        public int GetLevel(int heroId)
        {
            var hero = heroes.Find(h => h.Id == heroId);
            return hero.Level;
        }
    }
}
