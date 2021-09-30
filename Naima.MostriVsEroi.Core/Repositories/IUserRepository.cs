using Naima.MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckCredentials(string nickname, string password);
        bool Insert(string nickname, string password);
        bool CheckDiscriminator(string nickname);
        User GetUserByNickname(string nickname);
        User GetById(int id);
        User Update(User user);
    }
}
