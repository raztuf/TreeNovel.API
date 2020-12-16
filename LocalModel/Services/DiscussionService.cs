using DAL.Interface;
using LocalModel.Models;
using LocalModel.Services.Interface;
using LocalModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal = DAL.Models;

namespace LocalModel.Services
{
    public class DiscussionService : IDiscussionService
    {
        IDiscussionRepo<dal.Discussion> _repo;
        IUserRepo<dal.User> _uRepo;

        public DiscussionService(IDiscussionRepo<dal.Discussion> DiscussionRepo, IUserRepo<dal.User> UserRepo)
        {
            _repo = DiscussionRepo;
            _uRepo = UserRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Discussion> GetAllMains()
        {
            return _repo.GetAllMains().Select(x => x.toLocal(_uRepo));
        }

        public IEnumerable<Discussion> GetAllReplys(int Id)
        {
            return _repo.GetAllReplys(Id).Select(x => x.toLocal(_uRepo));
        }

        public Discussion GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal(_uRepo);
        }

        public void Insert(DiscussionToDal c)
        {
            _repo.Insert(c.toDal());
        }

        public void Update(DiscussionToDal c)
        {
            _repo.Update(c.toDal());
        }
    }
}
