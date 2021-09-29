using Naima.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> ShowCategoriesByDiscriminator(int v);
        Category GetById(int idCategory);
    }
}
