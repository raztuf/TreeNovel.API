using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IChapterRepo<Chapter>
    {
        bool Delete(int Id);
        IEnumerable<Chapter> GetAll();
        IEnumerable<Chapter> GetReplies(int Id);
        IEnumerable<Chapter> GetByUserId(int Id);
        Chapter GetOne(int Id);
        void Insert(Chapter c);
        void Update(Chapter c);
    }
}
