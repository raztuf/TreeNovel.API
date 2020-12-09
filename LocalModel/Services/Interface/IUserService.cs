using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface IUserService
    {
        bool? CheckUser(User u);
        IEnumerable<User> GetAll();
        User GetOne(int Id);
        void Register(User u);
        void SwitchActivate(int Id);
        void SwitchAdmin(int Id);
        User GetByMail(string Mail);
        void Update(User u);
    }
}
