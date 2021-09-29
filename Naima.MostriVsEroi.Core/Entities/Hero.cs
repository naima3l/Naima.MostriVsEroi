using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Entities
{
    public class Hero : Character
    {
        public int AccumulatedPoints { get; set; }
        public int? IdPlayer { get; set; }

        //public Hero() { }

        public Hero(int? id, string name, int level, int lifePoints, Category category, Weapon weapon, int points, int? idPlayer) 
            :base(id, name, level, lifePoints, category, weapon)
        {
            AccumulatedPoints = points;
            IdPlayer = idPlayer;
        }

        public Hero()
        {
        }
    }
}
