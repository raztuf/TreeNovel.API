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
    public class ChapterService : IChapterService
    {
        IChapterRepo<dal.Chapter> _repo;

        public ChapterService(IChapterRepo<dal.Chapter> ChapterRepo)
        {
            _repo = ChapterRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Chapter> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public IEnumerable<Chapter> GetByUserId(int Id)
        {
            return _repo.GetByUserId(Id).Select(x => x.toLocal());
        }

        public Chapter GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public void Insert(Chapter c)
        {
            _repo.Insert(c.toDal());
        }

        public void Update(Chapter c)
        {
            _repo.Update(c.toDal());
        }
    }
}
