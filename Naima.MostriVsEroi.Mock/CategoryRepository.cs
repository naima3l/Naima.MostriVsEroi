using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Mock
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> categories = new List<Category>()
        {
            new Category(1, "Guerriero", 0),
            new Category(2, "Mago", 0),
            new Category(3, "Cultista", 1),
            new Category(4, "Orco", 1),
            new Category(5, "Signore del male", 1)
        };

        public Category GetById(int idCategory)
        {
            return categories.Find(c=> c.idCategory == idCategory);
        }

        public List<Category> ShowCategoriesByDiscriminator(int v)
        {
            return categories.Where(c => c.Discriminator == v).ToList();
        }
    }
}
