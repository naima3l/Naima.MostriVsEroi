using Naima.MostriVsEroi.Ado;
using Naima.MostriVsEroi.Core.BL;
using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Mock;
using System;
using System.Collections.Generic;

namespace Naima.MostriVsEroi.ConsoleApp
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new HeroRepository(), new MonsterRepository(), new UserRepository(), new CategoryRepository(), new WeaponRepository());
        //private static readonly IBusinessLayer bl = new BusinessLayer(new HeroRepositoryADO(), new MonsterRepositoryADO(), new UserRepositoryADO(), new CategoryRepositoryADO(), new WeaponRepositoryADO());
        static void Main(string[] args)
        {
            Menu();

        }


        private static void Menu()
        {
            bool continuare = true;
            int choice;
            do
            {
                Console.WriteLine("Benvenuto a 'Mostri vs Eroi' !");
                Console.WriteLine("Premi 1 per accedere \nPremi 2 per registrarti \nPremi 0 per uscire");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 2)
                {
                    Console.WriteLine("Scelta non valida! Riprova");
                }

                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                    case 0:
                        Console.WriteLine("Alla prossima partita!");
                        continuare = false;
                        break;
                }
            } while (continuare);
            return;
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
            if (checkExistance == false) //vuol dire che non è già registrato, allora posso aggiungerlo alla lista di utenti
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
            int choice;
            int heroId;
            bool continuare = true;
            do
            {
                Console.WriteLine("Premi 1 per GIOCA \nPremi 2 per CREA NUOVO EROE \nPremi 3 per ELIMINA EROE \nPremi 0 per ESCI");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
                {
                    Console.WriteLine("Scelta non valida! Riprova");
                }

                switch (choice)
                {
                    case 1:
                        heroId = ChooseHero(user.Id);
                        continuare = Play(user.Id, heroId);
                        break;
                    case 2:
                        heroId = CreateHero(user.Id);
                        Play(user.Id, heroId);
                        break;
                    case 3:
                        DeleteHero(user.Id);
                        break;
                    case 0:
                        continuare = false;
                        break;
                }
            } while (continuare);

        }

        public static bool Play(int id, int heroId)
        {
            Hero hero = bl.GetHeroById(heroId);

            List<Monster> monsters = bl.GetMonstersByHeroLevel(hero.Level);
            Random random = new Random();
            int monsterId = random.Next(1, monsters.Count); // Arianna -> senza il +1

            Monster monster = bl.getMonsterById(monsterId);

            Console.WriteLine("Iniziamo!");
            HeroChoice(id, hero, monster);

            //Aggiunto per problema //+
            int[] res = bl.GetLevelByAccumulatedPoints(hero.AccumulatedPoints, hero.Level);
            hero.AccumulatedPoints = res[0]; //+
            hero.Level = res[1];
            hero.LifePoints = bl.GetLifePointsByLevel(hero.Level);
            monster.LifePoints = bl.GetLifePointsByLevel(monster.Level);

            bl.UpdateHero(hero);
            bl.UpdateMonster(monster); //+

            //giocare di nuovo
            return PlayAgain(id, hero, monster);
        }

        private static void HeroChoice(int id, Hero hero, Monster monster)
        {
            int choice, c = 0;
            do
            {
                Console.WriteLine("Tocca a te eroe");
                Console.WriteLine("Premi 1 per attaccare il mostro \nPremi 2 per fuggire");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
                {
                    Console.WriteLine("Scelta non valida. Riprova");
                }
                switch (choice)
                {
                    case 1:
                        HeroAttack(id, hero, monster);
                        break;
                    case 2:
                        c = RunAway(id, hero, monster);
                        if (c > 0)
                        {
                            break;
                        }
                        break;
                }
            } while (hero.LifePoints > 0 && monster.LifePoints > 0 && c == 0);


            if(c > 0)
            {
                hero.LifePoints = 0;
                monster.LifePoints = 0;
                return;
            }
            else if (hero.LifePoints > 0)
            {
                hero.AccumulatedPoints += (monster.Level * 10);

                Console.WriteLine("Hai vinto!");
            }
            else
            {

                Console.WriteLine("Mi dispiace. Il mostro ha vinto! Sarà per la prossima");
            }
            return;
        }

        private static bool PlayAgain(int id, Hero hero, Monster monster)
        {
            int choice;

            Console.WriteLine("Vuoi giocare ancora? \nPremi 1 per giocare con un nuovo eroe \nPremi 2 per giocare con lo stesso eroe \nPremi 0 per non giocare più");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 2)
            {
                Console.WriteLine("Scelta non valida! Riprova");
            }

            User user = bl.GetUserById(id);

            switch (choice)
            {
                case 1:
                    hero.Id = ChooseHero(id);
                    hero = bl.GetHeroById((int)hero.Id);

                    List<Monster> monsters = bl.GetMonstersByHeroLevel(hero.Level);
                    Random random = new Random();
                    int monsterId = random.Next(monsters.Count + 1);
                    monster = bl.getMonsterById(monsterId);

                    HeroChoice(id, hero, monster);
                    return PlayAgain(id, hero, monster); //+
                case 2:
                    List<Monster> monsters1 = bl.GetMonstersByHeroLevel(hero.Level);
                    Random random1 = new Random();
                    monsterId = random1.Next(monsters1.Count + 1);
                    monster = bl.getMonsterById(monsterId);

                    HeroChoice(id, hero, monster);
                    return PlayAgain(id, hero, monster); //+
                case 0:
                    if (user.UserDiscriminator == 0)
                    {
                        ShowMenuNotAdmin(user);
                        return false;
                    }
                    else
                    {
                        ShowMenuAdmin(user);
                        return false;
                    }
            }
            return true;
        }

        private static int RunAway(int id, Hero hero, Monster monster)
        {
            Random random = new Random();

            bool choice = random.Next(0, 2) > 0;

            if (choice == false)
            {
                MonsterAttack(id, hero, monster);
                return 0;
            }
            else
            {
                if((hero.AccumulatedPoints -(monster.Level * 5)) < 0)
                {
                    hero.AccumulatedPoints = 0;
                }
                else
                {
                    hero.AccumulatedPoints -= (monster.Level * 5);
                }

                bl.UpdateHero(hero);
                return 1;
            }
        }

        private static void HeroAttack(int id, Hero hero, Monster monster)
        {
            monster.LifePoints -= hero.Weapon.DamagePoints;
            monster = bl.UpdateMonster(monster);

            if (monster.LifePoints <= 0)
            {
                return;
            }
            else
            {
                MonsterAttack(id, hero, monster);
                return;
            }

        }

        private static void MonsterAttack(int id, Hero hero, Monster monster)
        {
            int lifePoints = hero.LifePoints - monster.Weapon.DamagePoints;
            hero = bl.UpdateHeroLifePoints(lifePoints, (int)hero.Id);

            if (hero.LifePoints <= 0)
            {
                return;
            }
            else
            {
                HeroChoice(id, hero, monster);
                return;
            }
        }

        private static void DeleteHero(int id)
        {
            List<Hero> heroes = bl.ShowHeroesByPlayer(id);
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

            var res = bl.DeleteHero(idHero, id);
            Console.WriteLine(res);
        }

        private static int CreateHero(int id)
        {
            string name;
            int idCategory, idWeapon;
            Category category;
            Weapon weapon;

            Console.WriteLine("Inserisci il nome dell'eroe che vuoi creare");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Inserisci un nome valido");
            }

            List<Category> categories = bl.ShowCategoriesByDiscriminator(0); //discriminatore eroe
            if (categories.Count > 0)
            {
                foreach (var c in categories)
                {
                    Console.WriteLine($"{c.idCategory}, {c.Name}");
                }
            }
            Console.WriteLine("Inserisci l'id della categoria del tuo eroe");
            while (!int.TryParse(Console.ReadLine(), out idCategory) || idCategory < 1 || idCategory > categories.Count)
            {
                Console.WriteLine("Inserisci un id valido!");
            }
            category = bl.GetCategoryById(idCategory);

            List<Weapon> weapons = bl.ShowWeaponsByCategory(idCategory);
            if (weapons.Count > 0)
            {
                foreach (var w in weapons)
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
            return bl.GetHeroByName(name);
        }

        private static int ChooseHero(int id)
        {
            List<Hero> heroes = bl.ShowHeroesByIdPlayer(id);
            List<Hero> allHeros = bl.ShowHeroes();

            if (heroes.Count > 0)
            {
                foreach (var h in heroes)
                {
                    Console.WriteLine($"{h.Id}, {h.Name}, {h.Level}, {h.LifePoints}, {h.Weapon.Name} {h.Weapon.DamagePoints}");
                }
            }

            Console.WriteLine("Scegli l'erore indicando il suo id");
            int idHero;
            while (!int.TryParse(Console.ReadLine(), out idHero) || idHero < 0 || idHero > (allHeros.Count))
            {
                Console.WriteLine("Id non valido! Riprova");
            }
            bl.UpdateHeroIdUser(idHero, id);

            return idHero;
        }

        private static void Login()
        {
            string nickname, password;

            Console.WriteLine("Inserisci il tuo nickname");
            nickname = Console.ReadLine();
            while (string.IsNullOrEmpty(nickname))
            {
                Console.WriteLine("Inserisci un nickname valido");
            }

            Console.WriteLine("Inserisci la tua password");
            password = Console.ReadLine();
            while (string.IsNullOrEmpty(nickname))
            {
                Console.WriteLine("Inserisci una password valida (max 6)");
            }

            var checkCredentials = bl.CheckCredentials(nickname, password);
            if (checkCredentials == false)
            {
                Console.WriteLine("Nickname o password errati");
                return;
            }

            User user = bl.GetUserByNickname(nickname);

            int levelHeros = bl.GetHeroesLevel3ByPlayer(user.Id);
            if (levelHeros > 0)
            {
                user.UserDiscriminator = 1;
                user = bl.UpdateUser(user);
            }

            var checkAdmin = bl.CheckDiscriminator(nickname);
            if (checkAdmin == false) //non admin
            {
                ShowMenuNotAdmin(user);
            }
            else
            {
                ShowMenuAdmin(user);
            }

        }

        private static void ShowMenuAdmin(User user)
        {
            bool check = true;
            int choice;
            int heroId;

            do
            {
                Console.WriteLine("Premi 1 per GIOCA \nPremi 2 per CREA NUOVO EROE \nPremi 3 per ELIMINA EROE \nPremi 4 per CREA NUOVO MOSTRO \nPremi 5 per MOSTRA CLASSIFICA GLOBALE \nPremi 0 per ESCI");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.WriteLine("Scelta non valida! Riprova");
                }

                switch (choice)
                {
                    case 1:
                        heroId = ChooseHero(user.Id);
                        check = Play(user.Id, heroId);
                        break;
                    case 2:
                        heroId = CreateHero(user.Id);
                        check = Play(user.Id, heroId);
                        break;
                    case 3:
                        DeleteHero(user.Id);
                        break;
                    case 4:
                        CreateMonster();
                        break;
                    case 5:
                        ShowGloablRanking();
                        break;
                    case 0:
                        check = false;
                        break;
                }

            } while (check);
        }

        private static void ShowGloablRanking()
        {
            List<Hero> bestHeroes = bl.ShowBest10Heroes();
            int count = 1;
            if (bestHeroes.Count > 0)
            {
                if (bestHeroes.Count < 10)
                {
                    Console.WriteLine($"Non ci sono ancora 10 migliori eroi, ma ti farò vedere i migliori che ho");
                    foreach (var h in bestHeroes)
                    {
                        if (count < 10)
                        {
                            Console.WriteLine($"{h.Name} {h.Level} {h.AccumulatedPoints}");
                            count++;
                        }
                    }
                    return;
                }
                Console.WriteLine($"I migliori 10 eroi di ordine di livello sono:");
                foreach (var h in bestHeroes)
                {
                    Console.WriteLine($"{h.Name} {h.Level} {h.AccumulatedPoints}");
                }
            }
            else Console.WriteLine("Al momento non è possibile mostrare la classifica dei 10 migliori eroi");
            return;
        }

        private static void CreateMonster()
        {
            string name;
            int idCategory, idWeapon;
            Category category;
            Weapon weapon;

            Console.WriteLine("Inserisci il nome del mostro che vuoi creare");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Inserisci un nome valido");
            }

            List<Category> categories = bl.ShowCategoriesByDiscriminator(1); //discriminatore mostro
            if (categories.Count > 0)
            {
                foreach (var c in categories)
                {
                    Console.WriteLine($"{c.idCategory}, {c.Name}");
                }
            }
            Console.WriteLine("Inserisci l'id della categoria del tuo mostro");
            while (!int.TryParse(Console.ReadLine(), out idCategory) || idCategory < 1 || idCategory > 5)
            {
                Console.WriteLine("Inserisci un id valido!");
            }
            category = bl.GetCategoryById(idCategory);

            List<Weapon> weapons = bl.ShowWeaponsByCategory(idCategory);
            if (weapons.Count > 0)
            {
                foreach (var w in weapons)
                {
                    Console.WriteLine($"{w.IdWeapon}, {w.Name}, Punti danno : {w.DamagePoints}");
                }
            }
            Console.WriteLine("Inserisci l'id dell'arma del tuo mostro");
            while (!int.TryParse(Console.ReadLine(), out idWeapon) || idWeapon < 1 || idWeapon > 24)
            {
                Console.WriteLine("Inserisci un id valido!");
            }
            weapon = bl.GetWeaponById(idWeapon);

            //creo l'eroe
            var res = bl.InsertNewMonster(name, category, weapon);
            Console.WriteLine(res);
        }
    }
}
