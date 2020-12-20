using DAL.Interface;
using dal = DAL.Models;
using DAL.Repository;
using LocalModel.Models;
using LocalModel.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LocalModel.Tools;

namespace LocalModel.Services
{
    public class UserService : IUserService
    {
        IUserRepo<dal.User> _repo;

        public UserService(IUserRepo<dal.User> UserRepo)
        {
            _repo = UserRepo;
        }
        public bool? CheckUser(User u)
        {
            bool? response = _repo.CheckUser(u.toDal());
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public User GetByMail(string Mail)
        {
            return _repo.GetByMail(Mail).toLocal();
        }

        public User GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public void Register(User u)
        {
            _repo.Insert(u.toDal());
        }

        public void SwitchActivate(int Id)
        {
            _repo.Delete(Id);
        }

        public void SetDelete(int Id)
        {
            _repo.SetDelete(Id);
        }

        public void Update(User u)
        {
            _repo.Update(u.toDal());
        }
    }
}
