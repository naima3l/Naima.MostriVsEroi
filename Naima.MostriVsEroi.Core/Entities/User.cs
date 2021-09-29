using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public int UserDiscriminator { get; set; } //0 non admin, 1 admin

        public User() { }

        public User(int id, string nickname, string password, int userDiscriminator)
        {
            Id = id;
            NickName = nickname;
            Password = password;
            UserDiscriminator = userDiscriminator;
        }
    }
}
