using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeNovel.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}
