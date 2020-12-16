using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IStoryRepo<Story>
    {
        bool Delete(int Id);
        IEnumerable<Story> GetAll();
        IEnumerable<Story> GetByCategory(int Id);
        Story GetOne(int Id);
        void Insert(Story s);
        void Update(Story s);
    }
}
