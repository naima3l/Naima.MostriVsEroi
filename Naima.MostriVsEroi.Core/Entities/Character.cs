using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Entities
{
    public class Character
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int LifePoints { get; set; }
        public Category Category { get; set; }
        public Weapon Weapon { get; set; }

        public Character(int? id, string name, int level, int lifePoints, Category category, Weapon weapon)
        {
            Id = id;
            Name = name;
            Level = level;
            LifePoints = lifePoints;
            Category = category;
            Weapon = weapon;
        }
    }
}
