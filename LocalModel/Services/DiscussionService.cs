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

        public DiscussionService(IDiscussionRepo<dal.Discussion> DiscussionRepo)
        {
            _repo = DiscussionRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Discussion> GetAllMains()
        {
            return _repo.GetAllMains().Select(x => x.toLocal());
        }

        public IEnumerable<Discussion> GetAllReplys(int Id)
        {
            return _repo.GetAllReplys(Id).Select(x => x.toLocal());
        }

        public Discussion GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public void Insert(Discussion c)
        {
            _repo.Insert(c.toDal());
        }

        public void Update(Discussion c)
        {
            _repo.Update(c.toDal());
        }
    }
}
