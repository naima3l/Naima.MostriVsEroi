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
            new Hero(1, "The Victorious Bandit", 1,20, new Category(1,"Guerriero", 0), new Weapon(1,"Alabarda", 1, 15),0, 1), //livello 1
            new Hero(2, "The Red Caped Spirit", 2,40, new Category(2,"Mago", 0), new Weapon(9,"Onda d'urto", 2, 15),0, 2), //2
            new Hero(3, "Kinetic Rattler", 3,60, new Category(2,"Mago", 0), new Weapon(7,"Bacchetta", 2, 5),0, 3), //3
            new Hero(4, "Triumphant Orphan", 4,80, new Category(2,"Mago", 0), new Weapon(8,"Bastone Magico", 2, 10),0, 1), //4
            new Hero(5, "Nuclear Arctic Fox", 5,100, new Category(1,"Guerriero", 0), new Weapon(2,"Ascia", 1, 8),0, 3), //5
            new Hero(6, "All-Seeing Pythoness", 5,100, new Category(1,"Guerriero", 0), new Weapon(2,"Ascia", 1, 8),0, 3), //
            new Hero(7, "Snapping Toreador", 5,100, new Category(1,"Guerriero", 0), new Weapon(2,"Ascia", 1, 8),0, 3), //
            new Hero(8, "Celestial Dagger", 5,100, new Category(1,"Guerriero", 0), new Weapon(2,"Ascia", 1, 8),0, 3), //
            new Hero(9, "Grim Lizardwoman", 5,100, new Category(1,"Guerriero", 0), new Weapon(2,"Ascia", 1, 8),0, 3), //
            new Hero(10, "The Peculiar Fire Giant", 5,100, new Category(1,"Guerriero", 0), new Weapon(2,"Ascia", 1, 8),0, 3), //
            new Hero(11, "The Invisible Sharpshooter", 1,20, new Category(1,"Guerriero", 0), new Weapon(2,"Ascia", 1, 8),0, 3) //
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

        public Hero DeleteById(int idHero, int id)
        {
            Hero hero = heroes.FirstOrDefault(u => u.Id == idHero && u.IdPlayer == id);
            heroes.Remove(hero);
            return hero;
        }

        public List<Hero> GetAll()
        {
            return heroes;
        }

        public List<Hero> ShowBest10Heroes()
        {
            var best = heroes.OrderByDescending(h => h.Level).ThenByDescending(h => h.AccumulatedPoints);
            //var b = best.OrderByDescending(h => h.AccumulatedPoints);
            
            if(best.Count() == 0)
            {
                return null;
            }
            List<Hero> h = new List<Hero>();
            foreach(var bt in best)
            {
                h.Add(bt);
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

        public int GetLife(int heroId)
        {
            var hero = heroes.Find(h => h.Id == heroId);
            return hero.LifePoints;
        }

        public Hero GetById(int heroId)
        {
            return heroes.FirstOrDefault(h => h.Id == heroId);
        }

        public Hero UpdateLifePoints(int lifePoints, int id)
        {
            var hero = GetById(id);

            heroes.Remove(hero);

            hero.LifePoints = lifePoints;
            heroes.Add(hero);

            return hero;

        }

        public void UpdateHero(Hero hero)
        {
            var h = GetById((int)hero.Id);

            heroes.Remove(h);

            heroes.Add(hero);
        }

        public List<Hero> GetByPlayer(int id)
        {
            return heroes.Where(h => h.IdPlayer == id).ToList();
        }

        public int GetHeroesLevel3ByPlayer(int id)
        {
            var h = heroes.Where(u => u.IdPlayer == id && u.Level == 3);
            return h.Count();
        }

        public List<Hero> GetAllByIdPlayer(int id)
        {
            return heroes.Where(h => h.IdPlayer == id).ToList();
        }
    }
}
