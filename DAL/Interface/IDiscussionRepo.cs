using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IDiscussionRepo<Discussion>
    {
        Discussion GetOne(int Id);
        IEnumerable<Discussion> GetAllReplys(int Id);
        IEnumerable<Discussion> GetAllMains();
        void Insert(Discussion c);
        void Update(Discussion c);
        bool Delete(int Id);
    }
}
