using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface ICategoryRepo<Category>
    {
        bool Delete(int Id);
        IEnumerable<Category> GetAll();
        Category GetOne(int Id);
        void Insert(Category c);
        void Update(Category c);
    }
}
