using Naima.MostriVsEroi.Core.Entities;
using Naima.MostriVsEroi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima.MostriVsEroi.Mock
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new List<User>()
        {
            new User(1,"pazzoxxx","123456", 0), //non admin
            new User(2,"lol12","123456", 0),
            new User(3,"bultboss","123456", 1) //admin
        };


        public bool CheckCredentials(string nickname, string password)
        {
            var user = users.FirstOrDefault(u => u.NickName == nickname && u.Password == password);
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public bool CheckDiscriminator(string nickname)
        {
            var userD = users.FirstOrDefault(u => u.NickName == nickname).UserDiscriminator;
            if(userD == 0)
            {
                return false; //non admin
            }
            return true; //admin
        }

        public User GetById(int id)
        {
            return users.Find(u => u.Id == id);
        }

        public User GetUserByNickname(string nickname)
        {
            return users.FirstOrDefault(u => u.NickName == nickname);
        }

        public bool Insert(string nickname, string password)
        {
            int id = users.Count() + 1;
            User user = new User(id, nickname, password, 0);
            users.Add(user);
            return true;
        }
    }
}
