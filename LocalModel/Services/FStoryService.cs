using DAL.Interface;
using DAL.Repository;
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
    public class FStoryService : IFStoryService
    {
        IFStoryRepo<dal.FStory> _repo;

        public FStoryService(IFStoryRepo<dal.FStory> FStoryRepo)
        {
            _repo = FStoryRepo;
        }

        public IEnumerable<FStory> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public FStory GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }
    }
}
