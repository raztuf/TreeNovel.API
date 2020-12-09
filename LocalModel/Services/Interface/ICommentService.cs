using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface ICommentService
    {
        Comment GetOne(int Id);
        IEnumerable<Comment> GetAll(int Id);
        void Insert(Comment c);
        void Update(Comment c);
        void Delete(int Id);
    }
}
