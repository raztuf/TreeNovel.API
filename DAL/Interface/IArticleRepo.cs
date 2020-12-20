using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IArticleRepo<Article>
    {
        Article GetOne(int Id);
        IEnumerable<Article> GetAll();
        void Insert(Article a);
        void Update(Article a);
        bool Delete(int Id);
    }
}
