using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
