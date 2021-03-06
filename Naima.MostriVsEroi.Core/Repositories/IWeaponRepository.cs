using Naima.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Repositories
{
    public interface IWeaponRepository : IRepository<Weapon>
    {
        List<Weapon> ShowWeaponsByCategory(int idCategory);
        Weapon GetById(int idWeapon);
    }
}
