using Naima.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.BL
{
    public interface IBusinessLayer
    {
        bool CheckCredentials(string nickname, string password);
        string InserNewUser(string nickname, string password);
        bool CheckDiscriminator(string nickname);
        List<Hero> ShowHeroes();
        User GetUserByNickname(string nickname);
        void UpdateHeroIdUser(int idHero, int id);
        List<Category> ShowCategoriesByDiscriminator(int v);
        Category GetCategoryById(int idCategory);
        List<Weapon> ShowWeaponsByCategory(int idCategory);
        Weapon GetWeaponById(int idWeapon);
        string InsertNewHero(string name, Category category, Weapon weapon, int id);
        string DeleteHero(int idHero, int id);
        string InsertNewMonster(string name, Category category, Weapon weapon);
        List<Hero> ShowBest10Heroes();
        int GetHeroByName(string name);
        int GetHeroLevel(int heroId);
        List<Monster> GetMonstersByHeroLevel(int level);
        int GetHeroLifePoints(int heroId);
        int GetMonsterLifePoints(int monsterId);
        Hero GetHeroById(int heroId);
        Monster getMonsterById(int monsterId);
        Monster UpdateMonster(Monster monster);
        Hero UpdateHeroLifePoints(int lifePoints, int id);
        void UpdateHero(Hero hero);
        User GetUserById(int id);
        List<Hero> ShowHeroesByPlayer(int id);
        int GetHeroesLevel3ByPlayer(int id);
        User UpdateUser(User user);
        int GetLifePointsByLevel(int level);
        int[] GetLevelByAccumulatedPoints(int accumulatedPoints, int level);
    }
}
