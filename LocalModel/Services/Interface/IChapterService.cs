using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface IChapterService
    {
        void Delete(int Id);
        IEnumerable<Chapter> GetAll();
        IEnumerable<Chapter> GetReplies(int Id);
        IEnumerable<Chapter> GetByUserId(int Id);
        IEnumerable<Chapter> GetByCategory(string Name);
        Chapter GetOne(int Id);
        void Insert(ChapterToDal c);
        void Update(ChapterToDal c);
    }
}
