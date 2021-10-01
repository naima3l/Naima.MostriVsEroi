using Microsoft.Data.SqlClient;
using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Ado
{
    public class HeroRepositoryADO : IHeroRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                            "Initial Catalog = HeroesVsMonsters;" +
                            "Integrated Security = true;";

        public Hero AddNewHero(string name, Category category, Weapon weapon, int id)
        {
            throw new NotImplementedException();
        }

        public Hero DeleteById(int idHero, int id)
        {
            throw new NotImplementedException();
        }

        public List<Hero> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Hero> GetAllByIdPlayer(int id)
        {
            throw new NotImplementedException();
        }

        public Hero GetById(int heroId)
        {
            throw new NotImplementedException();
        }

        public List<Hero> GetByPlayer(int id)
        {
            throw new NotImplementedException();
        }

        public int GetHeroesLevel3ByPlayer(int id)
        {
            throw new NotImplementedException();
        }

        public int GetIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public int GetLevel(int heroId)
        {
            throw new NotImplementedException();
        }

        public int GetLife(int heroId)
        {
            throw new NotImplementedException();
        }

        public List<Hero> ShowBest10Heroes()
        {
            throw new NotImplementedException();
        }

        public void UpdateHero(Hero hero)
        {
            throw new NotImplementedException();
        }

        public Hero UpdateLifePoints(int lifePoints, int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserId(int idHero, int id)
        {
            throw new NotImplementedException();
        }
    }
}
