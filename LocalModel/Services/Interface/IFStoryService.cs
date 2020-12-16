using LocalModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalModel.Services.Interface
{
    public interface IFStoryService
    {
        FStory GetOne(int Id);
        IEnumerable<FStory> GetAll();
    }
}
