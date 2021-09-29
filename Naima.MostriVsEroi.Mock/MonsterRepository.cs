using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Mock
{
    public class MonsterRepository : IMonsterRepository
    {
        private static List<Monster> monsters = new List<Monster>()
        {
            new Monster(1,"Baba Jaga",1,20,new Category(3,"Cultista",1), new Weapon(11,"Discorso noioso",3,4)),
            new Monster(2,"Kelpie",2,40,new Category(4,"Orco",1), new Weapon(16,"Clava",4,5)),
            new Monster(3,"Golem",3,60,new Category(5,"Signore del male",1), new Weapon(20,"Divinazione",5,15)),
            new Monster(4,"Mandragola",4,80,new Category(5,"Signore del male",1), new Weapon(24,"Tempesta oscura",5,15)),
            new Monster(5,"Voldemort",5,100,new Category(5,"Signore del male",1), new Weapon(19,"Alabarda del drago",5,30))
        };
        public bool AddNewMonster(string name, Category category, Weapon weapon)
        {
            //nel caso non sia possibile usare il costruttore vuoto
            monsters.Add(new Monster((monsters.Count() + 1), name, 1, 20, category, weapon));
           
            //Monster monster = new Monster();
            //monster.Name = name;
            //monster.LifePoints = 20;
            //monster.Level = 1;
            //monster.Weapon = weapon;
            //monster.Category = category;
            //monster.Id = monsters.Count() + 1;

            //monsters.Add(monster);
            return true;
        }

        public Monster GetById(int monsterId)
        {
            return monsters.FirstOrDefault(m => m.Id == monsterId);
        }

        public int GetLife(int monsterId)
        {
            var monster = monsters.Find(m => m.Id == monsterId);
            return monster.LifePoints;
        }

        public List<Monster> GetMonstersByHeroLevel(int level)
        {
            return monsters.Where(m => m.Level <= level).ToList();
        }

        public Monster UpdateLifePoints(int lifePoints, int id)
        {
            var monster = GetById(id);
            monsters.Remove(monster);

            monster.LifePoints = lifePoints;
            monsters.Add(monster);

            return monster;
        }
    }
}
