using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Entities
{
    public class Monster : Character
    {
        public Monster()
        {
        }

        public Monster(int? id, string name, int level, int lifePoints, Category category, Weapon weapon)
            : base(id, name, level, lifePoints, category, weapon)
        {
        }
    }
}
