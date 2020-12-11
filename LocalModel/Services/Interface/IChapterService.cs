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
        IEnumerable<Chapter> GetByUserId(int Id);
        Chapter GetOne(int Id);
        void Insert(ChapterToDal c);
        void Update(ChapterToDal c);
    }
}
