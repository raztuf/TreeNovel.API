using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface IDiscussionService
    {
        Discussion GetOne(int Id);
        IEnumerable<Discussion> GetAllReplys(int Id);
        IEnumerable<Discussion> GetAllMains();
        void Insert(DiscussionToDal c);
        void Update(DiscussionToDal c);
        void Delete(int Id);
    }
}
