using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeNovel.Models;
using LocalModel.Models;


namespace TreeNovel.Tools
{
    public static class Mappers
    {
        public static User newToLocal(this NewUserInfo newUser)
        {
            return new User
            {
                Mail = newUser.Mail,
                Username = newUser.Username,
                Password = newUser.Password,
            };
        }
    }
}
