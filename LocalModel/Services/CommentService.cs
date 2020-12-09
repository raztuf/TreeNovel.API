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

        public CommentService(ICommentRepo<dal.Comment> CommentRepo)
        {
            _repo = CommentRepo;
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public IEnumerable<Comment> GetAll(int Id)
        {
            return _repo.GetAll(Id).Select(x => x.toLocal());
        }

        public Comment GetOne(int Id)
        {
            return _repo.GetOne(Id).toLocal();
        }

        public void Insert(Comment c)
        {
            _repo.Insert(c.toDal());
        }

        public void Update(Comment c)
        {
            _repo.Update(c.toDal());
        }
    }
}
