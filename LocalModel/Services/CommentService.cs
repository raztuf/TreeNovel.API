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
    public class CommentService : ICommentService
    {
        ICommentRepo<dal.Comment> _repo;
        IUserRepo<dal.User> _uRepo;

        public CommentService(ICommentRepo<dal.Comment> CommentRepo, IUserRepo<dal.User> UserRepo)
        {
            _repo = CommentRepo;
            _uRepo = UserRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Comment> GetAll(int Id)
        {
            return _repo.GetAll(Id).Select(x => x.toLocal(_uRepo));
        }

        public Comment GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal(_uRepo);
        }

        public void Insert(CommentToDal c)
        {
            _repo.Insert(c.toDal());
        }

        public void Update(CommentToDal c)
        {
            _repo.Update(c.toDal());
        }
    }
}
