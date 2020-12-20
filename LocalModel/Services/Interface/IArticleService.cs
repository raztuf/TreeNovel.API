using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface IArticleService
    {
        Article GetOne(int Id);
        IEnumerable<Article> GetAll();
        void Insert(Article a);
        void Update(Article a);
        void Delete(int Id);
    }
}
