using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Mock
{
    public class WeaponRepository : IWeaponRepository
    {
        private static List<Weapon> weapons = new List<Weapon>()
        {
            //-------------EROI------------------------
            new Weapon(1,"Alabarda",1,15), //GUERRIERO
            new Weapon(2,"Ascia",1,8),
            new Weapon(3,"Mazza",1,5),
            new Weapon(4,"Spada",1,10),
            new Weapon(5,"Spadone",1,15),
            //--------------------------
            new Weapon(6,"Arco e frecce",2,8), //MAGO
            new Weapon(7,"Bacchetta",2,5), //MAGO
            new Weapon(8,"Bastone magico",2,10), //MAGO
            new Weapon(9,"Onda d'urto",2,15), //MAGO
            new Weapon(10,"Pugnale",2,5), //MAGO
            //------------------------------------------
            //-------------MOSTRI------------------------
            new Weapon(11,"Discorso noioso",3,4), //CULTISTA
            new Weapon(12,"Farneticazione",3,7), //CULTISTA
            new Weapon(13,"Imprecazione",3,5),//CULTISTA
            new Weapon(14,"Magia nera",3,3),//CULTISTA
            //---------------------------------
            new Weapon(15,"Arco",4,7), //ORCO
            new Weapon(16,"Clava",4,5), //ORCO
            new Weapon(17,"Spada rotta",4,3), //ORCO
            new Weapon(18,"Mazza chiodata",4,10), //ORCO
            //--------------------------
            new Weapon(19,"Alabarda del drago",5,30), //SIGNORE DEL MALE
            new Weapon(20,"Divinazione",5,15), //SIGNORE DEL MALE
            new Weapon(21,"Fulmine",5,10), //SIGNORE DEL MALE
            new Weapon(22,"Fulmine celeste",5,15), //SIGNORE DEL MALE
            new Weapon(23,"Tempesta",5,8), //SIGNORE DEL MALE
            new Weapon(24,"Tempesta oscura",5,15) //SIGNORE DEL MALE
        };

        public Weapon GetById(int idWeapon)
        {
            return weapons.Find(w => w.IdWeapon == idWeapon);
        }

        public List<Weapon> ShowWeaponsByCategory(int idCategory)
        {
            return weapons.Where(w => w.IdCategory == idCategory).ToList();
        }
    }
}
