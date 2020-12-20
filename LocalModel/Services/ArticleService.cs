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
    public class ArticleService : IArticleService
    {
        IArticleRepo<dal.Article> _repo;

        public ArticleService(IArticleRepo<dal.Article> ArticleRepo)
        {
            _repo = ArticleRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public Article GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public void Insert(Article a)
        {
            _repo.Insert(a.toDal());
        }

        public void Update(Article a)
        {
            _repo.Update(a.toDal());
        }
    }
}
