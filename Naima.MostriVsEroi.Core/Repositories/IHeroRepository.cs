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
        Hero DeleteById(int idHero);
    }
}
