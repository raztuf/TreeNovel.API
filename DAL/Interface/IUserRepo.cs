using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IUserRepo<User>
    {
        IEnumerable<User> GetAll();
        User GetOne(int Id);
        void Insert(User u);
        bool Delete(int Id);
        void SetAdmin(int Id);
        bool? CheckUser(User u);
        User GetByMail(string Mail);
        void Update(User u);
    }
}
