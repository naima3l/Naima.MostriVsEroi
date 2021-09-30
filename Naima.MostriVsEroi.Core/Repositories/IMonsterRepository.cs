using Naima.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Repositories
{
    public interface IMonsterRepository : IRepository<Monster>
    {
        bool AddNewMonster(string name, Category category, Weapon weapon);
        List<Monster> GetMonstersByHeroLevel(int level);
        int GetLife(int monsterId);
        Monster GetById(int monsterId);
        Monster Update(Monster monster);
    }
}
