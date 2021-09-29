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

        public string DeleteHero(int idHero)
        {
            var heroToDelete = heroRepo.DeleteById(idHero);
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

        public List<Category> ShowCategoriesByDiscriminator(int v)
        {
            return categoryRepo.ShowCategoriesByDiscriminator(v);
        }

        public List<Hero> ShowHeroes()
        {
            return heroRepo.GetAll();
        }

        public List<Weapon> ShowWeaponsByCategory(int idCategory)
        {
            return weaponRepo.ShowWeaponsByCategory(idCategory);
        }

        public void UpdateHeroIdUser(int idHero, int id)
        {
            heroRepo.UpdateUserId(idHero, id);
        }
    }
}
