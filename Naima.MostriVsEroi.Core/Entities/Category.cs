using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Entities
{
    public class Category
    {
        public int idCategory { get; set; }
        public string Name { get; set; }
        public int Discriminator { get; set; } //1 => Hero, 2 => Monster

        public Category() { }
        public Category(int id, string name, int discriminator)
        {
            idCategory = id;
            Name = name;
            Discriminator = discriminator;
        }

    }
}
