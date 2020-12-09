using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface ICommentRepo<Comment>
    {
        Comment GetOne(int Id);
        IEnumerable<Comment> GetAll(int Id);
        void Insert(Comment c);
        void Update(Comment c);
        bool Delete(int Id);
    }
}
