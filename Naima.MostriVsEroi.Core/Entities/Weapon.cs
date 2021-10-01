using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Entities
{
    public class Weapon
    {
        public int IdWeapon { get; set; }
        public string Name { get; set; }
        public int IdCategory { get; set; }
        public int DamagePoints { get; set; }

        public Weapon(int id, string name, int idCat, int dPoints)
        {
            IdWeapon = id;
            Name = name;
            IdCategory = idCat;
            DamagePoints = dPoints;
        }

        public Weapon()
        {
        }
    }
}
