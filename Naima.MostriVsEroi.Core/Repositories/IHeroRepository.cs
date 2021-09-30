using Naima.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Repositories
{
    public interface IHeroRepository : IRepository<Hero>
    {
        List<Hero> GetAll();
        void UpdateUserId(int idHero, int id);
        Hero AddNewHero(string name, Category category, Weapon weapon, int id);
        Hero DeleteById(int idHero, int id);
        List<Hero> ShowBest10Heroes();
        int GetIdByName(string name);
        int GetLevel(int heroId);
        int GetLife(int heroId);
        Hero GetById(int heroId);
        Hero UpdateLifePoints(int lifePoints, int id);
        void UpdateHero(Hero hero);
        List<Hero> GetByPlayer(int id);
        int GetHeroesLevel3ByPlayer(int id);
    }
}
