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
    public class CategoryService : ICategoryService
    {
        ICategoryRepo<dal.Category> _repo;

        public CategoryService(ICategoryRepo<dal.Category> CategoryRepo)
        {
            _repo = CategoryRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _repo.GetAll().Select(x => x.toLocal());
        }

        public Category GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public void Insert(Category c)
        {
            _repo.Insert(c.toDal());
        }

        public void Update(Category c)
        {
            _repo.Update(c.toDal());
        }
    }
}
