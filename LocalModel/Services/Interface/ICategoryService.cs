using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface ICategoryService
    {
        void Delete(int Id);
        IEnumerable<Category> GetAll();
        Category GetOne(int Id);
        void Insert(Category c);
        void Update(Category c);
    }
}
