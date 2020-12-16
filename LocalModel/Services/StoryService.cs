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
    public class StoryService : IStoryService
    {
        IStoryRepo<dal.Story> _repo;

        public StoryService(IStoryRepo<dal.Story> StoryRepo)
        {
            _repo = StoryRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Story> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public IEnumerable<Story> GetByCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public Story GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public void Insert(Story s)
        {
            _repo.Insert(s.toDal());
        }

        public void Update(Story s)
        {
            _repo.Update(s.toDal());
        }
    }
}
