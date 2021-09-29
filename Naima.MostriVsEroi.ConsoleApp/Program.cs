using Naima.MostriVsEroi.Core.BL;
using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Mock;
using System;
using System.Collections.Generic;

namespace Naima.MostriVsEroi.ConsoleApp
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new HeroRepository(),new MonsterRepository(), new UserRepository(), new CategoryRepository(), new WeaponRepository());
        static void Main(string[] args)
        {
            bool check = true;
            int choice;
            do
            {
                Console.WriteLine("Benvenuto a 'Mostri vs Eroi' !");
                Console.WriteLine("Premi 1 per accedere \nPremi 2 per registrarti \nPremi 0 per uscire");
                while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 2)
                {
                    Console.WriteLine("Scelta non valida! Riprova");
                }

                switch(choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                    case 0:
                        Console.WriteLine("Alla prossima partita!");
                        check = false;
                        break;
                }
            } while (check);    
            
        }

        private static void Register()
        {
            Console.WriteLine("REGISTRATI");

            string nickname, password;

            Console.WriteLine("Inserisci il tuo nickname");
            nickname = Console.ReadLine();
            while (string.IsNullOrEmpty(nickname))
            {
                Console.WriteLine("Inserisci un nickname valido");
            }

            Console.WriteLine("Inserisci la tua password");
            password = Console.ReadLine();
            while (string.IsNullOrEmpty(nickname) || nickname.Length < 6) //ho stabilito che la lunghezza della password fosse 6
            {
                Console.WriteLine("Inserisci una password valida (max 6)");
            }

            var checkExistance = bl.CheckCredentials(nickname, password);
            if(checkExistance == false) //vuol dire che non è già registrato, allora posso aggiungerlo alla lista di utenti
            {
                var res = bl.InserNewUser(nickname, password);
                Console.WriteLine(res);
                var user = bl.GetUserByNickname(nickname);
                ShowMenuNotAdmin(user);
            }
            else
            {
                Console.WriteLine("Mi dispiace ma esiste già un utente con quelle credenziali");
                return;
            }
        }

        private static void ShowMenuNotAdmin(User user)
        {
            bool check = true;
            int choice;

            do
            {
                Console.WriteLine("Premi 1 per GIOCA \nPremi 2 per CREA NUOVO EROE \nPremi 3 per ELIMINA EROE \nPremi 0 per ESCI");
                while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
                {
                    Console.WriteLine("Scelta non valida! Riprova");
                }

                switch(choice)
                {
                    case 1:
                        ChooseHero(user.Id);
                        break;
                    case 2:
                        CreateHero(user.Id);
                        break;
                    case 3:
                        DeleteHero();
                        break;
                    case 0:
                        check = false;
                        break;
                }

            } while (check);
        }

        private static void DeleteHero()
        {
            List<Hero> heroes = bl.ShowHeroes();
            if (heroes.Count > 0)
            {
                foreach (var h in heroes)
                {
                    Console.WriteLine($"{h.Id}, {h.Name}, {h.Level}, {h.LifePoints}, {h.Weapon}");
                }
            }

            Console.WriteLine("Scegli l'erore da eliminare indicando il suo id");
            int idHero;
            while (!int.TryParse(Console.ReadLine(), out idHero) || idHero < 0 || idHero > heroes.Count)
            {
                Console.WriteLine("Id non valido! Riprova");
            }

            var res = bl.DeleteHero(idHero);
            Console.WriteLine(res);
        }

        private static void CreateHero(int id)
        {
            string name;
            int idCategory, idWeapon;
            Category category;
            Weapon weapon;

            Console.WriteLine("Inserisci il nome dell'eroe che vuoi creare");
            name = Console.ReadLine();
            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Inserisci un nome valido");
            }

            List<Category> categories = bl.ShowCategoriesByDiscriminator(0);
            if(categories.Count > 0)
            {
                foreach(var c in categories)
                {
                    Console.WriteLine($"{c.idCategory}, {c.Name}");
                }
            }
            Console.WriteLine("Inserisci l'id della categoria del tuo eroe");
            while(!int.TryParse(Console.ReadLine(), out idCategory) || idCategory < 1 || idCategory > 5)
            {
                Console.WriteLine("Inserisci un id valido!");
            }
            category = bl.GetCategoryById(idCategory);

            List<Weapon> weapons =  bl.ShowWeaponsByCategory(idCategory);
            if(weapons.Count > 0)
            {
                foreach(var w in weapons)
                {
                    Console.WriteLine($"{w.IdWeapon}, {w.Name}, Punti danno : {w.DamagePoints}");
                }
            }
            Console.WriteLine("Inserisci l'id dell'arma del tuo eroe");
            while (!int.TryParse(Console.ReadLine(), out idWeapon) || idWeapon < 1 || idWeapon > 24)
            {
                Console.WriteLine("Inserisci un id valido!");
            }
            weapon = bl.GetWeaponById(idWeapon);

            //creo l'eroe
            var res = bl.InsertNewHero(name, category, weapon, id);
            Console.WriteLine(res);
        }

        private static void ChooseHero(int id)
        {
            List<Hero> heroes = bl.ShowHeroes();
            if(heroes.Count > 0)
            {
                foreach(var h in heroes)
                {
                    Console.WriteLine($"{h.Id}, {h.Name}, {h.Level}, {h.LifePoints}, {h.Weapon}");
                }
            }

            Console.WriteLine("Scegli l'erore indicando il suo id");
            int idHero;
            while(!int.TryParse(Console.ReadLine(), out idHero) || idHero < 0 || idHero > heroes.Count)
            {
                Console.WriteLine("Id non valido! Riprova");
            }
            bl.UpdateHeroIdUser(idHero, id);
        }

        private static void Login()
        {
            string nickname, password;

            Console.WriteLine("Inserisci il tuo nickname");
            nickname = Console.ReadLine();
            while(string.IsNullOrEmpty(nickname))
            {
                Console.WriteLine("Inserisci un nickname valido");
            }

            Console.WriteLine("Inserisci la tua password");
            password = Console.ReadLine();
            while (string.IsNullOrEmpty(nickname) || nickname.Length < 6) //ho stabilito che la lunghezza della password fosse 6
            {
                Console.WriteLine("Inserisci una password valida (max 6)");
            }

            var checkCredentials = bl.CheckCredentials(nickname, password);
            if(checkCredentials == false)
            {
                Console.WriteLine("Nickname o password errati");
                return;
            }

            User user = bl.GetUserByNickname(nickname);

            var checkAdmin = bl.CheckDiscriminator(nickname);
            if(checkAdmin == false) //non admin
            {
                ShowMenuNotAdmin(user);
            }
            ShowMenuAdmin(user);
        }

        private static void ShowMenuAdmin(User user)
        {
            throw new NotImplementedException();
        }
    }
}
