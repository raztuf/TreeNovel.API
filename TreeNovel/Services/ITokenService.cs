using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeNovel.Models;

namespace TreeNovel.Services
{
    public interface ITokenService
    {
        UserToken Authenticate(string mail, string password);
    }
}
