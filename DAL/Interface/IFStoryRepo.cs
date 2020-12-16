using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IFStoryRepo<FStory>
    {
        FStory GetOne(int Id);
        IEnumerable<FStory> GetAll();
    }
}
