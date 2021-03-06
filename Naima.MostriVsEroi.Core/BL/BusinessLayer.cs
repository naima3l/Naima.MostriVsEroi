using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.BL
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IHeroRepository heroRepo;
        private readonly IMonsterRepository monsterRepo;
        private readonly IUserRepository userRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly IWeaponRepository weaponRepo;

        public BusinessLayer(IHeroRepository heroRepository, IMonsterRepository monsterRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, IWeaponRepository weaponRepository)
        {
            heroRepo = heroRepository;
            monsterRepo = monsterRepository;
            userRepo = userRepository;
            categoryRepo = categoryRepository;
            weaponRepo = weaponRepository;
        }

        public bool CheckCredentials(string nickname, string password)
        {
            return userRepo.CheckCredentials(nickname, password);
        }

        public bool CheckDiscriminator(string nickname)
        {
            return userRepo.CheckDiscriminator(nickname);
        }

        public string DeleteHero(int idHero, int id)
        {
            var heroToDelete = heroRepo.DeleteById(idHero,id);
            if(heroToDelete !=null)
            {
                return "L'eroe è stato cancellato";
            }
            return "Si è verificato un problema durante l'eliminazione dell'eroe";
        }

        public Category GetCategoryById(int idCategory)
        {
            return categoryRepo.GetById(idCategory);
        }

        public Hero GetHeroById(int heroId)
        {
            return heroRepo.GetById(heroId);
        }

        public int GetHeroByName(string name)
        {
            return heroRepo.GetIdByName(name);
        }

        public int GetHeroesLevel3ByPlayer(int id)
        {
            return heroRepo.GetHeroesLevel3ByPlayer(id);
        }

        public int GetHeroLevel(int heroId)
        {
            return heroRepo.GetLevel(heroId);
        }

        public int GetHeroLifePoints(int heroId)
        {
            return heroRepo.GetLife(heroId);
        }

        public int[] GetLevelByAccumulatedPoints(int accumulatedPoints, int level)
        {
            int[] s = new int[2];

            if (accumulatedPoints >= 30 && accumulatedPoints <= 59 && level <= 2)
            {
                s[0] = 0;
                s[1] = 2;
            }
            else if (accumulatedPoints >= 60 && accumulatedPoints <= 89 && level <= 3)
            {
                s[0] = 0;
                s[1] = 3;
            }
            else if (accumulatedPoints >= 90 && accumulatedPoints <= 119 && level <= 4)
            {
                s[0] = 0;
                s[1] = 4;
            }
            else if (accumulatedPoints >= 120 && level <= 5)
            {
                s[0] = 0;
                s[1] = 5;
            }
            else
            {
                s[0] = accumulatedPoints;
                s[1] = level;
            }

            return s;
        }

        public int GetLifePointsByLevel(int level)
        {
            if(level == 1)
            {
                return 20;
            }
            else if(level == 2)
            {
                return 40;
            }
            else if (level == 3)
            {
                return 60;
            }
            else if (level == 4)
            {
                return 80;
            }
            else  
            {
                return 100;
            }
        }

        public Monster getMonsterById(int monsterId)
        {
            return monsterRepo.GetById(monsterId);
        }

        public int GetMonsterLifePoints(int monsterId)
        {
            return monsterRepo.GetLife(monsterId);
        }

        public List<Monster> GetMonstersByHeroLevel(int level)
        {
            return monsterRepo.GetMonstersByHeroLevel(level);
        }

        public User GetUserById(int id)
        {
            return userRepo.GetById(id);
        }

        public User GetUserByNickname(string nickname)
        {
            return userRepo.GetUserByNickname(nickname);
        }

        public Weapon GetWeaponById(int idWeapon)
        {
            return weaponRepo.GetById(idWeapon);
        }

        public string InserNewUser(string nickname, string password)
        {
            bool operation = userRepo.Insert(nickname, password);
            if(operation == true)
            {
                return "Registrazione avvenuta con successo";
            }
            return "Si è verificato un problema durante la registrazione";
        }

        public string InsertNewHero(string name, Category category, Weapon weapon, int id)
        {
            var hero = heroRepo.AddNewHero(name, category, weapon, id);
            if(hero != null)
            {
                return "Eroe inserito";
            }
            return "Si è verificato un problema nell'inserimento dell'eroe";
        }

        public string InsertNewMonster(string name, Category category, Weapon weapon)
        {
            var monster = monsterRepo.AddNewMonster(name, category, weapon);
            if(monster == true)
            {
                return "Il mostro è stato creato correttamente";
            }
            return "Si è verificato un problema nella creazione del mostro";
        }

        public List<Hero> ShowBest10Heroes()
        {
            return heroRepo.ShowBest10Heroes();
        }

        public List<Category> ShowCategoriesByDiscriminator(int v)
        {
            return categoryRepo.ShowCategoriesByDiscriminator(v);
        }

        public List<Hero> ShowHeroes()
        {
            return heroRepo.GetAll();
        }

        public List<Hero> ShowHeroesByIdPlayer(int id)
        {
            return heroRepo.GetAllByIdPlayer(id);
        }

        public List<Hero> ShowHeroesByPlayer(int id)
        {
            return heroRepo.GetByPlayer(id);
        }

        public List<Weapon> ShowWeaponsByCategory(int idCategory)
        {
            return weaponRepo.ShowWeaponsByCategory(idCategory);
        }

        public void UpdateHero(Hero hero)
        {
            heroRepo.UpdateHero(hero);
        }

        public void UpdateHeroIdUser(int idHero, int id)
        {
            heroRepo.UpdateUserId(idHero, id);
        }

        public Hero UpdateHeroLifePoints(int lifePoints, int id)
        {
            return heroRepo.UpdateLifePoints(lifePoints, id);
        }

        public Monster UpdateMonster(Monster monster)
        {
            return monsterRepo.Update(monster);
        }

        public User UpdateUser(User user)
        {
            return userRepo.Update(user);
        }
    }
}
