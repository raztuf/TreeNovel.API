using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface IStoryService
    {
        void Delete(int Id);
        IEnumerable<Story> GetAll();
        IEnumerable<Story> GetByCategory(int Id);
        Story GetOne(int Id);
        void Insert(Story s);
        void Update(Story s);
    }
}
